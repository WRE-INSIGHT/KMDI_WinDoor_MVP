using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class CustomArrowHeadUC : UserControl, ICustomArrowHeadUC
    {
        public CustomArrowHeadUC()
        {
            InitializeComponent();
        }

        private int _arrowWidthId;
        public int ArrowWidthId
        {
            get
            {
                return _arrowWidthId;
            }
            set
            {
                _arrowWidthId = value;
            }
        }

        public int Arrow_Size
        {
            get
            {
                return (int)nud_ArrowSize.Value;
            }
            set
            {
                nud_ArrowSize.Value = value;
            }
        }
        public event EventHandler NudArrowSizeValueChangeEventRaised;
        public event EventHandler BtnDeleteArrowHeadClickEventRaised;

        private void btn_DeleteArrowHead_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, BtnDeleteArrowHeadClickEventRaised, e);
        }

        private void nud_ArrowSize_ValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, NudArrowSizeValueChangeEventRaised, e);
        }
    }
}
