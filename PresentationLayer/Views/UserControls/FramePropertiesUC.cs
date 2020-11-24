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
using ModelLayer.Model.Quotation.Frame;

namespace PresentationLayer.Views.UserControls
{
    public partial class FramePropertiesUC : UserControl, IFramePropertiesUC
    {
        public FramePropertiesUC()
        {
            InitializeComponent();
        }

        public int fHeight
        {
            get
            {
                return (int)num_fHeight.Value;
            }

            set
            {
                num_fHeight.Value = value;
            }
        }

        public string Frame_Name
        {
            set
            {
                lbl_frameName.Text = value;
            }
        }

        public FrameModel.Frame_Padding Frame_Type
        {
            set
            {
                if (value == FrameModel.Frame_Padding.Window)
                {
                    rdBtn_Window.Checked = true;
                }
                else if (value == FrameModel.Frame_Padding.Door)
                {
                    rdBtn_Door.Checked = true;
                }
                else if (value == FrameModel.Frame_Padding.Concrete)
                {
                    rdBtn_Concrete.Checked = true;
                }
            }
        }

        public int fWidth
        {
            get
            {
                return (int)num_fWidth.Value;
            }

            set
            {
                num_fWidth.Value = value;
            }
        }

        public int ThisHeight
        {
            set
            {
                this.Height = value;
            }
        }

        public event EventHandler FramePropertiesLoadEventRaised;

        public void BringToFrontThis()
        {
            this.BringToFront();
        }

        private void FramePropertiesUC_Load(object sender, EventArgs e)
        {
            num_fWidth.Maximum = int.MaxValue;
            num_fHeight.Maximum = int.MaxValue;
            this.Dock = DockStyle.Top;
            EventHelpers.RaiseEvent(this, FramePropertiesLoadEventRaised, e);
        }
    }
}
