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

        public event EventHandler btnCancelClickedEventRaised;
        public event EventHandler btnOKClickedEventRaised;
        public event EventHandler frmDimensionLoadEventRaised;

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
            EventHelpers.RaiseEvent(this, btnOKClickedEventRaised, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, btnCancelClickedEventRaised, e);
        }

        public void ClosefrmDimension()
        {
            this.Hide();
        }
    }
}
