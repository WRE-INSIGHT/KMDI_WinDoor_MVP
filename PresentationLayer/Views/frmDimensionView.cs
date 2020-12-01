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
    public partial class frmDimensionView : Form, IfrmDimensionView
    {
        public frmDimensionView()
        {
            InitializeComponent();
        }

        public int dimension_height
        {
            get
            {
                return this.Height;
            }

            set
            {
                this.Height = value;
            }
        }

        public int InumHeight
        {
            get
            {
                return (int)numHeight.Value;
            }

            set
            {
                numHeight.Value = value;
            }
        }

        public int InumWidth
        {
            get
            {
                return (int)numWidth.Value;
            }

            set
            {
                numWidth.Value = value;
            }
        }

        public bool c70rRadBtn_CheckState
        {
            set
            {
                rad_c70.Checked = value;
            }
        }

        public bool premiLineRadBtn_CheckState
        {
            set
            {
                rad_PremiLine.Checked = value;
            }
        }

        public int thisHeight
        {
            set
            {
                this.Height = value;
            }
        }

        public bool ThisVisibility
        {
            get
            {
                return this.Visible;
            }

            set
            {
                this.Visible = value;
            }
        }

        public event EventHandler btnCancelClickedEventRaised;
        public event EventHandler btnOKClickedEventRaised;
        public event EventHandler frmDimensionLoadEventRaised;
        public event EventHandler radbtnCheckChangedEventRaised;

        public void ShowfrmDimension()
        {
            this.Show();
        }
        private void frmDimensionView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, frmDimensionLoadEventRaised, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnOKClickedEventRaised, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnCancelClickedEventRaised, e);
        }

        public void ClosefrmDimension()
        {
            this.Hide();
        }

        private void radbtn_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, radbtnCheckChangedEventRaised, e);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
