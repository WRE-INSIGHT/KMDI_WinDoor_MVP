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
                    flp_PanelSpecs.Height = 166;
                }
                else if (value == false)
                {
                    flp_PanelSpecs.Height = 113;
                }
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

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            pnum_Width.Maximum = decimal.MaxValue;
            pnum_Height.Maximum = decimal.MaxValue;
            num_BladeCount.Maximum = decimal.MaxValue;

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

            List<GlassType> gType = new List<GlassType>();
            foreach (GlassType item in GlassType.GetAll())
            {
                gType.Add(item);
            }
            cmb_GlassType.DataSource = gType;

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
            pnl_Sash.DataBindings.Add(ModelBinding["Panel_SashPropertyVisibility"]);
            this.DataBindings.Add(ModelBinding["SashPanel_Visibility"]);
            cmb_FilmType.DataBindings.Add(ModelBinding["Panel_GlassFilm"]);
            cmb_GlazingArtNo.DataBindings.Add(ModelBinding["PanelGlazingBead_ArtNo"]);
            cmb_SashProfile.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
            cmb_SashReinf.DataBindings.Add(ModelBinding["Panel_SashReinfArtNo"]);
            cmb_GlassType.DataBindings.Add(ModelBinding["Panel_GlassType"]);
        }

        private void chk_Orientation_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ChkOrientationCheckChangedEventRaised, e);
        }

        private void cmb_SashProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbSashProfileSelectedValueChangedEventRaised, e);
        }

        private void cmb_SashReinf_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbSashReinfSelectedValueChangedEventRaised, e);
        }

        private void cmb_GlazingArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbGlazingArtNoSelectedValueChangedEventRaised, e);
        }

        private void cmb_FilmType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbFilmTypeSelectedValueChangedEventRaised, e);
        }

        private void btn_SelectGlassthickness_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, btnSelectGlassThicknessClickedEventRaised, e);
        }

        private void cmb_GlassType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbGlassTypeSelectedValueChangedEventRaised, e);
        }
    }
}
