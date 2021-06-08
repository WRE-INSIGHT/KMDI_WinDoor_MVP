using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using System.Collections.Generic;
using System.Drawing;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class RedArrowLinesUnitTest
    {
        IBasePlatformPresenter _basePlatformPresenter;

        [TestInitialize]
        public void SetUp()
        {
            _basePlatformPresenter = new BasePlatformPresenter(new BasePlatformUC());
        }

        [TestMethod]
        public void WidthList_ToPaint_2Panel400x400()
        {
            /*  ___________
             * |     |     |
             * |     |     |
             * |     |     |
             * |_____|_____|
             */
            int total_wd = 400;
            int[,] given_arr = new int[2, 2] { { 200, 0 }, { 200, 200 } };

            List<int> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(2, actual_lst.Count);
            Assert.AreEqual(200, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
        }

        [TestMethod]
        public void WidthList_ToPaint_3Panel400x400()
        {
            /*  _______________
             * |     |   |     |
             * |     |   |     |
             * |     |   |     |
             * |_____|___|_____|
             */
            int total_wd = 400;
            int[,] given_arr = new int[3, 2] { { 100, 0 }, { 200, 100 }, { 100, 300} };

            List<int> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(100, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
            Assert.AreEqual(100, actual_lst[2]);
        }

        [TestMethod]
        public void WidthList_ToPaint_5Panel400x400()
        {
            /*  _______________
             * |       |       |
             * |       |       |
             * |_______|_______|
             * |    |     |    |
             * |____|_____|____|
             */
            int total_wd = 400;
            int[,] given_arr = new int[5, 2] { { 200, 0 }, 
                                               { 200, 200 }, 
                                               { 100, 0 }, 
                                               { 200, 100 } , 
                                               { 100, 300 }
                                            };

            List<int> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(100, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
            Assert.AreEqual(100, actual_lst[2]);
        }
    }
}
