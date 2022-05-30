using CommonComponents;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class QuoteItemListUC : UserControl, IQuoteItemListUC
    {
        public QuoteItemListUC()
        {
            InitializeComponent();
        }

        public string ItemName
        {
            get
            {
                return tboxItemName.Text;
            }
            set
            {
                tboxItemName.Text = value;
            }
        }

        public string itemDimension
        {
            get
            {
                return tboxDimension.Text;
            }
            set
            {
                tboxDimension.Text = value;
            }
        }

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

        public event EventHandler QuoteItemListUCLoadEventRaised;

        private void QuoteItemListUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, QuoteItemListUCLoadEventRaised, e);
        }

        //public TextBox GetTboxItemName()
        //{
        //    return tboxItemName;
        //}

        //public TextBox GetTboxDimension()
        //{
        //    return tboxDimension;
        //}

        //public RichTextBox GetRtboxDesc()
        //{
        //    return rtboxDesc;
        //}

        public PictureBox GetPboxItemImage()
        {
            return pboxItemImage;
        }

    }
}
