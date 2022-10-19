﻿using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IScreenView : IViewCommon
    {
        NumericUpDown screen_Quantity { get; set; }
        NumericUpDown screen_factor { get; set; }
        NumericUpDown screen_height { get; set; }
        NumericUpDown screen_width { get; set; }
        string screen_windoorID { get; set; }

        event EventHandler ScreenViewLoadEventRaised;
        event EventHandler btnAddClickEventRaised;
        event DataGridViewRowPostPaintEventHandler dgvScreenRowPostPaintEventRaised;
        event EventHandler tsBtnPrintScreenClickEventRaised;
        event EventHandler computeTotalNetPriceEventRaised;

        void ShowScreemView();

        ComboBox GetCmbScreenType();
        ComboBox GetCmbBaseColor();
        NumericUpDown GetNudTotalPrice();
        NumericUpDown GetNudSet();
        NumericUpDown GetNudQuantity();
        DataGridView GetDatagrid();
        Panel GetPnlAddOns();

    }
}