using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace PresentationLayer.Views
{
    public partial class RDLCReportCompilerView : Form, IRDLCReportCompilerView
    {
        public string TxtBxOutofTownExpenses
        {
            get
            {
                return txt_oftexpenses.Text;
            }
            set
            {
                txt_oftexpenses.Text = value;
            }
        }
        public string TxtBxContractSummaryVat
        {
            get
            {
                return txt_SummaryVat.Text;
            }
            set
            {
                txt_SummaryVat.Text = value;
            }
        }
        public string TxtBxRowlimit
        {
            get
            {
                return txtbox_rowlimit.Text;
            }
            set
            {
                txtbox_rowlimit.Text = value;
            }
        }
        public string TxtContractSummaryLessDiscount
        {
            get
            {
                return txtbx_SummaryLessD.Text;
            }
            set
            {
                txtbx_SummaryLessD.Text = value;
            }
        }

        public string TxtGlassUpgradeRowLimit
        {
            get
            {
                return txt_Gurowlimit.Text;
            }
            set
            {
                txt_Gurowlimit.Text = value;
            }
        }

        public CheckBox GetScreenNetOfDiscountChkBox()
        {
            return chkbx_ScreenNetofDiscount;
        }

        public CheckBox GetSubTotalCheckBox()
        {
            return chkbox_subtotal;
        }
        public TextBox GetContracSummaryVatTextBox()
        {
            return txt_SummaryVat;
        }
        public CheckBox GetShowVatCheckBox()
        {
            return chkbox_showVat;
        }    
        public TextBox GetOOTTextBox()
        {
            return txt_oftexpenses;
        }
        public CheckedListBox GetChecklistBoxIndex()
        {
            return chk_showimagelist;
        }
        public void ShowRDLCReportCompilerView()
        {
            this.Show();
        }
        public void CloseRDLCReportCompilerView()
        {
            this.Close();
        }
        public CheckBox CheckListSelectAll()
        {
            return chk_selectall;
        }
        public ComboBox GUGlassType()
        {
            return cmb_GlassType;
        }
        public ComboBox GUReviewedBy()
        {
            return cmb_guReviewedBy;
        }
        public ComboBox GUNotedBy()
        {
            return cmb_guNotedBy;
        }
        public TextBox GUVat()
        {
            return txt_guVat;
        }
        public CheckBox GUShowReviewedBy()
        {
            return chkbx_guShowReviewedBy;
        }
        public CheckBox GUShowNotedBy()
        {
            return chkbx_guShowNotedBy;
        }
        public CheckBox GUShowVat()
        {
            return chkbx_guShowVat;
        }

        public CheckedListBox GUGlassListChkLst()
        {
            return chklst_glassType;
        }

        public  SaveFileDialog GetSaveFileDialog()
        {
            return saveFileDialog;
        }
        public Form GetRDLCReportCompilerForm()
        {
            return this;
        }

        public CheckBox GetContractSummaryLessDiscountChkBx()
        {
            return chkbx_SummaryLessD;
        }
        public TextBox GetContractSummaryLessDiscountTxtBx()
        {
            return txtbx_SummaryLessD;
        }

        public CheckBox GetGlassUpgradeSubTotal()
        {
            return chkbx_GuSubtotal;
        }
        public TextBox GetGlassUpgradeRowLimitTxtBx()
        {
            return txt_Gurowlimit;
        }

        public TextBox GetScreenRowLimitTxtBx()
        {
            return txtbox_rowlimit;
        }



        public event EventHandler chkboxsubtotalCheckedChangedEventRaised;
        public event EventHandler BtnCompileReportClickEventRaised;
        public event EventHandler RDLCReportCompilerViewLoadEventRaised;
        public event EventHandler chkselectallCheckedChangedEventRaised;
        public event EventHandler chkboxshowVatCheckedChangedEventRaised;
        public event EventHandler chkbxguShowReviewedByCheckedChangedEventRaised;
        public event EventHandler chkbxguShowNotedByCheckedChanged;
        public event EventHandler chkbxguShowVatCheckedChanged;
        public event EventHandler chkbx_SummaryLessD_CheckedChangedEventRaised;
        public event EventHandler chkbx_ScreenNetofDiscount_CheckedChangedEventRaised;
        public event EventHandler chkbx_GuSubtotal_CheckedChangedEventRaised;

        public RDLCReportCompilerView()
        {
            InitializeComponent();
        }
        
        private void btnCompileReport_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnCompileReportClickEventRaised,e);
        }

        private void RDLCReportCompilerView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, RDLCReportCompilerViewLoadEventRaised,e);
        }
 
        private void chk_selectall_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkselectallCheckedChangedEventRaised,e);
        }

        private void chkbox_showVat_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkboxshowVatCheckedChangedEventRaised, e);
        }

        private void chkbox_subtotal_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender,chkboxsubtotalCheckedChangedEventRaised, e);
        }

        private void chkbx_guShowReviewedBy_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbxguShowReviewedByCheckedChangedEventRaised, e);
        }

        private void chkbox_guShowNotedBy_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbxguShowNotedByCheckedChanged, e);
        }

        private void chkbx_guVat_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbxguShowVatCheckedChanged, e);
        }

        private void chkbx_SummaryLessD_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbx_SummaryLessD_CheckedChangedEventRaised, e);
        }

        private void chkbx_ScreenNetofDiscount_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbx_ScreenNetofDiscount_CheckedChangedEventRaised, e);
        }

        private void chkbx_GuSubtotal_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, chkbx_GuSubtotal_CheckedChangedEventRaised, e);
        }
    }
}
