using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.FlowsConnectionReferenceReplacer
{
    public partial class MyPluginControl : PluginControlBase, IPayPalPlugin, IGitHubPlugin
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        public string DonationDescription => "Donation for tool Flows Connection References replacer";
        public string EmailAccount => "tanguy92@hotmail.com";
        public string RepositoryName => "MscrmTools.FlowsConnectionReferenceReplacer";

        public string UserName => "MscrmTools";

        public void LoadItems()
        {
            SetWorkingState(true);
            wccr.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading items...",
                Work = (bw, e) =>
                {
                    crsSource.LoadConnectionReferences(Service);
                },
                PostWorkCallBack = e =>
                {
                    SetWorkingState(false);

                    if (e.Error != null)
                    {
                        MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    crsSource.DisplayConnectionReferences();
                    crsTarget.DisplayConnectionReferences();
                }
            });
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            crsTarget.Reset();
            crsSource.Reset();
            wccr.Reset();

            base.UpdateConnection(newService, detail, actionName, parameter);
        }

        private void crsSource_OnSelectionChanged(object sender, EventArgs e)
        {
            if (crsSource.SelectedReferences.Count == 0)
            {
                crsTarget.Filter(null);
                crsSource.Filter(null);
                return;
            }

            var connector = crsSource.SelectedReferences.First().GetAttributeValue<string>("connectorid");
            foreach (var cr in crsSource.SelectedReferences)
            {
                if (connector != cr.GetAttributeValue<string>("connectorid"))
                {
                    MessageBox.Show(this, "Please select only connection references for the same connector", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            crsTarget.Filter(connector);
            crsSource.Filter(connector);
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        private void SetWorkingState(bool isWorking)
        {
            toolStripMenu.Enabled = !isWorking;
            crsSource.Enabled = !isWorking;
            crsTarget.Enabled = !isWorking;
            wccr.Enabled = !isWorking;
        }

        private void tsbFindFlows_Click(object sender, EventArgs e)
        {
            if (crsTarget.SelectedReferences.Count == 0)
            {
                MessageBox.Show(this, "Please select a reference connection to use for replacement", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var selectedReferences = crsSource.SelectedReferences;

            if (selectedReferences.Any(sr => sr.GetAttributeValue<string>("connectorid") != crsTarget.SelectedReferences.First().GetAttributeValue<string>("connectorid")))
            {
                MessageBox.Show(this, "You selected connection references from different connectors. \n\nPlease select only connection references related to the same connector", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (crsTarget.SelectedReferences.Count == 0)
            {
                MessageBox.Show(this, "Please select a target connection reference", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            SetWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading flows...",
                Work = (bw, evt) =>
                {
                    wccr.LoadFlows(selectedReferences, Service);
                },
                PostWorkCallBack = evt =>
                {
                    SetWorkingState(false);

                    if (evt.Error != null)
                    {
                        MessageBox.Show(evt.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    wccr.TargetConnectionReference = crsTarget.SelectedReferences.First();
                    wccr.Display();
                }
            });
        }

        private void tsbLoad_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadItems);
        }

        private void tsbUpdateFLows_Click(object sender, EventArgs e)
        {
            var flows = wccr.SelectedFlows;

            if (DialogResult.Yes != MessageBox.Show(this, $"You will update connection references for {flows.Count} flow{(flows.Count > 1 ? "s" : "")}.\n\nFrom these connection references:\n- {string.Join("\n- ", crsSource.SelectedReferences.Select(r => r.GetAttributeValue<string>("connectionreferencelogicalname")))}\n\nTo this connection reference :\n- {crsTarget.SelectedReferences.First().GetAttributeValue<string>("connectionreferencelogicalname")}\n\nDo you confirm?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            SetWorkingState(true);

            var sourceRefs = crsSource.SelectedReferences;
            var targetRef = crsTarget.SelectedReferences.First().GetAttributeValue<string>("connectionreferencelogicalname");
            var unpublishedFlowErrors = new List<string>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating flows...",
                Work = (bw, evt) =>
                {
                    foreach (var flow in flows)
                    {
                        bw.ReportProgress(0, $"Updating flow {flow.GetAttributeValue<string>("name")}...");

                        var clientData = flow.GetAttributeValue<string>("clientdata");

                        foreach (var scr in sourceRefs)
                        {
                            clientData = clientData.Replace(scr.GetAttributeValue<string>("connectionreferencelogicalname"), targetRef);
                        }
                        flow["clientdata"] = clientData;
                        ((CrmServiceClient)Service).CallerId = flow.GetAttributeValue<EntityReference>("ownerid").Id;

                        try
                        {
                            Service.Update(flow);
                        }
                        catch (FaultException<OrganizationServiceFault> error)
                        {
                            if (error.Detail.ErrorCode == -2147220989)
                            {
                                unpublishedFlowErrors.Add(flow.GetAttributeValue<string>("name"));
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                },
                PostWorkCallBack = evt =>
                {
                    SetWorkingState(false);

                    ((CrmServiceClient)Service).CallerId = Guid.Empty;

                    if (evt.Error != null)
                    {
                        MessageBox.Show(evt.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (unpublishedFlowErrors.Count > 0)
                    {
                        MessageBox.Show($"Some flows were not updated because they are in draft mode:\n- {string.Join("\n- ", unpublishedFlowErrors)}\n\nPublished them before trying to replace their connection references", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    tsbFindFlows_Click(tsbFindFlows, EventArgs.Empty);
                }
            });
        }
    }
}