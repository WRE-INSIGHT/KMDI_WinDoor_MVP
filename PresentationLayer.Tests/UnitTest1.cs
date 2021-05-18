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
        public void leastWdTest()
        {
            int total_wd = 400;
            List<int> lst_wd = new List<int>();
            lst_wd.Add(200);
            lst_wd.Add(200);
            lst_wd.Add(100);
            lst_wd.Add(100);
            lst_wd.Add(100);
            lst_wd.Add(100);


            List<int> actual_lst_wd = _basePlatformPresenter.lst_wd_toPaint(total_wd, lst_wd);

            Assert.AreEqual(100, actual_lst_wd[0]);
            Assert.AreEqual(200, actual_lst_wd[1]);
            Assert.AreEqual(300, actual_lst_wd[2]);
            Assert.AreEqual(400, actual_lst_wd[3]);

            Assert.AreEqual(200, lst_wd[0]);
            Assert.AreEqual(200, lst_wd[1]);
            Assert.AreEqual(100, lst_wd[2]);
            Assert.AreEqual(100, lst_wd[3]);
            Assert.AreEqual(100, lst_wd[4]);
            Assert.AreEqual(100, lst_wd[5]);

            Assert.AreEqual(4, actual_lst_wd.Count);
            Assert.AreEqual(6, lst_wd.Count);
        }

    }
}
