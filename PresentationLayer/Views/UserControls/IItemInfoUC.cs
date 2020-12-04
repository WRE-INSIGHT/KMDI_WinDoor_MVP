using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IItemInfoUC
    {
        event EventHandler ItemInfoUCLoadEventRaised;
        //string ItemName { set; }
        //string ItemDimension { set; }
        //string ItemDesc { set; }
        //Image ItemImage { set; }
        //bool ItemVisibility { set; }
        //DockStyle dok { set; }
        void BringToFrontThis();
        void ThisBinding(Dictionary<string, Binding> windoorModelBinding);
    }
}