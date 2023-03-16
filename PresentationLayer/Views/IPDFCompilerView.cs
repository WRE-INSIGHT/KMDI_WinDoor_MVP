using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPDFCompilerView
    {
        event EventHandler btnCompileReportsClickEventRaised;
        event EventHandler btnCompilePDFClickEventRaised;
        event EventHandler changeSyncDirToolStripMenuItemClickEventRaised;
        void GetPDFCompilerView();
        void ClosePDFCompilerView();
        OpenFileDialog GetFileDialog();
    }
}