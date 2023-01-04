﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public interface IPP_LouverGallerySetPropertyUC : IViewCommon
    {
        event EventHandler LouverGallerySetPropertyUCLoadEventRaised;
        event EventHandler btnAddLouverClickEventRaised;
        Panel GetPanelBody();
    }
}