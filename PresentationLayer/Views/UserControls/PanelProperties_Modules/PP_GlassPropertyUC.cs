using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_GlassPropertyUC : UserControl, IPP_GlassPropertyUC
    {
        public PP_GlassPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPGlassPropertyLoadEventRaised;
        public event EventHandler cmbGlassTypeSelectedValueEventRaised;
        public event EventHandler cmbGlazingArtNoSelectedValueEventRaised;
        public event EventHandler cmbFilmTypeSelectedValueEventRaised;
        public event EventHandler btnSelectGlassThicknessClickedEventRaised;

        private void PP_GlassPropertyUC_Load(object sender, EventArgs e)
        {
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

            List<GlassType> gType = new List<GlassType>();
            foreach (GlassType item in GlassType.GetAll())
            {
                gType.Add(item);
            }
            cmb_GlassType.DataSource = gType;

            EventHelpers.RaiseEvent(this, PPGlassPropertyLoadEventRaised, e);
        }

        private void cmb_GlassType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbGlassTypeSelectedValueEventRaised, e);
        }

        private void cmb_GlazingArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbGlazingArtNoSelectedValueEventRaised, e);
        }

        private void cmb_FilmType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbFilmTypeSelectedValueEventRaised, e);
        }

        private void btn_SelectGlassthickness_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnSelectGlassThicknessClickedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_FilmType.DataBindings.Add(ModelBinding["Panel_GlassFilm"]);
            cmb_GlazingArtNo.DataBindings.Add(ModelBinding["PanelGlazingBead_ArtNo"]);
            cmb_GlassType.DataBindings.Add(ModelBinding["Panel_GlassType"]);
            lbl_GlassThicknessDesc.DataBindings.Add(ModelBinding["Panel_GlassThicknessDesc"]);
            chk_GlazingAdaptor.DataBindings.Add(ModelBinding["Panel_ChkGlazingAdaptor"]);
            this.DataBindings.Add(ModelBinding["Panel_GlassPropertyHeight"]);
            pnl_GlazingBeadArtNo.DataBindings.Add(ModelBinding["Panel_GlassPnlGlazingBeadVisibility"]);
            pnl_GlazingAdaptor.DataBindings.Add(ModelBinding["Panel_GlassPnlGlazingAdaptorVisibility"]);

        }


    }
}
