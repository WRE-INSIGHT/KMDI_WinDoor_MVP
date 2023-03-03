using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IQuoteItemListPresenter
    {
        IQuoteItemListView GetQuoteItemListView();
        IQuoteItemListPresenter GetNewInstance(IUnityContainer unityC,
                                               IQuotationModel quotationModel,
                                               IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                               IWindoorModel windoorModel,
                                               IMainPresenter mainPresenter);
        void SetAllItemDiscount(int inputedDiscount);
        void refreshItemList(object sender, EventArgs e);
        void PrintWindoorRDLC();
        List<IQuoteItemListUCPresenter> LstQuoteItemUC { get; set; }
        List<ShowItemImage> ShowItemImage_CheckList { get; set; }
        List<int> RDLCReportCompilerItemIndexes { get; set; }
        bool RenderPDFAtBackGround { get; set; }

        //List<IQuoteItemListUCPresenter> _lstQuoteItemUC { get; set; }
    }
}
