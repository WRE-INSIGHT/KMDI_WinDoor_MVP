using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class PanelPropertiesUC : UserControl
    {
        public PanelPropertiesUC()
        {
            InitializeComponent();
        }

        private void PanelPropertiesUC_Load(object sender, EventArgs e)
        {
            num_BladeCount.Maximum = decimal.MaxValue;
        }
    }
}
