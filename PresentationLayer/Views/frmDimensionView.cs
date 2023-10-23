using CommonComponents;
using System;
using System.Collections.Generic;
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

        public string SelectedBaseColor
        {
            get
            {
                return cmb_BaseColorOption.Text;
            }

            set
            {
                cmb_BaseColorOption.Text = value;
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

        public Panel GetPanelFrameQty()
        {
            return pnl_FrameQty;
        }

        public NumericUpDown GetNumWidth()
        {
            return numWidth;
        }
        public NumericUpDown GetNumHeigth()
        {
            return numHeight;
        }

        public event EventHandler btnCancelClickedEventRaised;
        public event EventHandler btnOKClickedEventRaised;
        public event EventHandler frmDimensionLoadEventRaised;
        public event EventHandler cmbSystemOptionSelectedValueChangedEventRaised;
        public event EventHandler cmbBaseColorOptionSelectedValueChangedEventRaised;
        public event EventHandler numWidthEnterEventRaised;
        public event EventHandler numHeightEnterEventRaised;
        public event EventHandler nudFrameQtyValueChangedEventRaised;


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

            List<Base_Color> BaseColor = new List<Base_Color>();
            foreach (Base_Color item in Base_Color.GetAll())
            {
                BaseColor.Add(item);
            }
            cmb_BaseColorOption.DataSource = BaseColor;


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

        private void cmb_BaseColorOption_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbBaseColorOptionSelectedValueChangedEventRaised, e);
        }

        private void numWidth_Enter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numWidthEnterEventRaised, e);
        }

        private void numHeight_Enter(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, numHeightEnterEventRaised, e);
        }

        private void nud_FrameQty_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudFrameQtyValueChangedEventRaised, e);
        }
    }
}
