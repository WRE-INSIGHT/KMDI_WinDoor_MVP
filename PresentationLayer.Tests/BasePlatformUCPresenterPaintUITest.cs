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


        #region 400x400Test

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
            Assert.AreEqual(100, actual_lst_wd[1]);
            Assert.AreEqual(100, actual_lst_wd[2]);
            Assert.AreEqual(100, actual_lst_wd[3]);

            Assert.AreEqual(4, actual_lst_wd.Count);
            Assert.AreEqual(6, lst_wd.Count);
        }


        [TestMethod]
        public void leastHtTest()
        {
            int total_ht = 400;
            List<int> lst_ht = new List<int>();
            lst_ht.Add(200);
            lst_ht.Add(200);
            lst_ht.Add(200);
            lst_ht.Add(200);
            lst_ht.Add(200);
            lst_ht.Add(200);

            List<int> actual_lst_ht = _basePlatformPresenter.lst_ht_toPaint(total_ht, lst_ht);

            Assert.AreEqual(200, actual_lst_ht[0]);
            Assert.AreEqual(200, actual_lst_ht[1]);

            Assert.AreEqual(2, actual_lst_ht.Count);
            Assert.AreEqual(6, lst_ht.Count);
        }

        #endregion


        #region 550x1200Test
        [TestMethod]
        public void leastWdTest2()
        {
            int total_wd = 550;
            List<int> lst_wd = new List<int>();
            lst_wd.Add(550);
            lst_wd.Add(550);
            lst_wd.Add(550);
            lst_wd.Add(550);
            lst_wd.Add(225);
            lst_wd.Add(225);


            List<int> actual_lst_wd = _basePlatformPresenter.lst_wd_toPaint(total_wd, lst_wd);

            Assert.AreEqual(225, actual_lst_wd[0]);
            Assert.AreEqual(225, actual_lst_wd[1]);
           


            Assert.AreEqual(2, actual_lst_wd.Count);
            Assert.AreEqual(6, lst_wd.Count);
        }


        [TestMethod]
        public void leastHtTest2()
        {
            int total_ht = 1200;
            List<int> lst_ht = new List<int>();
            lst_ht.Add(600);
            lst_ht.Add(600);
            lst_ht.Add(150);
            lst_ht.Add(150);
            lst_ht.Add(150);
            lst_ht.Add(150);

            List<int> actual_lst_ht = _basePlatformPresenter.lst_ht_toPaint(total_ht, lst_ht);

            Assert.AreEqual(150, actual_lst_ht[0]);
            Assert.AreEqual(150, actual_lst_ht[1]);
            Assert.AreEqual(150, actual_lst_ht[2]);
            Assert.AreEqual(150, actual_lst_ht[3]);
            Assert.AreEqual(600, actual_lst_ht[4]);
           // Assert.AreEqual(150, actual_lst_ht[5]);
            //Assert.AreEqual(150, actual_lst_ht[6]);
            //Assert.AreEqual(150, actual_lst_ht[7]);




            Assert.AreEqual(5, actual_lst_ht.Count);
            Assert.AreEqual(6, lst_ht.Count);
        }

        #endregion




    }
}
