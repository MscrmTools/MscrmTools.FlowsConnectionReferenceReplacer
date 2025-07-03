using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.FlowsConnectionReferenceReplacer
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Flows Connection References Replacer"),
        ExportMetadata("Description", "This tool allows to replace Connection references in flow definitions by another one"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#606060"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "White")]
    public class MyPlugin : PluginBase, IPayPalPlugin
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        public string DonationDescription => "Donation for tool Flows Connection References replacer";
        public string EmailAccount => "tanguy92@hotmail.com";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}