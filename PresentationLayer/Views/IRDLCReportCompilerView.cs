using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IRDLCReportCompilerView
    {
        string TxtBxOutofTownExpenses { get; set; }
        event EventHandler BtnCompileReportClickEventRaised;
        event EventHandler RDLCReportCompilerViewLoadEventRaised;
        event EventHandler chkselectallCheckedChangedEventRaised;
        CheckedListBox GetChecklistBoxIndex();
        void ShowRDLCReportCompilerView();
        void CloseRDLCReportCompilerView();
        CheckBox CheckListSelectAll();
        SaveFileDialog GetSaveFileDialog();
        Form GetRDLCReportCompilerForm();
    }
}