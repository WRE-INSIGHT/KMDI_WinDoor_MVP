using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
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
        void refreshItemList();
        void PrintWindoorRDLC();
        void PrintContractSummaryRDLC();
        void PrintScreenRDLC();
        void QuoteItemList_PrintAnnexRDLC();
        void PrintGlassUpgrade();
        List<IQuoteItemListUCPresenter> LstQuoteItemUC { get; set; }
        List<ShowItemImage> ShowItemImage_CheckList { get; set; }
        List<int> RDLCReportCompilerItemIndexes { get; set; }
        bool RenderPDFAtBackGround { get; set; }
        string RDLCReportCompilerOutOfTownExpenses { get; set; }
        bool CallFrmRDLCCompiler { get; set; }
        decimal OutOfTownCharges { get; }
        string RDLCReportCompilerVatContractSummery { get; set; }
        bool RDLCReportCompilerShowSubTotal { get; set; }
        void ContractSummaryComputation();
        bool ShowVatContactSummary { get; set; }
        string RDLCReportCompilerRowLimit { get; set; }
        string RDLCGUGlassType { get; set; }
        string RDLCGUReviewedByOfficial { get; set; }
        int RDLCGUReviewedByOfficialPos { get; set; }
        string RDLCGUNotedByOfficial { get; set; }    
        int RDLCGUNotedByOfficialPos { get; set; }
        string  RDLCGUVatPercentage { get; set; }
        bool RDLCGUShowReviewedBy { get; set; }
        bool RDLCGUShowNotedBy { get; set; }
        bool RDLCGUShowVat { get; set; }
        string RDLCGUFileName { get; set; }
        DataTable GlassUpgradeDT { get; set; }


        //List<IQuoteItemListUCPresenter> _lstQuoteItemUC { get; set; }
    }
}
