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

        private void PP_RotoswingPropertyUC_Load(object sender, EventArgs e)
        {
            List<Rotoswing_HandleArtNo> rotoswing = new List<Rotoswing_HandleArtNo>();
            foreach (Rotoswing_HandleArtNo item in Rotoswing_HandleArtNo.GetAll())
            {
                rotoswing.Add(item);
            }
            cmb_RotoswingNo.DataSource = rotoswing;

            EventHelpers.RaiseEvent(this, PPRotoswingPropertyLoadEventRaised, e);
            cmb_RotoswingNo.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RotoswingNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRotoswingNoSelectedValueEventRaised, e);
        }
        
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_RotoswingOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Panel_RotoswingOptionsHeight"]);
            cmb_RotoswingNo.DataBindings.Add(ModelBinding["Panel_RotoswingArtNo"]);
        }

        public Panel GetRotoswingOptionPNL()
        {
            return pnl_RotoswingOptions;
        }
    }
}
