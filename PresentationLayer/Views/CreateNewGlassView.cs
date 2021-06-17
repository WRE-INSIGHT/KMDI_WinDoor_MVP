using CommonComponents;
using System;
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

        private int _tboxGlassThickness1;
        public int tboxGlassThickness_1
        {
            get
            {
                return (int)_tboxGlassThickness1;
            }
            set
            {
                _tboxGlassThickness1 = value;
                tboxGlassThickness1.Text = Convert.ToInt32(value).ToString();
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

        public string lblDescriptionView
        {
            set
            {
                lblDescription.Text = value;
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

        public CreateNewGlassView()
        {
            InitializeComponent();

            tboxGlassThickness1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxGlassThickness2.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxGlassThickness3.TextChanged += new EventHandler(OnTextChangeEventRaised);
        }

        private void OnTextChangeEventRaised(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender,GlassThicknessTextChange,e);
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

    }
}
