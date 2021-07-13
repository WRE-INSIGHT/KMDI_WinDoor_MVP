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
    public partial class ExplosionView : Form, IExplosionView
    {
        public ExplosionView()
        {
            InitializeComponent();
        }

        public event EventHandler ExplosionViewLoadEventRaised;

        private void ExplosionView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ExplosionViewLoadEventRaised, e);
            dgv_ExplosionMaterialList.Columns[0].Width = 963;
            dgv_ExplosionMaterialList.Columns[1].Width = 47;
            dgv_ExplosionMaterialList.Columns[2].Width = 58;
            dgv_ExplosionMaterialList.Columns[3].Width = 68;
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
    }
}
