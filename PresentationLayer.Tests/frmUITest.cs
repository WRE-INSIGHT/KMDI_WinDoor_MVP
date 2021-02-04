using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    public partial class frmUITest : Form
    {
        public frmUITest()
        {
            InitializeComponent();
        }

        private void frmUITest_SizeChanged(object sender, EventArgs e)
        {
            Controls[0].Invalidate();
        }
    }
}
