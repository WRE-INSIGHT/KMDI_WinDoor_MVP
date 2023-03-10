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
        private IScreenPresenter _screenPresenter;

        private ISP_PVCboxPropertyUCPresenter _sp_pVCboxPropertyUCPresenter;
        private ISP_CenterClosurePropertyUCPresenter _sp_CenterClosurePropertyUCPresenter;
        private ISP_SpringLoadedUCPresenter _sp_SpringLoadedPresenter;
        private ISP_MagnumScreenTypeUCPresenter _sp_magnumScreenTypePresenter;
        private ISP_PVCbox1067WithReinPropertyUCPresenter _sp_pvcbox1067WithReinPropertyUCPresenter;
        private ISP_6040MilledProfileWithReinforcementPropertyUCPresenter _sp_6040milledProfilewithreinforcementPropertyUCPresenter;
        private ISP_LandCoverPropertyUCPresenter _sp_landCoverPresenter;
        private ISP_373or374MilledProfilePropertyUCPresenter _sp_373or374MilledProfilePropertyUCPresenter;
        private ISP_1385MilledProfilePropertyUCPresenter _sp_1385MilledProfilePropertyUCPresenter;
        private ISP_6052MilledProfilePropertyUCPresenter _sp_6052MilledProfilePropertyUCPresenter;


        Panel _pnlAddOns;
       
      
        public ScreenAddOnPropertiesUCPresenter(IScreenAddOnPropertiesUC sp_screenAddOnPropertiesUC,
                                                ISP_PVCboxPropertyUCPresenter sp_pVCboxPropertyUCPresenter,
                                                ISP_CenterClosurePropertyUCPresenter sp_CenterClosurePropertyUCPresenter,
                                                ISP_SpringLoadedUCPresenter sp_springLoadedPresenter,
                                                ISP_MagnumScreenTypeUCPresenter sp_magnumScreenTypeUCPresenter,
                                                ISP_PVCbox1067WithReinPropertyUCPresenter sp_pvcbox1067WithReinPropertyUCPresenter,
                                                ISP_6040MilledProfileWithReinforcementPropertyUCPresenter sp_6040milledProfilewithreinforcementPropertyUCPresenter,
                                                ISP_LandCoverPropertyUCPresenter landCoverPresenter,
                                                ISP_373or374MilledProfilePropertyUCPresenter sp_373or374MilledProfilePropertyUCPresenter,
                                                ISP_1385MilledProfilePropertyUCPresenter sp_1385MilledProfilePropertyUCPresenter,
                                                ISP_6052MilledProfilePropertyUCPresenter sp_6052MilledProfilePropertyUCPresenter
                                                )
        {
            _screenAddOnPropertiesUC = sp_screenAddOnPropertiesUC;
            _sp_pVCboxPropertyUCPresenter = sp_pVCboxPropertyUCPresenter;
            _sp_CenterClosurePropertyUCPresenter = sp_CenterClosurePropertyUCPresenter;
            _sp_SpringLoadedPresenter = sp_springLoadedPresenter;
            _sp_magnumScreenTypePresenter = sp_magnumScreenTypeUCPresenter;
            _sp_pvcbox1067WithReinPropertyUCPresenter = sp_pvcbox1067WithReinPropertyUCPresenter;
            _sp_6040milledProfilewithreinforcementPropertyUCPresenter = sp_6040milledProfilewithreinforcementPropertyUCPresenter;
            _sp_landCoverPresenter = landCoverPresenter;
            _sp_373or374MilledProfilePropertyUCPresenter = sp_373or374MilledProfilePropertyUCPresenter;
            _sp_1385MilledProfilePropertyUCPresenter = sp_1385MilledProfilePropertyUCPresenter;
            _sp_6052MilledProfilePropertyUCPresenter = sp_6052MilledProfilePropertyUCPresenter;
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
          
            ISP_6052MilledProfilePropertyUCPresenter milled6052profilepresenter = _sp_6052MilledProfilePropertyUCPresenter.CreateNewInstance(_unityC,_mainPresenter,_screenModel,_screenPresenter);
            UserControl milled6052presenter = (UserControl)milled6052profilepresenter.Get6052MilledProfilePropertyUC();
            _pnlAddOns.Controls.Add(milled6052presenter);
            milled6052presenter.Dock = DockStyle.Top;
            milled6052presenter.BringToFront();

            
            ISP_1385MilledProfilePropertyUCPresenter milled1385profilepresenter = _sp_1385MilledProfilePropertyUCPresenter.CreateNewInstance(_unityC,_mainPresenter,_screenModel,_screenPresenter);
            UserControl miled1385presenter = (UserControl)milled1385profilepresenter.Get1385MilledProfilePropertyUC();
            _pnlAddOns.Controls.Add(miled1385presenter);
            miled1385presenter.Dock = DockStyle.Top;
            miled1385presenter.BringToFront();

            ISP_373or374MilledProfilePropertyUCPresenter milled373or374profilepresenter = _sp_373or374MilledProfilePropertyUCPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
            UserControl milled373or374presenter = (UserControl)milled373or374profilepresenter.Get373or374MilledProfilePropertyUC();
            _pnlAddOns.Controls.Add(milled373or374presenter);
            milled373or374presenter.Dock = DockStyle.Top;
            milled373or374presenter.BringToFront();

            ISP_LandCoverPropertyUCPresenter landCoverPresenter = _sp_landCoverPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl landcover = (UserControl)landCoverPresenter.GetLandCoverPropertyUC();
            _pnlAddOns.Controls.Add(landcover);
            landcover.Dock = DockStyle.Top;
            landcover.BringToFront();

            ISP_6040MilledProfileWithReinforcementPropertyUCPresenter _6040milledprofilewithrein = _sp_6040milledProfilewithreinforcementPropertyUCPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
            UserControl _6040milledprofile = (UserControl)_6040milledprofilewithrein.Get6040MilledProfile();
            _pnlAddOns.Controls.Add(_6040milledprofile);
            _6040milledprofile.Dock = DockStyle.Top;
            _6040milledprofile.BringToFront();

            ISP_PVCbox1067WithReinPropertyUCPresenter pvcbox1067withreinprop = _sp_pvcbox1067WithReinPropertyUCPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
            UserControl pvc1067withrein = (UserControl)pvcbox1067withreinprop.GetPVCbox1067WithReinPropertyUC();
            _pnlAddOns.Controls.Add(pvc1067withrein);
            pvc1067withrein.Dock = DockStyle.Top;
            pvc1067withrein.BringToFront();

            ISP_MagnumScreenTypeUCPresenter magnumScreenTypeUCP = _sp_magnumScreenTypePresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl magnumScreenType = (UserControl)magnumScreenTypeUCP.GetMagnumScreenTypeView();
            _pnlAddOns.Controls.Add(magnumScreenType);
            magnumScreenType.Dock = DockStyle.Top;
            magnumScreenType.BringToFront();

            ISP_SpringLoadedUCPresenter springloadedUCP = _sp_SpringLoadedPresenter.GetNewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
            UserControl springloadedUC = (UserControl)springloadedUCP.GetspringloadedUC();
            _pnlAddOns.Controls.Add(springloadedUC);
            springloadedUC.Dock = DockStyle.Top;
            springloadedUC.BringToFront();


            ISP_PVCboxPropertyUCPresenter pvcBoxPropUCP = _sp_pVCboxPropertyUCPresenter.CreatenewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
            UserControl pvcBoxProp = (UserControl)pvcBoxPropUCP.GetPVCboxPropertyUC();
            _pnlAddOns.Controls.Add(pvcBoxProp);
            pvcBoxProp.Dock = DockStyle.Top;
            pvcBoxProp.BringToFront();

            _screenModel.Screen_CenterClosureVisibility = true;
            _screenModel.Screen_CenterClosureVisibilityOption = true;
            ISP_CenterClosurePropertyUCPresenter centerClosurePropUCP = _sp_CenterClosurePropertyUCPresenter.CreateNewInstance(_unityC, _mainPresenter, _screenModel,_screenPresenter);
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
                                                                    IScreenModel screenModel,
                                                                    IScreenPresenter screenPresenter)
        {
            unityC
                    .RegisterType<IScreenAddOnPropertiesUC, ScreenAddOnPropertiesUC>()
                    .RegisterType<IScreenAddOnPropertiesUCPresenter, ScreenAddOnPropertiesUCPresenter>();
            ScreenAddOnPropertiesUCPresenter screenAddOns = unityC.Resolve<ScreenAddOnPropertiesUCPresenter>();
            screenAddOns._unityC = unityC;
            screenAddOns._mainPresenter = mainPresenter;
            screenAddOns._screenModel = screenModel;
            screenAddOns._screenPresenter = screenPresenter;
            return screenAddOns;
        }




    }
}
