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
        }

        private void OnFixedPanelUCLoadEventRaised(object sender, EventArgs e)
        {
            
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

        public IFixedPanelUC GetFixedPanelUCAsThumbnail()
        {
            _fixedPanelUC.thisdock = DockStyle.Fill;
            return _fixedPanelUC;
        }
    }
}
