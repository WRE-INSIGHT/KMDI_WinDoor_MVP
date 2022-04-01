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
        public event EventHandler CmbGlazingArtNoSelectedValueChangedEventRaised;
        public event EventHandler CmbFilmTypeSelectedValueChangedEventRaised;
        public event EventHandler CmbSashProfileSelectedValueChangedEventRaised;
        public event EventHandler CmbSashReinfSelectedValueChangedEventRaised;
        public event EventHandler btnSelectGlassThicknessClickedEventRaised;
        public event EventHandler CmbGlassTypeSelectedValueChangedEventRaised;
        public event EventHandler CmbHandleTypeSelectedValueChangedEventRaised;

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
