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


        public int cmbSelectedindex
        {
            set
            {
                cmbBetweenTheGlass1.SelectedIndex = value;
                cmbBetweenTheGlass2.SelectedIndex = value;
                cmbColor1.SelectedIndex = value;
                cmbColor2.SelectedIndex = value;
                cmbColor3.SelectedIndex = value;
                cmbGlassType1.SelectedIndex = value;
                cmbGlassType2.SelectedIndex = value;
                cmbGlassType3.SelectedIndex = value;

            }
        }


        public string cmbGlassType_1
        {
            get
            {
                return cmbGlassType1.Text;
            }
            set
            {
                cmbGlassType1.SelectedValue = value;
            }

        }

        public string cmbGlassType_2
        {
            get
            {
                return cmbGlassType2.Text;
            }
            set
            {
                cmbGlassType2.SelectedValue = value;
            }

        }

        public string cmbGlassType_3
        {
            get
            {
                return cmbGlassType3.Text;
            }
            set
            {
                cmbGlassType3.SelectedValue = value;
            }

        }

        public string cmbColor_1
        {
            get
            {
                return cmbColor1.Text;
            }
            set
            {
                cmbColor1.SelectedValue = value;
            }
        }

        public string cmbColor_2
        {
            get
            {
                return cmbColor2.Text;
            }
            set
            {
                cmbColor2.SelectedValue = value;
            }
        }

        public string cmbColor_3
        {
            get
            {
                return cmbColor3.Text;
            }
            set
            {
                cmbColor3.SelectedValue = value;
            }
        }

        public string cmbBetweenTheGlass_1
        {
            get
            {
                return cmbBetweenTheGlass1.Text;
            }
            set
            {
                cmbBetweenTheGlass1.SelectedValue = value;
            }
        }

        public string cmbBetweenTheGlass_2
        {
            get
            {
                return cmbBetweenTheGlass2.Text;
            }
            set
            {
                cmbBetweenTheGlass2.SelectedValue = value;
            }
        }

        public NumericUpDown GetNudGlassThickness1()
        {
            return nudGlassThickness1;
        }
        public NumericUpDown GetNudGlassThickness2()
        {
            return nudGlassThickness2;
        }
        public NumericUpDown GetNudGlassThickness3()
        {
            return nudGlassThickness3;
        }
        public NumericUpDown GetNudBetweenTheGlass1()
        {
            return nudBetweenTheGlass1;
        }

        public NumericUpDown GetNudBetweenTheGlass2()
        {
            return nudBetweenTheGlass2;
        }

        public TextBox GetTboxTotalGlassThickness1()
        {
            return tboxTotalGlassThickness;
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
            this.ShowDialog();
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
