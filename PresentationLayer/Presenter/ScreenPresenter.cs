using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.CommonMethods;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
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

        private IPrintQuotePresenter _printQuotePresenter;
        private IScreenAddOnPropertiesUCPresenter _screenAddOnPropertiesUCPresenter;
        private IExchangeRatePresenter _exchangeRatePresenter;

        private DataTable _screenDT = new DataTable();

        private DataGridView _dgv_Screen;


        CommonFunctions commonfunc = new CommonFunctions();
        Panel _pnlAddOns;
        NumericUpDown _screenWidth, _screenHeight, _factor,_discount;
        TextBox _screenitemnum;

        public ScreenPresenter(IScreenView screenView,
                               IPrintQuotePresenter printQuotePresenter,
                               IScreenAddOnPropertiesUCPresenter screenAddOnPropertiesUCPresenter,
                               IExchangeRatePresenter exchangeRatePresenter)
        {
            _screenView = screenView;
            _printQuotePresenter = printQuotePresenter;
            _screenAddOnPropertiesUCPresenter = screenAddOnPropertiesUCPresenter;
            _exchangeRatePresenter = exchangeRatePresenter;
            _dgv_Screen = _screenView.GetDatagrid();
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
                  

            _pnlAddOns = _screenView.GetPnlAddOns();
            _screenWidth = _screenView.screen_width;
            _screenHeight = _screenView.screen_height;
            _factor = _screenView.screen_factor;
            _discount = _screenView.screen_discountpercentage;
            _screenitemnum = _screenView.screen_itemnumber;

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

            foreach (DataGridViewRow r in _dgv_Screen.SelectedRows)
            {
                var dgv_value = r.Cells[0].Value;
                var dgv_indices = r.Cells[0].RowIndex;
                int i = 0;
                foreach (DataRow row in _screenDT.Select())
                {               
                    var swp = row.ItemArray[0];
                    if (dgv_indices == i)
                    {
                        _screenModel.Screen_ItemNumber = Convert.ToDecimal(_screenView.screen_itemnumber.Text);
                        _screenModel.DeleteItemNumber(Convert.ToDecimal(dgv_value));
                        _dgv_Screen.Rows.RemoveAt(dgv_indices);
                        _screenDT.Rows.RemoveAt(dgv_indices);

                        _prev_itemnum = _itemnumholder;
                        var _strippedItemNum = (int)Decimal.Truncate(Convert.ToDecimal(dgv_value));

                        if (_prev_itemnum > _strippedItemNum || _prev_itemnum == 0)
                        {
                            _itemnumholder = _strippedItemNum;
                            _screenModel.Screen_NextItemNumber = _itemnumholder;
                            _screenView.getTxtitemListNumber().Text = Convert.ToString(_screenModel.Screen_NextItemNumber);
                        }
                        break;
                    }
                    i++;               
                }
            }
            
        }

        #region Events
        private void _screenView_cmbPlisséTypeSelectedIndexChangedEventRaised(object sender, EventArgs e)
        {
           var plisse_Rd =  _screenModel.Screen_PlisséType = (PlisseType)((ComboBox)sender).SelectedValue;

            if(plisse_Rd == PlisseType._RD)
            {
                _screenView.getNudPlisseRd().Visible = true;
                _screenView.getLblPlisseRd().Visible = true;
            }
            else
            {
                _screenView.getNudPlisseRd().Visible = false;
                _screenView.getLblPlisseRd().Visible = false;
            }
        }

        private void _screenView_tsBtnExchangeRateClickEventRaised(object sender, EventArgs e)
        {
            IExchangeRatePresenter exchangeRate = _exchangeRatePresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel);
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
            _screenModel.Screen_Height = (int)((NumericUpDown)sender).Value;
            _screenModel.ComputeScreenTotalPrice();
           _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Width = (int)((NumericUpDown)sender).Value;
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_nudPlisseRdValueChangeEventRaise(object sender, EventArgs e)
        {
            _screenModel.PlissedRd_Panels = (int)((NumericUpDown)sender).Value;
        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ScreenType screenType = (ScreenType)((ComboBox)sender).SelectedValue;
            _screenModel.Screen_Types = screenType;

            var plisseType = _screenModel.Screen_PlisséType;

            if (screenType == ScreenType._Plisse)
            {
                _screenView.getLblPlisse().Visible = true;
                _screenView.getCmbPlisse().Visible = true;

                if(plisseType == PlisseType._RD)
                {
                    _screenView.getNudPlisseRd().Visible = true;
                    _screenView.getLblPlisseRd().Visible = true;
                }
            }
            else
            {
                _screenView.getLblPlisse().Visible = false;
                _screenView.getCmbPlisse().Visible = false;
                _screenView.getNudPlisseRd().Visible = false;
                _screenView.getLblPlisseRd().Visible = false;
            }


            if (screenType == ScreenType._RollUp)
            {                
                _screenModel.SpringLoad_Visibility = true;                              
            }
            else
            {
                _screenModel.SpringLoad_Visibility = false;
            }

            if(screenType == ScreenType._Magnum)
            {
                _screenModel.SP_MagnumScreenType_Visibility = true;
            }
            else
            {
                _screenModel.SP_MagnumScreenType_Visibility = false;
            }


            _screenModel.ComputeScreenTotalPrice();
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

            if (_screenDT != null)
            {
                foreach (DataGridViewRow Datarow in _screenView.GetDatagrid().Rows)
                {
                    _dsq.dtScreen.Rows.Add(Datarow.Cells[1].Value ?? string.Empty,
                                           Datarow.Cells[2].Value ?? string.Empty,
                                           Datarow.Cells[3].Value ?? string.Empty,
                                           Datarow.Cells[4].Value ?? string.Empty,
                                           Datarow.Cells[5].Value ?? 0,
                                           "", 
                                           Datarow.Cells[0].Value ?? 0,
                                           Datarow.Cells[7].Value ?? 0,
                                           1,
                                           "",
                                           Datarow.Cells[6].Value ?? ""
                                           );
                }
            }
            _mainPresenter.printStatus = "ScreenItem";

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, _mainPresenter);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtScreen.DefaultView;
            printQuote.GetPrintQuoteView().ShowPrintQuoteView();
        }

        private void _screenView_dgvScreenRowPostPaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //commonfunc.rowpostpaint(sender, e);
        }

        public void GetCurrentAmount()
        {
            _screenModel.ComputeScreenTotalPrice();
            _screenView.GetNudTotalPrice().Value = _screenModel.Screen_TotalAmount;
        }

        private void _screenView_btnAddClickEventRaised(object sender, EventArgs e)
        {        
              
            _screenModel.Screen_ItemNumber = Convert.ToDecimal(_screenitemnum.Text);           
            _screenModel.ItemNumberList();
            _screenView.getTxtitemListNumber().Text = Convert.ToString(_screenModel.Screen_NextItemNumber);

            if (_screenModel.Screen_ItemNumber != 0)
            {
                 GetCurrentAmount();
                _screenDT.Rows.Add(CreateNewRow_ScreenDT());
                _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
            }
        }


        private void _screenView_ScreenViewLoadEventRaised(object sender, System.EventArgs e)
        {
            _screenDT.Columns.Add(CreateColumn("Item No.", "Item No.", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));                                                 
            _screenDT.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Price", "Price", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));
            _screenDT.Columns.Add(CreateColumn("Discount", "Discount", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Net Price", "Net Price", "System.String"));



            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
            _screenView.GetDatagrid().Columns[0].Width = 35;
            _screenView.GetDatagrid().Columns[1].Width = 330;
            _screenView.GetDatagrid().Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[5].Width = 85;
            _screenView.GetDatagrid().Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _screenView.GetDatagrid().Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            _screenView.GetNudTotalPrice().Maximum = decimal.MaxValue;
            _screenView.GetNudTotalPrice().DecimalPlaces = 2;
            _screenWidth.Maximum = decimal.MaxValue;
            _screenHeight.Maximum = decimal.MaxValue;
            _factor.DecimalPlaces = 1;
            _discount.Value = 30;
            _screenitemnum.Text = "1";
            _screenModel.Screen_Quantity = 1;
            _screenModel.Screen_Set = 1;
            _screenModel.Screen_ExchangeRate = 64;
            _screenModel.PlissedRd_Panels = 1;
            _screenModel.DiscountPercentage = 0.3m;
            
                      
        

            IScreenAddOnPropertiesUCPresenter addOnsPropUCP = _screenAddOnPropertiesUCPresenter.GetNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl addOnsProp = (UserControl)addOnsPropUCP.GetScreenAddOnPropertiesUCView();
            _pnlAddOns.Controls.Add(addOnsProp);
            addOnsProp.Dock = DockStyle.Top;
            addOnsProp.BringToFront();


        }

        #endregion

        public DataTable PopulateDgvScreen()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item No.", Type.GetType("System.String"));
            dt.Columns.Add("Type of Insect Screen", Type.GetType("System.String"));
            dt.Columns.Add("Dimension (mm) \n per panel", Type.GetType("System.String"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
            dt.Columns.Add("Price", Type.GetType("System.String"));
            dt.Columns.Add("Quantity", Type.GetType("System.Int32"));
            dt.Columns.Add("Discount", Type.GetType("System.String"));
            dt.Columns.Add("Net Price", Type.GetType("System.String"));

            foreach (DataRow screenDTRow in _screenDT.Rows)
            {
                dt.Rows.Add(screenDTRow["Item No."],
                            screenDTRow["Type of Insect Screen"],                           
                            screenDTRow["Dimension (mm) \n per panel"],
                            screenDTRow["Window/Door I.D."],
                            screenDTRow["Price"],
                            screenDTRow["Quantity"],
                            screenDTRow["Discount"],
                            screenDTRow["Net Price"]);
            }

            return dt;
        }
        string setDesc, centerClosureDesc;
        public DataRow CreateNewRow_ScreenDT()
        {
            DataRow newRow;       
            newRow = _screenDT.NewRow();

            if (_screenModel.Screen_Set > 1)
            {
                setDesc = " (Sets of " + _screenModel.Screen_Set.ToString() + ")";
            }
            else
            {
                setDesc = " ";
            }

            //if (_screenModel.Screen_Width > 1500)
            //{
            //    centerClosureDesc = " - center closure";
            //}
           
            newRow["Item No."] = Convert.ToString(_screenModel.Screen_ItemNumber);
            newRow["Type of Insect Screen"] = _screenModel.Screen_Types + centerClosureDesc + setDesc  + _screenModel.PlisseMagnumType;
            newRow["Dimension (mm) \n per panel"] = _screenModel.Screen_Width + " x " + _screenModel.Screen_Height;
            newRow["Window/Door I.D."] = _screenModel.Screen_WindoorID;
            newRow["Price"] = _screenModel.Screen_UnitPrice.ToString("n");
            newRow["Quantity"] = _screenModel.Screen_Quantity;
            newRow["Discount"] = Convert.ToString(_screenModel.Screen_Discount) + "%";
            newRow["Net Price"] =  _screenModel.Screen_NetPrice.ToString("n");

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



            return binding;
        }


        public IScreenView GetScreenView()
        {
            return _screenView;
        }

        public IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                                  IMainPresenter mainPresenter,
                                                  IScreenModel screenModel)
        {
            unityC
                    .RegisterType<IScreenView, ScreenView>()
                    .RegisterType<IScreenPresenter, ScreenPresenter>();
            ScreenPresenter screen = unityC.Resolve<ScreenPresenter>();
            screen._unityC = unityC;
            screen._mainPresenter = mainPresenter;
            screen._screenModel = screenModel;

            return screen;
        }

     

        


    }
}
