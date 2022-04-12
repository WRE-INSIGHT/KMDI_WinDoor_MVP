using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CustomArrowHeadView : Form, ICustomArrowHeadView
    {
        public CustomArrowHeadView()
        {
            InitializeComponent();
        }
        public event EventHandler BtnAddArrowHeadWidthCkickEventRaised;
        public event EventHandler BtnAddArrowHeadHeightCkickEventRaised;
        public event EventHandler BtnSaveCustomArrowCkickEventRaised;
        public event EventHandler CustomArrowHeadViewLoadEventRaised;


        public Panel GetPnlArrowWD()
        {
            return pnl_ArrowWidth;
        }
        public Panel GetPnlArrowHT()
        {
            return pnl_ArrowHeight;
        }

        private void btn_AddArrowHeadWidth_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnAddArrowHeadWidthCkickEventRaised, e);
        }


  

        public void SetBtnSaveBackColor(Color color)
        {
            btn_SaveCustomArrow.BackColor = color;
        }

        public void SetLblTotalArrowLength_Text(string totalArrowWd, string totalArrowHt)
        {
            lbl_ArrowWidthLength.Text = totalArrowWd;
            lbl_ArrowHeightLength.Text = totalArrowHt;
            //SetLblTotalArrowLength_BackColor();
        }

        private void SetLblTotalArrowLength_BackColor()
        {
            int totalArrowHT = Convert.ToInt32(lbl_ArrowHeightLength.Text);
            int totalArrowWD = Convert.ToInt32(lbl_ArrowWidthLength.Text);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            pnl_ArrowHeight.DataBindings.Add(ModelBinding["Pnl_ArrowHeightVisibility"]);
            pnl_ArrowWidth.DataBindings.Add(ModelBinding["Pnl_ArrowWidthVisibility"]);
            lbl_ArrowHtCount.DataBindings.Add(ModelBinding["Lbl_ArrowHtCount"]);
            lbl_ArrowWdCount.DataBindings.Add(ModelBinding["Lbl_ArrowWdCount"]);
        }


        public void ShowCustomArrowHead()
        {
            this.Show();
        }

        private void CustomArrowHeadView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, CustomArrowHeadViewLoadEventRaised , e);
        }

        private void btn_SaveCustomArrow_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnSaveCustomArrowCkickEventRaised, e);
        }

        private void btn_AddArrowHeadHeight_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnAddArrowHeadHeightCkickEventRaised, e);
        }
    }
}
