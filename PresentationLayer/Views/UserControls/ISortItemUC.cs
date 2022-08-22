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
        event MouseEventHandler lblItemMouseMoveEventRaised;
        event MouseEventHandler lblItemMouseDownEventRaised;
        event MouseEventHandler lblItemMouseUpEventRaised;
        event EventHandler SortItemUCLoadEventRaised;
        string ItemName { get; set; }
        //string itemWindoorNumber { get; set; }
        string itemDesc { get; set; }
        PictureBox GetPboxItemImage();
        string itemDimension { get; set; }
        UserControl GetSortItem();
    }
}
