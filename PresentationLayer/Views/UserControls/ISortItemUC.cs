using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface ISortItemUC
    {
        event MouseEventHandler cbItemMouseMoveEventRaised;
        event MouseEventHandler cbItemMouseDownEventRaised;
        event MouseEventHandler cbItemMouseUpEventRaised;
        event EventHandler SortItemUCLoadEventRaised;
        event EventHandler DeleteToolStripButtonClickEventRaised;
        event EventHandler DuplicateToolStripButtonClickEventRaised;

        event EventHandler cbitem_CheckedChangedEventRaised;
        string ItemName { get; set; }
        //string itemWindoorNumber { get; set; }
        string itemDesc { get; set; }
        PictureBox GetPboxItemImage();
        string itemDimension { get; set; }
        bool itemSelected { get; set; }
        UserControl GetSortItem();
    }
}
