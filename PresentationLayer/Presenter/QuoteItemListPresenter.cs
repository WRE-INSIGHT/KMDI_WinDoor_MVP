using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.IO;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class QuoteItemListPresenter : IQuoteItemListPresenter
    {
        IQuoteItemListView _quoteItemListView;

        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;


        string itemName, itemDesc, ItemDimension;

        public QuoteItemListPresenter(IQuoteItemListView quoteItemListView,
                                      IPrintQuotePresenter printQuotePresenter)
        {
            _quoteItemListView = quoteItemListView;
            _printQuotePresenter = printQuotePresenter;

            SubscribeToEventSetup();
        }


        private void SubscribeToEventSetup()
        {
            _quoteItemListView.TSbtnPrintClickEventRaised += new EventHandler(OnTSbtnPrintClickEventRaised);
            _quoteItemListView.QuoteItemListViewLoadEventRaised += _quoteItemListView_QuoteItemListViewLoadEventRaised;
        }


        private void _quoteItemListView_QuoteItemListViewLoadEventRaised(object sender, EventArgs e)
        {
            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                _quoteItemListUCPresenter = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
                UserControl quoteItem = (UserControl)_quoteItemListUCPresenter.GetiQuoteItemListUC();
                _quoteItemListView.GetPnlPrintBody().Controls.Add(quoteItem);
                quoteItem.Dock = DockStyle.Top;
                quoteItem.BringToFront();

                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                _quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName= wdm.WD_name;
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDimension= wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString();
                _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc= "";
                _quoteItemListUCPresenter.GetiQuoteItemListUC().GetPboxItemImage().Image = wdm.WD_image;
            }

        }


        private void OnTSbtnPrintClickEventRaised(object sender, EventArgs e)
        {
         

            DSQuotation _dsq = new DSQuotation();
            /*
          ID
          dtItemName
          dtDescription
          dtDimension
          dtImage
          dtQuantity
          dtPrice
          dtDiscount
          dtNetPrice
           */

            populateitemInfo();

            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
               
                MemoryStream mstream = new MemoryStream();
                _quotationModel.Lst_Windoor[i].WD_image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] arrimage = mstream.ToArray();
                string byteToStr = Convert.ToBase64String(arrimage);

                _dsq.dtQuote.Rows.Add(_quoteItemListUCPresenter.GetiQuoteItemListUC().ItemName,
                                      _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDesc,
                                      _quoteItemListUCPresenter.GetiQuoteItemListUC().itemDimension,
                                      byteToStr,
                                      1,    
                                      0,
                                      0,
                                      0);

                

            }

            IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, this);
            printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtQuote.DefaultView;
            printQuote.GetPrintQuoteView().ShowPrintQuoteView();
         


        }

        public void populateitemInfo()
        {
            IQuoteItemListUCPresenter quoteItemLUCP = _quoteItemListUCPresenter.GetNewInstance(_unityC, _windoorModel);
            itemName = quoteItemLUCP.GetiQuoteItemListUC().ItemName;
            itemDesc = quoteItemLUCP.GetiQuoteItemListUC().itemDesc;
            ItemDimension = quoteItemLUCP.GetiQuoteItemListUC().itemDimension;
        }

        public IQuoteItemListView GetQuoteItemListView()
        {
            return _quoteItemListView;
        }

        public IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC,
                                                      IQuotationModel quotationModel,
                                                      IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                      IWindoorModel windoorModel)
        {
            unityC
                    .RegisterType<IQuoteItemListPresenter, QuoteItemListPresenter>()
                    .RegisterType<IQuoteItemListView, QuoteItemListView>();
            QuoteItemListPresenter quoteItemList = unityC.Resolve<QuoteItemListPresenter>();
            quoteItemList._unityC = unityC;
            quoteItemList._quotationModel = quotationModel;
            quoteItemList._quoteItemListUCPresenter = quoteItemListUCPresenter;
            quoteItemList._windoorModel = windoorModel;
            //quoteItemList._printQuotePresenter = printQuotePresenter;

            return quoteItemList;
        }
    }
}
