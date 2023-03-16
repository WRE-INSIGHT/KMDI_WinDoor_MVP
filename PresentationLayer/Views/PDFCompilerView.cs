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
    public partial class PDFCompilerView : Form, IPDFCompilerView
    {

        public event EventHandler changeSyncDirToolStripMenuItemClickEventRaised;
        public event EventHandler btnCompileReportsClickEventRaised;
        public event EventHandler btnCompilePDFClickEventRaised;

        public OpenFileDialog GetFileDialog()
        {
            return openFileDialog1;
        }
        public PDFCompilerView()
        {
            InitializeComponent();
        }

        public void GetPDFCompilerView()
        {
            this.Show();
        }
        public void ClosePDFCompilerView()
        {
            this.Close();
        }

        private void changeSyncDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, changeSyncDirToolStripMenuItemClickEventRaised,e);
        }

        private void btn_CompileReports_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnCompileReportsClickEventRaised ,e);
        }

        private void btn_CompilePDF_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnCompilePDFClickEventRaised ,e );
        }
    }
}
