using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IRDLCReportCompilerView
    {
        string TxtBxOutofTownExpenses { get; set; }
        string TxtBxContractSummaryVat { get; set; }
        string TxtBxRowlimit { get; set; }
        CheckBox GetSubTotalCheckBox();

        event EventHandler chkboxsubtotalCheckedChangedEventRaised;
        event EventHandler BtnCompileReportClickEventRaised;
        event EventHandler RDLCReportCompilerViewLoadEventRaised;
        event EventHandler chkselectallCheckedChangedEventRaised;
        event EventHandler chkboxshowVatCheckedChangedEventRaised;
        CheckedListBox GetChecklistBoxIndex();
        void ShowRDLCReportCompilerView();
        void CloseRDLCReportCompilerView();
        CheckBox CheckListSelectAll();
        SaveFileDialog GetSaveFileDialog();
        Form GetRDLCReportCompilerForm();
        TextBox GetOOTTextBox();
        TextBox GetContracSummaryVatTextBox();
        CheckBox GetShowVatCheckBox();
    }
}