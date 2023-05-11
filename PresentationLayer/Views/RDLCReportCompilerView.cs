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
        public  SaveFileDialog GetSaveFileDialog()
        {
            return saveFileDialog;
        }
        public Form GetRDLCReportCompilerForm()
        {
            return this;
        }

        public event EventHandler BtnCompileReportClickEventRaised;
        public event EventHandler RDLCReportCompilerViewLoadEventRaised;
        public event EventHandler chkselectallCheckedChangedEventRaised;
        public event EventHandler chkboxshowVatCheckedChangedEventRaised;

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
    }
}
