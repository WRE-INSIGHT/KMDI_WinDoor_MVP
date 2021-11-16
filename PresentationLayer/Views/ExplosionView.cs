using CommonComponents;
using PresentationLayer.CommonMethods;
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
    public partial class ExplosionView : Form, IExplosionView
    {
        public ExplosionView()
        {
            InitializeComponent();
        }

        public event EventHandler ExplosionViewLoadEventRaised;

        CommonFunctions common_func = new CommonFunctions();

        private void ExplosionView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ExplosionViewLoadEventRaised, e);
            dgv_ExplosionMaterialList.Columns[0].Width = 963;
            dgv_ExplosionMaterialList.Columns[1].Width = 60;
            dgv_ExplosionMaterialList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_ExplosionMaterialList.Columns[2].Width = 58;
            dgv_ExplosionMaterialList.Columns[3].Width = 68;
            dgv_ExplosionMaterialList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_ExplosionMaterialList.Columns[4].Width = 98;
            dgv_ExplosionMaterialList.Columns[5].Width = 72;
        }

        public DataGridView Get_DgvExplosionMaterialList()
        {
            return dgv_ExplosionMaterialList;
        }

        public void ShowThisDialog()
        {
            this.ShowDialog();
        }

        private void dgv_ExplosionMaterialList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3) // size
            {
                if (e.Value.ToString().Contains(".0"))
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("N0");
                }
            }
        }

        private void dgv_ExplosionMaterialList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            common_func.rowpostpaint(sender, e);
        }
    }
}
