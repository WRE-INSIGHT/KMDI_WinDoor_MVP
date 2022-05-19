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


        public event EventHandler QuoteItemListUCLoadEventRaised;


        private void QuoteItemListUC_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, QuoteItemListUCLoadEventRaised, e);
        }

        //public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        //{
        //    pboxItemImage.DataBindings.Add(ModelBinding["PbItemImage"]);
        //}

        public TextBox GetTboxItemName()
        {
            return tboxItemName;
        }

        public TextBox GetTboxDimension()
        {
            return tboxDimension;
        }

        public RichTextBox GetRtboxDesc()
        {
            return rtboxDesc;
        }

        public PictureBox GetPboxItemImage()
        {
            return pboxItemImage;
        }

    }
}
