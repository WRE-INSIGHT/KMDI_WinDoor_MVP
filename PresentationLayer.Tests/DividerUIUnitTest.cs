using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenter.UserControls.Dividers;
using Unity;
using Unity.Lifetime;
using PresentationLayer.Views.UserControls.Dividers;
using System.Windows.Forms;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class DividerUIUnitTest
    {
        IMullionUCPresenter _mullionUCP;

        IUnityContainer UnityC;

        [TestInitialize]
        public void SetUp()
        {
            UnityC = new UnityContainer()
               .RegisterType<IMullionUC, MullionUC>(new ContainerControlledLifetimeManager())
               .RegisterType<IMullionUCPresenter, MullionUCPresenter>(new ContainerControlledLifetimeManager());

            _mullionUCP = UnityC.Resolve<MullionUCPresenter>();
        }
        [TestMethod]
        public void MullionUC_Testing()
        {
            frmDividerTesting frm = new frmDividerTesting();

            IMullionUCPresenter mullionUCP = _mullionUCP.GetNewInstance(UnityC);
            IMullionUC mullionUC = mullionUCP.GetMullion();

            frm.Controls[0].Controls[0].Controls.Add((UserControl)mullionUC);
            frm.ShowDialog();
        }
    }
}
