using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IRDLCReportCompilerView
    {
        string TxtBxOutofTownExpenses { get; set; }
        string TxtBxContractSummaryVat { get; set; }
        string TxtBxRowlimit { get; set; }
        string TxtContractSummaryLessDiscount { get; set; }
        CheckBox GetSubTotalCheckBox();

        event EventHandler chkboxsubtotalCheckedChangedEventRaised;
        event EventHandler BtnCompileReportClickEventRaised;
        event EventHandler RDLCReportCompilerViewLoadEventRaised;
        event EventHandler chkselectallCheckedChangedEventRaised;
        event EventHandler chkboxshowVatCheckedChangedEventRaised;
        event EventHandler chkbxguShowReviewedByCheckedChangedEventRaised;
        event EventHandler chkbxguShowNotedByCheckedChanged;
        event EventHandler chkbxguShowVatCheckedChanged;
        event EventHandler chkbx_SummaryLessD_CheckedChangedEventRaised;
        CheckedListBox GetChecklistBoxIndex();
        void ShowRDLCReportCompilerView();
        void CloseRDLCReportCompilerView();
        CheckBox CheckListSelectAll();
        SaveFileDialog GetSaveFileDialog();
        Form GetRDLCReportCompilerForm();
        TextBox GetOOTTextBox();
        TextBox GetContracSummaryVatTextBox();
        CheckBox GetShowVatCheckBox();
        ComboBox GUGlassType();
        ComboBox GUReviewedBy();
        ComboBox GUNotedBy();
        TextBox GUVat();
        CheckBox GUShowReviewedBy();
        CheckBox GUShowNotedBy();
        CheckBox GUShowVat();
        CheckedListBox GUGlassListChkLst();
        CheckBox GetContractSummaryLessDiscountChkBx();
        TextBox GetContractSummaryLessDiscountTxtBx();



    }
}