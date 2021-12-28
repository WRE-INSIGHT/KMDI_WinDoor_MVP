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

        private string _customText;
        [Description("Text displayed"), Category("Data")]
        public string CustomText
        {
            get
            {
                return _customText;
            }
            set
            {
                _customText = value;
            }
        }

        private int _divCount;
        public int DivCount
        {
            get
            {
                return _divCount;
            }
            set
            {
                _divCount = value;
                if (CustomText.Contains("Multi"))
                {
                    lblControlText.Text = CustomText + "(" + DivCount + ")" + " I(" + Iteration + ")";
                }
                else
                {
                    lblControlText.Text = CustomText + " I(" + Iteration + ")";
                }
            }
        }

        private int _iteration;
        public int Iteration
        {
            get
            {
                return _iteration;
            }

            set
            {
                _iteration = value;
                if (CustomText.Contains("Multi"))
                {
                    lblControlText.Text = CustomText + "(" + DivCount + ")" + " I(" + Iteration + ")";
                }
                else
                {
                    lblControlText.Text = CustomText + " I(" + Iteration + ")";
                }
            }
        }

        public event MouseEventHandler controlsUCMouseDownEventRaised;
        public event EventHandler controlsUCLoadEventRaised;
        public event EventHandler divcountToolStripMenuItemClickEventRaised;
        public event EventHandler iterationToolStripMenuItemClickEventRaised;

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

        private void lblControlText_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lblControlText.Text.Contains("Multi"))
                {
                    divcountToolStripMenuItem.Visible = true;
                    iterationToolStripMenuItem.Visible = true;
                }
                else if (lblControlText.Text.Contains("Panel"))
                {
                    divcountToolStripMenuItem.Visible = false;
                }
                cmenu_ControlsUC.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void divcountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, divcountToolStripMenuItemClickEventRaised, e);
        }

        private void iterationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, iterationToolStripMenuItemClickEventRaised, e);
        }
    }
}
