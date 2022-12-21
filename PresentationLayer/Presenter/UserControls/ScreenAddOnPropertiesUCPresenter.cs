using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Views.UserControls;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ScreenAddOnPropertiesUCPresenter : IScreenAddOnPropertiesUCPresenter
    {
        IScreenAddOnPropertiesUC _screenAddOnPropertiesUC;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IScreenModel _screenModel;

        private ISP_PVCboxPropertyUCPresenter _sp_pVCboxPropertyUCPresenter;
        private ISP_CenterClosurePropertyUCPresenter _sp_CenterClosurePropertyUCPresenter;
        private ISP_SpringLoadedUCPresenter _sp_SpringLoadedPresenter;
        private ISP_MagnumScreenTypeUCPresenter _sp_magnumScreenTypePresenter;

        Panel _pnlAddOns;
       
      
        public ScreenAddOnPropertiesUCPresenter(IScreenAddOnPropertiesUC sp_screenAddOnPropertiesUC,
                                                ISP_PVCboxPropertyUCPresenter sp_pVCboxPropertyUCPresenter,
                                                ISP_CenterClosurePropertyUCPresenter sp_CenterClosurePropertyUCPresenter,
                                                ISP_SpringLoadedUCPresenter sp_springLoadedPresenter,
                                                ISP_MagnumScreenTypeUCPresenter sp_magnumScreenTypeUCPresenter)
        {
            _screenAddOnPropertiesUC = sp_screenAddOnPropertiesUC;
            _sp_pVCboxPropertyUCPresenter = sp_pVCboxPropertyUCPresenter;
            _sp_CenterClosurePropertyUCPresenter = sp_CenterClosurePropertyUCPresenter;
            _sp_SpringLoadedPresenter = sp_springLoadedPresenter;
            _sp_magnumScreenTypePresenter = sp_magnumScreenTypeUCPresenter;

            _pnlAddOns = _screenAddOnPropertiesUC.GetPanelAddOns();
            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _screenAddOnPropertiesUC.ScreenAddOnPropertiesUCLoadEventRaised += _sp_screenAddOnPropertiesUC_ScreenAddOnPropertiesUCLoadEventRaised;
            _screenAddOnPropertiesUC.btnAddMatsClickEventRaised += _screenAddOnPropertiesUC_btnAddMatsClickEventRaised;
        }

        #region Events  

        private void _screenAddOnPropertiesUC_btnAddMatsClickEventRaised(object sender, EventArgs e)
        {
          //do somehting  
        }

        private void _sp_screenAddOnPropertiesUC_ScreenAddOnPropertiesUCLoadEventRaised(object sender, EventArgs e)
        {

            ISP_MagnumScreenTypeUCPresenter magnumScreenTypeUCP = _sp_magnumScreenTypePresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl magnumScreenType = (UserControl)magnumScreenTypeUCP.GetMagnumScreenTypeView();
            _pnlAddOns.Controls.Add(magnumScreenType);
            magnumScreenType.Dock = DockStyle.Top;
            magnumScreenType.BringToFront();

            ISP_SpringLoadedUCPresenter springloadedUCP = _sp_SpringLoadedPresenter.GetNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl springloadedUC = (UserControl)springloadedUCP.GetspringloadedUC();
            _pnlAddOns.Controls.Add(springloadedUC);
            springloadedUC.Dock = DockStyle.Top;
            springloadedUC.BringToFront();

            _screenModel.Screen_PVCVisibility = true;
            ISP_PVCboxPropertyUCPresenter pvcBoxPropUCP = _sp_pVCboxPropertyUCPresenter.CreatenewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl pvcBoxProp = (UserControl)pvcBoxPropUCP.GetPVCboxPropertyUC();
            _pnlAddOns.Controls.Add(pvcBoxProp);
            pvcBoxProp.Dock = DockStyle.Top;
            pvcBoxProp.BringToFront();

            _screenModel.Screen_CenterClosureVisibility = true;
            _screenModel.Screen_CenterClosureVisibilityOption = true;
            ISP_CenterClosurePropertyUCPresenter centerClosurePropUCP = _sp_CenterClosurePropertyUCPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl centerClosureProp = (UserControl)centerClosurePropUCP.GetISP_CenterClosurePropertyUC();
            _pnlAddOns.Controls.Add(centerClosureProp);
            centerClosureProp.Dock = DockStyle.Top;
            centerClosureProp.BringToFront();



        }


        #endregion

        public IScreenAddOnPropertiesUC GetScreenAddOnPropertiesUCView()
        {
            return _screenAddOnPropertiesUC;
        }

        public IScreenAddOnPropertiesUCPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter,
                                                                    IScreenModel screenModel)
        {
            unityC
                    .RegisterType<IScreenAddOnPropertiesUC, ScreenAddOnPropertiesUC>()
                    .RegisterType<IScreenAddOnPropertiesUCPresenter, ScreenAddOnPropertiesUCPresenter>();
            ScreenAddOnPropertiesUCPresenter screenAddOns = unityC.Resolve<ScreenAddOnPropertiesUCPresenter>();
            screenAddOns._unityC = unityC;
            screenAddOns._mainPresenter = mainPresenter;
            screenAddOns._screenModel = screenModel;
            return screenAddOns;
        }




    }
}
