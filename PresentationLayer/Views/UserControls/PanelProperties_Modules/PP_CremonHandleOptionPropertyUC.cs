using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_CremonHandleOptionPropertyUC : UserControl, IPP_CremonHandleOptionPropertyUC
    {
        public PP_CremonHandleOptionPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler cmbCremonArtNoSelectedValueChangedEventRaised;
        public event EventHandler PPCremonHandleOptionPropertyUCLoadEventRaised;

        private void cmb_CremonArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbCremonArtNoSelectedValueChangedEventRaised, e);
        }

        private void PP_CremonHandleOptionPropertyUC_Load(object sender, EventArgs e)
        {
            List<Cremon_HandleArtNo> CremonArtNo = new List<Cremon_HandleArtNo>();
            foreach (Cremon_HandleArtNo item in Cremon_HandleArtNo.GetAll())
            {
                CremonArtNo.Add(item);
            }
            cmb_CremonArtNo.DataSource = CremonArtNo;
            EventHelpers.RaiseEvent(sender, PPCremonHandleOptionPropertyUCLoadEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            this.DataBindings.Add(ModelBinding["Panel_CremonHandleArtNoVisibility"]);
            cmb_CremonArtNo.DataBindings.Add(ModelBinding["Panel_CremonArtNo"]);

        }

    }
}
