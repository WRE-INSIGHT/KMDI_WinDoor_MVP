using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IItemInfoUC : IViewCommon
    {
        bool WD_Selected { get; set; }
        int PboxItemImagerHeight { get; set; }
        event EventHandler ItemInfoUCLoadEventRaised;
        event MouseEventHandler lblItemMouseDoubleClickEventRaised;
        event MouseEventHandler lblItemMouseMoveEventRaised;
        event MouseEventHandler lblItemMouseDownEventRaised;
        event MouseEventHandler lblItemMouseUpEventRaised;
        string ItemName { get; }
        //string ItemDimension { set; }
        //string ItemDesc { set; }
        //Image ItemImage { set; }
        //bool ItemVisibility { set; }
        //DockStyle dok { set; }
        UserControl GetItemInfo();
        void BringToFrontThis();
        //void ThisBinding(Dictionary<string, Binding> windoorModelBinding);
    }
}