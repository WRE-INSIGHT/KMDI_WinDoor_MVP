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

        public event EventHandler GlassThicknessListViewLoadEventRaised;

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
    }
}
