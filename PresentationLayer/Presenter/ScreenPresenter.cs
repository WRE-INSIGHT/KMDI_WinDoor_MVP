using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Screen;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.CommonMethods;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using ServiceLayer.Services.QuotationServices;
using ServiceLayer.Services.ScreenServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class ScreenPresenter : IScreenPresenter
    {
        IScreenView _screenView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;
        private IQuotationServices _quotationServices;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IScreenPartialAdjustmentProperties _screenPartiallAdjustmentProperties;


        private IPrintQuotePresenter _printQuotePresenter;
        private IScreenAddOnPropertiesUCPresenter _screenAddOnPropertiesUCPresenter;
        private IExchangeRatePresenter _exchangeRatePresenter;
        private IScreenServices _screenService;
        private IScreenPartialAdjustmentSelectionPresenter _screenPartialAdjustmentSelection;

        private List<Freedom_ScreenType> _freedomScreenType = new List<Freedom_ScreenType>();
        private List<Freedom_ScreenSize> _freedomScreenSize = new List<Freedom_ScreenSize>();
        private List<PlisseType> _plisseType = new List<PlisseType>();
        private DataTable _screenDT = new DataTable();
        private DataGridView _dgv_Screen;
        private ScreenType screenType;
        private bool sortAscending = true,
                     screenInitialLoad = true,
                     _allowEditToColumns = true,
                     _onLoad = true,
                     _switchIsAddScreen = true;
        private decimal screenDiscountAverage,
                        _Screen_priceXquantiy,
                        _Screen_factor,
                        _Screen_addOnsSpecialFactor
                        ;
        private string _Screen_DimensionFormat,
                       _Screen_UnitPrice,
                       _Screen_Qty,
                       _Screen_Discount,
                       _Screen_NetPrice,
                       _Screen_PricingDimension,
                       _setDesc,
                       centerClosureDesc,
                       _printListPrice
                      ;
        private int tmrLoop = 0;

        DataTable dt; // Data table for populating datagrid view 

        CommonFunctions commonfunc = new CommonFunctions();
        Panel _pnlAddOns;
        NumericUpDown _screenWidth, _screenHeight, _factor, _discount, _screenqty;
        TextBox _screenitemnum;
        CheckBox _chkboxAllowEdit;
        ToolTip _EdittoColumns;
        Timer _setTimerForToolTip;
        ContextMenuStrip _dgvContextMenuStrip;
        ToolStripMenuItem _screenPartialAddItemMenu;

        CheckBox checkbox;
        NumericUpDown numericupdown;
        ComboBox comboBox;


        public ScreenPresenter(IScreenView screenView,
                               IPrintQuotePresenter printQuotePresenter,
                               IScreenAddOnPropertiesUCPresenter screenAddOnPropertiesUCPresenter,
                               IExchangeRatePresenter exchangeRatePresenter,
                               IScreenServices screenservices,
                               IScreenPartialAdjustmentSelectionPresenter screenPartialAdjustmentSelectionPresenter)
        {
            _screenView = screenView;
            _printQuotePresenter = printQuotePresenter;
            _screenAddOnPropertiesUCPresenter = screenAddOnPropertiesUCPresenter;
            _screenPartialAdjustmentSelection = screenPartialAdjustmentSelectionPresenter;
            _exchangeRatePresenter = exchangeRatePresenter;
            _dgv_Screen = _screenView.GetDatagrid();
            _screenService = screenservices;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _screenView.ScreenViewLoadEventRaised += _screenView_ScreenViewLoadEventRaised;
            _screenView.btnAddClickEventRaised += _screenView_btnAddClickEventRaised;
            _screenView.dgvScreenRowPostPaintEventRaised += _screenView_dgvScreenRowPostPaintEventRaised;
            _screenView.tsBtnPrintScreenClickEventRaised += _screenView_tsBtnPrintScreenClickEventRaised;
            _screenView.cmbbaseColorSelectedValueChangedEventRaised += _screenView_cmbbaseColorSelectedValueChangedEventRaised;
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised;
            _screenView.nudWidthValueChangedEventRaised += _screenView_nudWidthValueChangedEventRaised;
            _screenView.nudHeightValueChangedEventRaised += _screenView_nudHeightValueChangedEventRaised;
            _screenView.nudFactorValueChangedEventRaised += _screenView_nudFactorValueChangedEventRaised;
            _screenView.nudQuantityValueChangedEventRaised += _screenView_nudQuantityValueChangedEventRaised;
            _screenView.nudSetsValueChangedEventRaised += _screenView_nudSetsValueChangedEventRaised;
            _screenView.txtwindoorIDTextChangedEventRaised += _screenView_txtwindoorIDTextChangedEventRaised;
            _screenView.tsBtnExchangeRateClickEventRaised += _screenView_tsBtnExchangeRateClickEventRaised;
            _screenView.cmbPlisséTypeSelectedIndexChangedEventRaised += _screenView_cmbPlisséTypeSelectedIndexChangedEventRaised;
            _screenView.deleteToolStripMenuClickEventRaised += _screenView_deleteToolStripMenuClickEventRaised;
            _screenView.rdBtnDoorCheckChangeEventRaised += _screenView_rdBtnDoorCheckChangeEventRaised;
            _screenView.rdBtnWindowCheckChangeEventRaised += _screenView_rdBtnWindowCheckChangeEventRaised;
            _screenView.nudPlisseRdValueChangeEventRaise += _screenView_nudPlisseRdValueChangeEventRaise;
            _screenView.nudDiscountValueChangeEventRaised += _screenView_nudDiscountValueChangeEventRaised;
            _screenView.cmbFreedomSizeSelectedValueChangedEventRaised += _screenView_cmbFreedomSizeSelectedValueChangedEventRaised;
            _screenView.CellEndEditEventRaised += _screenView_CellEndEditEventRaised; 
            _screenView.dgvScreenColumnHeaderMouseClick += _screenView_dgvScreenColumnHeaderMouseClick;
            _screenView.dgvScreenCellDoubleClickEventRaised += _screenView_dgvScreenCellDoubleClickEventRaised;
            _screenView.dgvScreenCellClickEventRaised += _screenView_dgvScreenCellClickEventRaised;
            _screenView.nudFactorEnterEventRaised += _screenView_nudFactorEnterEventRaised;
            _screenView.nudHeightEnterEventRaised += _screenView_nudHeightEnterEventRaised;
            _screenView.nudWidthEnterEventRaised += _screenView_nudWidthEnterEventRaised;
            _screenView.ScreenView_FormClosingEventRaised += _screenView_ScreenView_FormClosingEventRaised;
            _screenView.chkbox_allowEdit_CheckedChangedEventRaised += _screenView_chkbox_allowEdit_CheckedChangedEventRaised;
            _screenView.ScreenView_ResizeEventRaised += _screenView_ScreenView_ResizeEventRaised;
            _screenView.tsb_ScreenAdjustment_ClickEventRaised += _screenView_tsb_ScreenAdjustment_ClickEventRaised;
            _screenView.tsb_Switch_ClickEventRaised += _screenView_tsb_Switch_ClickEventRaised;
            _screenView.addNewItemToolStripMenuItem_ClickEventRaised += _screenView_addNewItemToolStripMenuItem_ClickEventRaised;

            _pnlAddOns = _screenView.GetPnlAddOns();
            _screenWidth = _screenView.screen_width;
            _screenHeight = _screenView.screen_height;
            _screenqty = _screenView.screen_quantity;
            _factor = _screenView.screen_factor;
            _discount = _screenView.screen_discountpercentage;
            _screenitemnum = _screenView.screen_itemnumber;
            _chkboxAllowEdit = _screenView.getCheckBoxAllowEdit();
            _dgvContextMenuStrip = _screenView.GetDgvContextMenuStrip();
            _screenPartialAddItemMenu = _screenView.GetScreenPartialAddItemCMS();

        }

        #region Events
        private void _screenView_addNewItemToolStripMenuItem_ClickEventRaised(object sender, EventArgs e)
        {
            decimal itemNumberBasedOnParentItem = 0, 
                    childNetPrice = 0m,
                    childScreenTotalAmount = 0m;
            bool _addNewItem = false;
            int childqtyCount = 1;
            string title = "",
                   promptext = "",
                   numText = "",
                   setDesc = "";

            if (_dgv_Screen.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in _dgv_Screen.SelectedRows)
                {
                    var itemNumber = row.Cells[0].Value;
                    var itemIndex = row.Cells[0].RowIndex;
                    decimal _deciItemNumber = Convert.ToDecimal(itemNumber);

                    foreach(IScreenPartialAdjustmentProperties item in _mainPresenter.Lst_ScreenPartialAdjustment)
                    {
                        
                        if (_deciItemNumber == item.Screen_ItemNumber)
                        {
                            if (!item.Screen_IsChild)
                            {

                                if (item.Screen_Quantity > 1)
                                {
                                    title = "Quantity";
                                    promptext = "\nAre you sure to add another screen?";
                                    numText = "Input Number of Quantity";
                                }
                                else
                                {
                                    title = "Validate Quantity";
                                    promptext = "Notice: Only 1 Quantity Detected,\nAre you sure to add another screen?";
                                    numText = "Input Number of Quantity";
                                }

                                if (DialogResult.OK == ShowQtyPrompt(title, promptext, numText, ref childqtyCount))
                                {
                                    _addNewItem = true;
                                }
                                else
                                {
                                    _addNewItem = false;
                                }

                                if (_addNewItem)
                                {
                                    PriceNQtyDeduction(item, childqtyCount, ref childNetPrice, ref childScreenTotalAmount);

                                    _deciItemNumber = _deciItemNumber + .1m; // to avoid .1 in ItemNumber

                                    do
                                    {
                                        itemNumberBasedOnParentItem = _deciItemNumber + .1m;
                                        _deciItemNumber = itemNumberBasedOnParentItem;
                                    }

                                    while (IsChildrenItemNumberExit(itemNumberBasedOnParentItem));

                                    long ChildID = ChildIDBasedOnParent(item, itemNumberBasedOnParentItem); // 'item' for finding Parent Screen type

                                    _mainPresenter.Dic_PaScreenID.Add(ChildID, itemNumberBasedOnParentItem); // add  to dic_PaScreenID child Id

                                    IScreenPartialAdjustmentProperties Spap = new ScreenPartialAdjustmentProperties();

                                    Spap.Screen_Parent_ID = item.Screen_id; // used for delete (add qty back)

                                    Spap.Screen_id = ChildID; // primary key 
                                    Spap.Screen_ItemNumber = itemNumberBasedOnParentItem; // child item number
                                    Spap.Screen_WindoorID = item.Screen_WindoorID;

                                    if (item.Screen_Set > 1)
                                    {
                                        if (item.Screen_Description.Contains("(Sets of"))
                                        {
                                            setDesc = " ";
                                        }
                                        else
                                        {
                                            setDesc = " (Sets of " + item.Screen_Set.ToString() + ")";
                                        }
                                    }
                                    else
                                    {
                                        setDesc = " ";
                                    }


                                    Spap.Screen_Description = item.Screen_Description + setDesc;
                                    Spap.Screen_Set = item.Screen_Set;
                                    Spap.Screen_DisplayedDimension = item.Screen_DisplayedDimension;
                                    Spap.Screen_UnitPrice = item.Screen_UnitPrice;
                                    Spap.Screen_Quantity = childqtyCount;
                                    Spap.Screen_NetPrice = childNetPrice;
                                    Spap.Screen_Discount = item.Screen_Discount;
                                    Spap.Screen_TotalAmount = childScreenTotalAmount;
                                    Spap.Screen_Original_Quantity = 0;// child screen original qty is always zero

                                    Spap.Screen_IsChild = true;

                                    _mainPresenter.Lst_ScreenPartialAdjustment.Add(Spap);
                                    Insert_Adjustment_to_DGV(Spap);


                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Screen ID is missing, Choose parent screen for adding new item/s");
                            }
                        }
                    }
                }
                SortScreenPartialAdjustmentList();
                SortScreenDataTableAscending();

                //PopulateDataGridView();

                LoadScreenPartialAdjustmentColumns();

                if (_mainPresenter.Lst_ScreenPartialAdjustment.Count != 0)
                {
                    LoadScreenPartialList();
                }

            }
            
        }

        private void PriceNQtyDeduction(IScreenPartialAdjustmentProperties SPAP,int childQtyCount, ref decimal childNetPrice,ref decimal childScreenTotalAmount)
        {

            decimal newDiscountPercentage = (SPAP.Screen_Discount / 100m);

            int ParentQtyCount = SPAP.Screen_Quantity;

            ParentQtyCount = SPAP.Screen_Quantity - childQtyCount;

            if(ParentQtyCount <= 1)
            {
                ParentQtyCount = 1;
            }

            decimal discount = SPAP.Screen_UnitPrice * newDiscountPercentage;
            decimal Discounted_UnitPrice = (SPAP.Screen_UnitPrice - discount);

            decimal ParentNetPrice = Discounted_UnitPrice * ParentQtyCount;
            decimal ParentScreenTotalAmount = SPAP.Screen_UnitPrice * ParentQtyCount;

            childNetPrice = Discounted_UnitPrice * childQtyCount;
            childScreenTotalAmount = SPAP.Screen_UnitPrice * childQtyCount;

            SPAP.Screen_Quantity = ParentQtyCount; // new screen_quantity
            SPAP.Screen_NetPrice = ParentNetPrice; // new screen netprice
            SPAP.Screen_TotalAmount = ParentScreenTotalAmount; // new screen_total_amount
            

        }
        private void PriceNQtyAddition(long screen_id, ref bool delete)
        {
            bool isChild = false;
            int qtyToAdd = 0;
            long parent_id = 0;

            foreach (IScreenPartialAdjustmentProperties spap in _mainPresenter.Lst_ScreenPartialAdjustment) // searh child screen
            {
                if (screen_id == spap.Screen_id)
                {
                    if (spap.Screen_IsChild)
                    {
                        isChild = true;
                        qtyToAdd = spap.Screen_Quantity;
                        parent_id = spap.Screen_Parent_ID;
                    }

                    break;
                }
            }

            if (isChild)
            {
                foreach (IScreenPartialAdjustmentProperties spap in _mainPresenter.Lst_ScreenPartialAdjustment) // search parent screen
                {
                    if (spap.Screen_id == parent_id)
                    {
                        if (spap.Screen_Type_Revised == null)
                        {
                            delete = true;

                            if (spap.Screen_Quantity < spap.Screen_Original_Quantity)
                            {
                                decimal newDiscountPercentage = (spap.Screen_Discount / 100m);

                                int ParentQtyCount = spap.Screen_Quantity + qtyToAdd;

                                if (ParentQtyCount > spap.Screen_Original_Quantity)// more than original quantity
                                {
                                    ParentQtyCount = spap.Screen_Original_Quantity;
                                }

                                decimal discount = spap.Screen_UnitPrice * newDiscountPercentage;
                                decimal Discounted_UnitPrice = (spap.Screen_UnitPrice - discount);

                                decimal ParentNetPrice = Discounted_UnitPrice * ParentQtyCount;
                                decimal ParentScreenTotalAmount = spap.Screen_UnitPrice * ParentQtyCount;

                                spap.Screen_Quantity = ParentQtyCount; // new screen_quantity
                                spap.Screen_NetPrice = ParentNetPrice; // new screen netprice
                                spap.Screen_TotalAmount = ParentScreenTotalAmount; // new screen_total_amount
                            }

                        }
                        else
                        {
                            MessageBox.Show("Parent screen's already adjusted, Screen_Type_Revised is not Null");
                            delete = false;
                        }
                    }
                }
            }
            else
            {
                //delete Parent and Child Screen
                DialogResult Resdel = MessageBox.Show("Deleting parent screen will also delete succeding child screen/s,\nDo you want to continue? ", "Confirmation", MessageBoxButtons.YesNo);

                if (DialogResult.Yes == Resdel)
                {
                    delete = true;

                    parent_id = screen_id;

                    List<decimal> screenItemNum = new List<decimal>();

                    foreach (IScreenPartialAdjustmentProperties childScreens in _mainPresenter.Lst_ScreenPartialAdjustment)
                    {
                        if (childScreens.Screen_IsChild)
                        {
                            if (childScreens.Screen_Parent_ID == parent_id)
                            {
                                screenItemNum.Add(childScreens.Screen_ItemNumber);// add to list
                            }
                        }
                    }

                    foreach (var itemsToDel in screenItemNum)
                    {
                        _mainPresenter.Lst_ScreenPartialAdjustment.RemoveAll(x => x.Screen_ItemNumber == itemsToDel);// delete
                    }

                }
                else if (DialogResult.No == Resdel)
                {
                    delete = false;
                }

            }
        }



        #region Custom Input Box
        private DialogResult ShowQtyPrompt(string title, string promptText, string numText,ref int value)
        {

            Form form = new Form();
            Label label = new Label();
            Label QtyLabel = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            numericupdown = new NumericUpDown();
            checkbox = new CheckBox();
            comboBox = new ComboBox();

            comboBox.Items.Add("Quantity");
            comboBox.Items.Add("Set");
            comboBox.SelectedIndex = 0;

            checkbox.CheckedChanged += Checkbox_CheckedChanged;

            form.Text = title;
            label.Text = promptText;
            QtyLabel.Text = "No. of Quantity";
            //textBox.Text = value;

            numericupdown.Maximum = decimal.MaxValue;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //positions
            label.SetBounds(9, 20, 372, 13);
            //textBox.SetBounds(12, 45, 372, 20);
            checkbox.SetBounds(190,30,372,20);
            QtyLabel.SetBounds(9, 62, 50, 20);
            comboBox.SetBounds(122, 50, 180, 20); 
            numericupdown.SetBounds(12, 78, 372, 20); // 25
            buttonOk.SetBounds(228, 102, 80, 23); // 25
            buttonCancel.SetBounds(309, 102, 75, 23); // 25

            //anchors and dock
            label.AutoSize = true;
            QtyLabel.AutoSize = true;         
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            checkbox.Anchor = numericupdown.Anchor | AnchorStyles.Right;
            comboBox.Anchor = comboBox.Anchor | AnchorStyles.Right;
            numericupdown.Anchor = numericupdown.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 130);
            //form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.Controls.AddRange(new Control[] { QtyLabel,comboBox, label, checkbox,numericupdown, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            numericupdown.Enabled = false;
            comboBox.Enabled = false;

            comboBox.Visible = false; // false for now change algo

            DialogResult dialogResult = form.ShowDialog();
            //value = textBox.Text;

            try
            {
                value = Convert.ToInt32(numericupdown.Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Display Custom Modal\n" + ex.Message);
            }
           
              
            return dialogResult;
        }   

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox.Checked)
            {
                numericupdown.Enabled = true;
                comboBox.Enabled = true;
            }
            else
            {
                numericupdown.Enabled = false;
                comboBox.Enabled = false;
            }
        }
        #endregion

        private ScreenType GetScreenType(IScreenPartialAdjustmentProperties spap)
        {
            ScreenType xs = null;
            foreach(var item in _mainPresenter.Screen_List)
            {
                if(item.Screen_id == spap.Screen_id)
                {
                    xs = item.Screen_Types;
                }
            }

            return xs;
        }

        private bool IsQtyValidated(long ItemNumber)
        {
            bool isQtyMorethanOne = false;

            foreach(var item in _mainPresenter.Screen_List)
            {
                if(item.Screen_id == ItemNumber)
                {
                    if(item.Screen_Quantity > 1)
                    {
                        isQtyMorethanOne = true;
                        break;
                    }
                }
            }
            return isQtyMorethanOne;
        }


        private long ChildIDBasedOnParent(IScreenPartialAdjustmentProperties SPAP,decimal itemNumberBasedOnParentItem)
        {
            long childID = 0;
            foreach(var mpScreenList in _mainPresenter.Screen_List)
            {
                if(mpScreenList.Screen_id == SPAP.Screen_id)
                {
                    childID = PriKeyGen(mpScreenList.Screen_Types, itemNumberBasedOnParentItem);
                    break;
                }
            }

            return childID; 
        }

        private bool IsChildrenItemNumberExit(decimal itemNum)
        {
            bool itemNumExist = false;

            foreach(IScreenPartialAdjustmentProperties item in _mainPresenter.Lst_ScreenPartialAdjustment)
            {
                if(item.Screen_ItemNumber == itemNum)
                {
                    itemNumExist = true;
                    break;
                }
            }

            return itemNumExist;

        }

        public void Insert_Adjustment_to_DGV(IScreenPartialAdjustmentProperties sdm)
        {         
            #region Populate DataTable for Partiald Adjustment

            DataRow newRow;
            newRow = _screenDT.NewRow();

            string setDesc;

            if (sdm.Screen_Set > 1)
            {
                setDesc = " (Sets of " + sdm.Screen_Set.ToString() + ")";
            }
            else
            {
                setDesc = " ";
            }

            newRow["Item No."] = sdm.Screen_ItemNumber;
            newRow["Window/Door I.D."] = sdm.Screen_WindoorID;
            newRow["Type of Insect Screen"] = sdm.Screen_Description + setDesc;
            newRow["Dimension (mm) \n per panel"] = sdm.Screen_DisplayedDimension;
            newRow["Price"] = sdm.Screen_UnitPrice.ToString("n");
            newRow["Quantity"] = sdm.Screen_Quantity;
            newRow["Net Price"] = sdm.Screen_NetPrice.ToString("n");

            newRow["Rev_Type of Insect Screen"] = DBNull.Value;
            newRow["Rev_Dimension (mm) \n per panel"] = DBNull.Value;
            newRow["Rev_Price"] = DBNull.Value;
            newRow["Rev_Quantity"] = DBNull.Value; 
            newRow["Rev_Discount"] = DBNull.Value;
            newRow["Rev_Net Price"] = DBNull.Value;
            
            newRow["Adjustment"] = DBNull.Value;

            newRow["ScreenType"] =  DBNull.Value;
            newRow["Factor"] =  DBNull.Value;
            newRow["AddOnsSpecialFactor"] =  DBNull.Value;

            _screenDT.Rows.Add(newRow);
            #endregion
        }

        private void _screenView_tsb_Switch_ClickEventRaised(object sender, EventArgs e)
        {
            if (_switchIsAddScreen)
            {
                #region Icon Changer
                _switchIsAddScreen = false;
                _screenView.GetToolStripBtnSwitch().Image = Properties.Resources.RedSwitch;
                _screenView.GetAddBtn().Text = "Update";
                #endregion
                #region Button Visibility
                _screenView.GetToolStripBtnScreenAdjustment().Visible = true;
                _screenPartialAddItemMenu.Visible = true;
                #endregion

                //Load Screen Partial Adjustment Dt Columns
                LoadScreenPartialAdjustmentColumns();

                if (_mainPresenter.Lst_ScreenPartialAdjustment.Count != 0)
                {
                    LoadScreenPartialList();
                }                              
            }
            else
            {
                #region Icon Changer
                _switchIsAddScreen = true;
                _screenView.GetToolStripBtnSwitch().Image = Properties.Resources.GreenSwitch;
                _screenView.GetAddBtn().Text = "Add";
                #endregion
                #region Button Visibility
                _screenView.GetToolStripBtnScreenAdjustment().Visible = false;
                _screenPartialAddItemMenu.Visible = false;
                #endregion

                //Load Screen Dt Columns
                LoadScreenColumns();

                if (_mainPresenter.Screen_List.Count != 0)
                {
                    LoadScreenList();
                }

            }
        }

        private void LoadScreenPartialList()
        {
            foreach(var item in _mainPresenter.Lst_ScreenPartialAdjustment)
            {
                string setDescRevised = " ",adjPriceFormat = " " , discountFormat = " ";

                if (item.Screen_Set > 1)
                {
                    if (item.Screen_Description.Contains("(Sets of"))
                    {
                        _setDesc = " ";
                    }
                    else
                    {
                        _setDesc = " (Sets of " + item.Screen_Set.ToString() + ")";
                    }
                }
                else
                {
                    _setDesc = " ";
                }

                if(item.Screen_Set_Revised > 1)
                {
                    if (item.Screen_Description_Revised.Contains("(Sets of"))
                    {
                        setDescRevised = " ";
                    }
                    else
                    {
                        setDescRevised = " (Sets of " + item.Screen_Set_Revised.ToString() + ")";
                    }
                }
                else
                {
                    setDescRevised = " ";
                }

                if (item.Screen_Adjustment_Price <= -1)
                {
                    adjPriceFormat = "( " + item.Screen_Adjustment_Price.ToString("n").Replace("-", "") + " )";
                }
                else
                {
                    adjPriceFormat = item.Screen_Adjustment_Price.ToString("n");
                }

                discountFormat = item.Screen_Discount_Revised.ToString() + "%";

                _screenDT.Rows.Add(item.Screen_ItemNumber,
                                   item.Screen_WindoorID,
                                   item.Screen_Description + _setDesc,
                                   item.Screen_DisplayedDimension,
                                   item.Screen_UnitPrice.ToString("n"),
                                   item.Screen_Quantity,
                                   item.Screen_NetPrice.ToString("n"),

                                   item.Screen_Description_Revised + setDescRevised,
                                   item.Screen_DisplayedDimes_Revised,
                                   item.Screen_UnitPrice_Revised.ToString("n"),
                                   item.Screen_Quantity_Revised,
                                   discountFormat,
                                   item.Screen_NetPrice_Revised.ToString("n"),

                                   adjPriceFormat, // screen_adjustment_price

                                   item.Screen_Type_Revised,
                                   item.Screen_Factor_Revised,
                                   item.Screen_AddOnsSpecialFactor_Revised
                                   );

                _screenView.GetDatagrid().DataSource = PopulateDgvScreen();

                
            }
        }
        private void LoadScreenList()
        {
            foreach (var item in _mainPresenter.Screen_List)
            {
                if (item.Screen_Set > 1)
                {
                    if (item.Screen_Description.Contains("(Sets of"))
                    {
                        _setDesc = " ";
                    }
                    else
                    {
                        _setDesc = " (Sets of " + item.Screen_Set.ToString() + ")";
                    }
                }
                else
                {
                    _setDesc = " ";
                }

                if (item.Screen_Types == ScreenType._NoInsectScreen || item.Screen_Types == ScreenType._UnnecessaryForInsectScreen)
                {
                    _Screen_DimensionFormat = " - ";
                    _Screen_UnitPrice = " - ";
                    _Screen_Qty = null;
                    _Screen_Discount = " - ";
                    _Screen_NetPrice = " - ";
                    _Screen_factor = 0;
                    _Screen_PricingDimension = " - ";
                    _Screen_addOnsSpecialFactor = 0;
                }
                else
                {
                    if (item.Screen_DisplayedDimension == null || item.Screen_DisplayedDimension == " " || item.Screen_DisplayedDimension == "")//new project doesnt need this,you can remove this after weeks or months 
                    {
                        _Screen_DimensionFormat = item.Screen_Width + " x " + item.Screen_Height;
                        item.Screen_DisplayedDimension = _Screen_DimensionFormat; // populate properties use in compiler
                    }
                    else
                    {
                        _Screen_DimensionFormat = item.Screen_DisplayedDimension;
                    }

                    _Screen_UnitPrice = item.Screen_UnitPrice.ToString("n");
                    _Screen_Qty = item.Screen_Quantity.ToString();
                    _Screen_Discount = Convert.ToString(item.Screen_Discount) + "%";
                    _Screen_NetPrice = item.Screen_NetPrice.ToString("n");
                    _Screen_factor = item.Screen_Factor;
                    _Screen_PricingDimension = item.Screen_Width + " x " + item.Screen_Height;
                    _Screen_addOnsSpecialFactor = item.Screen_AddOnsSpecialFactor;
                }

                _screenDT.Rows.Add(
                                    item.Screen_ItemNumber,//Convert.ToString(item.Screen_ItemNumber),
                                    item.Screen_Description + _setDesc,
                                    _Screen_DimensionFormat,
                                    item.Screen_WindoorID,
                                    _Screen_UnitPrice,
                                    _Screen_Qty,
                                    _Screen_Discount,
                                    _Screen_NetPrice,
                                    item.Screen_Types,
                                    _Screen_factor,
                                    _Screen_PricingDimension,
                                    _Screen_addOnsSpecialFactor
                                  );

                _screenModel.Screen_ItemNumber = item.Screen_ItemNumber;
                _screenModel.ItemNumberList();
            }
            _screenView.getTxtitemListNumber().Text = Convert.ToString(_screenModel.Screen_NextItemNumber);
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();

        }
        private void LoadScreenPartialAdjustmentColumns()
        {
            #region Load Screen Partial Adjustment Columns
            // clear before adding new columns
            _screenDT.Columns.Clear(); 
            _screenDT.Rows.Clear();
            _dgv_Screen.DataSource = null;
            _dgv_Screen.Refresh();

            //Closed Contract
            _screenDT.Columns.Add(CreateColumn("Item No.", "Item No.", "System.Decimal")); //Item No   
            _screenDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String")); //Window/Door ID  
            _screenDT.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));//Screen Type    
            _screenDT.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));//Dimension                
            _screenDT.Columns.Add(CreateColumn("Price", "Price", "System.String"));//Price  
            _screenDT.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));//Qty 
            _screenDT.Columns.Add(CreateColumn("Net Price", "Net Price", "System.String"));//Net Price  

            //Revised Contract
            _screenDT.Columns.Add(CreateColumn("Rev_Type of Insect Screen", "Type of Insect Screen", "System.String")); //ScreenType  
            _screenDT.Columns.Add(CreateColumn("Rev_Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String")); //Dimension
            _screenDT.Columns.Add(CreateColumn("Rev_Price", "Price", "System.String"));//Price  
            _screenDT.Columns.Add(CreateColumn("Rev_Quantity", "Quantity", "System.Int32"));//Qty  
            _screenDT.Columns.Add(CreateColumn("Rev_Discount", "Discount", "System.String"));//Discount  
            _screenDT.Columns.Add(CreateColumn("Rev_Net Price", "Net Price", "System.String"));//Net Price  

            //Adjustment
            _screenDT.Columns.Add(CreateColumn("Adjustment", "Adjustment", "System.String"));  

            //Additional Info *Hidden
            _screenDT.Columns.Add(CreateColumn("ScreenType", "ScreenType", "System.String"));//Screen Type from model  
            _screenDT.Columns.Add(CreateColumn("Factor", "Factor", "System.Decimal"));//Factor  
            _screenDT.Columns.Add(CreateColumn("AddOnsSpecialFactor", "AddOnsSpecialFactor", "System.Decimal"));//AddOnsSpecialFactor  

            //Set DataSource for DataGrid
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();

            //DatagridView Column size
            _screenView.GetDatagrid().Columns[0].Width = 35;//Item No
            _screenView.GetDatagrid().Columns[1].Width = 150;//Window/Door ID
            _screenView.GetDatagrid().Columns[2].Width = 200;//Screen Type 
            _screenView.GetDatagrid().Columns[3].Width = 80;//Dimension
            _screenView.GetDatagrid().Columns[4].Width = 80;//Price
            _screenView.GetDatagrid().Columns[5].Width = 55;//Qty
            _screenView.GetDatagrid().Columns[6].Width = 80;//Net Price

            _screenView.GetDatagrid().Columns[7].Width = 300;//ScreenType
            _screenView.GetDatagrid().Columns[8].Width = 80;//Dimension
            _screenView.GetDatagrid().Columns[9].Width = 80;//Price
            _screenView.GetDatagrid().Columns[10].Width = 80;//Qty
            _screenView.GetDatagrid().Columns[11].Width = 80;//Discount
            _screenView.GetDatagrid().Columns[12].Width = 80;//Net Price
            _screenView.GetDatagrid().Columns[13].Width = 90;//Adjustment

            _screenView.GetDatagrid().Columns[14].Visible = false; //Screen Type from model
            _screenView.GetDatagrid().Columns[15].Visible = false; //Factor
            _screenView.GetDatagrid().Columns[16].Visible = false; //AddOnsSpecialFactor
            #endregion
            #region DGV Header Color
            // color combi sample , LightBlue & LightGoldenrodYellow ,LightSkyBlue & LightBlue

            Color beforeC = Color.LightSkyBlue,
                  afterC = Color.LightBlue;

            _dgv_Screen.EnableHeadersVisualStyles = false;
            _dgv_Screen.Columns[0].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[1].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[2].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[4].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[3].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[5].HeaderCell.Style.BackColor = beforeC;
            _dgv_Screen.Columns[6].HeaderCell.Style.BackColor = beforeC;

            _dgv_Screen.Columns[7].HeaderCell.Style.BackColor = afterC;
            _dgv_Screen.Columns[8].HeaderCell.Style.BackColor = afterC;
            _dgv_Screen.Columns[9].HeaderCell.Style.BackColor = afterC;
            _dgv_Screen.Columns[10].HeaderCell.Style.BackColor =afterC;
            _dgv_Screen.Columns[11].HeaderCell.Style.BackColor =afterC;
            _dgv_Screen.Columns[12].HeaderCell.Style.BackColor = afterC;
            _dgv_Screen.Columns[13].HeaderCell.Style.BackColor = afterC;



            #endregion
        }
        private void LoadScreenColumns()
        {
            #region Load Screen Columns for Adding
            // clear before adding new columns
            _screenDT.Columns.Clear();
            _screenDT.Rows.Clear();
            _dgv_Screen.DataSource = null;
            _dgv_Screen.Refresh();

            _screenDT.Columns.Add(CreateColumn("Item No.", "Item No.", "System.Decimal"));
            _screenDT.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Price", "Price", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));
            _screenDT.Columns.Add(CreateColumn("Discount", "Discount", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Net Price", "Net Price", "System.String"));
            _screenDT.Columns.Add(CreateColumn("ScreenType", "ScreenType", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Factor", "Factor", "System.Decimal"));
            _screenDT.Columns.Add(CreateColumn("PricingDimension", "PricingDimension", "System.String"));
            _screenDT.Columns.Add(CreateColumn("AddOnsSpecialFactor", "AddOnsSpecialFactor", "System.Decimal"));

            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
            _screenView.GetDatagrid().Columns[0].Width = 35;
            _screenView.GetDatagrid().Columns[1].Width = 330;
            _screenView.GetDatagrid().Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[5].Width = 85;
            _screenView.GetDatagrid().Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[8].Visible = false;
            _screenView.GetDatagrid().Columns[9].Visible = false;
            _screenView.GetDatagrid().Columns[10].Visible = false;
            _screenView.GetDatagrid().Columns[11].Visible = false;

            #endregion
            #region DGV Header Color
            _dgv_Screen.EnableHeadersVisualStyles = true;
            #endregion
        }

        private void _screenView_tsb_ScreenAdjustment_ClickEventRaised(object sender, EventArgs e)
        {
            if (_screenView.GetToolStripBtnScreenAdjustment().Visible)
            {
                IScreenPartialAdjustmentSelectionPresenter partialAdjusmentSelection = _screenPartialAdjustmentSelection.CreateNewInstance(_unityC,
                                                                                                                                           _mainPresenter,
                                                                                                                                           this,
                                                                                                                                           _screenModel,
                                                                                                                                           _screenPartiallAdjustmentProperties);

                partialAdjusmentSelection.GetScreenPartialAdjustmentView().ShowPartialAdjustmentSelectionView();
            }
        }

        private void _screenView_ScreenView_ResizeEventRaised(object sender, EventArgs e)
        {
            // Control Location           
        }

        private void _screenView_chkbox_allowEdit_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                bool _isBreak = false;

                if (_chkboxAllowEdit.Checked)
                {
                    _allowEditToColumns = true;

                    if (!_onLoad)
                    {
                        int _indexCounter = 0;

                        for (int i = 0; i < _screenDT.Rows.Count; i++)
                        {
                            _indexCounter = 0;

                            decimal item = Convert.ToDecimal(_screenDT.Rows[i].ItemArray[0]);

                            foreach (DataRow dtrow in _screenDT.Rows)
                            {
                                decimal comp = Convert.ToDecimal(dtrow.ItemArray[0]);

                                if (i != _indexCounter)
                                {
                                    if (item == comp)
                                    {
                                        MessageBox.Show("Similar Item Number Detected " + "Item #" + item + " ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        _chkboxAllowEdit.Checked = false;
                                        _allowEditToColumns = false;
                                        _isBreak = true;
                                        SelectSimilarItems(item);
                                        break;
                                    }
                                }
                                _indexCounter++;

                            }

                            if (_isBreak)
                            {
                                break;
                            }

                        }

                        #region Update ItemNumber MainPresenter
                        if (!_isBreak)
                        {
                            int _index = 0;

                            foreach (var item in _mainPresenter.Screen_List)
                            {
                                item.Screen_ItemNumber = Convert.ToDecimal(_screenDT.Rows[_index].ItemArray[0]);
                                _index++;
                            }

                            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
                        }
                        #endregion

                    }


                }
                else
                {
                    _allowEditToColumns = false;
                }

                SetReadPropDgvColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Allow_Edit_CheckChange " + this + ex.Message);
            }
        }

        private void SelectSimilarItems(decimal itemNum)
        {
            foreach (DataGridViewRow dtgRow in _dgv_Screen.Rows)
            {
                if (Convert.ToDecimal(dtgRow.Cells[0].Value) == itemNum)
                {
                    dtgRow.Selected = true;
                }
            }
        }

        private void SetReadPropDgvColumn()
        {
            if (!_onLoad)
            {
                if (_allowEditToColumns)
                {
                    foreach (DataGridViewColumn dgvCol in _dgv_Screen.Columns)
                    {
                        dgvCol.ReadOnly = false;
                    }
                }
                else
                {
                    foreach (DataGridViewColumn dgvCol in _dgv_Screen.Columns)
                    {
                        if (!dgvCol.Index.Equals(0))
                        {
                            dgvCol.ReadOnly = true;
                        }
                    }
                }
            }
        }

        private void _screenView_ScreenView_FormClosingEventRaised(object sender, FormClosingEventArgs e)
        {
            foreach (var item in _mainPresenter.Screen_List)
            {
                //check for screen id 
                if (item.Screen_id == 0)
                {
                    item.Screen_id = PriKeyGen(item.Screen_Types, item.Screen_ItemNumber);
                }
            }
        }

        private void _screenView_nudWidthEnterEventRaised(object sender, EventArgs e)
        {
            _screenView.GetNudWidth().Select(0, _screenView.GetNudWidth().Text.Length);
        }

        private void _screenView_nudHeightEnterEventRaised(object sender, EventArgs e)
        {
            _screenView.GetNudHeight().Select(0, _screenView.GetNudHeight().Text.Length);
        }

        private void _screenView_nudFactorEnterEventRaised(object sender, EventArgs e)
        {
            _screenView.GetNudFactor().Select(0, _screenView.GetNudFactor().Text.Length);
        }

        private void _screenView_dgvScreenCellClickEventRaised(object sender, EventArgs e)
        {
            _dgv_Screen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void _screenView_dgvScreenCellDoubleClickEventRaised(object sender, EventArgs e)
        {
            _dgv_Screen.SelectionMode = DataGridViewSelectionMode.CellSelect;

            if (!_allowEditToColumns && !_dgv_Screen.CurrentCell.ColumnIndex.Equals(0))
            {

                _EdittoColumns.Active = true;
                //_EdittoColumns.AutoPopDelay = 4000;
                //_EdittoColumns.InitialDelay = 600;
                _EdittoColumns.IsBalloon = true;
                _EdittoColumns.ToolTipIcon = ToolTipIcon.Info;
                _EdittoColumns.ShowAlways = true;

                //_EdittoColumns.SetToolTip(_chkboxAllowEdit, " Allow Edit to Columns");

                _EdittoColumns.Show("Allow Edit To" + "\n" + "Cell   ", _chkboxAllowEdit, 2000);

                //_setTimerForToolTip.Start();
            }
        }

        private void _setTimerForToolTip_Tick(object sender, EventArgs e)
        {
            //if (tmrLoop == 2)
            //{
            //    _EdittoColumns.Active = false;
            //    //_EdittoColumns.Hide(_chkboxAllowEdit);
            //    _setTimerForToolTip.Stop();
            //    tmrLoop = 0;
            //}
            //else
            //{
            //    tmrLoop++;
            //}
        }

        private void _screenView_dgvScreenColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_mainPresenter.Screen_List.Count != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (sortAscending == true)
                    {
                        SortScreenDataTableAscending();

                        if (_switchIsAddScreen)
                        {
                            #region Sort Screen List
                            SortScreenList();
                            #endregion
                        }
                        else
                        {
                            #region Sort Screen Partial Adjusment List
                            SortScreenPartialAdjustmentList();
                            #endregion
                        }

                    }
                    else
                    {
                        SortScreenDataTableDescending();
                    }

                    _dgv_Screen.DataSource = PopulateDgvScreen();

                }

            }

        }

        #region Sort ScreenDT And List 

        private void SortScreenPartialAdjustmentList()
        {
            #region Sort MainPresenter Partial Adjustment List
            List<IScreenPartialAdjustmentProperties> sortedList = new List<IScreenPartialAdjustmentProperties>();
            sortedList = _mainPresenter.Lst_ScreenPartialAdjustment.AsEnumerable().OrderBy(r => r.Screen_ItemNumber).ToList();
            _mainPresenter.Lst_ScreenPartialAdjustment.Clear();

            _mainPresenter.Lst_ScreenPartialAdjustment.AddRange(sortedList);
            #endregion
        }

        private void SortScreenList()
        {
            #region Sort MainPresenter Screen List
            List<IScreenModel> sortedlist = new List<IScreenModel>();

            sortedlist = _mainPresenter.Screen_List.AsEnumerable().OrderBy(r => r.Screen_ItemNumber).ToList();
            _mainPresenter.Screen_List.Clear();

            _mainPresenter.Screen_List.AddRange(sortedlist);
            #endregion
        }

        private void SortScreenDataTableAscending()
        {
            #region DataTable Ascending
            DataTable Sortedtable = _screenDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Item No."))
                                                                    .CopyToDataTable();
            _screenDT.Clear();
            _screenDT = Sortedtable.AsEnumerable().CopyToDataTable();
            sortAscending = false;
            #endregion
        }
        private void SortScreenDataTableDescending()
        {
            #region DataTable Descending
            DataTable Sortedtable = _screenDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Item No.")).Reverse()
                                                                    .CopyToDataTable();
            _screenDT.Clear();
            _screenDT = Sortedtable.AsEnumerable().CopyToDataTable();
            sortAscending = true;
            #endregion
        }

        #endregion

        private void _screenView_CellEndEditEventRaised(object sender, EventArgs e)
        {
            try
            {           
                bool _initialLoop = true, 
                    _initialLoopForItemNoEdit = true;
                
                int _rowCountForItemNoEdit = 0;
                
                var currCellVal = _dgv_Screen.CurrentCell.Value;
                var currCell_col = _dgv_Screen.CurrentCell.ColumnIndex;
                var currCell_row = _dgv_Screen.CurrentCell.RowIndex;
                var prev_itemnumber = _screenDT.Rows[currCell_row].ItemArray[0];
                
                _screenDT.Rows[currCell_row][currCell_col] = currCellVal;
                 
                decimal itemnumber = Convert.ToDecimal(_screenDT.Rows[currCell_row].ItemArray[0]);
                
                foreach (DataRow dtrow in _screenDT.Select())
                {
                   decimal dtrowitem = Convert.ToDecimal(dtrow.ItemArray[0]);
                
                    if (_allowEditToColumns)
                    {
                        if (itemnumber == dtrowitem)
                        {
                            if (_initialLoop)
                            {
                                try
                                {
                                    if (_switchIsAddScreen) // tab switch 
                                    {
                
                                        #region itemnumber -> windoorId
                                    if (currCell_col == 0)
                                    {
                                        foreach (var item in _mainPresenter.Screen_List.ToArray())
                                        {
                                            _rowCountForItemNoEdit++;

                                            #region 1st Algo 
                                            if (item.Screen_ItemNumber == Convert.ToDecimal(prev_itemnumber))
                                            {
                                                try
                                                {
                                                    if (_initialLoopForItemNoEdit)
                                                    {
                                                        _rowCountForItemNoEdit = currCell_row;// use for editing item number outside the initial loop

                                                        item.Screen_ItemNumber = Convert.ToDecimal(dtrow.ItemArray[0]);
                                                        Console.WriteLine("New Item Number" + item.Screen_ItemNumber.ToString());

                                                        _screenModel.Screen_ItemNumber = item.Screen_ItemNumber;
                                                        _screenModel.ItemNumberList();
                                                        _screenModel.DeleteItemNumber(Convert.ToDecimal(prev_itemnumber));
                                                        _screenView.getTxtitemListNumber().Text = _screenModel.Screen_NextItemNumber.ToString();

                                                        prev_itemnumber = item.Screen_ItemNumber;
                                                        _initialLoopForItemNoEdit = false;

                                                    }
                                                    else if (!_initialLoopForItemNoEdit)
                                                    {
                                                        item.Screen_ItemNumber += 1;
                                                        prev_itemnumber = item.Screen_ItemNumber;
                                                        _screenDT.Rows[_rowCountForItemNoEdit][currCell_col] = item.Screen_ItemNumber;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Invalid Input: " + " " + ex.Message);
                                                    Console.WriteLine("Error in " + this + " " + ex.Message);
                                                }

                                            }
                                            #endregion
                                        }
                                    }
                                    else if (currCell_col == 1 || currCell_col == 2 || currCell_col == 3)
                                    {
                                        foreach (var item in _mainPresenter.Screen_List.ToArray())
                                        {
                                            if (item.Screen_ItemNumber == Convert.ToDecimal(itemnumber))
                                            {
                                                var new_screenType = dtrow.ItemArray[1].ToString().Trim();
                                                //foreach (var scrtype in ScreenType.GetAll())
                                                //{
                                                //    if (new_screenType == scrtype.DisplayName)
                                                //    {
                                                //        item.Screen_Types = scrtype;                                            
                                                //    }
                                                //}
                                                item.Screen_Description = new_screenType;
                                                item.Screen_DisplayedDimension = dtrow.ItemArray[2].ToString();
                                                item.Screen_WindoorID = dtrow.ItemArray[3].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    #endregion
                
                                        #region listPrice -> netPrice
                                    if (currCell_col == 4 || currCell_col == 5 || currCell_col == 6)//4-list price, 5-Qty, 6-Discount
                                    {
                                        foreach (ScreenType scrtyp in ScreenType.GetAll())
                                        {
                                            string scrType_str = Convert.ToString(scrtyp);
                                            string[] screenSplit_Arr = Convert.ToString(dtrow.ItemArray[1]).Split('(');
                                            //var screenType = screenSplit_Arr[0].TrimEnd();
                                            string screenType = Convert.ToString(dtrow.ItemArray[8]);
                                            if (screenType == scrType_str)
                                            {
                                                _screenModel.FromCellEndEdit = true; 
                                                _screenModel.Screen_Types = scrtyp;

                                                try
                                                {
                                                    _screenModel.Screen_UnitPrice = Convert.ToDecimal(dtrow.ItemArray[4]);
                                                    _screenModel.Screen_Quantity = Convert.ToInt32(dtrow.ItemArray[5]);
                                                    _screenModel.DiscountPercentage = Convert.ToDecimal(dtrow.ItemArray[6].ToString().Trim('%')) / 100m;
                                                    _screenModel.ComputeScreenTotalPrice();

                                                    _screenDT.Rows[currCell_row][4] = _screenModel.Screen_UnitPrice.ToString("n");
                                                    _screenDT.Rows[currCell_row][5] = _screenModel.Screen_Quantity;
                                                    _screenDT.Rows[currCell_row][6] = Convert.ToString(_screenModel.Screen_Discount) + "%";
                                                    _screenDT.Rows[currCell_row][7] = _screenModel.Screen_NetPrice.ToString("n");

                                                    _screenView.screen_discountpercentage.Value = _screenModel.Screen_Discount;
                                                    _screenView.screen_quantity.Value = _screenModel.Screen_Quantity;

                                                    foreach (var item in _mainPresenter.Screen_List.ToArray())
                                                    {
                                                        if (item.Screen_ItemNumber == Convert.ToDecimal(itemnumber))
                                                        {
                                                            item.Screen_UnitPrice = _screenModel.Screen_UnitPrice;
                                                            item.Screen_Quantity = _screenModel.Screen_Quantity;
                                                            item.Screen_Discount = _screenModel.Screen_Discount;
                                                            item.Screen_NetPrice = _screenModel.Screen_NetPrice;
                                                            item.Screen_TotalAmount = _screenModel.Screen_TotalAmount;
                                                            break;
                                                        }
                                                    }

                                                    try
                                                    {
                                                        _screenView.GetDatagrid().DataSource = PopulateDgvScreen();

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Console.WriteLine("Error refresh DataGrid");
                                                    }

                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Invalid Input: " + this + "\n\n Error: " + ex.Message);

                                                }
                                                 _screenModel.FromCellEndEdit = false; // allow screenModel to compute
                                            }

                                        }
                                            _screenModel.ReSelectScreenType(_screenView.GetScreenTypeCmb().SelectedValue.ToString()); // ReSelect ScreenType Every Edit
                                    }
                                    #endregion

                                    }
                                    else
                                    {
                                        //edit screen partial adjustment 
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Cell End Edit " + ex.Message);
                                }
                                _screenModel.Screen_UnitPrice = 0;
                                _screenModel.Screen_Quantity = 0;
                                _screenModel.DiscountPercentage = 0;
                
                                _initialLoop = false;
                
                            }
                        }
                    }      
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cell End edit, Switch Upon Editing" + ex.Message);
            }

            try
            {
                _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
                _mainPresenter.SetChangesMark();
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Error, Refresh Datagrid, DataGrid DataSource PopulateDgvScreen" + " " + ex.Message);
                Console.WriteLine("Error , " + this +  " , Refresh Datagrid, DataGrid DataSource PopulateDgvScreen" + " " + ex.Message );
            }
        }

        private void _screenView_cmbFreedomSizeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Freedom_ScreenSize = (Freedom_ScreenSize)((ComboBox)sender).SelectedValue;
        }

        private void _screenView_nudDiscountValueChangeEventRaised(object sender, EventArgs e)
        {
            _screenModel.DiscountPercentage = ((decimal)((NumericUpDown)sender).Value / 100m);
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_rdBtnWindowCheckChangeEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Types_Door = false;
            _screenModel.Screen_Types_Window = true;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_rdBtnDoorCheckChangeEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Types_Window = false;
            _screenModel.Screen_Types_Door = true;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_deleteToolStripMenuClickEventRaised(object sender, EventArgs e)
        {
            decimal _prev_itemnum = 0;
            decimal _itemnumholder = 0;
            _screenDT.AcceptChanges();
            foreach (DataGridViewRow r in _dgv_Screen.SelectedRows)
            {
                var dgv_value = r.Cells[0].Value;
                var dgv_indices = r.Cells[0].RowIndex;
                decimal _delScreenRow = Convert.ToDecimal(dgv_value);
                int i = 0;
                                 
                foreach (DataRow row in _screenDT.Rows)
                {
                    if (_switchIsAddScreen)
                    {
                        #region Add Screen(delete)
                        bool deleteItem = true,
                            _delscreenPartialAdjustment = false;
                        var swp = row.ItemArray[0];

                        if (dgv_indices == i)
                        {
                            if (_mainPresenter.Dic_PaScreenID.ContainsValue(_delScreenRow))
                            {
                                if (MessageBox.Show("Item # " + _delScreenRow + " Exist in Partial Adjustment, Do you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    _delscreenPartialAdjustment = true;
                                }
                                else
                                {
                                    deleteItem = false;
                                }
                            }
                            else
                            {
                                deleteItem = true;
                                _delscreenPartialAdjustment = false;
                            }

                            if (deleteItem)
                            {
                                _screenModel.Screen_ItemNumber = Convert.ToDecimal(_screenView.screen_itemnumber.Text);
                                _screenModel.DeleteItemNumber(Convert.ToDecimal(dgv_value));
                                //_screenDT.Rows.Remove(row);
                                _dgv_Screen.Rows.RemoveAt(dgv_indices);
                                _screenDT.Rows.RemoveAt(dgv_indices);
                                _mainPresenter.Screen_List.RemoveAll(s => s.Screen_ItemNumber == _delScreenRow); // delete in main presenter list 

                                if (_delscreenPartialAdjustment)
                                {                              
                                    var scp = _mainPresenter.Lst_ScreenPartialAdjustment.FirstOrDefault(x => x.Screen_ItemNumber == _delScreenRow);
                                    _mainPresenter.Dic_PaScreenID.Remove(scp.Screen_id);                                                                                        
                                    _mainPresenter.Lst_ScreenPartialAdjustment.RemoveAll(s => s.Screen_ItemNumber == _delScreenRow); // delete in mainP model list                                
                                }

                                _prev_itemnum = _itemnumholder;
                                var _strippedItemNum = (int)Decimal.Truncate(Convert.ToDecimal(dgv_value));

                                if (_prev_itemnum > _strippedItemNum || _prev_itemnum == 0)
                                {
                                    _itemnumholder = _strippedItemNum;
                                    _screenModel.Screen_NextItemNumber = _itemnumholder;
                                    _screenView.getTxtitemListNumber().Text = Convert.ToString(_screenModel.Screen_NextItemNumber);
                                }
                                _mainPresenter.SetChangesMark();
                                break;
                            }
                        }
                        i++;
                        #endregion
                    }
                    else
                    {
                        #region Screen PartialAdjustment (delete)

                        if (dgv_indices == i)
                        {
                            bool delete = false;

                            var scp = _mainPresenter.Lst_ScreenPartialAdjustment.FirstOrDefault(x => x.Screen_ItemNumber == _delScreenRow);
                            if (_mainPresenter.Dic_PaScreenID.ContainsKey(scp.Screen_id))
                            {
                                PriceNQtyAddition(scp.Screen_id, ref delete);
                                if (delete)
                                {
                                    //_dgv_Screen.Rows.RemoveAt(dgv_indices);
                                    //_screenDT.Rows.RemoveAt(dgv_indices);
                                    _mainPresenter.Dic_PaScreenID.Remove(scp.Screen_id);
                                    _mainPresenter.Lst_ScreenPartialAdjustment.RemoveAll(s => s.Screen_ItemNumber == _delScreenRow);

                                    if (_screenDT.Rows.Count != 0)
                                    {
                                        SortScreenPartialAdjustmentList();
                                        SortScreenDataTableAscending();

                                        PopulateDataGridView();

                                        LoadScreenPartialAdjustmentColumns();
                                    }

                                    if (_mainPresenter.Lst_ScreenPartialAdjustment.Count != 0)
                                    {
                                        LoadScreenPartialList();
                                    }

                                }
                                break;
                            }
                        }
                        i++;
                        #endregion
                    }

                }
               
            }
            _screenDT.AcceptChanges();
            _screenView.screenViewWindoorID = "";
            WindoorIDGetter();
        }

        

        private void _screenView_cmbPlisséTypeSelectedIndexChangedEventRaised(object sender, EventArgs e)
        {
            //plisse and freedom use the same combobox
            if (screenType != ScreenType._Freedom)
            {
                var plisse_Rd = _screenModel.Screen_PlisséType = (PlisseType)((ComboBox)sender).SelectedValue;

                if (plisse_Rd == PlisseType._RD)
                {
                    _screenView.getLblPlisseRd().Text = "Panel/s";
                    _screenView.getNudPlisseRd().Visible = true;
                    _screenView.getLblPlisseRd().Visible = true;
                }
                else if (screenType == ScreenType._Plisse && plisse_Rd == PlisseType._SR)
                {
                    _screenModel.SP_MagnumScreenType_Visibility = true;
                    _screenView.getNudPlisseRd().Visible = false;
                    _screenView.getLblPlisseRd().Visible = false;
                }
                else
                {
                    _screenModel.SP_MagnumScreenType_Visibility = false;
                    _screenView.getNudPlisseRd().Visible = false;
                    _screenView.getLblPlisseRd().Visible = false;
                }
            }
            else
            {
                _screenModel.Freedom_ScreenType = (Freedom_ScreenType)((ComboBox)sender).SelectedValue;
            }
            GetCurrentAmount();
        }

        private void _screenView_tsBtnExchangeRateClickEventRaised(object sender, EventArgs e)
        {
            IExchangeRatePresenter exchangeRate = _exchangeRatePresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel,this);
            exchangeRate.GetExchangeRateView().ShowExchangeRate();
        }

        private void _screenView_txtwindoorIDTextChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_WindoorID = (string)((TextBox)sender).Text;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudSetsValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Set = (int)((NumericUpDown)sender).Value;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudQuantityValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Quantity = (int)((NumericUpDown)sender).Value;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudFactorValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Factor = (decimal)((NumericUpDown)sender).Value;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                _screenModel.Screen_Height = (int)((NumericUpDown)sender).Value;
                _screenModel.ComputeScreenTotalPrice();
                _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in heightValue Loc: " + this + " " + ex.Message);
            }
            
        }

        private void _screenView_nudWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                _screenModel.Screen_Width = (int)((NumericUpDown)sender).Value;
                _screenModel.ComputeScreenTotalPrice();
                _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in widthValue Loc:" + this + " " + ex.Message);             
            }
            
        }

        private void _screenView_nudPlisseRdValueChangeEventRaise(object sender, EventArgs e)
        {
            try
            {
                _screenModel.PlissedRd_Panels = (int)((NumericUpDown)sender).Value;
                GetCurrentAmount();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
            }            
        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            screenType = (ScreenType)((ComboBox)sender).SelectedValue;
            _screenModel.Screen_Types = screenType;

            var plisseType = _screenModel.Screen_PlisséType;

            if (screenType == ScreenType._Plisse || screenType == ScreenType._Freedom)
            {
                if (screenType == ScreenType._Plisse)
                {

                    _screenView.getCmbPlisse().DataSource = _plisseType;

                    #region Visibility false 
                    _screenView.getCmbFreedom().Visible = false;
                    _screenView.getLblPlisseRd().Visible = false;
                    _screenModel.SP_MagnumScreenType_Visibility = false;
                    #endregion

                    #region Visibility True 
                    _screenView.getLblPlisse().Text = "Plissé Type";
                    _screenView.getLblPlisse().Visible = true;
                    _screenView.getCmbPlisse().Visible = true;
                    #endregion

                    if (plisseType == PlisseType._RD)
                    {
                        _screenView.getLblPlisseRd().Text = "Panel/s";
                        _screenView.getNudPlisseRd().Visible = true;
                        _screenView.getLblPlisseRd().Visible = true;                       
                    }
                 
                    if (plisseType == PlisseType._SR)
                    {
                        _screenModel.SP_MagnumScreenType_Visibility = true;
                    }
                    else
                    {
                        _screenModel.SP_MagnumScreenType_Visibility = false;
                    }
                    _screenModel.Screen_6052MilledProfileVisibility = true;
                    _screenModel.Screen_1067PVCboxVisibility = true;
                    _screenModel.Screen_6040MilledProfileVisibility = true;
                    _screenModel.Screen_LandCoverVisibility = true;
                }
                else if (screenType == ScreenType._Freedom)
                {
                    _screenView.getCmbPlisse().DataSource = _freedomScreenType;

                    #region visibility false                           
                    _screenView.getNudPlisseRd().Visible = false;
                    #endregion

                    #region Visibility True 
                    _screenView.getLblPlisse().Text = "Type";
                    _screenView.getLblPlisse().Visible = true;
                    _screenView.getCmbPlisse().Visible = true;
                    _screenView.getCmbFreedom().Location = new System.Drawing.Point(87, 110);
                    _screenView.getLblPlisseRd().Text = "Size";
                    _screenView.getCmbFreedom().Visible = true;
                    _screenView.getLblPlisseRd().Visible = true;

                    _screenModel.Screen_FreedomTotalChangerVisibility = true;
                    #endregion
                   
                }

            }
            else
            {
                _screenModel.SP_MagnumScreenType_Visibility = false;
                _screenView.getLblPlisse().Visible = false;
                _screenView.getCmbPlisse().Visible = false;
                _screenView.getNudPlisseRd().Visible = false;
                _screenView.getLblPlisseRd().Visible = false;
                _screenView.getCmbFreedom().Visible = false;
                _screenModel.Screen_6040MilledProfileVisibility = false;
                _screenModel.Screen_6052MilledProfileVisibility = false;        
                _screenModel.Screen_1067PVCboxVisibility = false;
                _screenModel.Screen_LandCoverVisibility = false;
                _screenModel.Screen_FreedomTotalChangerVisibility = false;


            }

            if (screenType == ScreenType._BuiltInSideroll)
            {
                _screenModel.Screen_6052MilledProfileVisibility = true;
                _screenModel.Screen_1385MilledProfileVisibility = true;
            }
            else
            {
                // condition to prevent closing of add-ons in plisse 
                if (screenType != ScreenType._Plisse)
                {
                    _screenModel.Screen_6052MilledProfileVisibility = false;
                }
                _screenModel.Screen_1385MilledProfileVisibility = false;
            }

            if (screenType == ScreenType._RollUp)
            {
                _screenModel.SpringLoad_Visibility = true;
                _screenModel.Screen_PVCVisibility = true;
            }
            else
            {
                _screenModel.SpringLoad_Visibility = false;
                _screenModel.Screen_PVCVisibility = false;

            }

            if(screenType == ScreenType._Maxxy)
            {
                _screenModel.Screen_373or374MilledProfileVisibility = true;
            }
            else
            {
                _screenModel.Screen_373or374MilledProfileVisibility = false;
            }

            //if (screenType == ScreenType._Magnum)
            //{
            //    _screenModel.SP_MagnumScreenType_Visibility = true;
            //}
            //else
            //{
            //    _screenModel.SP_MagnumScreenType_Visibility = false;
            //}

            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
            _screenModel.ScreenPropAddOnsReset();
        }

        private void _screenView_cmbbaseColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_BaseColor = (Base_Color)((ComboBox)sender).SelectedValue;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_computeTotalNetPriceEventRaised(object sender, EventArgs e)
        {
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_tsBtnPrintScreenClickEventRaised(object sender, EventArgs e)
        {
            if (_screenView.GetToolStripBtnScreenAdjustment().Visible)
            {
                PrintScreenPartialAdjustmentList();
            }
            else
            {
                PrintScreenList();
            }
            
        }

        private void PrintScreenPartialAdjustmentList()
        {
            #region Screen Partial Adjustment List

            #region
        }

        private void PrintScreenList()
        {
            #region Screen List
            DSQuotation _dsq = new DSQuotation();
            /*
            (Name - index)
            Type of Insect Screen [0]
            Dimension(mm) \n per panel [2]
            Window / Door I.D. [3]
            Unit Price[4]
            Quantity [5]
            Screen Item Number [1]
            Discounted price [7]
            Discount Percentage [6]
            */
            try
            {

                var ScreenTotalListPrice = _mainPresenter.Screen_List.Sum(x => x.Screen_TotalAmount);
                foreach (var item in _mainPresenter.Screen_List)
                {
                    //Screen_priceXquantiy = item.Screen_UnitPrice * item.Screen_Quantity;
                    //NetPriceTotal = NetPriceTotal + Screen_priceXquantiy;
                    if (item.Screen_Quantity > 1)
                    {
                        for (int i = 1; i <= item.Screen_Quantity; i++)
                        {
                            screenDiscountAverage = screenDiscountAverage + item.Screen_Discount;
                        }
                    }
                    else if (item.Screen_Quantity == 1)
                    {
                        screenDiscountAverage = screenDiscountAverage + item.Screen_Discount;
                    }
                    else
                    {
                        Console.WriteLine("Zero Quantity Detected");
                    }

                    Console.WriteLine(item.Screen_UnitPrice.ToString());
                    Console.WriteLine(item.Screen_TotalAmount.ToString());

                }

                decimal DiscountPercentage = screenDiscountAverage / _mainPresenter.Screen_List.Sum(y => y.Screen_Quantity);
                Console.WriteLine(DiscountPercentage.ToString());

                if (_screenDT != null)
                {
                    foreach (DataGridViewRow Datarow in _screenView.GetDatagrid().Rows)
                    {
                        if (Datarow.Cells[4].Value.ToString() == " - ")
                        {
                            _printListPrice = "0";
                        }
                        else
                        {
                            _printListPrice = Datarow.Cells[4].Value.ToString();
                        }

                        #region Net of Discount
                        string str_DiscountPerItem = Datarow.Cells[6].Value.ToString();
                        decimal dec_DiscounPerItem = 0;

                        if (str_DiscountPerItem.Contains("%"))
                        {
                            //use for NetPrice 
                            dec_DiscounPerItem = 1 - (Convert.ToDecimal(String.Format("{0,0:N2}", Decimal.Parse(str_DiscountPerItem.Replace("%", "")) / 100)));
                        }
                        else
                        {
                            dec_DiscounPerItem = 0;
                        }

                        #endregion

                        _dsq.dtScreen.Rows.Add(Datarow.Cells[1].Value ?? string.Empty,
                                               Datarow.Cells[2].Value ?? string.Empty,
                                               Datarow.Cells[3].Value ?? string.Empty,
                                               _printListPrice,
                                               Datarow.Cells[5].Value ?? 0,
                                               ScreenTotalListPrice,
                                               Datarow.Cells[0].Value ?? 0,
                                               Datarow.Cells[7].Value ?? 0,
                                               1,
                                               "",
                                               Datarow.Cells[6].Value ?? string.Empty,
                                               "",
                                               DiscountPercentage, //dtDiscountAverage,
                                               dec_DiscounPerItem //dtPerItemDiscountPercentage
                                               );
                    }
                }
                _Screen_priceXquantiy = 0;
                screenDiscountAverage = 0;
                _mainPresenter.printStatus = "ScreenItem";

                IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, _mainPresenter);
                printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtScreen.DefaultView;
                printQuote.GetPrintQuoteView().ShowPrintQuoteView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Screen List Count is 0: ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void _screenView_dgvScreenRowPostPaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //commonfunc.rowpostpaint(sender, e);         
        }

        public void GetCurrentAmount()
        {
            _screenModel.Screen_Height = Convert.ToInt32(_screenView.screen_height.Value);
            _screenModel.Screen_Width = Convert.ToInt32(_screenView.screen_width.Value);
            _screenModel.FromCellEndEdit = false;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
    
        }

        private void _screenView_btnAddClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_switchIsAddScreen)
                {
                    _screenModel.Screen_ItemNumber = Convert.ToDecimal(_screenitemnum.Text);
                    _screenModel.ItemNumberList();
                    _screenView.getTxtitemListNumber().Text = Convert.ToString(_screenModel.Screen_NextItemNumber);

                    if (_screenModel.Screen_ItemNumber != 0)
                    {
                        GetCurrentAmount();
                        _screenDT.Rows.Add(CreateNewRow_ScreenDT());
                        _screenView.screen_quantity.Value = _screenModel.Screen_Quantity;
                        _screenView.screen_discountpercentage.Value = _screenModel.Screen_Discount;
                        _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
                        screenInitialLoad = false;
                        WindoorIDGetter();
                    }
                }
                else
                {
                    _screenModel.ReSelectScreenType(_screenView.GetScreenTypeCmb().SelectedValue.ToString()); // ReSelect ScreenType
                    GetCurrentAmount(); // ReCompute Screen
                    PartialAdjustmentUpdateSelectedScreen();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                MessageBox.Show("Invalid Item Number","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }

        private void PartialAdjustmentUpdateSelectedScreen()
        {
            foreach(DataGridViewRow dgv in _dgv_Screen.SelectedRows)
            {
                int _indxcounter = 0;

                decimal item_num = Convert.ToDecimal(dgv.Cells["Item No."].Value);

                if (_mainPresenter.Dic_PaScreenID.Values.Contains(item_num))
                {
                    foreach (IScreenPartialAdjustmentProperties scp in _mainPresenter.Lst_ScreenPartialAdjustment)
                    {
                        if (scp.Screen_ItemNumber == item_num)
                        {
                            //decimal _adjustedPrice = _screenModel.Screen_UnitPrice - scp.Screen_UnitPrice; // missing qty

                            if (_screenModel.Screen_Set > 1) // current model (computation)
                            {
                                _setDesc = " (Sets of " + _screenModel.Screen_Set.ToString() + ")";
                            }
                            else
                            {
                                _setDesc = " ";
                            }


                            decimal _adjustedPrice = 0;
                            decimal frmSCMTotalAmount = Math.Round(_screenModel.Screen_TotalAmount,1);
                            decimal frmLSTTotalAmount = Math.Round(scp.Screen_TotalAmount, 1);

                            _adjustedPrice = frmSCMTotalAmount - frmLSTTotalAmount;

                            scp.Screen_Type_Revised = _screenModel.Screen_Types;
                            scp.Screen_Description_Revised = _screenModel.Screen_Description + _setDesc;
                            scp.Screen_Set_Revised = _screenModel.Screen_Set;
                            scp.Screen_UnitPrice_Revised = _screenModel.Screen_UnitPrice;
                            scp.Screen_Quantity_Revised = _screenModel.Screen_Quantity;
                            scp.Screen_Discount_Revised = _screenModel.Screen_Discount;
                            scp.Screen_NetPrice_Revised = _screenModel.Screen_NetPrice;
                            scp.Screen_DisplayedDimes_Revised = _screenModel.Screen_DisplayedDimension;
                            scp.Screen_Factor_Revised = _screenModel.Screen_Factor;
                            scp.Screen_AddOnsSpecialFactor_Revised = _screenModel.Screen_AddOnsSpecialFactor;
                            scp.Screen_TotalAmount_Revised = _screenModel.Screen_TotalAmount;
                            scp.Screen_Adjustment_Price = _adjustedPrice;

                            foreach (DataRow dtrow in _screenDT.Select())
                            {
                                decimal dtrowitem = Convert.ToDecimal(dtrow.ItemArray[0]);
                                if (dtrowitem == item_num)
                                {

                                    string discountFormat = scp.Screen_Discount_Revised.ToString() + "%";

                                    _screenDT.Rows[_indxcounter][7] = scp.Screen_Description_Revised;
                                    _screenDT.Rows[_indxcounter][8] = scp.Screen_DisplayedDimes_Revised;
                                    _screenDT.Rows[_indxcounter][9] = scp.Screen_UnitPrice_Revised.ToString("n");
                                    _screenDT.Rows[_indxcounter][10] = scp.Screen_Quantity_Revised;
                                    _screenDT.Rows[_indxcounter][11] = discountFormat;
                                    _screenDT.Rows[_indxcounter][12] = scp.Screen_NetPrice_Revised.ToString("n");

                                    if(scp.Screen_Adjustment_Price <= -1)
                                    {
                                        string adjusPriceFormat = scp.Screen_Adjustment_Price.ToString("n").Replace("-","");
                                        _screenDT.Rows[_indxcounter][13] = "( " + adjusPriceFormat + " )" ;
                                    }
                                    else
                                    {
                                        _screenDT.Rows[_indxcounter][13] = scp.Screen_Adjustment_Price.ToString("n");
                                    }


                                    break;
                                }

                                _indxcounter++;
                            }


                        }
                    }
                }
            }
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
        }

        public async void GetProjectFactor()
        {
            try
            {
                string[] province = _mainPresenter.projectAddress.Split(',');
                decimal value = await _quotationServices.GetFactorByProvince((province[province.Length - 2]).Trim());
                _screenModel.Screen_AddOnsSpecialFactor = value;
                Console.WriteLine(_screenModel.Screen_AddOnsSpecialFactor.ToString() + " Project Factor Based on Location ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this + " " + ex.Message );
            }
                     

        }
        private void _screenView_ScreenViewLoadEventRaised(object sender, System.EventArgs e)
        {
            LoadScreenColumns();

             GetProjectFactor();
            _screenView.GetNudTotalPrice().Maximum = decimal.MaxValue;
            _screenView.GetNudTotalPrice().DecimalPlaces = 2;
            _screenWidth.Maximum = decimal.MaxValue;
            _screenHeight.Maximum = decimal.MaxValue;
            _screenqty.Maximum = int.MaxValue;
            _factor.DecimalPlaces = 1;
            _discount.Value = 30;
            _screenitemnum.Text = "1";
            _screenModel.Screen_ItemNumber = 1;
            _screenModel.Screen_Quantity = 1;
            _screenModel.Screen_Set = 1;
            _screenModel.Screen_ExchangeRate = 64;
            _screenModel.Screen_ExchangeRateAUD = 40;
            _screenModel.PlissedRd_Panels = 1;
            _screenModel.DiscountPercentage = 0.3m;
            _screenModel.Date_Assigned = _mainPresenter.dateAssigned;

            _chkboxAllowEdit.Checked = true;

            WindoorIDGetter(); 
        
            _dgv_Screen.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.Programmatic);

            if (_mainPresenter.Screen_List.Count != 0)
            {
                LoadScreenList();
            }

            foreach (PlisseType item in PlisseType.GetAll())
            {
                _plisseType.Add(item);
            }

            foreach (Freedom_ScreenType item in Freedom_ScreenType.GetAll())
            {
                _freedomScreenType.Add(item);
            }

            _screenPartialAddItemMenu.Visible = false;
             _onLoad = false;
            _EdittoColumns = new ToolTip();
            _setTimerForToolTip = new Timer();

            #region Set Timer Create EventHandler 
            _setTimerForToolTip.Interval = 1000;//1 sec
            _setTimerForToolTip.Tick += _setTimerForToolTip_Tick;
            #endregion

            IScreenAddOnPropertiesUCPresenter addOnsPropUCP = _screenAddOnPropertiesUCPresenter.GetNewInstance(_unityC, _mainPresenter, _screenModel,this);
            UserControl addOnsProp = (UserControl)addOnsPropUCP.GetScreenAddOnPropertiesUCView();
            _pnlAddOns.Controls.Add(addOnsProp);
            addOnsProp.Dock = DockStyle.Fill;
            addOnsProp.BringToFront();
        }

       

        private void WindoorIDGetter()
        {
            try
            {
                _screenView.screenViewWindoorID = ""; 
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if (screenInitialLoad != true)
                    {
                        if (wdm.WD_id == _screenModel.Screen_NextItemNumber)
                        {                       
                            _screenView.screenViewWindoorID = wdm.WD_WindoorNumber + " " + wdm.WD_itemName;
                            break;
                        }
                    }
                    else
                    {
                        _screenView.screenViewWindoorID = wdm.WD_WindoorNumber + " " + wdm.WD_itemName;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getting windoor NAME & NUMBER " + this + ex.Message);
            }

        }

        #endregion

        public DataTable PopulateDgvScreen()
        {
            if (_switchIsAddScreen)
            {
                dt = new DataTable();
                dt.Columns.Add("Item No.", Type.GetType("System.Decimal"));
                dt.Columns.Add("Type of Insect Screen", Type.GetType("System.String"));
                dt.Columns.Add("Dimension (mm) \n per panel", Type.GetType("System.String"));
                dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
                dt.Columns.Add("Price", Type.GetType("System.String"));
                dt.Columns.Add("Quantity", Type.GetType("System.Int32"));
                dt.Columns.Add("Discount", Type.GetType("System.String"));
                dt.Columns.Add("Net Price", Type.GetType("System.String"));
                dt.Columns.Add("ScreenType", Type.GetType("System.String"));
                dt.Columns.Add("Factor", Type.GetType("System.Decimal"));
                dt.Columns.Add("PricingDimension", Type.GetType("System.String"));
                dt.Columns.Add("AddOnsSpecialFactor", Type.GetType("System.Decimal"));


                foreach (DataRow screenDTRow in _screenDT.Rows)
                {
                    dt.Rows.Add(screenDTRow["Item No."],
                                screenDTRow["Type of Insect Screen"],
                                screenDTRow["Dimension (mm) \n per panel"],
                                screenDTRow["Window/Door I.D."],
                                screenDTRow["Price"],
                                screenDTRow["Quantity"],
                                screenDTRow["Discount"],
                                screenDTRow["Net Price"],
                                screenDTRow["ScreenType"],
                                screenDTRow["Factor"],
                                screenDTRow["PricingDimension"],
                                screenDTRow["AddOnsSpecialFactor"]);


                }
            }
            else if(!_switchIsAddScreen)
            {
                dt = new DataTable();

                dt.Columns.Add("Item No.", Type.GetType("System.Decimal"));
                dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
                dt.Columns.Add("Type of Insect Screen", Type.GetType("System.String"));
                dt.Columns.Add("Dimension (mm) \n per panel", Type.GetType("System.String"));
                dt.Columns.Add("Price", Type.GetType("System.String"));
                dt.Columns.Add("Quantity", Type.GetType("System.Int32"));
                dt.Columns.Add("Net Price", Type.GetType("System.String"));

                dt.Columns.Add("Rev_Type of Insect Screen", Type.GetType("System.String"));
                dt.Columns.Add("Rev_Dimension (mm) \n per panel", Type.GetType("System.String"));
                dt.Columns.Add("Rev_Price", Type.GetType("System.String"));
                dt.Columns.Add("Rev_Quantity", Type.GetType("System.Int32"));
                dt.Columns.Add("Rev_Discount", Type.GetType("System.String"));
                dt.Columns.Add("Rev_Net Price", Type.GetType("System.String"));

                dt.Columns.Add("Adjustment", Type.GetType("System.String"));

                dt.Columns.Add("ScreenType", Type.GetType("System.String"));
                dt.Columns.Add("Factor", Type.GetType("System.Decimal"));
                dt.Columns.Add("AddOnsSpecialFactor", Type.GetType("System.Decimal"));

                foreach (DataRow screenDTRow in _screenDT.Rows)
                {
                    dt.Rows.Add(screenDTRow["Item No."],
                                screenDTRow["Window/Door I.D."],
                                screenDTRow["Type of Insect Screen"],
                                screenDTRow["Dimension (mm) \n per panel"],
                                screenDTRow["Price"],
                                screenDTRow["Quantity"],
                                screenDTRow["Net Price"],
                                screenDTRow["Rev_Type of Insect Screen"],
                                screenDTRow["Rev_Dimension (mm) \n per panel"],
                                screenDTRow["Rev_Price"],
                                screenDTRow["Rev_Quantity"],
                                screenDTRow["Rev_Discount"],
                                screenDTRow["Rev_Net Price"],
                                screenDTRow["Adjustment"],
                                screenDTRow["ScreenType"],
                                screenDTRow["Factor"],
                                screenDTRow["AddOnsSpecialFactor"]);
                }

            }
            
                return dt;    
                  
        }

        private long PriKeyGen(ScreenType ScType,decimal itemnum)
        {
            long _priKeyGen = 0;

            string[] screenType = ScType.ToString().Split();

            StringBuilder firstChar = new StringBuilder();

            foreach (string words in screenType)
            {
                if (!String.IsNullOrEmpty(words))
                {
                    firstChar.Append(words[0]);
                }
            }

            string holder = "";
            string itemNumStr = itemnum.ToString();

            if (itemNumStr.Contains("."))
            {
                itemNumStr = itemNumStr.Replace(".", "");
            }

            foreach (char chr in firstChar.ToString())
            {
                holder = holder + GetCharIndex(chr).ToString();
            }

            holder = itemNumStr + holder;

            _priKeyGen = (Convert.ToInt64(holder));

            return _priKeyGen;

        }

        private static int GetCharIndex(char value)
        {
            char upper = char.ToUpper(value);
            if (upper < 'A' || upper > 'Z')
            {
                upper = 'A';
            }

            return (int)upper - (int)'A';
        }

        public DataRow CreateNewRow_ScreenDT()
        {

            DataRow newRow;
            newRow = _screenDT.NewRow();
            string _Screen_Type;

            if (_screenModel.Screen_Set > 1)
            {
                _setDesc = " (Sets of " + _screenModel.Screen_Set.ToString() + ")";
            }
            else
            {
                _setDesc = " ";
            }

            if (_screenModel.Screen_Types == ScreenType._UnnecessaryForInsectScreen || _screenModel.Screen_Types == ScreenType._NoInsectScreen)
            {
                _Screen_DimensionFormat = " - ";
                _Screen_UnitPrice = " - ";
                _Screen_Discount = " - ";
                _Screen_NetPrice = " - ";
                _Screen_factor = 0;
                _Screen_PricingDimension = " - ";
                _Screen_addOnsSpecialFactor = 0;
            }
            else
            {
                _Screen_DimensionFormat = _screenModel.Screen_DisplayedDimension;
                _Screen_UnitPrice = _screenModel.Screen_UnitPrice.ToString("n");
                _Screen_Discount = Convert.ToString(_screenModel.Screen_Discount) + "%";
                _Screen_NetPrice = _screenModel.Screen_NetPrice.ToString("n");
                _Screen_factor = _screenModel.Screen_Factor;
                _Screen_PricingDimension = _screenModel.Screen_Width + " x " + _screenModel.Screen_Height;
                _Screen_addOnsSpecialFactor = _screenModel.Screen_AddOnsSpecialFactor;
            }
            
            newRow["Item No."] = _screenModel.Screen_ItemNumber;
            newRow["Type of Insect Screen"] = _screenModel.Screen_Description  + _setDesc + centerClosureDesc;
            newRow["Dimension (mm) \n per panel"] = _Screen_DimensionFormat;
            newRow["Window/Door I.D."] = _screenModel.Screen_WindoorID;
            newRow["Price"] = _Screen_UnitPrice;

            if(_screenModel.Screen_Quantity == 0)
            {
                newRow["Quantity"] = DBNull.Value;
            }
            else
            {
                newRow["Quantity"] = _screenModel.Screen_Quantity;
            }

            newRow["Discount"] = _Screen_Discount;
            newRow["Net Price"] = _Screen_NetPrice;
            newRow["ScreenType"] = _screenModel.Screen_Types;
            newRow["Factor"] = _Screen_factor;
            newRow["PricingDimension"] = _Screen_PricingDimension;
            newRow["AddOnsSpecialFactor"] = _Screen_addOnsSpecialFactor;
            
            _screenModel.Screen_id = PriKeyGen(_screenModel.Screen_Types,_screenModel.Screen_ItemNumber); // set priKey

            IScreenModel scr = _screenService.AddScreenModel(_screenModel.Screen_id,
                                                             _screenModel.Screen_ItemNumber,
                                                             _screenModel.Screen_Width,
                                                             _screenModel.Screen_Height,
                                                             _screenModel.Screen_Types,
                                                             _screenModel.Screen_WindoorID,
                                                             _screenModel.Screen_UnitPrice,
                                                             _screenModel.Screen_Quantity,
                                                             _screenModel.Screen_Set,
                                                             _screenModel.Screen_Discount,
                                                             _screenModel.Screen_NetPrice,
                                                             _screenModel.Screen_TotalAmount,
                                                             _screenModel.Screen_Description,
                                                             _screenModel.Screen_Factor,
                                                             _screenModel.Screen_AddOnsSpecialFactor,
                                                             _screenModel.Screen_DisplayedDimension);
           
            _mainPresenter.Screen_List.Add(scr);

            return newRow;
        }

        private DataColumn CreateColumn(string columname, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columname;
            col.Caption = caption;
            return col;
        }


        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("PlissedRd_Panels", new Binding("Value", _screenModel, "PlissedRd_Panels", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Built_in_SideRoll_Ver", new Binding("Value", _screenModel, "Built_in_SideRoll_Ver", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Types_Window", new Binding("Checked", _screenModel, "Screen_Types_Window", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Types_Door", new Binding("Checked", _screenModel, "Screen_Types_Door", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_BaseColor", new Binding("Text", _screenModel, "Screen_BaseColor", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Type", new Binding("Text", _screenModel, "Screen_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_PlisséType", new Binding("Text", _screenModel, "Screen_PlisséType", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Width", new Binding("Value", _screenModel, "Screen_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Height", new Binding("Value", _screenModel, "Screen_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Factor", new Binding("Value", _screenModel, "Screen_Factor", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Set", new Binding("Value", _screenModel, "Screen_Set", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_WindoorID", new Binding("Text", _screenModel, "Screen_WindoorID", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Quantity", new Binding("Value", _screenModel, "Screen_Quantity", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("DiscountPercentage", new Binding("Value", _screenModel, "DiscountPercentage", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_ItemNumber", new Binding("Text", _screenModel, "Screen_ItemNumber", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Freedom_ScreenSize", new Binding("Text", _screenModel, "Freedom_ScreenSize", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public void PopulateDataGridView()
        {
            //refresh
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
        }
        public IScreenView GetScreenView()
        {
            return _screenView;
        }

        public IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                                  IMainPresenter mainPresenter,
                                                  IScreenModel screenModel,
                                                  IQuotationServices quotationServices,
                                                  IQuotationModel quotationModel,
                                                  IWindoorModel windoorModel,
                                                  IScreenPartialAdjustmentProperties screenPartiallAdjustmentProperties
                                                  )
        {
            unityC
                    .RegisterType<IScreenView, ScreenView>()
                    .RegisterType<IScreenPresenter, ScreenPresenter>();
            ScreenPresenter screen = unityC.Resolve<ScreenPresenter>();
            screen._unityC = unityC;
            screen._mainPresenter = mainPresenter;
            screen._screenModel = screenModel;
            screen._quotationServices = quotationServices;
            screen._quotationModel = quotationModel;
            screen._windoorModel = windoorModel;
            screen._screenPartiallAdjustmentProperties = screenPartiallAdjustmentProperties;


            return screen;
        }






    }
}
