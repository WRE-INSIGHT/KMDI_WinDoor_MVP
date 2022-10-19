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
        private IPrintQuotePresenter _printQuotePresenter;
        private IScreenAddOnPropertiesUCPresenter _screenAddOnPropertiesUCPresenter;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        private DataTable _screenDT = new DataTable();


        CommonFunctions commonfunc = new CommonFunctions();

        Panel _pnlAddOns;
        ComboBox _baseColor, _screenType;
        NumericUpDown _screenWidth, _screenHeight, _factor, _screenQty;
        DataGridView _dgvScreen;
        string _windoorID;

        #region Variables
        //roll up
        decimal
        ExchangeRate = 64m,

        HeadRailPricePerLinearMeter_White,
        HeadRailPricePerLinearMeter_WoodGrain,
        SlidingBarPricePerPiece_White,
        SlidingBarPricePerPiece_WoodGrain,
        MeshWithTubePricePerLinearMeter_White,
        MeshWithTubePricePerLinearMeter_WoodGrain,
        GuidePricePerLinearMeter_White,
        GuidePricePerLinearMeter_WoodGrain,
        PilePricePerLinearMeter_White,
        PilePricePerLinearMeter_WoodGrain,
        AntiwindBrushPricePerLinearMeter_White,
        AntiwindBrushPricePerLinearMeter_WoodGrain,
        KitForVerticalOpeningHeadrailPricePerLinearMeter_White,
        KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain,
        BrakePriceperPiece_White,
        BrakePriceperPiece_WoodGrain,
        SupportForFixingHeadRailPricePerLinearMeter_White,
        SupportForFixingHeadRailPricePerLinearMeter_WoodGrain,
        SpringLoadedPricePerPiece_White = 0,
        SpringLoadedPricePerPiece_WoodGrain = 0,

        HeadRailPrice,
        SlidingBarPrice,
        MeshWithTubePrice,
        GuidePrice,
        PilePrice,
        AntiwindBrushPrice,
        KitForVerticalOpeningHeadrailPrice,
        BrakePrice,
        SupportForFixingHeadRailPrice,
        SpringLoadedPrice,

        HeadRailQty = 1,
        SlidingBarQty = 1,
        MeshWithTubeQty = 1,
        GuideQty = 2,
        PileQty = 2,
        AntiwindBrushQty = 2,
        KitForVerticalOpeningHeadrailQty = 1,
        BrakeQty = 1,
        SupportForFixingHeadRailQty = 2,
        SpringLoadedQty = 1,

        WasteCost,
        FreightCost,
        DandTCost,
        SmallShopItemCost,
        OverheadCost,
        ContingenciesCost,
        TotalPrice;

        #endregion

        public ScreenPresenter(IScreenView screenView,
                               IPrintQuotePresenter printQuotePresenter,
                               IScreenAddOnPropertiesUCPresenter screenAddOnPropertiesUCPresenter)
        {
            _screenView = screenView;
            _printQuotePresenter = printQuotePresenter;
            _screenAddOnPropertiesUCPresenter = screenAddOnPropertiesUCPresenter;

            SubscribeToEventSetup();
        }



        private void SubscribeToEventSetup()
        {
            _screenView.ScreenViewLoadEventRaised += _screenView_ScreenViewLoadEventRaised;
            _screenView.btnAddClickEventRaised += _screenView_btnAddClickEventRaised;
            _screenView.dgvScreenRowPostPaintEventRaised += _screenView_dgvScreenRowPostPaintEventRaised;
            _screenView.tsBtnPrintScreenClickEventRaised += _screenView_tsBtnPrintScreenClickEventRaised;
            _screenView.computeTotalNetPriceEventRaised += _screenView_computeTotalNetPriceEventRaised;
            _screenView.cmbbaseColorSelectedValueChangedEventRaised += _screenView_cmbbaseColorSelectedValueChangedEventRaised;
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised;
            _screenView.nudWidthValueChangedEventRaised += _screenView_nudWidthValueChangedEventRaised;
            _screenView.nudHeightValueChangedEventRaised += _screenView_nudHeightValueChangedEventRaised;
            _screenView.nudFactorValueChangedEventRaised += _screenView_nudFactorValueChangedEventRaised;
            _screenView.nudQuantityValueChangedEventRaised += _screenView_nudQuantityValueChangedEventRaised;
            _screenView.nudSetsValueChangedEventRaised += _screenView_nudSetsValueChangedEventRaised;
            _screenView.txtwindoorIDTextChangedEventRaised += _screenView_txtwindoorIDTextChangedEventRaised;




            _pnlAddOns = _screenView.GetPnlAddOns();
            _screenQty = _screenView.screen_Quantity;
            _screenWidth = _screenView.screen_width;
            _screenHeight = _screenView.screen_height;
            _factor = _screenView.screen_factor;
            _baseColor = _screenView.GetCmbBaseColor();
            _screenType = _screenView.GetCmbScreenType();
            _dgvScreen = _screenView.GetDatagrid();
            _windoorID = _screenView.screen_windoorID;
        }
        #region Events
        private void _screenView_txtwindoorIDTextChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_WindoorID = (string)((TextBox)sender).Text;
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudSetsValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Set = (int)((NumericUpDown)sender).Value;
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudQuantityValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Quantity = (int)((NumericUpDown)sender).Value;
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudFactorValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Factor = (int)((NumericUpDown)sender).Value;
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Height = (int)((NumericUpDown)sender).Value;
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudWidthValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Width = (int)((NumericUpDown)sender).Value;
            ComputeScreenTotalPrice();
        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_Types = (ScreenType)((ComboBox)sender).SelectedValue;
            ComputeScreenTotalPrice();
        }

        private void _screenView_cmbbaseColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _screenModel.Screen_BaseColor = (Base_Color)((ComboBox)sender).SelectedValue;
            ComputeScreenTotalPrice();
        }

        private void _screenView_computeTotalNetPriceEventRaised(object sender, EventArgs e)
        {
            ComputeScreenTotalPrice();
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

        public DataRow CreateNewRow_ScreenDT()
        {
            // _screenView.screen_windoorID = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_screenView.screen_windoorID.ToLower());
            DataRow newRow;
            newRow = _screenDT.NewRow();
            newRow["Type of Insect Screen"] = _screenType.SelectedValue;
            newRow["Dimension (mm) \n per panel"] = _screenWidth.Value + " x " + +_screenHeight.Value;
            newRow["Window/Door I.D."] = _screenView.screen_windoorID;
            newRow["Unit Price"] = _screenView.GetNudTotalPrice().Value;
            newRow["Quantity"] = _screenView.GetNudQuantity().Value;
            newRow["Total Amount"] = _screenView.GetNudTotalPrice().Value * _screenView.GetNudQuantity().Value;
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
        int pvc0505Price, pvc1067Price;

        public void ComputeScreenTotalPrice()
        {
            decimal basicFiveMats;
            if (_screenModel.Screen_Width > 0)
            {
                Console.WriteLine("width:" + _screenModel.Screen_Width);
            }

            if (_screenModel.Screen_Height > 0)
            {
                Console.WriteLine("ht:" + _screenModel.Screen_Height);
            }

            if (_screenModel.Screen_Factor > 0)
            {
                Console.WriteLine("f:" + _screenModel.Screen_Factor);
            }

            Console.WriteLine("0505 qty:" + _screenModel.Screen_0505Qty);
            Console.WriteLine("0505 qty:" + _screenModel.Screen_0505Width);
            Console.WriteLine("0505 qty:" + _screenModel.Screen_1067Height);
            Console.WriteLine("0505 qty:" + _screenModel.Screen_1067Qty);



            if (_screenHeight.Value != 0 &&
                _screenHeight.Value != 0 &&
                _factor.Value != 0)
            {
                if (_screenModel.Screen_Types == ScreenType._RollUp)
                {
                    if (_screenModel.Screen_BaseColor == Base_Color._White ||
                        _screenModel.Screen_BaseColor == Base_Color._Ivory)
                    {
                        #region White

                        #region Default Roll-Up Mats

                        HeadRailPricePerLinearMeter_White = (26.46m / 5.8m) * ExchangeRate * 1.42m;
                        SlidingBarPricePerPiece_White = (16.92m / 5.8m) * ExchangeRate * 1.42m;
                        MeshWithTubePricePerLinearMeter_White = 58.45761m / 5.8m * ExchangeRate;
                        GuidePricePerLinearMeter_White = 14.18m / 5.8m * ExchangeRate * 1.42m;
                        PilePricePerLinearMeter_White = 0.15396m * ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_White = 0.38639m * ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_White = 4.2108m * ExchangeRate;
                        BrakePriceperPiece_White = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPricePerLinearMeter_White = 0.4773m * ExchangeRate;
                        if (_screenWidth.Value >= 1500)
                        {
                            SpringLoadedPricePerPiece_White = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_White * HeadRailQty * _screenWidth.Value) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_White * SlidingBarQty * _screenWidth.Value) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_White * MeshWithTubeQty * _screenWidth.Value) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_White * GuideQty * _screenHeight.Value) / 1000m;
                        PilePrice = ((_screenHeight.Value + _screenWidth.Value) * PilePricePerLinearMeter_White * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_White * AntiwindBrushQty * _screenHeight.Value) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_White * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_White * SupportForFixingHeadRailQty;

                        if (_screenWidth.Value >= 1500)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion
                    }
                    else if (_screenModel.Screen_BaseColor == Base_Color._DarkBrown)
                    {
                        #region WoodGrain

                        #region defaultMats

                        HeadRailPricePerLinearMeter_WoodGrain = 5.574m * ExchangeRate * 1.4m;
                        SlidingBarPricePerPiece_WoodGrain = 3.606m * ExchangeRate * 1.4m;
                        MeshWithTubePricePerLinearMeter_WoodGrain = 58.45761m / 5.8m * ExchangeRate;
                        GuidePricePerLinearMeter_WoodGrain = 3.398m * ExchangeRate * 1.4m;
                        PilePricePerLinearMeter_WoodGrain = 0.15396m * ExchangeRate;
                        AntiwindBrushPricePerLinearMeter_WoodGrain = 0.38639m * ExchangeRate;
                        KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain = 4.2108m * ExchangeRate;
                        BrakePriceperPiece_WoodGrain = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPricePerLinearMeter_WoodGrain = 0.4773m * ExchangeRate;
                        if (_screenWidth.Value >= 1500)
                        {
                            SpringLoadedPricePerPiece_WoodGrain = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion

                        HeadRailPrice = (HeadRailPricePerLinearMeter_WoodGrain * HeadRailQty * _screenWidth.Value) / 1000m;
                        SlidingBarPrice = (SlidingBarPricePerPiece_WoodGrain * SlidingBarQty * _screenWidth.Value) / 1000m;
                        MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_WoodGrain * MeshWithTubeQty * _screenWidth.Value) / 1000m;
                        GuidePrice = (GuidePricePerLinearMeter_WoodGrain * GuideQty * _screenHeight.Value) / 1000m;
                        PilePrice = ((_screenHeight.Value + _screenWidth.Value) * PilePricePerLinearMeter_WoodGrain * PileQty) / 1000m;
                        AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_WoodGrain * AntiwindBrushQty * _screenHeight.Value) / 1000m;
                        KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain * KitForVerticalOpeningHeadrailQty;
                        BrakePrice = 2.5m * ExchangeRate;
                        SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_WoodGrain * SupportForFixingHeadRailQty;
                        if (_screenWidth.Value >= 1500)
                        {
                            SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                        }

                        #endregion
                    }

                }
                else if (_screenModel.Screen_Types == ScreenType._Piconet)
                {
                    if (_screenModel.Screen_BaseColor == Base_Color._White ||
                        _screenModel.Screen_BaseColor == Base_Color._Ivory)
                    {

                    }
                    else if (_screenModel.Screen_BaseColor == Base_Color._DarkBrown)
                    {

                    }
                }
                else if (_screenModel.Screen_Types == ScreenType._PlisseSRSlimLine)
                {
                    if (_screenModel.Screen_BaseColor == Base_Color._White ||
                        _screenModel.Screen_BaseColor == Base_Color._Ivory)
                    {

                    }
                    else if (_screenModel.Screen_BaseColor == Base_Color._DarkBrown)
                    {

                    }
                }

                if (_screenModel.Screen_PVCVisibility == true &&
                    _screenModel.Screen_0505Width != 0 &&
                    _screenModel.Screen_1067Height != 0 &&
                    _screenModel.Screen_0505Qty != 0 &&
                    _screenModel.Screen_1067Qty != 0)
                {
                    pvc0505Price = (_screenModel.Screen_0505Width / 1000) * _screenModel.Screen_0505Qty * 300;
                    pvc1067Price = (_screenModel.Screen_1067Height / 1000) * _screenModel.Screen_1067Qty * 420;
                }



                basicFiveMats = HeadRailPrice +
                                       SlidingBarPrice +
                                       MeshWithTubePrice +
                                       GuidePrice +
                                       PilePrice +
                                       AntiwindBrushPrice;

                WasteCost = basicFiveMats * 0.1m;

                FreightCost = (basicFiveMats +
                              KitForVerticalOpeningHeadrailPrice +
                              BrakePrice +
                              SupportForFixingHeadRailPrice +
                              SpringLoadedPrice +
                              WasteCost) * 0.05m;

                DandTCost = (basicFiveMats +
                            KitForVerticalOpeningHeadrailPrice +
                            BrakePrice +
                            SupportForFixingHeadRailPrice +
                            SpringLoadedPrice +
                            WasteCost +
                            FreightCost) * 0.16m;

                SmallShopItemCost = 200;
                OverheadCost = 0.2m * 6000;
                ContingenciesCost = (basicFiveMats +
                                    KitForVerticalOpeningHeadrailPrice +
                                    BrakePrice +
                                    SupportForFixingHeadRailPrice +
                                    SpringLoadedPrice +
                                    WasteCost +
                                    FreightCost +
                                    DandTCost +
                                    SmallShopItemCost +
                                    OverheadCost) * 0.05m;

                TotalPrice = basicFiveMats +
                             KitForVerticalOpeningHeadrailPrice +
                             BrakePrice +
                             SupportForFixingHeadRailPrice +
                             SpringLoadedPrice +
                             WasteCost +
                             FreightCost +
                             DandTCost +
                             SmallShopItemCost +
                             OverheadCost +
                             ContingenciesCost +
                             //add ons materials
                             pvc0505Price +
                             pvc1067Price;



                _screenView.GetNudTotalPrice().Value = (Math.Ceiling(TotalPrice) * _factor.Value) * _screenQty.Value;

            }
            else
            {
                _screenView.GetNudTotalPrice().Value = 0;
            }
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
        //DataTable screenDT)
        {
            unityC
                    .RegisterType<IScreenView, ScreenView>()
                    .RegisterType<IScreenPresenter, ScreenPresenter>();
            ScreenPresenter screen = unityC.Resolve<ScreenPresenter>();
            screen._unityC = unityC;
            screen._mainPresenter = mainPresenter;
            screen._screenModel = screenModel;
            //screen._screenDT = screenDT;

            return screen;
        }


    }
}
