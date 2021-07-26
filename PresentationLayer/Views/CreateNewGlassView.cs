using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassView : Form, ICreateNewGlassView
    {
        public bool pnlGlassVisible2
        {
            set
            {
                pnlGlass2.Visible = value;
            }
        }

        public bool pnlGlassVisible3
        {
            set
            {
                pnlGlass3.Visible = value;
            }
        }

        public bool pnlTotalGlassVisible
        {
            set
            {
                pnlTotal.Visible = value;
            }
        }


        public bool SpacerVisible
        {
            set
            {
                lblSpacerUnit1.Visible = value;
                lblSpacerUnit2.Visible = value;
                cmbBetweenTheGlass1.Visible = value;
                cmbBetweenTheGlass2.Visible = value;
            }
        }

        public NumericUpDown GlassThickness1
        {
            get
            {
                return nudGlassThickness1;
            }
            set
            {
                nudGlassThickness1.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown GlassThickness2
        {
            get
            {
                return nudGlassThickness2;
            }
            set
            {
                nudGlassThickness2.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown GlassThickness3
        {
            get
            {
                return nudGlassThickness3;
            }
            set
            {
                nudGlassThickness3.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown BetweenTheGlass1
        {
            get
            {
                return nudBetweenTheGlass1;
            }
            set
            {
                nudBetweenTheGlass1.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown BetweenTheGlass2
        {
            get
            {
                return nudBetweenTheGlass2;
            }
            set
            {
                nudBetweenTheGlass2.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown TotalThickness
        {
            get
            {
                return nudTotalGlassThickness;
            }
            set
            {
                nudTotalGlassThickness.Value = Convert.ToDecimal(value);
            }
        }


        public string lblBetweenTheGlass
        {
            set
            {
                lblBetweenTheGlass1.Text = value;
                lblBetweenTheGlass2.Text = value;
            }
        }

        public string lblGlassHeader
        {
            set
            {
                lblGlass.Text = value;
            }
        }


        int crntFormWD;
        public string lblDescriptionView
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                lblDescription.Text = value;
                lblDescription.AutoSize = true;
                lblDescription.MaximumSize = new Size(crntFormWD, 0);
                crntFormWD = this.Width - 100;
            }
        }

        public int GlassViewHeight
        {
            set
            {
                this.Height = value;
            }
        }


        public ComboBox GlassType1()
        {
            return cmbGlassType1;
        }

        public ComboBox GlassType2()
        {
            return cmbGlassType2;
        }

        public ComboBox GlassType3()
        {
            return cmbGlassType3;
        }
        public ComboBox Color1()
        {
            return cmbColor1;
        }

        public ComboBox Color2()
        {
            return cmbColor2;
        }

        public ComboBox Color3()
        {
            return cmbColor3;
        }

        public ComboBox Spacer1()
        {
            return cmbBetweenTheGlass1;
        }

        public ComboBox Spacer2()
        {
            return cmbBetweenTheGlass2;
        }

        public event EventHandler NewGlassViewLoadEventRaised;
        public event EventHandler GlassThicknessTextChange;
        public event EventHandler BtnAddGlassClick;

        public CreateNewGlassView()
        {
            InitializeComponent();
        }

        private void OnTextChangeEventRaised(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, GlassThicknessTextChange, e);
        }


        public void ShowThis()
        {
            this.Show();
        }

        public void CloseThis()
        {
            this.Hide();
        }

        private void CreateNewGlassView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NewGlassViewLoadEventRaised, e);
        }

        private void btnAddGlass_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnAddGlassClick, e);
        }


    }
}
