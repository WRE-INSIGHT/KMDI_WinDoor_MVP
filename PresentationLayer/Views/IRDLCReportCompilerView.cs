using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IRDLCReportCompilerView
    {
        string TxtBxOutofTownExpenses { get; set; }
        event EventHandler BtnCompileReportClickEventRaised;
        event EventHandler RDLCReportCompilerViewLoadEventRaise;
        CheckedListBox GetChecklistBoxIndex();
        void ShowRDLCReportCompilerView();
        void CloseRDLCReportCompilerView();
    }
}