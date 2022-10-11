﻿using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class ScreenPresenter : IScreenPresenter
    {
        IScreenView _screenView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private DataTable _screenDT = new DataTable();


        CommonFunctions commonfunc = new CommonFunctions();

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

        public ScreenPresenter(IScreenView screenView)
        {
            _screenView = screenView;

            SubscribeToEventSetup();
        }
        ComboBox _baseColor, _screenType;
        NumericUpDown _screen_Width, _screen_Height, _factor;
        DataGridView _dgvScreen;
        string _windoorID;
        private void SubscribeToEventSetup()
        {
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised1;
            _screenView.cmbbaseColorSelectedValueChangedEventRaised += _screenView_cmbbaseColorSelectedValueChangedEventRaised;
            _screenView.nudHeightValueChangedEventRaised += _screenViewnudHeightValueChangedEventRaised;
            _screenView.nudWidthValueChangedEventRaised += _screenView_nudWidthValueChangedEventRaised;
            _screenView.nudFactorValueChangedEventRaised += _screenView_nudFactorValueChangedEventRaised;
            _screenView.cmbScreenTypeSelectedValueChangedEventRaised += _screenView_cmbScreenTypeSelectedValueChangedEventRaised;
            _screenView.ScreenViewLoadEventRaised += _screenView_ScreenViewLoadEventRaised;
            _screenView.btnAddClickEventRaised += _screenView_btnAddClickEventRaised;
            _screenView.dgvScreenRowPostPaintEventRaised += _screenView_dgvScreenRowPostPaintEventRaised;

            _screen_Width = _screenView.screen_width;
            _screen_Height = _screenView.screen_height;
            _factor = _screenView.screen_factor;
            _baseColor = _screenView.GetCmbBaseColor();
            _screenType = _screenView.GetCmbScreenType();
            _dgvScreen = _screenView.GetDatagrid();
            _windoorID = _screenView.screen_windoorID;
        }

        #region Events

        private void _screenView_dgvScreenRowPostPaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void _screenView_btnAddClickEventRaised(object sender, EventArgs e)
        {
            _screenDT.Rows.Add(CreateNewRow_ScreenDT());
            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised1(object sender, EventArgs e)
        {
            ComputeScreenTotalPrice();
        }

        private void _screenView_cmbbaseColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComputeScreenTotalPrice();
        }

        private void _screenView_ScreenViewLoadEventRaised(object sender, System.EventArgs e)
        {
            _screenDT.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _screenDT.Columns.Add(CreateColumn("Unit Price", "Unit Price", "System.Decimal"));
            _screenDT.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));
            _screenDT.Columns.Add(CreateColumn("Total Amount", "Total Amount", "System.Decimal"));


            //_screenDT.Rows.Add("super duper pang harang na screen");


            _screenView.GetDatagrid().DataSource = PopulateDgvScreen();
            _screenView.GetDatagrid().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            _screenView.GetNudTotalPrice().Maximum = decimal.MaxValue;
            _screenView.GetNudTotalPrice().DecimalPlaces = 2;
            _screen_Width.Maximum = decimal.MaxValue;
            _screen_Height.Maximum = decimal.MaxValue;
            _factor.DecimalPlaces = 1;

        }

        private void _screenView_cmbScreenTypeSelectedValueChangedEventRaised(object sender, System.EventArgs e)
        {
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudFactorValueChangedEventRaised(object sender, System.EventArgs e)
        {
            ComputeScreenTotalPrice();
        }

        private void _screenView_nudWidthValueChangedEventRaised(object sender, System.EventArgs e)
        {
            ComputeScreenTotalPrice();
        }

        private void _screenViewnudHeightValueChangedEventRaised(object sender, System.EventArgs e)
        {
            ComputeScreenTotalPrice();
        }
        #endregion

        public DataTable PopulateDgvScreen()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type of Insect Screen", Type.GetType("System.String"));
            dt.Columns.Add("Dimension (mm) \n per panel", Type.GetType("System.String"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
            dt.Columns.Add("Unit Price", Type.GetType("System.String"));
            dt.Columns.Add("Quantity", Type.GetType("System.String"));
            dt.Columns.Add("Total Amount", Type.GetType("System.String"));

            foreach (DataRow screenDTRow in _screenDT.Rows)
            {
                dt.Rows.Add(screenDTRow["Type of Insect Screen"]);
                dt.Rows.Add(screenDTRow["Dimension (mm) \n per panel"]);
                dt.Rows.Add(screenDTRow["Window/Door I.D."]);
                dt.Rows.Add(screenDTRow["Unit Price"]);
                dt.Rows.Add(screenDTRow["Quantity"]);
                dt.Rows.Add(screenDTRow["Total Amount"]);
            }

            return dt;
        }

        public DataRow CreateNewRow_ScreenDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CreateColumn("Type of Insect Screen", "Type of Insect Screen", "System.String"));
            dt.Columns.Add(CreateColumn("Dimension (mm) \n per panel", "Dimension (mm) \n per panel", "System.String"));
            dt.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            dt.Columns.Add(CreateColumn("Unit Price", "Unit Price", "System.Decimal"));
            dt.Columns.Add(CreateColumn("Quantity", "Quantity", "System.Int32"));
            dt.Columns.Add(CreateColumn("Total Amount", "Total Amount", "System.Decimal"));

            // _screenView.screen_windoorID = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_screenView.screen_windoorID.ToLower());
            DataRow newRow;
            newRow = _screenDT.NewRow();
            newRow["Type of Insect Screen"] = _screenType.SelectedValue;
            newRow["Dimension (mm) \n per panel"] = _screen_Width.Value+ " x " + +_screen_Height.Value;
            newRow["Window/Door I.D."] = _screenView.screen_windoorID;
            newRow["Unit Price"] = _screenView.GetNudQuantity().Value;
            newRow["Quantity"] = _screenView.GetNudQuantity().Value;
            newRow["Total Amount"] = _screenView.GetNudTotalPrice().Value;
            //dt.Rows.Add(newRow);
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
        public void ComputeScreenTotalPrice()
        {
            decimal basicFiveMats;

            if (_screen_Height.Value != 0 &&
                _screen_Height.Value != 0 &&
                _factor.Value != 0)
            {
                if (_baseColor.Text == "White" ||
                    _baseColor.Text == "Ivory")
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
                    if (_screen_Width.Value >= 1500)
                    {
                        SpringLoadedPricePerPiece_White = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                    }

                    #endregion

                    HeadRailPrice = (HeadRailPricePerLinearMeter_White * HeadRailQty * _screen_Width.Value) / 1000m;
                    SlidingBarPrice = (SlidingBarPricePerPiece_White * SlidingBarQty * _screen_Width.Value) / 1000m;
                    MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_White * MeshWithTubeQty * _screen_Width.Value) / 1000m;
                    GuidePrice = (GuidePricePerLinearMeter_White * GuideQty * _screen_Height.Value) / 1000m;
                    PilePrice = ((_screen_Height.Value + _screen_Width.Value) * PilePricePerLinearMeter_White * PileQty) / 1000m;
                    AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_White * AntiwindBrushQty * _screen_Height.Value) / 1000m;
                    KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_White * KitForVerticalOpeningHeadrailQty;
                    BrakePrice = 2.5m * ExchangeRate;
                    SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_White * SupportForFixingHeadRailQty;

                    if (_screen_Width.Value >= 1500)
                    {
                        SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                    }

                    #endregion

                }
                else if (_baseColor.Text == "Dark Brown")
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
                    if (_screen_Width.Value >= 1500)
                    {
                        SpringLoadedPricePerPiece_WoodGrain = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                    }

                    #endregion

                    HeadRailPrice = (HeadRailPricePerLinearMeter_WoodGrain * HeadRailQty * _screen_Width.Value) / 1000m;
                    SlidingBarPrice = (SlidingBarPricePerPiece_WoodGrain * SlidingBarQty * _screen_Width.Value) / 1000m;
                    MeshWithTubePrice = (MeshWithTubePricePerLinearMeter_WoodGrain * MeshWithTubeQty * _screen_Width.Value) / 1000m;
                    GuidePrice = (GuidePricePerLinearMeter_WoodGrain * GuideQty * _screen_Height.Value) / 1000m;
                    PilePrice = ((_screen_Height.Value + _screen_Width.Value) * PilePricePerLinearMeter_WoodGrain * PileQty) / 1000m;
                    AntiwindBrushPrice = (AntiwindBrushPricePerLinearMeter_WoodGrain * AntiwindBrushQty * _screen_Height.Value) / 1000m;
                    KitForVerticalOpeningHeadrailPrice = KitForVerticalOpeningHeadrailPricePerLinearMeter_WoodGrain * KitForVerticalOpeningHeadrailQty;
                    BrakePrice = 2.5m * ExchangeRate;
                    SupportForFixingHeadRailPrice = SupportForFixingHeadRailPricePerLinearMeter_WoodGrain * SupportForFixingHeadRailQty;
                    if (_screen_Width.Value >= 1500)
                    {
                        SpringLoadedPrice = (2.1614m * 2 + 0.815m * 2 + 0.6304m + 0.4031m * 2) * ExchangeRate * 1.05m * 1.15m;
                    }

                    #endregion

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
                             ContingenciesCost;


                _screenView.GetNudTotalPrice().Value = (Math.Ceiling(TotalPrice) * _factor.Value);


            }
            else
            {
                _screenView.GetNudTotalPrice().Value = 0;
            }
        }

        public IScreenView GetScreenView()
        {
            return _screenView;
        }

        public IScreenPresenter CreateNewInstance(IUnityContainer unityC)
        //IMainPresenter mainPresenter)
        //DataTable screenDT)
        {
            unityC
                    .RegisterType<IScreenView, ScreenView>()
                    .RegisterType<IScreenPresenter, ScreenPresenter>();
            ScreenPresenter screen = unityC.Resolve<ScreenPresenter>();
            screen._unityC = unityC;
            //screen._mainPresenter = mainPresenter;
            //screen._screenDT = screenDT;

            return screen;
        }


    }
}
