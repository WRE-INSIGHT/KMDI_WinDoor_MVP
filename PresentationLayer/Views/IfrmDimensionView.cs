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
        event EventHandler radbtnCheckChangedEventRaised;

        int InumWidth { get; set; }
        int InumHeight { get; set; }
        int dimension_height { get; set; }
        int thisHeight { set; }
        bool c70rRadBtn_CheckState { set; }
        bool premiLineRadBtn_CheckState { set; }
        void ShowfrmDimension();
        void ClosefrmDimension();
    }
}
