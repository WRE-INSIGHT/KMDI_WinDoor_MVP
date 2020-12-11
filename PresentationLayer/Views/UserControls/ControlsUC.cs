using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class ControlsUC : UserControl, IControlsUC
    {
        public ControlsUC()
        {
            InitializeComponent();
        }

        [Description("Text displayed"), Category("Data")]
        public string CustomText
        {
            get
            {
                return lblControlText.Text;
            }
            set
            {
                lblControlText.Text = value;
            }
        }
        
        public event MouseEventHandler controlsUCMouseDownEventRaised;
        public event EventHandler controlsUCLoadEventRaised;

        private void ControlsUC_MouseDown(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseMouseEvent(this, controlsUCMouseDownEventRaised, e);
        }

        private void ControlsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, controlsUCLoadEventRaised, e);
        }

        public Panel GetWinDoorPanel()
        {
            return pnl_WinDoorPanel;
        }
    }
}
