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

namespace PresentationLayer.Views.UserControls
{
    public partial class PanelPropertiesUC : UserControl, IPanelPropertiesUC
    {
        public PanelPropertiesUC()
        {
            InitializeComponent();
        }

        public event EventHandler PanelPropertiesLoadEventRaised;

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            num_BladeCount.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            pnum_Width.DataBindings.Add(ModelBinding["Panel_Width"]);
            pnum_Height.DataBindings.Add(ModelBinding["Panel_Height"]);
            lbl_pnlname.DataBindings.Add(ModelBinding["Panel_Name"]);
            lbl_Type.DataBindings.Add(ModelBinding["Panel_Type"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_ChkText"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_Orient"]);
        }
    }
}
