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

        public ChangeItemColorPresenter(IChangeItemColorView changeItemColorView)
        {
            _changeItemColorView = changeItemColorView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _changeItemColorView.ChangeItemColorViewLoadEventRaised += _changeItemColorView_ChangeItemColorViewLoadEventRaised;
            _changeItemColorView.CmbBaseColorSelectedValueChangedEventRaised += _changeItemColorView_CmbBaseColorSelectedValueChangedEventRaised;
            _changeItemColorView.CmbInsideColorSelectedValueChangedEventRaised += _changeItemColorView_CmbInsideColorSelectedValueChangedEventRaised;
            _changeItemColorView.CmbOutsideColorSelectedValueChangedEventRaised += _changeItemColorView_CmbOutsideColorSelectedValueChangedEventRaised;
            _changeItemColorView.BtnOkClickEventRaised += _changeItemColorView_BtnOkClickEventRaised;
        }

        private void _changeItemColorView_BtnOkClickEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_BaseColor = base_color;
            _windoorModel.WD_InsideColor = inside_color;
            _windoorModel.WD_OutsideColor = outside_color;
            _windoorModel.SetMiddleCloser_onPanel();
            _changeItemColorView.CloseView();
            _mainPresenter.GetCurrentPrice();
        }

        private Base_Color base_color;
        private Foil_Color inside_color;
        private Foil_Color outside_color;

        private void _changeItemColorView_CmbOutsideColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            outside_color = (Foil_Color)((ComboBox)sender).SelectedValue;
        }

        private void _changeItemColorView_CmbInsideColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            inside_color = (Foil_Color)((ComboBox)sender).SelectedValue;
        }

        private void _changeItemColorView_CmbBaseColorSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            base_color = (Base_Color)((ComboBox)sender).SelectedValue;
        }

        private void _changeItemColorView_ChangeItemColorViewLoadEventRaised(object sender, EventArgs e)
        {
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

            return dictionary;
        }
    }
}
