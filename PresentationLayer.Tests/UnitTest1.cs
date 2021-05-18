using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using System.Collections.Generic;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class UnitTest1
    {

        IBasePlatformPresenter _basePlatformPresenter;

        [TestInitialize]
        public void SetUp()
        {
            _basePlatformPresenter = new BasePlatformPresenter(new BasePlatformUC());
        }

        [TestMethod]
        public void TestMethod()
        {
            int total_wd = 400;
            List<int> lst_wd = new List<int>();
            lst_wd.Add(200);
            lst_wd.Add(200);
            lst_wd.Add(100);
            lst_wd.Add(100);
            lst_wd.Add(100);
            lst_wd.Add(100);


            List<int> actual_lst_wd = _basePlatformPresenter.lst_wd_toPaint(400, lst_wd);

            Assert.AreEqual(200, actual_lst_wd[0]);
        }

    }
}
