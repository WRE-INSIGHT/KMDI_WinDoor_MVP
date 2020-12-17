using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class FixedPanelUCPresenter : IFixedPanelUCPresenter
    {

        IFixedPanelUC _fixedPanelUC;

        private IPanelModel _panelModel;

        private IUnityContainer _unityC;

        public FixedPanelUCPresenter(IFixedPanelUC fixedPanelUC)
        {
            _fixedPanelUC = fixedPanelUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _fixedPanelUC.fixedPanelUCLoadEventRaised += new EventHandler(OnFixedPanelUCLoadEventRaised);
            _fixedPanelUC.fixedPanelUCSizeChangedEventRaised += new EventHandler(OnFixedPanelUCSizeChangedEventRaised);
        }

        private void OnFixedPanelUCSizeChangedEventRaised(object sender, EventArgs e)
        {
            try
            {
                int thisWd = ((UserControl)sender).Width,
                    thisHt = ((UserControl)sender).Height,
                    pnlModelWd = _panelModel.Panel_Width,
                    pnlModelHt = _panelModel.Panel_Height;

                if (thisWd != pnlModelWd)
                {
                    _panelModel.Panel_Width = thisWd;
                }
                if (thisHt != pnlModelHt)
                {
                    _panelModel.Panel_Height = thisHt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFixedPanelUCLoadEventRaised(object sender, EventArgs e)
        {
            //_fixedPanelUC.ThisBinding(CreateBindingDictionary());
        }
        private Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Width", new Binding("Width", _panelModel, "Panel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Height", new Binding("Height", _panelModel, "Panel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC, IPanelModel panelModel)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._panelModel = panelModel;

            return fixedPanelUCP;
        }

        public IFixedPanelUC GetFixedPanelUC()
        {
            _fixedPanelUC.ThisBinding(CreateBindingDictionary());
            return _fixedPanelUC;
        }

        public IFixedPanelUCPresenter GetNewInstance(IUnityContainer unityC)
        {
            unityC
                .RegisterType<IFixedPanelUC, FixedPanelUC>()
                .RegisterType<IFixedPanelUCPresenter, FixedPanelUCPresenter>();
            FixedPanelUCPresenter fixedPanelUCP = unityC.Resolve<FixedPanelUCPresenter>();
            fixedPanelUCP._unityC = unityC;

            return fixedPanelUCP;
        }
    }
}
