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

namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    public partial class SP_FreedomTotalChangerUC : UserControl, ISP_FreedomTotalChangerUC
    {
        public SP_FreedomTotalChangerUC()
        {
            InitializeComponent();
        }

        public event EventHandler chkboxtotalChangerCheckedChangedEventRaised;
        public event EventHandler SPFreedomTotalChangerUCLoadEventRaised;

        public CheckBox GetFreedomTotalChangerChkBx()
        {
            return chkbox_totalChanger;
        }

        private void chkbox_totalChanger_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxtotalChangerCheckedChangedEventRaised, e);
        }

        private void SP_FreedomTotalChangerUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SPFreedomTotalChangerUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Screen_FreedomTotalChangerVisibility"]);
            chkbox_totalChanger.DataBindings.Add(ModelBinding["Screen_FreedomTotalChangerIsChecked"]);
        }
    }
}
