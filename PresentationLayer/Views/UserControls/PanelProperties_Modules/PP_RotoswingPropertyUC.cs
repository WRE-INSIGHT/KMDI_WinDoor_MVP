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
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_RotoswingPropertyUC : UserControl, IPP_RotoswingPropertyUC
    {
        public PP_RotoswingPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPRotoswingPropertyLoadEventRaised;
        public event EventHandler cmbRotoswingNoSelectedValueEventRaised;
        public event EventHandler cmbEspagnoletteSelectedValueEventRaised;
        public event EventHandler cmbMiddleCloserSelectedValueEventRaised;

        private void PP_RotoswingPropertyUC_Load(object sender, EventArgs e)
        {
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

            List<Rotoswing_HandleArtNo> rotoswing = new List<Rotoswing_HandleArtNo>();
            foreach (Rotoswing_HandleArtNo item in Rotoswing_HandleArtNo.GetAll())
            {
                rotoswing.Add(item);
            }
            cmb_RotoswingNo.DataSource = rotoswing;

            EventHelpers.RaiseEvent(this, PPRotoswingPropertyLoadEventRaised, e);
        }

        private void cmb_RotoswingNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRotoswingNoSelectedValueEventRaised, e);
        }

        private void cmb_Espagnolette_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbEspagnoletteSelectedValueEventRaised, e);
        }

        private void cmb_MiddleCloser_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbMiddleCloserSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_RotoswingOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Panel_RotoswingOptionsHeight"]);
            cmb_Espagnolette.DataBindings.Add(ModelBinding["Panel_EspagnoletteArtNo"]);
            cmb_MiddleCloser.DataBindings.Add(ModelBinding["Panel_MiddleCloserArtNo"]);
            cmb_RotoswingNo.DataBindings.Add(ModelBinding["Panel_RotoswingArtNo"]);
        }

        public FlowLayoutPanel GetRotoswingOptionFLP()
        {
            return flp_RotoswingOptions;
        }
    }
}
