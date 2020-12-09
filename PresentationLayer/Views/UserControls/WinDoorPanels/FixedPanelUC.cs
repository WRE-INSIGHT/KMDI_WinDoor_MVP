using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.WinDoorPanels
{
    public partial class FixedPanelUC : UserControl, IFixedPanelUC
    {
        public FixedPanelUC()
        {
            InitializeComponent();
        }

        public event EventHandler fixedPanelUCLoadEventRaised;
    }
}
