using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
        public event EventHandler cmbRioArtNo2SelectedValueChangedEventRaised;


        private void PP_RioPropertyUC_Load(object sender, EventArgs e)
        {
            List<Rio_HandleArtNo> rio = new List<Rio_HandleArtNo>();
            foreach (Rio_HandleArtNo item in Rio_HandleArtNo.GetAll())
            {
                rio.Add(item);
            }
            cmb_RioArtNo.DataSource = rio;

            List<Rio_HandleArtNo> rio2 = new List<Rio_HandleArtNo>();
            foreach (Rio_HandleArtNo item2 in Rio_HandleArtNo.GetAll())
            {
                rio2.Add(item2);
            }
            cmb_RioArtNo2.DataSource = rio2;

            if (cmb_RioArtNo2.Visible == true)
            {
                this.Size = new System.Drawing.Size(154, 56);
            }
            else if (cmb_RioArtNo2.Visible == false)
            {
                this.Size = new System.Drawing.Size(154, 28);
            }
            EventHelpers.RaiseEvent(this, PPRioPropertyLoadEventRaised, e);
        }

        private void cmb_RioArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRioArtNoSelectedValueChangedEventRaised, e);
        }

        private void cmb_RioArtNo2_SelectedValueChanged(object sender, EventArgs e)
        {
         
            EventHelpers.RaiseEvent(sender, cmbRioArtNo2SelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_RioArtNo.DataBindings.Add(ModelBinding["Panel_RioArtNo"]);
            cmb_RioArtNo2.DataBindings.Add(ModelBinding["Panel_RioArtNo2"]);
            this.DataBindings.Add(ModelBinding["Panel_RioOptionsVisibility"]);
            pnl_RioArtNo2.DataBindings.Add(ModelBinding["Panel_RioOptionsVisibility2"]);

        }
        private void cmb_RioArtNo_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RioArtNo2_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void cmb_RioArtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmb_RioArtNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
