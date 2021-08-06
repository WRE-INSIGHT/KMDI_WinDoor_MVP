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

namespace PresentationLayer.Views.UserControls.DividerProperties_Modules
{
    public partial class DP_CladdingPropertyUC : UserControl, IDP_CladdingPropertyUC
    {
        public DP_CladdingPropertyUC()
        {
            InitializeComponent();
        }

        public event EventHandler DPCladdingPropertyUCLoadEventRaised;

        private void DP_CladdingPropertyUC_Load(object sender, EventArgs e)
        {
            num_CladdingSize.Maximum = decimal.MaxValue;
            EventHelpers.RaiseEvent(this, DPCladdingPropertyUCLoadEventRaised, e);
        }
    }
}
