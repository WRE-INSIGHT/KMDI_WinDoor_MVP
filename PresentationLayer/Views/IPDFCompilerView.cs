using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPDFCompilerView
    {
        event EventHandler btnCompileReportsClickEventRaised;
        event EventHandler btnCompilePDFClickEventRaised;
        event EventHandler changeSyncDirToolStripMenuItemClickEventRaised;
        event FormClosedEventHandler PDFCompilerViewFormClosedEventRaised;
        event EventHandler wthAnnex_chkbx_CheckedChangedEventRaised;

        void GetPDFCompilerView();
        void ClosePDFCompilerView();
        CheckBox GetPartialAdjustmentCheckbox();
        CheckBox GetAnnexCheckbox();
        OpenFileDialog GetFileDialog();

    }
}