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
