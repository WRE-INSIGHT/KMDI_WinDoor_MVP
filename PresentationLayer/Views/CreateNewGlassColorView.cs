using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassColorView : Form, ICreateNewGlassColorView
    {
        public string tboxGlassColorView
        {
            get
            {
                return tboxGlassColor.Text;
            }
            set
            {
                tboxGlassColor.Text = value;
            }
        }
        public CreateNewGlassColorView()
        {
            InitializeComponent();
        }

        public event EventHandler OnCreateNewGlassColorViewLoadEventRaised;
        public event EventHandler OnBtnAddGlassColorClickEventRaised;
        public event DataGridViewRowPostPaintEventHandler DgvGlassColorListRowpostpaintEventRaised;

        public void ShowThis()
        {
            this.Show();
        }

        public void CloseThis()
        {
            this.Hide();
        }

        public DataGridView GetDgvGlassColorList()
        {
            return dgvGlassColorList;
        }

        private void CreateNewGlassColorView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnCreateNewGlassColorViewLoadEventRaised, e);
        }

        private void dgvGlassColorList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, DgvGlassColorListRowpostpaintEventRaised, e);
        }

        private void btnAddGlassColor_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnBtnAddGlassColorClickEventRaised, e);
        }
    }
}
