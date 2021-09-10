using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Divider;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public class DP_LeverEspagnolettePropertyUCPresenter : IDP_LeverEspagnolettePropertyUCPresenter, IPresenterCommon
    {
        IDP_LeverEspagnolettePropertyUC _dp_leverEspagnolettePropertyUC;

        private IDividerModel _divModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public DP_LeverEspagnolettePropertyUCPresenter(IDP_LeverEspagnolettePropertyUC dp_leverEspagnolettePropertyUC)
        {
            _dp_leverEspagnolettePropertyUC = dp_leverEspagnolettePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _dp_leverEspagnolettePropertyUC.DPLeverEspagnolettePropertyUCLoadEventRaised += _dp_leverEspagnolettePropertyUC_DPLeverEspagnolettePropertyUCLoadEventRaised;
            _dp_leverEspagnolettePropertyUC.cmbLeverEspagSelectedValueChangedEventRaised += _dp_leverEspagnolettePropertyUC_cmbLeverEspagSelectedValueChangedEventRaised;
            _dp_leverEspagnolettePropertyUC.DPLeverEspagnolettePropertyUCVisibleChangedEventRaised += _dp_leverEspagnolettePropertyUC_DPLeverEspagnolettePropertyUCVisibleChangedEventRaised;
            _dp_leverEspagnolettePropertyUC.SashProfileChangedEventRaised += _dp_leverEspagnolettePropertyUC_SashProfileChangedEventRaised;
        }

        private void _dp_leverEspagnolettePropertyUC_SashProfileChangedEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _dp_leverEspagnolettePropertyUC_DPLeverEspagnolettePropertyUCVisibleChangedEventRaised(object sender, EventArgs e)
        {
            UserControl leverEspag = (UserControl)sender;
            if (!_initialLoad)
            {
                if (leverEspag.Visible == true)
                {
                    _divModel.AdjustPropertyPanelHeight("addLeverEspag");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                }
                else if (leverEspag.Visible == false)
                {
                    _divModel.AdjustPropertyPanelHeight("minusLeverEspag");
                    _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                    _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusLeverEspag");
                }
            }
        }

        private void _dp_leverEspagnolettePropertyUC_cmbLeverEspagSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                _divModel.Div_LeverEspagArtNo = (LeverEspagnolette_ArticleNo)((ComboBox)sender).SelectedValue;
            }
        }

        private void _dp_leverEspagnolettePropertyUC_DPLeverEspagnolettePropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _dp_leverEspagnolettePropertyUC.ThisBinding(CreateBindingDictionary());
            _divModel.Div_LeverEspagArtNo = LeverEspagnolette_ArticleNo._625_205;
            _initialLoad = false;
        }

        public IDP_LeverEspagnolettePropertyUC GetDPLeverEspagPropertyUC()
        {
            return _dp_leverEspagnolettePropertyUC;
        }

        public IDP_LeverEspagnolettePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel)
        {
            unityC
                .RegisterType<IDP_LeverEspagnolettePropertyUC, DP_LeverEspagnolettePropertyUC>()
                .RegisterType<IDP_LeverEspagnolettePropertyUCPresenter, DP_LeverEspagnolettePropertyUCPresenter>();
            DP_LeverEspagnolettePropertyUCPresenter presenter = unityC.Resolve<DP_LeverEspagnolettePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._divModel = divModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Div_LeverEspagArtNo", new Binding("Text", _divModel, "Div_LeverEspagArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

        public void BindSashProfileArtNo()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_SashProfileArtNo", new Binding("Panel_SashProfileArtNo", _divModel.Div_DMPanel, "Panel_SashProfileArtNo", true, DataSourceUpdateMode.OnPropertyChanged));

            _dp_leverEspagnolettePropertyUC.SashPropBinding(binding);

            if (_divModel.Div_DMPanel != null && _divModel.Div_DMPanel.Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            {
                _divModel.AdjustPropertyPanelHeight("addLeverEspag");
                _divModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
                _divModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "addLeverEspag");
            }
        }
    }
}
