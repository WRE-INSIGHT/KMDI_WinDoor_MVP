using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class SortItemUC : UserControl, ISortItemUC
    {
        public SortItemUC()
        {
            InitializeComponent();
        }
        public event EventHandler SortItemUCLoadEventRaised;

        public string ItemName
        {
            get
            {
                return lbl_item.Text;
            }
            set
            {
                lbl_item.Text = value;
            }
        }
        public PictureBox GetPboxItemImage()
        {
            return pboxItemImage;
        }
        //public string itemWindoorNumber
        //{
        //    get
        //    {
        //        return tboxWindoorNumber.Text;
        //    }
        //    set
        //    {
        //        tboxWindoorNumber.Text = value;
        //    }
        //}
        public string itemDesc
        {
            get
            {
                return rtboxDesc.Text;
            }
            set
            {
                rtboxDesc.Text = value;
            }
        }
        private void SortItemUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, SortItemUCLoadEventRaised, e);
        }
    }
}
