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
using static EnumerationTypeLayer.EnumerationTypes;

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

        public bool SashPanel_Visibility
        {
            get
            {
                return pnl_Sash.Visible;
            }

            set
            {
                pnl_Sash.Visible = value;
                if (value == true)
                {
                    //this.Height -= 53;
                    flp_PanelSpecs.Height = 166;
                }
                else if (value == false)
                {
                    //this.Height += 53;
                    flp_PanelSpecs.Height = 113;
                }
            }
        }

        public event EventHandler PanelPropertiesLoadEventRaised;
        public event EventHandler ChkOrientationCheckChangedEventRaised;
        public event EventHandler CmbGlassThickSelectedValueChangedEventRaised;

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            pnum_Width.Maximum = decimal.MaxValue;
            pnum_Height.Maximum = decimal.MaxValue;
            num_BladeCount.Maximum = decimal.MaxValue;

            List<Glass_Thickness> gThickness = new List<Glass_Thickness>();
            foreach (Glass_Thickness item in Glass_Thickness.GetAll())
            {
                gThickness.Add(item);
            }
            cmb_GlassThick.DataSource = gThickness;

            List<GlazingBead_ArticleNo> gArtNo = new List<GlazingBead_ArticleNo>();
            foreach (GlazingBead_ArticleNo item in GlazingBead_ArticleNo.GetAll())
            {
                gArtNo.Add(item);
            }
            cmb_GlazingArtNo.DataSource = gArtNo;

            List<GlassFilm_Types> gFilm = new List<GlassFilm_Types>();
            foreach (GlassFilm_Types item in GlassFilm_Types.GetAll())
            {
                gFilm.Add(item);
            }
            cmb_FilmType.DataSource = gFilm;

            List<SashProfile_ArticleNo> sash = new List<SashProfile_ArticleNo>();
            foreach (SashProfile_ArticleNo item in SashProfile_ArticleNo.GetAll())
            {
                sash.Add(item);
            }
            cmb_SashProfile.DataSource = sash;

            List<SashReinf_ArticleNo> sashReinf = new List<SashReinf_ArticleNo>();
            foreach (SashReinf_ArticleNo item in SashReinf_ArticleNo.GetAll())
            {
                sashReinf.Add(item);
            }
            cmb_SashReinf.DataSource = sashReinf;

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
            //this.DataBindings.Add(ModelBinding["Panel_Visibility"]);
            cmb_GlassThick.DataBindings.Add(ModelBinding["Panel_GlassThickness"]);
            cmb_GlazingArtNo.DataBindings.Add(ModelBinding["PanelGlazingBead_ArtNo"]);
            this.DataBindings.Add(ModelBinding["PanelGlass_ID"]);
            this.DataBindings.Add(ModelBinding["Panel_ID"]);
            cmb_FilmType.DataBindings.Add(ModelBinding["Panel_GlassFilm"]);
            pnl_Sash.DataBindings.Add(ModelBinding["Panel_SashPropertyVisibility"]);
            this.DataBindings.Add(ModelBinding["SashPanel_Visibility"]);
        }

        private void chk_Orientation_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChkOrientationCheckChangedEventRaised, e);
        }

        private void cmb_GlassThick_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbGlassThickSelectedValueChangedEventRaised, e);
        }
    }
}
