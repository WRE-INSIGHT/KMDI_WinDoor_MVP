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
    public partial class PP_HandlePropertyUC : UserControl, IPP_HandlePropertyUC
    {
        public PP_HandlePropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPHandlePropertyLoadEventRaised;
        public event EventHandler cmbHandleTypeSelectedValueEventRaised;

        private void PP_HandlePropertyUC_Load(object sender, EventArgs e)
        {
            List<Handle_Type> hType = new List<Handle_Type>();
            foreach (Handle_Type item in Handle_Type.GetAll())
            {
                hType.Add(item);
            }
            cmb_HandleType.DataSource = hType;

            EventHelpers.RaiseEvent(this, PPHandlePropertyLoadEventRaised, e);
        }

        private void cmb_HandleType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbHandleTypeSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_HandleType.DataBindings.Add(ModelBinding["Panel_HandleType"]);
            this.DataBindings.Add(ModelBinding["Panel_HandleOptionsVisibility"]);
        }
    }
}
