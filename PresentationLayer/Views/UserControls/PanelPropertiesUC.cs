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
        public event EventHandler CmbEspagnoletteSelectedValueChangedEventRaised;
        public event EventHandler CmbMiddleCloserSelectedValueChangedEventRaised;
        public event EventHandler CmbLockingKitSelectedValueChangedEventRaised;
        public event EventHandler CmbRotoswingArtNoSelectedValueChangedEventRaised;
        public event EventHandler CmbRotaryArtNoSelectedValueChangedEventRaised;

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

            List<Handle_Type> hType = new List<Handle_Type>();
            foreach (Handle_Type item in Handle_Type.GetAll())
            {
                hType.Add(item);
            }
            cmb_HandleType.DataSource = hType;

            List<Espagnolette_ArticleNo> espArtNo = new List<Espagnolette_ArticleNo>();
            foreach (Espagnolette_ArticleNo item in Espagnolette_ArticleNo.GetAll())
            {
                espArtNo.Add(item);
            }
            cmb_Espagnolette.DataSource = espArtNo;

            List<MiddleCloser_ArticleNo> midArtNo = new List<MiddleCloser_ArticleNo>();
            foreach (MiddleCloser_ArticleNo item in MiddleCloser_ArticleNo.GetAll())
            {
                midArtNo.Add(item);
            }
            cmb_MiddleCloser.DataSource = midArtNo;

            List<LockingKit_ArticleNo> lockArtNo = new List<LockingKit_ArticleNo>();
            foreach (LockingKit_ArticleNo item in LockingKit_ArticleNo.GetAll())
            {
                lockArtNo.Add(item);
            }
            cmb_LockingKit.DataSource = lockArtNo;


            List<Rotoswing_HandleArtNo> rotoswing = new List<Rotoswing_HandleArtNo>();
            foreach (Rotoswing_HandleArtNo item in Rotoswing_HandleArtNo.GetAll())
            {
                rotoswing.Add(item);
            }
            cmb_RotoswingNo.DataSource = rotoswing;

            List<Rotary_HandleArtNo> rotary = new List<Rotary_HandleArtNo>();
            foreach (Rotary_HandleArtNo item in Rotary_HandleArtNo.GetAll())
            {
                rotary.Add(item);
            }
            cmb_RotaryArtNo.DataSource = rotary;

            List<MotorizedMech_ArticleNo> motormech = new List<MotorizedMech_ArticleNo>();
            foreach (MotorizedMech_ArticleNo item in MotorizedMech_ArticleNo.GetAll())
            {
                motormech.Add(item);
            }
            cmb_MotorizedMechanism.DataSource = motormech;

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
            cmb_FilmType.DataBindings.Add(ModelBinding["Panel_GlassFilm"]);
            cmb_GlazingArtNo.DataBindings.Add(ModelBinding["PanelGlazingBead_ArtNo"]);
            cmb_SashProfile.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
            cmb_SashReinf.DataBindings.Add(ModelBinding["Panel_SashReinfArtNo"]);
            cmb_GlassType.DataBindings.Add(ModelBinding["Panel_GlassType"]);
            lbl_GlassThicknessDesc.DataBindings.Add(ModelBinding["Panel_GlassThicknessDesc"]);
            cmb_HandleType.DataBindings.Add(ModelBinding["Panel_HandleType"]);
            this.DataBindings.Add(ModelBinding["Panel_PropertyHeight"]);
            flp_HandleOptions.DataBindings.Add(ModelBinding["Panel_HandleOptionsVisibility"]);
            pnl_RotoswingOptions.DataBindings.Add(ModelBinding["Panel_RotoswingOptionsVisibility"]);
            pnl_RotaryOptions.DataBindings.Add(ModelBinding["Panel_RotaryOptionsVisibility"]);
            flp_HandleOptions.DataBindings.Add(ModelBinding["Panel_HandleOptionsHeight"]);
            cmb_Espagnolette.DataBindings.Add(ModelBinding["Panel_EspagnoletteArtNo"]);
            txt_Striker.DataBindings.Add(ModelBinding["Panel_StrikerArtno"]);
            cmb_MiddleCloser.DataBindings.Add(ModelBinding["Panel_MiddleCloserArtNo"]);
            cmb_LockingKit.DataBindings.Add(ModelBinding["Panel_LockingKitArtNo"]);
            cmb_RotoswingNo.DataBindings.Add(ModelBinding["Panel_RotoswingArtNo"]);
            cmb_RotaryArtNo.DataBindings.Add(ModelBinding["Panel_RotaryArtNo"]);
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

        private void cmb_HandleType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbHandleTypeSelectedValueChangedEventRaised, e);
        }

        public Panel GetPnlRotoswingOptions()
        {
            return pnl_RotoswingOptions;
        }

        public Panel GetPnlRotaryOptions()
        {
            return pnl_RotaryOptions;
        }

        private void cmb_Espagnolette_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbEspagnoletteSelectedValueChangedEventRaised, e);
        }

        private void cmb_MiddleCloser_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbMiddleCloserSelectedValueChangedEventRaised, e);
        }

        private void cmb_LockingKit_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbLockingKitSelectedValueChangedEventRaised, e);
        }

        private void cmb_RotoswingNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbRotoswingArtNoSelectedValueChangedEventRaised, e);
        }

        private void cmb_RotaryArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CmbRotaryArtNoSelectedValueChangedEventRaised, e);
        }
    }
}
