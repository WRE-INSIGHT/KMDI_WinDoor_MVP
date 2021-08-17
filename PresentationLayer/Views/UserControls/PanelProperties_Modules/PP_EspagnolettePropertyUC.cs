using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_EspagnolettePropertyUC : UserControl, IPP_EspagnolettePropertyUC
    {
        public PP_EspagnolettePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPEspagnolettePropertyLoadEventRaised;
        public event EventHandler cmbEspagnoletteSelectedValueEventRaised;

        private void PP_EspagnolettePropertyUC_Load(object sender, EventArgs e)
        {
            List<Espagnolette_ArticleNo> espArtNo = new List<Espagnolette_ArticleNo>();
            foreach (Espagnolette_ArticleNo item in Espagnolette_ArticleNo.GetAll())
            {
                espArtNo.Add(item);
            }
            cmb_Espagnolette.DataSource = espArtNo;

            EventHelpers.RaiseEvent(this, PPEspagnolettePropertyLoadEventRaised, e);
        }

        private void cmb_Espagnolette_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbEspagnoletteSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_Espagnolette.DataBindings.Add(ModelBinding["Panel_EspagnoletteArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_EspagnoletteOptionsVisibility"]);
        }
    }
}
