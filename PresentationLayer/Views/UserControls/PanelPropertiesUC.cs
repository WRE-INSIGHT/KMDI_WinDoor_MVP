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
using static ModelLayer.Model.Quotation.QuotationModel;
using static EnumerationTypeLayer.EnumerationTypes;
using EnumerationTypeLayer;

namespace PresentationLayer.Views.UserControls
{
    public partial class Panel_PropertiesUC : UserControl, IPanelPropertiesUC
    {
        public Panel_PropertiesUC()
        {
            InitializeComponent();
        }

        private int _panelID;
        public int Panel_ID
        {
            get
            {
                return _panelID;
            }
            set
            {
                _panelID = value;
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                RemoveDataBinding();
            }
           
        }

        private void RemoveDataBinding()
        {
            pnum_Width.DataBindings.Clear();
            pnum_Height.DataBindings.Clear();
            lbl_pnlname.DataBindings.Clear();
            lbl_Type.DataBindings.Clear();
            chk_Orientation.DataBindings.Clear();
            this.DataBindings.Clear();



            pnum_Width.Dispose();
            pnum_Height.Dispose();
            lbl_pnlname.Dispose();
            lbl_Type.Dispose();
            chk_Orientation.Dispose();
            pnl_panelSpecsBody.Dispose();
            lbl_Height.Dispose();
            lbl_PanelGlassID.Dispose();
            lbl_pnlSpecs.Dispose();
            lbl_Width.Dispose();
            this.Dispose();

        }

        private int _panelGlassID;
        public int PanelGlass_ID
        {
            get
            {
                return _panelGlassID;
            }

            set
            {
                _panelGlassID = value;
                lbl_PanelGlassID.Text = "P" + _panelGlassID;
            }
        }

        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler ChkOrientationCheckChangedEventRaised;

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            pnum_Width.Maximum = decimal.MaxValue;
            pnum_Height.Maximum = decimal.MaxValue;
            num_BladeCount.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            pnum_Width.DataBindings.Add(ModelBinding["Panel_Width"]);
            pnum_Height.DataBindings.Add(ModelBinding["Panel_Height"]);
            lbl_pnlname.DataBindings.Add(ModelBinding["Panel_Name"]);
            lbl_Type.DataBindings.Add(ModelBinding["Panel_Type"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_ChkText"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_Orient"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_OrientVisibility"]);
            this.DataBindings.Add(ModelBinding["PanelGlass_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_PropertyHeight"]);
        }

        private void chk_Orientation_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChkOrientationCheckChangedEventRaised, e);
        }

        public Panel GetPanelSpecsPNL()
        {
            return pnl_panelSpecsBody;
        }
    }
}
