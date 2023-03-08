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

        public CheckedListBox GetChecklistBoxIndex()
        {
            return chk_showimagelist;
        }
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

        public event EventHandler BtnCompileReportClickEventRaised;
        public event EventHandler RDLCReportCompilerViewLoadEventRaised;
        public event EventHandler chkselectallCheckedChangedEventRaised;

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
    }
}
