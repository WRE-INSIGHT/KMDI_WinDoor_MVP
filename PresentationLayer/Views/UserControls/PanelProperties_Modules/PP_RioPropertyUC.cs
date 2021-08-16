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
    public partial class PP_RioPropertyUC : UserControl, IPP_RioPropertyUC
    {
        public PP_RioPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPRioPropertyLoadEventRaised;
        public event EventHandler cmbRioArtNoSelectedValueChangedEventRaised;

        private void PP_RioPropertyUC_Load(object sender, EventArgs e)
        {
            List<Rio_HandleArtNo> rio = new List<Rio_HandleArtNo>();
            foreach (Rio_HandleArtNo item in Rio_HandleArtNo.GetAll())
            {
                rio.Add(item);
            }
            cmb_RioArtNo.DataSource = rio;

            EventHelpers.RaiseEvent(this, PPRioPropertyLoadEventRaised, e);
        }

        private void cmb_RioArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRioArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_RioArtNo.DataBindings.Add(ModelBinding["Panel_RioArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_RioOptionsVisibility"]);
        }
    }
}
