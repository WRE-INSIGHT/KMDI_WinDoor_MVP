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

        public TextBox GetTboxGlassThickness1()
        {
            return tboxGlassThickness1;
        }
        public TextBox GetTboxGlassThickness2()
        {
            return tboxGlassThickness2;
        }
        public TextBox GetTboxGlassThickness3()
        {
            return tboxGlassThickness3;
        }
        public TextBox GetTboxBetweenTheGlass1()
        {
            return tboxBetweenTheGlass1;
        }
        public TextBox GetTboxBetweenTheGlass2()
        {
            return tboxBetweenTheGlass2;
        }
        public TextBox GetTboxTotalGlassThickness1()
        {
            return tboxTotalGlassThickness;
        }

        //private int _tboxGlassThickness1;
        //public int tboxGlassThickness_1
        //{
        //    get
        //    {
        //        return _tboxGlassThickness1;
        //    }
        //    set
        //    {
        //        _tboxGlassThickness1 = value;
        //        tboxGlassThickness1.Text = Convert.ToInt32(value).ToString();
        //    }
        //}


        //private int _tboxGlassThickness2;
        //public int tboxGlassThickness_2
        //{
        //    get
        //    {
        //        return _tboxGlassThickness2;
        //    }
        //    set
        //    {
        //        _tboxGlassThickness2 = value;
        //        tboxGlassThickness2.Text = Convert.ToInt32(value).ToString();
        //    }
        //}


        //private int _tboxGlassThickness3;
        //public int tboxGlassThickness_3
        //{
        //    get
        //    {
        //        return _tboxGlassThickness3;
        //    }
        //    set
        //    {
        //        _tboxGlassThickness3 = value;
        //        tboxGlassThickness3.Text = Convert.ToInt32(value).ToString();
        //    }
        //}


        //public string tboxBetweenTheGlass_1
        //{
        //    get
        //    {
        //        return tboxBetweenTheGlass1.Text;
        //    }
        //    set
        //    {
        //        tboxBetweenTheGlass1.Text = value;
        //    }
        //}


        //public string tboxBetweenTheGlass_2
        //{
        //    get
        //    {
        //        return tboxBetweenTheGlass2.Text;
        //    }
        //    set
        //    {
        //        tboxBetweenTheGlass2.Text = value;
        //    }
        //}


        //private int _tboxTotalGlassThickness;
        //public int tboxTotalGlassThickness1
        //{
        //    get
        //    {
        //        return _tboxTotalGlassThickness;
        //    }
        //    set
        //    {
        //        _tboxTotalGlassThickness = value;
        //        tboxTotalGlassThickness.Text = Convert.ToInt32(value).ToString();
        //    }
        //}

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

            tboxGlassThickness1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxGlassThickness2.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxGlassThickness3.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbGlassType1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbGlassType2.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbGlassType3.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbColor1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbColor2.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbColor3.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbBetweenTheGlass1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            cmbBetweenTheGlass2.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxBetweenTheGlass1.TextChanged += new EventHandler(OnTextChangeEventRaised);
            tboxBetweenTheGlass2.TextChanged += new EventHandler(OnTextChangeEventRaised);

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
