using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IScreenView : IViewCommon
    {
        NumericUpDown screen_factor { get; set; }
        NumericUpDown screen_height { get; set; }
        NumericUpDown screen_width { get; set; }
        TextBox screen_itemnumber { get; set; }
        NumericUpDown screen_quantity { get; set; }
        NumericUpDown screen_discountpercentage { get; set; }

        string screenViewWindoorID { get; set; }
        event EventHandler ScreenViewLoadEventRaised;
        event EventHandler btnAddClickEventRaised;
        event DataGridViewRowPostPaintEventHandler dgvScreenRowPostPaintEventRaised;
        event EventHandler tsBtnPrintScreenClickEventRaised;
        event EventHandler cmbbaseColorSelectedValueChangedEventRaised;
        event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        event EventHandler nudWidthValueChangedEventRaised;
        event EventHandler nudHeightValueChangedEventRaised;
        event EventHandler nudFactorValueChangedEventRaised;
        event EventHandler nudQuantityValueChangedEventRaised;
        event EventHandler nudSetsValueChangedEventRaised;
        event EventHandler txtwindoorIDTextChangedEventRaised;
        event EventHandler tsBtnExchangeRateClickEventRaised;
        event EventHandler cmbPlisséTypeSelectedIndexChangedEventRaised;
        event EventHandler deleteToolStripMenuClickEventRaised;
        event EventHandler rdBtnDoorCheckChangeEventRaised;
        event EventHandler rdBtnWindowCheckChangeEventRaised;
        event EventHandler nudPlisseRdValueChangeEventRaise;
        event EventHandler nudDiscountValueChangeEventRaised;
        event EventHandler txtItemNumTextChangeEventRaised;
        event EventHandler cmbFreedomSizeSelectedValueChangedEventRaised;
        event EventHandler CellEndEditEventRaised;
        event DataGridViewCellMouseEventHandler dgvScreenColumnHeaderMouseClick;
        event EventHandler dgvScreenCellDoubleClickEventRaised;
        event EventHandler dgvScreenCellClickEventRaised;
        event EventHandler nudWidthEnterEventRaised;
        event EventHandler nudHeightEnterEventRaised;
        event EventHandler nudFactorEnterEventRaised;
        event FormClosingEventHandler ScreenView_FormClosingEventRaised;

        void ShowScreemView();

        NumericUpDown GetNudTotalPrice();
        DataGridView GetDatagrid();
        Panel GetPnlAddOns();
        Label getLblPlisse();
        ComboBox getCmbPlisse();
        NumericUpDown getNudPlisseRd();
        Label getLblPlisseRd();
        TextBox getTxtitemListNumber();
        ComboBox getCmbFreedom();
        NumericUpDown GetNudWidth();

        NumericUpDown GetNudHeight();

        NumericUpDown GetNudFactor();
        NumericUpDown GetNudSets();



    }
}