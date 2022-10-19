﻿using ModelLayer.Model.Quotation.Screen;
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


        Panel _pnlAddOns;
        public ScreenAddOnPropertiesUCPresenter(IScreenAddOnPropertiesUC sp_screenAddOnPropertiesUC,
                                                ISP_PVCboxPropertyUCPresenter sp_pVCboxPropertyUCPresenter)
        {
            _screenAddOnPropertiesUC = sp_screenAddOnPropertiesUC;
            _sp_pVCboxPropertyUCPresenter = sp_pVCboxPropertyUCPresenter;

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
            _screenModel.Screen_PVCVisibility = true;
            ISP_PVCboxPropertyUCPresenter pvcBoxPropUCP = _sp_pVCboxPropertyUCPresenter.CreatenewInstance(_unityC, _mainPresenter, _screenModel);
            UserControl pvcBoxProp = (UserControl)pvcBoxPropUCP.GetPVCboxPropertyUC();
            _pnlAddOns.Controls.Add(pvcBoxProp);
            pvcBoxProp.Dock = DockStyle.Top;
            pvcBoxProp.BringToFront();
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