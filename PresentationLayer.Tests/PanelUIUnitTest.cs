using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using Unity;
using Unity.Lifetime;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class PanelUIUnitTest
    {
        ICasementPanelUCPresenter _casementUCP;
        [TestInitialize]
        public void SetUp()
        {
            IUnityContainer UnityC;
            UnityC = new UnityContainer()
                .RegisterType<ICasementPanelUC, CasementPanelUC>(new ContainerControlledLifetimeManager())
                .RegisterType<ICasementPanelUCPresenter, CasementPanelUCPresenter>(new ContainerControlledLifetimeManager());

            _casementUCP = UnityC.Resolve<CasementPanelUCPresenter>();
        }

        [TestMethod]
        public void CasementUITest()
        {
            frmUITest frm = new frmUITest();

            ICasementPanelUC casementUC = _casementUCP.GetCasementPanelUC();

            frm.ShowDialog();
        }
    }
}
