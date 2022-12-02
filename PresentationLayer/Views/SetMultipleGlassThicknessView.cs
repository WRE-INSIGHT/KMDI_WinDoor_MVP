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
    public partial class SetMultipleGlassThicknessView : Form, ISetMultipleGlassThicknessView
    {

        public event EventHandler cmbSelectGlassTypeEventRaised;
        public event EventHandler setMultipleGlassThicknessLoadEventRaised;
        public event EventHandler mouseClickEventRaised;

        public void ShowMultipleThckView()
        {
            this.ShowDialog();
        }
        public SetMultipleGlassThicknessView()
        {
            InitializeComponent();
        }

        public DataGridView Get_DgvGlassList()
        {
            return setGlssThckNssDGV;
        }

        private void SetMultipleGlassThicknessView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, setMultipleGlassThicknessLoadEventRaised, e);
        }

        private void cmb_GlassType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbSelectGlassTypeEventRaised,e);
        }

        private void setGlssThckNssDGV_MouseClick(object sender, MouseEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, mouseClickEventRaised, e);
        }
    }
}
