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

namespace PresentationLayer.Views.UserControls
{
    public partial class ControlsUC : UserControl
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
    }
}
