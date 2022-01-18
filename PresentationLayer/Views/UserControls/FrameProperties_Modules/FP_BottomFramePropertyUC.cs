using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    public partial class FP_BottomFramePropertyUC : UserControl, IFP_BottomFramePropertyUC
    {
        public FP_BottomFramePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler chkbotFrameCheckedChangedEventRaised;

        private void chk_botFrame_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbotFrameCheckedChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            throw new NotImplementedException();
        }
    }
}
