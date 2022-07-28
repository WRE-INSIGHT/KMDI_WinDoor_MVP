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

        //string ItemName { set; }
        //string ItemDimension { set; }
        //string ItemDesc { set; }
        //Image ItemImage { set; }
        //bool ItemVisibility { set; }
        //DockStyle dok { set; }
        void BringToFrontThis();
        //void ThisBinding(Dictionary<string, Binding> windoorModelBinding);
    }
}