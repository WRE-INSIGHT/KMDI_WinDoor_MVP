using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public interface IFrameImagerUC: IViewCommon
    {
        int frameID { get; set; }
        bool thisVisible { get; }
        Padding thisPadding { get; set; }

        event EventHandler frameLoadEventRaised;
        event PaintEventHandler outerFramePaintEventRaised;
        
        void AddImagerControl(Control ctrlObj);
        void DeleteImagerControl(UserControl userctrlObj);
    }
}