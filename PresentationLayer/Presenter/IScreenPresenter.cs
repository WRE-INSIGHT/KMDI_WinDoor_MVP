using CommonComponents;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Screen;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls.ScreenAddonsPropertiesUCPresenter_Module;
using PresentationLayer.Views;
using ServiceLayer.Services.QuotationServices;
using System.Collections.Generic;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPresenter : IPresenterCommon
    {
        IScreenView GetScreenView();
        IScreenPresenter CreateNewInstance(IUnityContainer unityC,
                                           IMainPresenter mainPresenter,
                                           IScreenModel screenModel,
                                           IQuotationServices quotationServices,
                                           IQuotationModel quotationModel,
                                           IWindoorModel windoorModel,
                                           IScreenPartialAdjustmentProperties screenPartiallAdjustmentProperties);
       



        DataTable PopulateDgvScreen();
        DataRow CreateNewRow_ScreenDT();
        void GetCurrentAmount();
        void Insert_Adjustment_to_DGV(IScreenPartialAdjustmentProperties sdm);
        void PopulateDataGridView();

    }
}