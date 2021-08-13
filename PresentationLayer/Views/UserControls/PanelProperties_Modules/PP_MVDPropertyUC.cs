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
    public partial class PP_MVDPropertyUC : UserControl, IPP_MVDPropertyUC
    {
        public PP_MVDPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPMVDPropertyLoadEventRaised;
        public event EventHandler cmbMVDArtNoSelectedValueChangedEventRaised;

        private void PP_MVDPropertyUC_Load(object sender, EventArgs e)
        {
            List<MVD_HandleArtNo> mvd = new List<MVD_HandleArtNo>();
            foreach (MVD_HandleArtNo item in MVD_HandleArtNo.GetAll())
            {
                mvd.Add(item);
            }
            cmb_MVDArtNo.DataSource = mvd;

            EventHelpers.RaiseEvent(this, PPMVDPropertyLoadEventRaised, e);
        }

        private void cmb_MVDArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbMVDArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_MVDArtNo.DataBindings.Add(ModelBinding["Panel_MVDArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_MVDOptionsVisibility"]);
        }
    }
}
