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
    public partial class PP_RotaryPropertyUC : UserControl, IPP_RotaryPropertyUC
    {
        public PP_RotaryPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler PPRotaryPropertyLoadEventRaised;
        public event EventHandler cmbRotaryArtNoSelectedValueChangedEventRaised;
        public event EventHandler cmbLockingKitSelectedValueChangedEventRaised;

        private void PP_RotaryPropertyUC_Load(object sender, EventArgs e)
        {
            List<LockingKit_ArticleNo> lockArtNo = new List<LockingKit_ArticleNo>();
            foreach (LockingKit_ArticleNo item in LockingKit_ArticleNo.GetAll())
            {
                lockArtNo.Add(item);
            }
            cmb_LockingKit.DataSource = lockArtNo;

            List<Rotary_HandleArtNo> rotary = new List<Rotary_HandleArtNo>();
            foreach (Rotary_HandleArtNo item in Rotary_HandleArtNo.GetAll())
            {
                rotary.Add(item);
            }
            cmb_RotaryArtNo.DataSource = rotary;

            EventHelpers.RaiseEvent(this, PPRotaryPropertyLoadEventRaised, e);
            cmb_RotaryArtNo.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            cmb_LockingKit.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
        }
        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void cmb_RotaryArtNo_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbRotaryArtNoSelectedValueChangedEventRaised, e);
        }

        private void cmb_LockingKit_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbLockingKitSelectedValueChangedEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["Panel_RotaryOptionsVisibility"]);
            cmb_LockingKit.DataBindings.Add(ModelBinding["Panel_LockingKitArtNo"]);
            cmb_RotaryArtNo.DataBindings.Add(ModelBinding["Panel_RotaryArtNo"]);
        }
    }
}
