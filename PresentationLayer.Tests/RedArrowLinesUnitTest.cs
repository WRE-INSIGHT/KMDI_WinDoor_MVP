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
            decimal[,] given_arr = new decimal[2, 2] { { 200, 0 }, { 200, 200 } };

            List<decimal> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

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
            decimal[,] given_arr = new decimal[3, 2] { { 100, 0 }, { 200, 100 }, { 100, 300} };

            List<decimal> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

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
            decimal[,] given_arr = new decimal[5, 2] { { 200, 0 }, 
                                               { 200, 200 }, 
                                               { 100, 0 }, 
                                               { 200, 100 } , 
                                               { 100, 300 }
                                            };

            List<decimal> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(100, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
            Assert.AreEqual(100, actual_lst[2]);
        }

        [TestMethod]
        public void WidthList_ToPaint_6Panel1800x1600()
        {
            /*  _________________________
             *  |       |       |       | 
             *  |       |       |       |
             *  |_______|_______|_______|
             *  |       |       |       |
             *  |       |       |       |
             *  |_______|_______|_______|
             */
            int total_wd = 1800;
            decimal[,] given_arr = new decimal[6, 2] { { 600, 0 },
                                               { 600, 0 },
                                               { 600, 600 },
                                               { 600, 600 },
                                               { 600, 1200 },
                                               { 600, 1200 }
                                            };

            List<decimal> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(600, actual_lst[0]);
            Assert.AreEqual(600, actual_lst[1]);
            Assert.AreEqual(600, actual_lst[2]);
        }

        [TestMethod]
        public void WidthList_ToPaint_11Panel2400x1900()
        {
            /*  _________________________
             *  |   |   |       |   |   | 
             *  |___|___|       |___|___|
             *  |   |   |       |   |   |
             *  |___|___|       |___|___|
             *  |       |       |       |
             *  |_______|_______|_______|
             */
            int total_wd = 2400;
            decimal[,] given_arr = new decimal[11, 2] { { 792, 690 },
                                                { 804, 484 },
                                                { 804, 896 },
                                                { 402, 484 },
                                                { 402, 587 },
                                                { 402, 484 },
                                                { 402, 587 },
                                                { 402, 896 },
                                                { 402, 999 },
                                                { 402, 896 },
                                                { 402, 999 }
                                            };

            List<decimal> actual_lst = _basePlatformPresenter.WidthList_ToPaint(total_wd, given_arr);

            Assert.AreEqual(5, actual_lst.Count);
            Assert.AreEqual(402, actual_lst[0]);
            Assert.AreEqual(402, actual_lst[1]);
            Assert.AreEqual(792, actual_lst[2]);
            Assert.AreEqual(402, actual_lst[3]);
            Assert.AreEqual(402, actual_lst[4]);
        }

        [TestMethod]
        public void HeightList_ToPaint2Panel400x400()
        {
            /*  ________
             * |        |
             * |________|
             * |        |
             * |________|
             */
            int total_ht = 400;
            decimal[,] given_arr = new decimal[2, 2] { { 200, 0 }, { 200, 200 } };

            List<decimal> actual_lst = _basePlatformPresenter.HeightList_ToPaint(total_ht, given_arr);

            Assert.AreEqual(2, actual_lst.Count);
            Assert.AreEqual(200, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
        }

        [TestMethod]
        public void HeightList_ToPaint_3Panel400x400()
        {
            /*  ___________
             * |           |
             * |___________|
             * |           |
             * |___________|
             * |           |
             * |___________|
             */

            int total_ht = 400;
            decimal[,] given_arr = new decimal[3, 2] { { 100, 0 }, { 200, 100 }, { 100, 300 } };

            List<decimal> actual_lst = _basePlatformPresenter.HeightList_ToPaint(total_ht, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(100, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
            Assert.AreEqual(100, actual_lst[2]);
        }

        [TestMethod]
        public void HeightList_ToPaint_5Panel400x400()
        {
            /*  _______________
             * |       |       |
             * |       |_______|
             * |       |       |
             * |_______|       |
             * |       |       |
             * |       |_______|
             * |       |       |
             * |_______|_______|
             */

            int total_ht = 400;
            decimal[,] given_arr = new decimal[5, 2] { { 200, 0 },
                                               { 200, 200 },
                                               { 100, 0 },
                                               { 200, 100 } ,
                                               { 100, 300 }
                                            };

            List<decimal> actual_lst = _basePlatformPresenter.HeightList_ToPaint(total_ht, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(100, actual_lst[0]);
            Assert.AreEqual(200, actual_lst[1]);
            Assert.AreEqual(100, actual_lst[2]);
        }

        [TestMethod]
        public void HeightList_ToPaint_6Panel1800x1600()
        {
            /*  _________________________
             *  |       |       |       | 
             *  |       |       |       |
             *  |_______|_______|_______|
             *  |       |       |       |
             *  |       |       |       |
             *  |_______|_______|_______|
             */
            int total_ht = 1600;
            decimal[,] given_arr = new decimal[6, 2] { { 533, 0 },
                                               { 533, 0 },
                                               { 533, 533 },
                                               { 533, 533 },
                                               { 533, 1066 },
                                               { 533, 1066 }
                                            };

            List<decimal> actual_lst = _basePlatformPresenter.HeightList_ToPaint(total_ht, given_arr);

            Assert.AreEqual(3, actual_lst.Count);
            Assert.AreEqual(533, actual_lst[0]);
            Assert.AreEqual(533, actual_lst[1]);
            Assert.AreEqual(533, actual_lst[2]);
        }
    }
}
