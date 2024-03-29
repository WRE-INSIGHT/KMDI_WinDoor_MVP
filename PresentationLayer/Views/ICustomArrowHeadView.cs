﻿using CommonComponents;
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
        event EventHandler CustomArrowHeadViewLoadEventRaised;
        event PaintEventHandler pnl_CustomArrowPaintEventRaised;
        PictureBox GetPbox();

        void ShowCustomArrowHead();
        Panel GetPnlArrowWD();
        Panel GetPnlArrowHT();
        void SetBtnSaveBackColor(Color color);
        void SetLblTotalArrowLength_Text(string totalArrowWd, string totalArrowHt);
        void SetLblTotalArrowLengthHeight_BackColor(Color lbl_heightColor);
        void SetLblTotalArrowLengthWidth_BackColor(Color lbl_widthColor);


        Panel GetPnlCustomArrow();

        decimal Lbl_ArrowHeightLength { get; set; }
        decimal Lbl_ArrowWidthLength { get; set; }


    }
}