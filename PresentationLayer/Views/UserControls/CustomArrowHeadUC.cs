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

        private int _arrowId;
        public int ArrowId
        {
            get
            {
                return _arrowId;
            }
            set
            {
                _arrowId = value;
            }
        }

        public decimal Arrow_Size
        {
            get
            {
                return nud_ArrowSize.Value;
            }
            set
            {
                nud_ArrowSize.Value = value;
            }
        }
        public int ArrowCountWD
        {
            get
            {
                return Convert.ToInt32(lbl_count.Text);
            }
            set
            {
                lbl_count.Text = Convert.ToString(value);
            }
        }

        public int ArrowCountHT
        {
            get
            {
                return Convert.ToInt32(lbl_count.Text);
            }
            set
            {
                lbl_count.Text = Convert.ToString(value);
            }
        }

        public string ArrowHeadName
        {
            get
            {
                return lbl_ArrowHead.Text;
            }
            set
            {
                lbl_ArrowHead.Text = value;
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

        private void CustomArrowHeadUC_Load(object sender, EventArgs e)
        {
            //nud_ArrowSize.Maximum = decimal.MaxValue;
        }
        public void SetNudMaxValue()
        {
            nud_ArrowSize.Maximum = decimal.MaxValue;
        }
    }
}
