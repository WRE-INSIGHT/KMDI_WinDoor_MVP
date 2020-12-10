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
            WireAllControls(this);
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

        [Description("Image displayed"), Category("Data")]
        public Image CustomImage
        {
            get
            {
                return pbox_Image.Image;
            }
            set
            {
                pbox_Image.Image = value;
            }
        }

        public event MouseEventHandler controlsUCMouseDownEventRaised;

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                ctl.MouseDown += ControlsUC_MouseDown;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }
        
        private void ctl_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            //this.InvokeOnClick(this, EventArgs.Empty);
        }

        private void ControlsUC_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Test");
            EventHelpers.RaiseMouseEvent(this, controlsUCMouseDownEventRaised, e);
        }

        private void ControlsUC_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }
    }
}
