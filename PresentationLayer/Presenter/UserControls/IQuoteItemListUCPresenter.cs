using CommonComponents;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IQuoteItemListUCPresenter : IPresenterCommon
    {

        IQuoteItemListUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, IQuotationModel quotationModel, IMainPresenter mainPresenter);
        IQuoteItemListUC GetiQuoteItemListUC();


    }
}
