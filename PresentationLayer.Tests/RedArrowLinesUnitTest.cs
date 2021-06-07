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
            int total_wd = 400;
            Dictionary<int, Point> dict_WdPt = new Dictionary<int, Point>();
            dict_WdPt.Add(200, new Point(0, 0));
            dict_WdPt.Add(200, new Point(200, 0));

            List<int> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, dict_WdPt);

            Assert.AreEqual(200, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
        }
    }
}
