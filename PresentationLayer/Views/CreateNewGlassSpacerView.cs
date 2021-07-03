using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassSpacerView : Form, ICreateNewGlassSpacerView
    {

        public string tboxGlassSpacerView
        {
            get
            {
                return tboxGlassSpacer.Text;
            }
            set
            {
                tboxGlassSpacer.Text = value;
            }
        }

        public CreateNewGlassSpacerView()
        {
            InitializeComponent();
        }

        public event EventHandler OnCreateNewGlassSpacerViewLoadEventRaised;
        public event EventHandler OnBtnAddGlassSpacerClickEventRaised;
        public event DataGridViewRowPostPaintEventHandler OnDgvGlassSpacerListRowpostpaintEventRaised;

        public void ShowThis()
        {
            this.Show();
        }

        public void CloseThis()
        {
            this.Hide();
        }

        private void CreateNewGlassSpacerView_Load(object sender, System.EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnCreateNewGlassSpacerViewLoadEventRaised, e);
        }

        private void btnAddGlassSpacer_Click(object sender, System.EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, OnBtnAddGlassSpacerClickEventRaised, e);
        }

        private void dgvGlassSpacerList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, OnDgvGlassSpacerListRowpostpaintEventRaised, e);
        }

        public DataGridView GetDgvGlassSpacerList()
        {
            return dgvGlassSpacerList;
        }
    }
}
