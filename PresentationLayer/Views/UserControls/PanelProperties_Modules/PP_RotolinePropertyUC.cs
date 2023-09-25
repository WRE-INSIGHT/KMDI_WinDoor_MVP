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
    public partial class PP_RotolinePropertyUC : UserControl, IPP_RotolinePropertyUC
    {
        public PP_RotolinePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPRotolinePropertyLoadEventRaised;
        public event EventHandler cmbRotolineArtNoSelectedValueChangedEventRaised;

        private void PP_RotolinePropertyUC_Load(object sender, EventArgs e)
        {
            List<Rotoline_HandleArtNo> rotoline = new List<Rotoline_HandleArtNo>();
            foreach (Rotoline_HandleArtNo item in Rotoline_HandleArtNo.GetAll())
            {
                rotoline.Add(item);
            }
            cmb_RotolineArtNo.DataSource = rotoline;

            EventHelpers.RaiseEvent(this, PPRotolinePropertyLoadEventRaised, e);
            cmb_RotolineArtNo.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RotolineArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRotolineArtNoSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_RotolineArtNo.DataBindings.Add(ModelBinding["Panel_RotolineArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_RotolineOptionsVisibility"]);
        }
        private void cmb_RotolineArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_RotolineArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
