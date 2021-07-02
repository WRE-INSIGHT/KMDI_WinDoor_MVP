using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassTypeView : Form, ICreateNewGlassTypeView
    {
        public string tboxGlassTypeView
        {
            get
            {
                return tboxGlassType.Text;
            }
            set
            {
                tboxGlassType.Text = value;
            }
        }
            
        public CreateNewGlassTypeView()
        {
            InitializeComponent();
        }

        public event EventHandler OnCreateNewGlassTypeViewLoadEventRaised;
        public event EventHandler OnBtnAddGlassTypeClickEventRaised;

        public void ShowThis()
        {
            this.Show();
        }

        public void CloseThis()
        {
            this.Hide();
        }

        public DataGridView GetDgvGlassTypeList()
        {
            return dgvGlassTypeList;
        }

        private void CreateNewGlassTypeView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnCreateNewGlassTypeViewLoadEventRaised, e);
        }

        private void btnAddGlassType_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnBtnAddGlassTypeClickEventRaised, e);
        }
    }
}
