using CommonComponents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface ICustomArrowHeadView : IViewCommon
    {
        event EventHandler BtnAddArrowHeadHeightCkickEventRaised;
        event EventHandler BtnAddArrowHeadWidthCkickEventRaised;
        event EventHandler BtnSaveCustomArrowCkickEventRaised;
        void ShowCustomArrowHead();
        Panel GetPnlArrowWD();
        Panel GetPnlArrowHT();
        void SetBtnSaveBackColor(Color color);
        void SetLblTotalCladdingLength_Text(string totalArrowWd, string totalArrowHT);

    }
}