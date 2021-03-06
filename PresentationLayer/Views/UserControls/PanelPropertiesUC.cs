﻿using System;
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

namespace PresentationLayer.Views.UserControls
{
    public partial class PanelPropertiesUC : UserControl, IPanelPropertiesUC
    {
        public PanelPropertiesUC()
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

        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler ChkOrientationCheckChangedEventRaised;

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            pnum_Width.Maximum = decimal.MaxValue;
            pnum_Height.Maximum = decimal.MaxValue;
            num_BladeCount.Maximum = decimal.MaxValue;
            cmb_GlazingArtNo.DataSource = Enum.GetValues(typeof(GlazingBead_ArticleNo));
            EventHelpers.RaiseEvent(this, PanelPropertiesLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            pnum_Width.DataBindings.Add(ModelBinding["Panel_Width"]);
            pnum_Height.DataBindings.Add(ModelBinding["Panel_Height"]);
            //pnum_Width.DataBindings.Add(ModelBinding["Panel_PNumEnable1"]);
            //pnum_Height.DataBindings.Add(ModelBinding["Panel_PNumEnable2"]);
            lbl_pnlname.DataBindings.Add(ModelBinding["Panel_Name"]);
            lbl_Type.DataBindings.Add(ModelBinding["Panel_Type"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_ChkText"]);
            chk_Orientation.DataBindings.Add(ModelBinding["Panel_Orient"]);
            this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            cmb_GlassThick.DataBindings.Add(ModelBinding["Panel_GlassThickness"]);
            cmb_GlazingArtNo.DataBindings.Add(ModelBinding["PanelGlazingBead_ArtNo"]);
        }

        private void chk_Orientation_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChkOrientationCheckChangedEventRaised, e);
        }
    }
}
