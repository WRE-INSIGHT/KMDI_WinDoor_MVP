using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Divider;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ModelLayer.Tests
{
    [TestClass]
    public class MultiPanelModelUnitTest
    {
        IMultiPanelModel mpanelParent;
        [TestInitialize]
        public void SetUp()
        {
            mpanelParent = new MultiPanelModel(1,
                                               "MultiTransom_1",
                                               100,
                                               100,
                                               DockStyle.Fill,
                                               true,
                                               FlowDirection.TopDown,
                                               new Control(),
                                               new UserControl(),
                                               1,
                                               new List<IPanelModel>(),
                                               new List<IDividerModel>(),
                                               new List<IMultiPanelModel>(),
                                               1,
                                               new List<Control>());
        }

        [TestMethod]
        public void GetNextIndex_Test_EmptyBoth_IMultiPanelModel_IPanelModel()
        {
            int expected_index = 0;

            Assert.AreEqual(expected_index, mpanelParent.GetNextIndex());
        }

        [TestMethod]
        public void GetNextIndex_Test_IMultiPanelModelCountOne_IPanelModelCountZero()
        {
            int expected_index = 1;
            IMultiPanelModel mpanelChild1 = new MultiPanelModel(1,
                                                                "MultiMullion_1",
                                                                100,
                                                                100,
                                                                DockStyle.None,
                                                                true,
                                                                FlowDirection.TopDown,
                                                                new Control(),
                                                                new UserControl(),
                                                                1,
                                                                new List<IPanelModel>(),
                                                                new List<IDividerModel>(),
                                                                new List<IMultiPanelModel>(),
                                                                1,
                                                                new List<Control>());
            mpanelParent.MPanelLst_MultiPanel.Add(mpanelChild1);
            Assert.AreEqual(expected_index, mpanelParent.GetNextIndex());
        }

        [TestMethod]
        public void GetNextIndex_Test_IMultiPanelModelCountOne_IPanelModelCountOne()
        {
            int expected_index = 2;
            IMultiPanelModel mpanelChild1 = new MultiPanelModel(1,
                                                                "MultiMullion_1",
                                                                100,
                                                                100,
                                                                DockStyle.None,
                                                                true,
                                                                FlowDirection.TopDown,
                                                                new Control(),
                                                                new UserControl(),
                                                                1,
                                                                new List<IPanelModel>(),
                                                                new List<IDividerModel>(),
                                                                new List<IMultiPanelModel>(),
                                                                1,
                                                                new List<Control>());
            IPanelModel panelChild1 = new PanelModel(1,
                                                    "Panel_1",
                                                    100,
                                                    100,
                                                    DockStyle.None,
                                                    "Fixed Panel",
                                                    false,
                                                    new Control(),
                                                    new UserControl(),
                                                    true,
                                                    new UserControl(),
                                                    new UserControl(),
                                                    1);
            mpanelParent.MPanelLst_MultiPanel.Add(mpanelChild1);
            mpanelParent.MPanelLst_Panel.Add(panelChild1);
            Assert.AreEqual(expected_index, mpanelParent.GetNextIndex());
        }
    }
}
