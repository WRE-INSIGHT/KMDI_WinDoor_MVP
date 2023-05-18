using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class GlassThicknessListView : Form, IGlassThicknessListView
    {
        public GlassThicknessListView()
        {
            InitializeComponent();
        }

        public string SearchVal
        {
            get
            {
                return txtbox_search.Text;
            }
            set
            {
                txtbox_search.Text = value;
            }
        }

        public event EventHandler GlassThicknessListViewLoadEventRaised;
        public event DataGridViewRowPostPaintEventHandler DgvGlassThicknessListRowpostpaintEventRaised;
        public event DataGridViewCellEventHandler DgvGlassThicknessListCellDoubleClickEventRaised;
        public event EventHandler txtboxsearchTextChangedEventRaised;

        public DataGridView Get_DgvGlassThicknessList()
        {
            return dgv_GlassThicknessList;
        }

        public void ShowThisDialog()
        {
            this.ShowDialog();
        }

        private void GlassThicknessList_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, GlassThicknessListViewLoadEventRaised, e);
        }

        private void dgv_GlassThicknessList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, DgvGlassThicknessListRowpostpaintEventRaised, e);
        }

        private void dgv_GlassThicknessList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = dgv_GlassThicknessList.Rows[e.RowIndex].Cells["Description"];
            if (cell.Value.ToString() == "Laminated" || cell.Value.ToString() == "Insulated")
            {
                e.CellStyle.Font = new Font("Segoe UI", 10.0f, FontStyle.Bold);
            }
        }

        private void dgv_GlassThicknessList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EventHelpers.RaiseDatagridviewCellEvent(sender, DgvGlassThicknessListCellDoubleClickEventRaised, e);
        }

        public void CloseThisDialog()
        {
            this.Close();
        }

        private void txtbox_search_TextChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender,txtboxsearchTextChangedEventRaised,e);
        }
    }
}
