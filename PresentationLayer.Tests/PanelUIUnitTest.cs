using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using Unity;
using Unity.Lifetime;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ServiceLayer.Services.PanelServices;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.CommonServices;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class PanelUIUnitTest
    {
        ICasementPanelUCPresenter _casementUCP;
        IAwningPanelUCPresenter _awningUCP;
        IUnityContainer UnityC;

        private IPanelModel _panelModel;

        [TestInitialize]
        public void SetUp()
        {
            UnityC = new UnityContainer()
                .RegisterType<IPanelModel, PanelModel>(new ContainerControlledLifetimeManager())

                .RegisterType<ICasementPanelUC, CasementPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>(new ContainerControlledLifetimeManager())

                .RegisterType<IAwningPanelUC, AwningPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IAwningPanelUCPresenter, AwningPanelUCPresenter>(new ContainerControlledLifetimeManager());

            _casementUCP = UnityC.Resolve<CasementPanelUCPresenter>();
            _awningUCP = UnityC.Resolve<AwningPanelUCPresenter>();

            frmUITest frm = new frmUITest();

            _panelModel = AddPanelModel(frm.Width,
                                        frm.Height,
                                        new UserControl(),
                                        new UserControl(),
                                        new UserControl(),
                                        "Awning",
                                        true,
                                        1);

    }

        public IPanelModel AddPanelModel(int panelWd,
                                     int panelHt,
                                     Control panelParent,
                                     UserControl panelFrameGroup,
                                     UserControl panelFramePropertiesGroup,
                                     string panelType,
                                     bool panelVisibility,
                                     int panelID = 0,
                                     string panelName = "",
                                     DockStyle panelDock = DockStyle.Fill,
                                     bool panelOrient = false)
        {
            if (panelName == "")
            {
                panelName = "Panel " + panelID;
            }

            IPanelServices _panelServices = new PanelServices(new ModelDataAnnotationCheck());
            _panelModel = _panelServices.CreatePanelModel(panelID,
                                                          panelName,
                                                          panelWd,
                                                          panelHt,
                                                          panelDock,
                                                          panelType,
                                                          panelOrient,
                                                          panelParent,
                                                          panelFrameGroup,
                                                          panelVisibility,
                                                          panelFramePropertiesGroup);

            return _panelModel;
        }

        [TestMethod]
        public void CasementUITest()
        {
            frmUITest frm = new frmUITest();
            IFrameModel frame = new FrameModel(1, "Frame 1", 400, 400, FrameModel.Frame_Padding.Door, true, new System.Collections.Generic.List<IPanelModel>());

            ICasementPanelUCPresenter casementUCP = _casementUCP.GetNewInstance(UnityC, _panelModel, frame);
            ICasementPanelUC casementUC = casementUCP.GetCasementPanelUC();
            frm.Controls.Add((UserControl)casementUC);
            frm.ShowDialog();
        }

        [TestMethod]
        public void AwningUITest()
        {
            frmUITest frm = new frmUITest();
            IFrameModel frame = new FrameModel(1, "Frame 1", 400, 400, FrameModel.Frame_Padding.Door, true, new System.Collections.Generic.List<IPanelModel>());

            IAwningPanelUCPresenter awningUCP = _awningUCP.GetNewInstance(UnityC, _panelModel, frame);
            IAwningPanelUC awningUC = awningUCP.GetAwningPanelUC();
            frm.Controls.Add((UserControl)awningUC);
            frm.ShowDialog();
        }
    }
}
