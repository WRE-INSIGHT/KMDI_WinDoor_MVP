﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using ModelLayer.Model.Quotation.Panel;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class FixedPanelUCPresenter : IFixedPanelUCPresenter
    {
        IFixedPanelUC _fixedPanelUC;

        private IPanelModel _panelModel;

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
    }
}
