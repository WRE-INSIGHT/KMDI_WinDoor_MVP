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
using System.Linq;
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


        private IPrintQuotePresenter _printQuotePresenter;
        private IScreenAddOnPropertiesUCPresenter _screenAddOnPropertiesUCPresenter;
        private IExchangeRatePresenter _exchangeRatePresenter;
        private IScreenServices _screenService;

        private List<Freedom_ScreenType> _freedomScreenType = new List<Freedom_ScreenType>();
        private List<Freedom_ScreenSize> _freedomScreenSize = new List<Freedom_ScreenSize>();
        private List<PlisseType> _plisseType = new List<PlisseType>();
        private DataTable _screenDT = new DataTable();
        private DataGridView _dgv_Screen;
        private ScreenType screenType;
        private bool sortAscending = true,
                     screenInitialLoad = true;
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


        CommonFunctions commonfunc = new CommonFunctions();
        Panel _pnlAddOns;
        NumericUpDown _screenWidth, _screenHeight, _factor, _discount,_screenqty;
        TextBox _screenitemnum;

        public ScreenPresenter(IScreenView screenView,
                               IPrintQuotePresenter printQuotePresenter,
                               IScreenAddOnPropertiesUCPresenter screenAddOnPropertiesUCPresenter,
                               IExchangeRatePresenter exchangeRatePresenter,
                               IScreenServices screenservices)
        {
            _screenView = screenView;
            _printQuotePresenter = printQuotePresenter;
            _screenAddOnPropertiesUCPresenter = screenAddOnPropertiesUCPresenter;
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

            _pnlAddOns = _screenView.GetPnlAddOns();
            _screenWidth = _screenView.screen_width;
            _screenHeight = _screenView.screen_height;
            _screenqty = _screenView.screen_quantity;
            _factor = _screenView.screen_factor;
            _discount = _screenView.screen_discountpercentage;
            _screenitemnum = _screenView.screen_itemnumber;

        }

        private void _screenView_ScreenView_FormClosingEventRaised(object sender, FormClosingEventArgs e)
        {
            //foreach(DataGridViewRow r in _dgv_Screen.Rows)
            //{
            //    //Console.WriteLine(r.Cells[0].Value + " " + r.Cells[1].Value + " " + r.Cells[2].Value + " " + r.Cells[3].Value + " " + r.Cells[4].Value + " " + r.Cells[5].Value + " " + r.Cells[6].Value + " " + r.Cells[7].Value + " " + r.Cells[8].Value + " " +r.Cells[9].Value + " " + r.Cells[10].Value + " " + r.Cells[11].Value);
            //    MessageBox.Show("Item No_" + r.Cells[0].Value + "Insect Screen_ " + r.Cells[1].Value + "Dimension_ " + r.Cells[2].Value + "WIndoorID_ " + r.Cells[3].Value + " Price_" + r.Cells[4].Value + "QTY_ " + r.Cells[5].Value + "Discount_ " + r.Cells[6].Value + " NetPrice" + r.Cells[7].Value + "ScreenTypeOriginal " + r.Cells[8].Value + " Factor" + r.Cells[9].Value + "PricingDimension " + r.Cells[10].Value + "AddOnsSpecialFactor " + r.Cells[11].Value);
            //}
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
        }

        private void _screenView_dgvScreenColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_mainPresenter.Screen_List.Count != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (sortAscending == true)
                    {
                        DataTable Sortedtable = _screenDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Item No."))
                                                                    .CopyToDataTable();
                        _screenDT.Clear();
                        _screenDT = Sortedtable.AsEnumerable().CopyToDataTable();
                        sortAscending = false;

                        List<IScreenModel> sortedlist = new List<IScreenModel>();

                        sortedlist = _mainPresenter.Screen_List.AsEnumerable().OrderBy(r => r.Screen_ItemNumber).ToList();
                        _mainPresenter.Screen_List.Clear();

                        _mainPresenter.Screen_List.AddRange(sortedlist);
                        
                             
                    }
                    else
                    {
                        DataTable Sortedtable = _screenDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Item No.")).Reverse()
                                                                    .CopyToDataTable();
                        _screenDT.Clear();
                        _screenDT = Sortedtable.AsEnumerable().CopyToDataTable();
                        sortAscending = true;
                    }

                    _dgv_Screen.DataSource = PopulateDgvScreen();
                }
                
            }

        }

        #region Events
        private void _screenView_CellEndEditEventRaised(object sender, EventArgs e)
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
               if (itemnumber == dtrowitem)
               {
                    if (_initialLoop)
                    {
                        try
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
                                                Console.WriteLine(item.Screen_ItemNumber.ToString());
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

                                    }

                                }

                            }
                            #endregion
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

            try
            {
                _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
                _mainPresenter.SetChangesMark();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, Refresh Datagrid, DataGrid DataSource PopulateDgvScreen" + " " + ex.Message);
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
                    #region algo v1
                    var swp = row.ItemArray[0];
                    if (dgv_indices == i)
                    {
                        _screenModel.Screen_ItemNumber = Convert.ToDecimal(_screenView.screen_itemnumber.Text);
                        _screenModel.DeleteItemNumber(Convert.ToDecimal(dgv_value));
                        //_screenDT.Rows.Remove(row);
                        _dgv_Screen.Rows.RemoveAt(dgv_indices);
                        _screenDT.Rows.RemoveAt(dgv_indices);
                        _mainPresenter.Screen_List.RemoveAll(s => s.Screen_ItemNumber == _delScreenRow);

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
                    i++;
                    #endregion
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
                    if (item.Screen_Quantity > 1 )
                    {
                        for(int i = 1; i <= item.Screen_Quantity; i++)
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
                        if(Datarow.Cells[4].Value.ToString() == " - ")
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
                            dec_DiscounPerItem = 1 - (Convert.ToDecimal(  String.Format("{0,0:N2}", Decimal.Parse(str_DiscountPerItem.Replace("%","")) / 100)));
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
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + this + " " + ex.Message);
                MessageBox.Show("Invalid Item Number","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
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


            IScreenAddOnPropertiesUCPresenter addOnsPropUCP = _screenAddOnPropertiesUCPresenter.GetNewInstance(_unityC, _mainPresenter, _screenModel,this);
            UserControl addOnsProp = (UserControl)addOnsPropUCP.GetScreenAddOnPropertiesUCView();
            _pnlAddOns.Controls.Add(addOnsProp);
            addOnsProp.Dock = DockStyle.Fill;
            addOnsProp.BringToFront();
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

                if(item.Screen_Types == ScreenType._NoInsectScreen || item.Screen_Types == ScreenType._UnnecessaryForInsectScreen)
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
                    if(item.Screen_DisplayedDimension == null || item.Screen_DisplayedDimension == " " || item.Screen_DisplayedDimension == "")//new project doesnt need this,you can remove this after weeks or months 
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
            DataTable dt = new DataTable();
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

            return dt;
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
            

            IScreenModel scr = _screenService.AddScreenModel(_screenModel.Screen_ItemNumber,
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


        public IScreenView GetScreenView()
        {
            return _screenView;
        }

        public IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                                  IMainPresenter mainPresenter,
                                                  IScreenModel screenModel,
                                                  IQuotationServices quotationServices,
                                                  IQuotationModel quotationModel,
                                                  IWindoorModel windoorModel
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
            
            
            return screen;
        }






    }
}
