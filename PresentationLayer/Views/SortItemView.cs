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
        public event DragEventHandler SortItemDragDropEventRaiseEvent;
        public event DragEventHandler SortItemDragEnterEventRaiseEvent;

        public void showSortItem()
        {
            this.Show();
        }

        
        public Panel GetPnlSortItem()
        {
            return pnlSortItem;
        }

        private void SortItemView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemViewLoadEventRaised, e);
        }

        private void pnlSortItem_DragEnter(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, SortItemDragEnterEventRaiseEvent, e);
        }

        private void pnlSortItem_DragDrop(object sender, DragEventArgs e)
        {
            EventHelpers.RaiseDragEvent(sender, SortItemDragDropEventRaiseEvent, e);
        }

        public Form GetSortItem()
        {
            return this;
        }
    }
}
