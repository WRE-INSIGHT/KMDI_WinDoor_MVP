using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.CommonMethods;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
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

        CommonFunctions commonfunc = new CommonFunctions();
        Panel _pnlAddOns;
        NumericUpDown _screenWidth, _screenHeight, _factor;

        public ScreenPresenter(IScreenView screenView,
                               IPrintQuotePresenter printQuotePresenter,
                               IScreenAddOnPropertiesUCPresenter screenAddOnPropertiesUCPresenter,
                               IExchangeRatePresenter exchangeRatePresenter)
        {
            _screenView = screenView;
            _printQuotePresenter = printQuotePresenter;
            _screenAddOnPropertiesUCPresenter = screenAddOnPropertiesUCPresenter;
            _exchangeRatePresenter = exchangeRatePresenter;

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

            _pnlAddOns = _screenView.GetPnlAddOns();
            _screenWidth = _screenView.screen_width;
            _screenHeight = _screenView.screen_height;
            _factor = _screenView.screen_factor;
        }
        #region Events
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

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ScreenType screenType = (ScreenType)((ComboBox)sender).SelectedValue;
            _screenModel.Screen_Types = screenType;

            if (screenType == ScreenType._Plisse)
            {
                _screenView.getLblPlisse().Visible = true;
                _screenView.getCmbPlisse().Visible = true;
            }
            else
            {
                _screenView.getLblPlisse().Visible = false;
                _screenView.getCmbPlisse().Visible = false;
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
            Type of Insect Screen
            Dimension(mm) \n per panel
            Window / Door I.D.
            Unit Price
            Quantity
            Total Amount
            */

            if (_screenDT != null)
            {
                int item = 1;
                foreach (DataGridViewRow Datarow in _screenView.GetDatagrid().Rows)
                {

                    _dsq.dtScreen.Rows.Add(Datarow.Cells[0].Value ?? string.Empty,
                                           Datarow.Cells[1].Value ?? string.Empty,
                                           Datarow.Cells[2].Value ?? string.Empty,
                                           Datarow.Cells[3].Value ?? 0,
                                           Datarow.Cells[4].Value ?? 0,
                                           Datarow.Cells[5].Value ?? 0,
                                           item++);
                }
            }

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, _mainPresenter);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtScreen.DefaultView;
            printQuote.GetPrintQuoteView().ShowPrintQuoteView();
        }

        private void _screenView_dgvScreenRowPostPaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void _screenView_btnAddClickEventRaised(object sender, EventArgs e)
        {
            _screenDT.Rows.Add(CreateNewRow_ScreenDT());
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
        }


        private void _screenView_ScreenViewLoadEventRaised(object sender, System.EventArgs e)
        {
            _screenDT.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Unit Price", "Unit Price", "System.Decimal"));
            _screenDT.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));
            _screenDT.Columns.Add(CreateColumn("Total Amount", "Total Amount", "System.Decimal"));

            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
            _screenView.GetDatagrid().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _screenView.GetNudTotalPrice().Maximum = decimal.MaxValue;
            _screenView.GetNudTotalPrice().DecimalPlaces = 2;
            _screenWidth.Maximum = decimal.MaxValue;
            _screenHeight.Maximum = decimal.MaxValue;
            _factor.DecimalPlaces = 1;
            _screenModel.Screen_Quantity = 1;


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
            dt.Columns.Add("Type of Insect Screen", Type.GetType("System.String"));
            dt.Columns.Add("Dimension (mm) \n per panel", Type.GetType("System.String"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
            dt.Columns.Add("Unit Price", Type.GetType("System.Decimal"));
            dt.Columns.Add("Quantity", Type.GetType("System.Int32"));
            dt.Columns.Add("Total Amount", Type.GetType("System.Decimal"));

            foreach (DataRow screenDTRow in _screenDT.Rows)
            {
                dt.Rows.Add(screenDTRow["Type of Insect Screen"],
                            screenDTRow["Dimension (mm) \n per panel"],
                            screenDTRow["Window/Door I.D."],
                            screenDTRow["Unit Price"],
                            screenDTRow["Quantity"],
                            screenDTRow["Total Amount"]);
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
            if (_screenModel.Screen_Width > 1500)
            {
                centerClosureDesc = " - center closure";
            }

            newRow["Type of Insect Screen"] = _screenModel.Screen_Types + centerClosureDesc + setDesc;
            newRow["Dimension (mm) \n per panel"] = _screenModel.Screen_Width + " x " + _screenModel.Screen_Height;
            newRow["Window/Door I.D."] = _screenModel.Screen_WindoorID;
            newRow["Unit Price"] = _screenModel.Screen_TotalAmount;
            newRow["Quantity"] = _screenModel.Screen_Quantity;
            newRow["Total Amount"] = _screenModel.Screen_TotalAmount * _screenModel.Screen_Quantity;

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

            binding.Add("Screen_Types_Window", new Binding("Checked", _screenModel, "Screen_Types_Window", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Types_Door", new Binding("Checked", _screenModel, "Screen_Types_Door", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_BaseColor", new Binding("Text", _screenModel, "Screen_BaseColor", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Type", new Binding("Text", _screenModel, "Screen_Type", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Width", new Binding("Value", _screenModel, "Screen_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Height", new Binding("Value", _screenModel, "Screen_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Factor", new Binding("Value", _screenModel, "Screen_Factor", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Set", new Binding("Value", _screenModel, "Screen_Set", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_WindoorID", new Binding("Text", _screenModel, "Screen_WindoorID", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Screen_Quantity", new Binding("Value", _screenModel, "Screen_Quantity", true, DataSourceUpdateMode.OnPropertyChanged));

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
