using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IPDFWaitFormView
    {
        event EventHandler PDFWaitFormViewLoadEventRaised;

        void ClosePDFWaitFormView();
        Label GetImagelabel();
        Label GetPleaseWaitlabel();
        void ShowPDFwaitFormView(Form parent);
    }
}