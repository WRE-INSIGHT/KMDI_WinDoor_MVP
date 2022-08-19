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
    public partial class SortItemView : Form, ISortItemView
    {
        public SortItemView()
        {
            InitializeComponent();
        }

        public event EventHandler SortItemViewLoadEventRaised;

        public void showSortItem()
        {
            this.Show();
        }

        private void SortItemView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemViewLoadEventRaised, e);
        }
        public Panel GetPnlSortItem()
        {
            return pnlSortItem;
        }
    }
}
