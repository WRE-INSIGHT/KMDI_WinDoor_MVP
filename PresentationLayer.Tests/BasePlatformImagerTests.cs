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
            //400w x 400h basePlatformImager
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
            //800w x 400h basePlatformImager

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

        [TestMethod]
        public void Can_Draw_3_Frames()
        {
            //800w x 800h basePlatformImager
            //0.5f zoom means reduced to half (400w x 400h)

            int basePlatformImage_Width = 400;
            List<Size> frame_sizes = new List<Size>();
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));

            List<Point> outerFrame_point = _basePlatformImagerUCPresenter.OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width);

            Assert.AreEqual(0, outerFrame_point[0].X);
            Assert.AreEqual(0, outerFrame_point[0].Y);
            Assert.AreEqual(200, outerFrame_point[1].X);
            Assert.AreEqual(0, outerFrame_point[1].Y);
            Assert.AreEqual(0, outerFrame_point[2].X);
            Assert.AreEqual(200, outerFrame_point[2].Y);
        }

        [TestMethod]
        public void Can_Draw_4_Frames()
        {
            //800w x 800h basePlatformImager
            //0.5f zoom means reduced to half (400w x 400h)

            int basePlatformImage_Width = 400;
            List<Size> frame_sizes = new List<Size>();
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));

            List<Point> outerFrame_point = _basePlatformImagerUCPresenter.OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width);

            Assert.AreEqual(0, outerFrame_point[0].X);
            Assert.AreEqual(0, outerFrame_point[0].Y);
            Assert.AreEqual(200, outerFrame_point[1].X);
            Assert.AreEqual(0, outerFrame_point[1].Y);
            Assert.AreEqual(0, outerFrame_point[2].X);
            Assert.AreEqual(200, outerFrame_point[2].Y);
            Assert.AreEqual(200, outerFrame_point[3].X);
            Assert.AreEqual(200, outerFrame_point[3].Y);
        }

        [TestMethod]
        public void Can_Draw_5_Frames()
        {
            //800w x 1200h basePlatformImager
            //0.5f zoom means reduced to half (400w x 600h)

            int basePlatformImage_Width = 400;
            List<Size> frame_sizes = new List<Size>();
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));
            frame_sizes.Add(new Size(200, 200));

            List<Point> outerFrame_point = _basePlatformImagerUCPresenter.OuterFrame_DrawPoints(frame_sizes, basePlatformImage_Width);

            Assert.AreEqual(0, outerFrame_point[0].X);
            Assert.AreEqual(0, outerFrame_point[0].Y);

            Assert.AreEqual(200, outerFrame_point[1].X);
            Assert.AreEqual(0, outerFrame_point[1].Y);

            Assert.AreEqual(0, outerFrame_point[2].X);
            Assert.AreEqual(200, outerFrame_point[2].Y);

            Assert.AreEqual(200, outerFrame_point[3].X);
            Assert.AreEqual(200, outerFrame_point[3].Y);

            Assert.AreEqual(0, outerFrame_point[4].X);
            Assert.AreEqual(400, outerFrame_point[4].Y);
        }
    }
}
