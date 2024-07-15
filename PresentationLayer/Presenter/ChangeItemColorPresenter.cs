using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class ChangeItemColorPresenter : IChangeItemColorPresenter, IPresenterCommon
    {
        IChangeItemColorView _changeItemColorView;

        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;

        Panel pnlWoodec,
              pnlInOutColor,
              pnlPowderCoatedType;

        private Base_Color base_color;
        private Foil_Color inside_color;
        private Foil_Color outside_color;
        private PowderCoatType_Color powderCoatType_color;

        public ChangeItemColorPresenter(IChangeItemColorView changeItemColorView)
        {
            _changeItemColorView = changeItemColorView;

            pnlWoodec = _changeItemColorView.GetPanelWoodec();
            pnlInOutColor = _changeItemColorView.GetPanelInOutColor();
            pnlPowderCoatedType = _changeItemColorView.GetPnlPowderCoatdType();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _changeItemColorView.ChangeItemColorViewLoadEventRaised += _changeItemColorView_ChangeItemColorViewLoadEventRaised;
            _changeItemColorView.CmbBaseColorSelectedValueChangedEventRaised += _changeItemColorView_CmbBaseColorSelectedValueChangedEventRaised;
            _changeItemColorView.CmbInsideColorSelectedValueChangedEventRaised += _changeItemColorView_CmbInsideColorSelectedValueChangedEventRaised;
            _changeItemColorView.CmbOutsideColorSelectedValueChangedEventRaised += _changeItemColorView_CmbOutsideColorSelectedValueChangedEventRaised;
            _changeItemColorView.BtnOkClickEventRaised += _changeItemColorView_BtnOkClickEventRaised;
            _changeItemColorView.nudWoodecAdditionalValueChangedEventRaised += _changeItemColorView_nudWoodecAdditionalValueChangedEventRaised;
            _changeItemColorView.CmbColorAppliedToSelectedValueChangedEventRaised += _changeItemColorView_CmbColorAppliedToSelectedValueChangedEventRaised;
            _changeItemColorView.cmbPowderCoatTypeSelectedValueChangedEventRaised += _changeItemColorView_cmbPowderCoatTypeSelectedValueChangedEventRaised;


        }

        private void _changeItemColorView_cmbPowderCoatTypeSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_PowderCoatType = (PowderCoatType_Color)((ComboBox)sender).SelectedValue;
            powderCoatType_color = _windoorModel.WD_PowderCoatType;
        }

        public IChangeItemColorView GetChangeItemColorView()
        {
            return _changeItemColorView;
        }
        private void _changeItemColorView_CmbColorAppliedToSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_ColorAppliedTo = (ColorAppliedTo)((ComboBox)sender).SelectedValue;
        }

        private void _changeItemColorView_nudWoodecAdditionalValueChangedEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_WoodecAdditional = (decimal)((NumericUpDown)sender).Value;
        }

        private void _changeItemColorView_BtnOkClickEventRaised(object sender, EventArgs e)
        {
            if (_windoorModel.WD_ColorAppliedTo == ColorAppliedTo._ThisItemonly)
            {
                _windoorModel.WD_BaseColor = base_color;
                _windoorModel.WD_InsideColor = inside_color;
                _windoorModel.WD_OutsideColor = outside_color;
                if (base_color == Base_Color._PowderCoated)
                {
                    _windoorModel.WD_PowderCoatType = powderCoatType_color;
                }
                _windoorModel.SetMiddleCloser_onPanel();
                _changeItemColorView.CloseView();
                _mainPresenter.GetCurrentPrice();
            }
            else if (_windoorModel.WD_ColorAppliedTo == ColorAppliedTo._WholeProject)
            {
                //set to existing items
                foreach (IWindoorModel wdm in _mainPresenter.qoutationModel_MainPresenter.Lst_Windoor)
                {
                    wdm.WD_BaseColor = base_color;
                    wdm.WD_InsideColor = inside_color;
                    wdm.WD_OutsideColor = outside_color;
                    if (base_color == Base_Color._PowderCoated)
                    {
                        wdm.WD_PowderCoatType = powderCoatType_color;
                    }
                    _windoorModel.SetMiddleCloser_onPanel();
                    wdm.WD_WoodecAdditional = _changeItemColorView.GetNudWoodec().Value;

                    //pang kuha lahat ng price
                    wdm.WD_fileLoad = false;
                    _mainPresenter.qoutationModel_MainPresenter.BOMandItemlistStatus = "PriceItemList";
                    _mainPresenter.qoutationModel_MainPresenter.ItemCostingPriceAndPoints();
                    wdm.TotalPriceHistoryStatus = "System Generated Price";
                    wdm.WD_price = wdm.WD_currentPrice;  
                }

                _mainPresenter.GetCurrentPrice();

                //set to new items
                _mainPresenter.setColors(base_color, inside_color, outside_color, powderCoatType_color);
                _mainPresenter.setWoodecAdditional((int)_changeItemColorView.GetNudWoodec().Value);
                _changeItemColorView.CloseView();
            }


        }

    

        private void _changeItemColorView_CmbOutsideColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            outside_color = (Foil_Color)((ComboBox)sender).SelectedValue;
            if (outside_color == inside_color)
            {
                if ((outside_color == Foil_Color._Carbon ||
                    outside_color == Foil_Color._GreyOak ||
                    outside_color == Foil_Color._UmberOak ||
                    outside_color == Foil_Color._ChestnutOak ||
                    outside_color == Foil_Color._WashedOak))
                {
                    pnlWoodec.Visible = true;
                    _windoorModel.WD_WoodecAdditionalVisibility = true;
                }
                else
                {
                    _windoorModel.WD_WoodecAdditional = 0;
                    pnlWoodec.Visible = false;
                    _windoorModel.WD_WoodecAdditionalVisibility = false;
                }
            }
            else
            {
                _windoorModel.WD_WoodecAdditional = 0;
                pnlWoodec.Visible = false;
                _windoorModel.WD_WoodecAdditionalVisibility = false;
            }
        }

        private void _changeItemColorView_CmbInsideColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            inside_color = (Foil_Color)((ComboBox)sender).SelectedValue;
            if (outside_color == inside_color)
            {
                if ((inside_color == Foil_Color._Carbon ||
                    inside_color == Foil_Color._GreyOak ||
                    inside_color == Foil_Color._UmberOak ||
                    inside_color == Foil_Color._ChestnutOak ||
                    inside_color == Foil_Color._WashedOak))
                {
                    pnlWoodec.Visible = true;
                    _windoorModel.WD_WoodecAdditionalVisibility = true;
                }
                else
                {
                    _windoorModel.WD_WoodecAdditional = 0;
                    pnlWoodec.Visible = false;
                    _windoorModel.WD_WoodecAdditionalVisibility = false;
                }
            }
            else
            {
                _windoorModel.WD_WoodecAdditional = 0;
                pnlWoodec.Visible = false;
                _windoorModel.WD_WoodecAdditionalVisibility = false;
            }

        }

        private void _changeItemColorView_CmbBaseColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {

            base_color = (Base_Color)((ComboBox)sender).SelectedValue;
            if (base_color == Base_Color._PowderCoated)
            {
                pnlInOutColor.Visible = false;
                pnlWoodec.Visible = false;
                pnlPowderCoatedType.Visible = true;
                _windoorModel.WD_PowderCoatVisibility = true;
            }
            else
            {
                pnlInOutColor.Visible =true;
                pnlWoodec.Visible = false;
                pnlPowderCoatedType.Visible = false;
                _windoorModel.WD_PowderCoatVisibility = false;

            }
        }

        private void _changeItemColorView_ChangeItemColorViewLoadEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_ColorAppliedTo = ColorAppliedTo._ThisItemonly;
            if (_windoorModel.WD_PowderCoatType == null)
            {
                _windoorModel.WD_PowderCoatType = PowderCoatType_Color._Standard;
            }
            _changeItemColorView.ThisBinding(CreateBindingDictionary());
        }

        public void ShowView()
        {
            _changeItemColorView.ShowThisDialog();
        }

        public IChangeItemColorPresenter GetNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IWindoorModel windoorModel)
        {
            unityC
                .RegisterType<IChangeItemColorView, ChangeItemColorView>()
                .RegisterType<IChangeItemColorPresenter, ChangeItemColorPresenter>();
            ChangeItemColorPresenter presenter = unityC.Resolve<ChangeItemColorPresenter>();
            presenter._mainPresenter = mainPresenter;
            presenter._windoorModel = windoorModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> dictionary = new Dictionary<string, Binding>();
            dictionary.Add("WD_BaseColor", new Binding("Text", _windoorModel, "WD_BaseColor", true, DataSourceUpdateMode.OnPropertyChanged));
            dictionary.Add("WD_InsideColor", new Binding("Text", _windoorModel, "WD_InsideColor", true, DataSourceUpdateMode.OnPropertyChanged));
            dictionary.Add("WD_OutsideColor", new Binding("Text", _windoorModel, "WD_OutsideColor", true, DataSourceUpdateMode.OnPropertyChanged));
            //dictionary.Add("WD_WoodecAdditionalVisibility", new Binding("Visible", _windoorModel, "WD_WoodecAdditionalVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return dictionary;
        }
    }
}
