using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IFrameImagerUC: IViewCommon
    {
        int frameID { get; set; }
        bool thisVisible { get; }

        //event PaintEventHandler innerFramePaintEventRaised;
        //event PaintEventHandler outerFramePaintEventRaised;

        Panel GetInnerPanel();
        void InvalidatePanelInner();
        void InvalidateThis();
        void InvalidateThisParent();
        void InvalidateThisParentsParent();
    }
}