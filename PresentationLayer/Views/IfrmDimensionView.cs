using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IfrmDimensionView
    {
        event EventHandler frmDimensionLoadEventRaised;
        event EventHandler btnOKClickedEventRaised;
        event EventHandler btnCancelClickedEventRaised;

        int InumWidth { get; set; }
        int InumHeight { get; set; }
        int dimension_height { get; set; }
        void ShowfrmDimension();
        void ClosefrmDimension();
    }
}
