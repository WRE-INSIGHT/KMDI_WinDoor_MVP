using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ISortItemView
    {
        event EventHandler SortItemViewLoadEventRaised;
        event DragEventHandler SortItemDragDropEventRaiseEvent;
        event DragEventHandler SortItemDragEnterEventRaiseEvent;
        event EventHandler btnDeleteClickRaiseEvent;
        void showSortItem();
        Panel GetPnlSortItem();
        Form GetSortItem();
        Button btnDelete();
    }
}