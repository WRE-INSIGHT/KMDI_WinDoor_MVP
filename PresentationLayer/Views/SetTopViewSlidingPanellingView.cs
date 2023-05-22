using CommonComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views
{
    public partial class SetTopViewSlidingPanellingView : Form, ISetTopViewSlidingPanellingView
    {
        public SetTopViewSlidingPanellingView()
        {
            InitializeComponent();
        }

        public event EventHandler SetTopViewSlidingPanellingViewLoadEventRaised;
        public event EventHandler btnAddLeftLineClickEventRaised;
        public event EventHandler btnMinusLeftLineClickEventRaised;
        public event EventHandler btnAddRightLineClickEventRaised;
        public event EventHandler btnMinusRightLineClickEventRaised;



        public event PaintEventHandler pnlSlidingArrowPaintEventRaised;
        public event PaintEventHandler pnlPanellingPaintEventRaised;


        public void GetSetTopSlidingPanellingView()
        {
            this.Show();
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            pbox_frame.DataBindings.Add(ModelBinding["pboxFrame"]);
            cmb_topViewType.DataBindings.Add(ModelBinding["WD_TopViewType"]);
        }

        public PictureBox GetPbox()
        {
            return pbox_frame;
        }

        public Panel GetPnlPannelling()
        {
            return pnl_panelling;
        }

        private void SetTopViewSlidingPanellingView_Load(object sender, EventArgs e)
        {
            List<TopViewType> topview = new List<TopViewType>();
            foreach (TopViewType item in TopViewType.GetAll())
            {
                topview.Add(item);
            }
            cmb_topViewType.DataSource = topview;

            EventHelpers.RaiseEvent(sender, SetTopViewSlidingPanellingViewLoadEventRaised, e);
        }

        private void pnl_SlidingArrow_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, pnlSlidingArrowPaintEventRaised, e);

        }

        private void pnl_SlidingArrow_SizeChanged(object sender, EventArgs e)
        {
            pnl_SlidingArrow.Invalidate();
            pnl_panelling.Invalidate();
        }

        private void pnl_panelling_Paint(object sender, PaintEventArgs e)
        {
            EventHelpers.RaisePaintEvent(sender, pnlPanellingPaintEventRaised, e);
        }

        private void btnAddLeftLine_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddLeftLineClickEventRaised, e);
        }

        private void btnMinusLeftLine_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnMinusLeftLineClickEventRaised, e);
        }

        private void btnAddRightLine_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnAddRightLineClickEventRaised, e);
        }

        private void btnMinusRightLine_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btnMinusRightLineClickEventRaised, e);
        }
    }
}
