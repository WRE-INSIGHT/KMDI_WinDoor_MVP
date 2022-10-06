﻿using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IScreenView
    {
        NumericUpDown screen_factor { get; set; }
        NumericUpDown screen_height { get; set; }
        NumericUpDown screen_width { get; set; }

        event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        event EventHandler ScreenViewLoadEventRaised;
        event EventHandler nudWidthValueChangedEventRaised;
        event EventHandler nudHeightValueChangedEventRaised;
        event EventHandler nudFactorValueChangedEventRaised;
        event EventHandler cmbbaseColorSelectedValueChangedEventRaised;

        void ShowScreemView();

        ComboBox GetCmbScreenType();
        ComboBox GetCmbBaseColor();
        NumericUpDown GetNudTotalPrice();
        NumericUpDown GetNudSet();
        NumericUpDown GetNudQuantity();
        DataGridView GetDatagrid();
    }
}