using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using Moq;
using PresentationLayer.Presenter;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using Unity;

namespace PresentationLayer.Tests
{
    [TestClass]
    public class BasePlatformImagerTests
    {
        IBasePlatformImagerUCPresenter _basePlatformImagerUCPresenter;

        [TestInitialize]
        public void SetUp()
        {
            _basePlatformImagerUCPresenter = new BasePlatformImagerUCPresenter(new BasePlatformImagerUC());
        }

        [TestMethod]
        public void Can_Draw_1_Frame()
        {
            int basePlatformImage_Width = 400;
            List<Size> frame_sizes = new List<Size>();
            frame_sizes.Add(new Size(400, 400));

            List<Point> outerFrame_point = _basePlatformImagerUCPresenter.OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width);

            Assert.AreEqual(0, outerFrame_point[0].X);
            Assert.AreEqual(0, outerFrame_point[0].Y);
        }

        [TestMethod]
        public void Can_Draw_2_Frames()
        {
            int basePlatformImage_Width = 800;
            List<Size> frame_sizes = new List<Size>();
            frame_sizes.Add(new Size(400, 400));
            frame_sizes.Add(new Size(400, 400));

            List<Point> outerFrame_point = _basePlatformImagerUCPresenter.OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width);

            Assert.AreEqual(0, outerFrame_point[0].X);
            Assert.AreEqual(0, outerFrame_point[0].Y);
            Assert.AreEqual(400, outerFrame_point[1].X);
            Assert.AreEqual(0, outerFrame_point[1].Y);
        }
    }
}
