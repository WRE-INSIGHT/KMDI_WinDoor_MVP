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

namespace PresentationLayer.Views.UserControls
{
    public partial class MultiPanelPropertiesUC : UserControl, IMultiPanelPropertiesUC
    {
        private int _mpanelID;
        public int MPanelID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }

        public event EventHandler MultiPanelPropertiesLoadEventRaised;
        public event EventHandler glassbalancingClickedEventRaised;

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            this.DataBindings.Add(ModelBinding["MPanel_ID"]);
            this.DataBindings.Add(ModelBinding["MPanelProp_Height"]);
            lbl_MultiPanelName.DataBindings.Add(ModelBinding["MPanel_Name"]);
            num_Width.DataBindings.Add(ModelBinding["MPanel_Width"]);
            num_Height.DataBindings.Add(ModelBinding["MPanel_Height"]);
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                RemoveDataBinding();
            }

        }
        private void RemoveDataBinding()
        {
            this.DataBindings.Clear();
            lbl_MultiPanelName.DataBindings.Clear();
            num_Width.DataBindings.Clear();
            num_Height.DataBindings.Clear();


            this.Dispose();
            lbl_MultiPanelName.Dispose();
            num_Width.Dispose();
            num_Height.Dispose();
            lbl_Height.Dispose();
            lbl_Width.Dispose();
            pnl_MultiPanelProperties.Dispose();
            cmenu_mpanel.Dispose();
            panel1.Dispose();
            glassBalancingToolStripMenuItem.Dispose();
        }

        public MultiPanelPropertiesUC()
        {
            InitializeComponent();
        }

        private void MultiPanelPropertiesUC_Load(object sender, EventArgs e)
        {
            num_Height.Maximum = int.MaxValue;
            num_Width.Maximum = int.MaxValue;
            
            EventHelpers.RaiseEvent(this, MultiPanelPropertiesLoadEventRaised, e);

            if (lbl_MultiPanelName.Text.Contains("Transom"))
            {
                this.BackColor = SystemColors.ActiveCaption;
            }
            else if (lbl_MultiPanelName.Text.Contains("Mullion"))
            {
                this.BackColor = Color.MistyRose;
            }
        }

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        public Panel GetMultiPanelPropertiesPNL()
        {
            return pnl_MultiPanelProperties;
        }

        private void glassBalancingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, glassbalancingClickedEventRaised, e);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmenu_mpanel.Show(new Point(MousePosition.X, MousePosition.Y));
            }
           
        }

      
    }
}
