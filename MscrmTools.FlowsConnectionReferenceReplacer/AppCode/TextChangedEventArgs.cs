using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MscrmTools.FlowsConnectionReferenceReplacer.AppCode
{
    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs()
        {
        }

        public TextChangedEventArgs(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}