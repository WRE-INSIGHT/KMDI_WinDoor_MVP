using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Views
{
    public partial class MainView : Form, IMainView
    {
        public string Nickname
        {
            set
            {
                tsLbl_Welcome.Text = "Welcome, " + value;
            }
        }

        public string ofd_InitialDirectory
        {
            get
            {
                return openFileDialog1.InitialDirectory;
            }

            set
            {
                openFileDialog1.InitialDirectory = value;
            }
        }

        public bool flp_base_visibility
        {
            get
            {
                return flp_base.Visible;
            }

            set
            {
                flp_base.Visible = value;
            }
        }

        public string mainview_title
        {
            get
            {
                return this.Text;
            }

            set
            {
                this.Text = value;
            }
        }

        public int flp_base_Wd
        {
            get
            {
                return flp_base.Width;
            }

            set
            {
                flp_base.Width = value;
            }
        }

        public int flp_base_Ht
        {
            get
            {
                return flp_base.Height;
            }

            set
            {
                flp_base.Height = value;
            }
        }

        public event EventHandler MainViewLoadEventRaised;
        public event EventHandler MainViewClosingEventRaised;
        public event EventHandler OpenToolStripButtonClickEventRaised;
        public event EventHandler NewFrameButtonClickEventRaised;
        public event EventHandler NewQuotationMenuItemClickEventRaised;

        public MainView()
        {
            InitializeComponent();
        }

        public void ShowMainView()
        {
            this.Show();
        }
        
        private void MainView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, MainViewLoadEventRaised, e);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, MainViewClosingEventRaised, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.WndrDir;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                EventHelpers.RaiseEvent(this, OpenToolStripButtonClickEventRaised, e);
            }
        }

        private void tsBtnNwin_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, NewFrameButtonClickEventRaised, e);
        }

        public Panel GetBasePlatform()
        {
            return flp_base;
        }

        private void QuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, NewQuotationMenuItemClickEventRaised, e);
        }
    }
}
