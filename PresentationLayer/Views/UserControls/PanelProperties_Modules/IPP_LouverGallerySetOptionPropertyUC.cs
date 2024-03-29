﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_LouverGallerySetOptionPropertyUC : IViewCommon
    {
        event EventHandler LouverGallerySetOptionPropertyUCLoadEventRaised;
        event EventHandler btnDeleteGallerySetClickEventRaised;
        event EventHandler changeArtNoToolStripMenuItemClickEventRaised;

        string lblGallerySetArtNo { get; set; }
        TextBox GetCmbLouverGalleryArtNo();
    }
}