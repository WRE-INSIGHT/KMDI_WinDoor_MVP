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
        Label ItemDescriptionLbl { get; set; }
        NumericUpDown DiscountNum { get; set; }
        NumericUpDown GlassAmountNum { get; set; }
        Label QuoteNumberLbl { get; set; }
        NumericUpDown WindowsDoorsNum { get; set; }
        TextBox ItemDescriptionTxt { get; set; }
        PictureBox ItemImage { get; set; }
        
        event EventHandler GlassUpgradeView_LoadEventRaised;
        event EventHandler chkbx_ItemList_SelectedValueChangedEventRaised;
        event EventHandler GlassUpgradeView_SizeChangedEventRaised;
        event EventHandler btn_add_ClickEventRaised;
        event EventHandler deleteToolStripMenuItem_ClickEventRaised;
        event DataGridViewCellMouseEventHandler glassUpgradeDGV_ColumnHeaderMouseClickEventRaised;
        event EventHandler glassUpgradeDGV_CellEndEditEventRaised;
        event EventHandler cmb_glassType_SelectedValueChangedEventRaised;
        event DataGridViewCellMouseEventHandler glassUpgradeDGV_CellMouseClickEventRaised;
        event EventHandler chkbx_selectall_CheckedChangedEventRaised;



        void CloseGlassUpgradeView();
        ComboBox GlassTypeCmb();
        CheckedListBox ItemListChkBx();
        DataGridView GlassUpgradeDGView();
        Form GlassUpgraedViewForm();

        Panel ItemDescriptionPnl();
        CheckBox SelectAllItems();
        void ShowGlassUpgradeView();
    }
}