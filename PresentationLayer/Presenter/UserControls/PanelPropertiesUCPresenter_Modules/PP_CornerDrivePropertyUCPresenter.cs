using CommonComponents;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Views.UserControls.PanelProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter.UserControls.PanelPropertiesUCPresenter_Modules
{
    public class PP_CornerDrivePropertyUCPresenter : IPP_CornerDrivePropertyUCPresenter, IPresenterCommon
    {
        IPP_CornerDrivePropertyUC _pp_cornerDrivePropertyUC;

        private IPanelModel _panelModel;
        private IUnityContainer _unityC;

        bool _initialLoad = true;

        public PP_CornerDrivePropertyUCPresenter(IPP_CornerDrivePropertyUC pp_cornerDrivePropertyUC)
        {
            _pp_cornerDrivePropertyUC = pp_cornerDrivePropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _pp_cornerDrivePropertyUC.PPCornerDriveCLoadEventRaised += _pp_cornerDrivePropertyUC_PPCornerDriveCLoadEventRaised;
            _pp_cornerDrivePropertyUC.cmbCornerDriveSelectedValueChangedEventRaised += _pp_cornerDrivePropertyUC_cmbCornerDriveSelectedValueChangedEventRaised;
        }

        private void _pp_cornerDrivePropertyUC_cmbCornerDriveSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (_initialLoad == false)
            {
                _panelModel.Panel_CornerDriveArtNo = (CornerDrive_ArticleNo)cmb.SelectedValue;
            }
        }

        private void _pp_cornerDrivePropertyUC_PPCornerDriveCLoadEventRaised(object sender, EventArgs e)
        {
            _pp_cornerDrivePropertyUC.ThisBinding(CreateBindingDictionary());
            _initialLoad = false;
        }

        public IPP_CornerDrivePropertyUC GetPPCornerDriveUC()
        {
            return _pp_cornerDrivePropertyUC;
        }

        public IPP_CornerDrivePropertyUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IPP_CornerDrivePropertyUC, PP_CornerDrivePropertyUC>()
                .RegisterType<IPP_CornerDrivePropertyUCPresenter, PP_CornerDrivePropertyUCPresenter>();
            PP_CornerDrivePropertyUCPresenter presenter = unityC.Resolve<PP_CornerDrivePropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._panelModel = panelModel;

            return presenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();
            binding.Add("Panel_CornerDriveArtNo", new Binding("Text", _panelModel, "Panel_CornerDriveArtNo", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Panel_CornerDriveOptionsVisibility", new Binding("Visible", _panelModel, "Panel_CornerDriveOptionsVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }
    }
}
