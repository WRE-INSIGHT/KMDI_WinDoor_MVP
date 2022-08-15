using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

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

       // private SystemProfile_Option _SelectedSystem;
        public string SelectedSystem
        {
            get
            {
                return cmb_SystemOption.Text;
            }

            set
            {
                cmb_SystemOption.Text = value;
            }
        }

        //public bool c70rRadBtn_CheckState
        //{
        //    set
        //    {
        //        rad_c70.Checked = value;
        //    }
        //}

        //public bool premiLineRadBtn_CheckState
        //{
        //    set
        //    {
        //        rad_PremiLine.Checked = value;
        //    }
        //}

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
        public event EventHandler cmbSystemOptionSelectedValueChangedEventRaised;
        //public event EventHandler radbtnCheckChangedEventRaised;

        public void ShowfrmDimension()
        {
            this.ShowDialog();
        }
        private void frmDimensionView_Load(object sender, EventArgs e)
        {
            List<SystemProfile_Option> systemType = new List<SystemProfile_Option>();
            foreach (SystemProfile_Option item in SystemProfile_Option.GetAll())
            {
                systemType.Add(item);
            }
            cmb_SystemOption.DataSource = systemType;
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

        //private void radbtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    EventHelpers.RaiseEvent(sender, radbtnCheckChangedEventRaised, e);
        //}

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

        private void cmb_SystemOption_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbSystemOptionSelectedValueChangedEventRaised, e);
        }
    }
}
