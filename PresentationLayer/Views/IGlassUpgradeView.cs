using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IGlassUpgradeView
    {
        Label AENameAndPosLbl { get; set; }
        Label ClientAddressLbl { get; set; }
        Label ClientNameLbl { get; set; }
        Label DateLbl { get; set; }
        NumericUpDown DiscountNum { get; set; }
        NumericUpDown GlassAmountNum { get; set; }
        Label QuoteNumberLbl { get; set; }
        NumericUpDown WindowsDoorsNum { get; set; }

        event EventHandler GlassUpgradeView_LoadEventRaised;

        void CloseGlassUpgradeView();
        ComboBox GlassTypeCmb();
        DataGridView GlassUpgradeDGView();
        void ShowGlassUpgradeView();
    }
}