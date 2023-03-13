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
    public partial class PDFWaitFormView : Form, IPDFWaitFormView
    {

        public Label GetImagelabel()
        {
            return lbl_image;
        }
        public Label GetPleaseWaitlabel()
        {
            return lbl_Pwait;
        }
        public void ShowPDFwaitFormView(Form parent)
        {
            try
            {
                if (parent != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                        parent.Location.Y + parent.Height / 2 - this.Height / 2);
                }
                else
                {
                    this.StartPosition = FormStartPosition.CenterParent;
                }
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this +" " + ex.Message );
            }
        }
        public void ClosePDFWaitFormView()
        {
            if (lbl_image != null)
            {
                lbl_image.Image.Dispose();
            };
            this.Close();
        }
        public PDFWaitFormView()
        {
            InitializeComponent();
        }
        public event EventHandler PDFWaitFormViewLoadEventRaised;
        private void PDFWaitFormView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, PDFWaitFormViewLoadEventRaised, e);
        }
    }
}

