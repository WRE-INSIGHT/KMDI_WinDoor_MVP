using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class ScreenView : Form, IScreenView
    {
        public ScreenView()
        {
            InitializeComponent();
        }

        public NumericUpDown screen_width
        {
            get
            {
                return nud_Width;
            }
            set
            {
                nud_Width.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_height
        {
            get
            {
                return nud_Height;
            }
            set
            {
                nud_Height.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_factor
        {
            get
            {
                return nud_Factor;
            }
            set
            {
                nud_Factor.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_discountpercentage
        {
            get
            {
                return nud_Discount;
            }
            set
            {
                nud_Discount.Value = Convert.ToDecimal(value);
            }
        }

        public NumericUpDown screen_quantity
        {
            get
            {
                return nud_Quantity;
            }
            set
            {
                nud_Quantity.Value = Convert.ToInt32(value);
            }
        }

        public TextBox screen_itemnumber
        {
            get
            {
                return txt_ItemNum;
            }
            set
            {
                txt_ItemNum = value;
            }
        }
  
        public event EventHandler ScreenViewLoadEventRaised;
        public event EventHandler btnAddClickEventRaised;
        public event DataGridViewRowPostPaintEventHandler dgvScreenRowPostPaintEventRaised;
        public event EventHandler tsBtnPrintScreenClickEventRaised;
        public event EventHandler cmbbaseColorSelectedValueChangedEventRaised;
        public event EventHandler cmbScreenTypeSelectedValueChangedEventRaised;
        public event EventHandler nudWidthValueChangedEventRaised;
        public event EventHandler nudHeightValueChangedEventRaised;
        public event EventHandler nudFactorValueChangedEventRaised;
        public event EventHandler nudQuantityValueChangedEventRaised;
        public event EventHandler nudSetsValueChangedEventRaised;
        public event EventHandler txtwindoorIDTextChangedEventRaised;
        public event EventHandler tsBtnExchangeRateClickEventRaised;
        public event EventHandler cmbPlisséTypeSelectedIndexChangedEventRaised;
        public event EventHandler deleteToolStripMenuClickEventRaised;
        public event EventHandler rdBtnDoorCheckChangeEventRaised;
        public event EventHandler rdBtnWindowCheckChangeEventRaised;
        public event EventHandler nudPlisseRdValueChangeEventRaise;
        public event EventHandler nudDiscountValueChangeEventRaised;
        public event EventHandler txtItemNumTextChangeEventRaised;
        public event EventHandler cmbFreedomSizeSelectedValueChangedEventRaised;
        public event EventHandler CellEndEditEventRaised;
        
        public void ShowScreemView()
        {
            this.Show();
        }

        public NumericUpDown GetNudTotalPrice()
        {
            return nud_TotalPrice;
        }

        public Panel GetPnlAddOns()
        {
            return pnl_addOns;
        }

        public Label getLblPlisse()
        {
            return lbl_Plissé;
        }

        public ComboBox getCmbPlisse()
        {
            return cmb_PlisséType;
        }

        public DataGridView GetDatagrid()
        {
            return dgv_Screen;
        }

        public NumericUpDown getNudPlisseRd()
        {
            return nud_plissedRd;
        }

        public Label getLblPlisseRd()
        {
            return lbl_plissedRd;
        }

        public ComboBox getCmbFreedom()
        {
            return cmb_freedomSize;
        }
        public TextBox getTxtitemListNumber()
        {
            return txt_ItemNum;
        }

        private void ScreenView_Load(object sender, EventArgs e)
        {
            List<ScreenType> screen = new List<ScreenType>();
            foreach (ScreenType item in ScreenType.GetAll())
            {
                screen.Add(item);
            }            
            cmb_ScreenType.DataSource = screen;

            List<Base_Color> baseColor = new List<Base_Color>();
            foreach (Base_Color item in Base_Color.GetAll())
            {
                baseColor.Add(item);
            }
            cmb_baseColor.DataSource = baseColor;

            List<PlisseType> Plisse = new List<PlisseType>();
            foreach (PlisseType item in PlisseType.GetAll())
            {
                Plisse.Add(item);
            }
            cmb_PlisséType.DataSource = Plisse;

            List<Freedom_ScreenSize> Freedom = new List<Freedom_ScreenSize>();

            foreach(Freedom_ScreenSize item in Freedom_ScreenSize.GetAll())
            {
                Freedom.Add(item);
            }
            cmb_freedomSize.DataSource = Freedom;
                  

            EventHelpers.RaiseEvent(sender, ScreenViewLoadEventRaised, e);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddClickEventRaised, e);
        }

        private void dgv_Screen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            EventHelpers.RaiseDatagridviewRowpostpaintEvent(sender, dgvScreenRowPostPaintEventRaised, e);
        }

        private void tsBtnPrintScreen_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tsBtnPrintScreenClickEventRaised, e);
        }

        private void cmb_ScreenType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbScreenTypeSelectedValueChangedEventRaised, e);
        }

        private void cmb_baseColor_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbbaseColorSelectedValueChangedEventRaised, e);
        }

        private void nud_Width_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudWidthValueChangedEventRaised, e);
        }

        private void nud_Height_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudHeightValueChangedEventRaised, e);
        }

        private void nud_Factor_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudFactorValueChangedEventRaised, e);
        }

        private void nud_Quantity_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudQuantityValueChangedEventRaised, e);
        }

        private void nud_Sets_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudSetsValueChangedEventRaised, e);
        }

        private void txt_windoorID_TextChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, txtwindoorIDTextChangedEventRaised, e);
        }

        private void tsBtnExchangeRate_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, tsBtnExchangeRateClickEventRaised, e);
        }
        private void cmb_PlisséType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbPlisséTypeSelectedIndexChangedEventRaised, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, deleteToolStripMenuClickEventRaised, e);
        }

        private void rdBtn_Door_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, rdBtnDoorCheckChangeEventRaised, e);
        }
        private void rdBtn_Window_CheckedChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, rdBtnWindowCheckChangeEventRaised, e);
        }

        private void nud_plissedRd_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudPlisseRdValueChangeEventRaise, e);
        }

        private void nud_Discount_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudDiscountValueChangeEventRaised, e);
        }

        private void txt_ItemNum_TextChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, txtItemNumTextChangeEventRaised, e);
        }
        private void cmb_freedomSize_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbFreedomSizeSelectedValueChangedEventRaised,e);
        }
        private void nud_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudWidthValueChangedEventRaised, e);
        }
        private void nud_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudHeightValueChangedEventRaised, e);
        }
        private void dgv_Screen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CellEndEditEventRaised, e);
        }
        private void nud_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudQuantityValueChangedEventRaised, e);
        }

        private void nud_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHelpers.RaiseEvent(sender, nudDiscountValueChangeEventRaised, e);
        }
        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {       
            nud_plissedRd.DataBindings.Add(ModelBinding["PlissedRd_Panels"]);
            rdBtn_Window.DataBindings.Add(ModelBinding["Screen_Types_Window"]);
            rdBtn_Door.DataBindings.Add(ModelBinding["Screen_Types_Door"]);
            cmb_baseColor.DataBindings.Add(ModelBinding["Screen_BaseColor"]);
            cmb_ScreenType.DataBindings.Add(ModelBinding["Screen_Types"]);
            cmb_PlisséType.DataBindings.Add(ModelBinding["Screen_PlisséType"]);
            nud_Height.DataBindings.Add(ModelBinding["Screen_Width"]);
            nud_Width.DataBindings.Add(ModelBinding["Screen_Height"]);
            nud_Factor.DataBindings.Add(ModelBinding["Screen_Factor"]);
            nud_Sets.DataBindings.Add(ModelBinding["Screen_Set"]);
            txt_windoorID.DataBindings.Add(ModelBinding["Screen_WindoorID"]);
            nud_Quantity.DataBindings.Add(ModelBinding["Screen_Quantity"]);
            nud_Discount.DataBindings.Add(ModelBinding["DiscountPercentage"]);
            txt_windoorID.DataBindings.Add(ModelBinding["Screen_ItemNumber"]);
            cmb_freedomSize.DataBindings.Add(ModelBinding["Freedom_ScreenSize"]);
        }

        
    }
}
