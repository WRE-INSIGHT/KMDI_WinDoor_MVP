using ModelLayer.Model.Quotation;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPriceHistoryPresenter
    {
        IPriceHistoryView GetPriceHistoryView();

        IPriceHistoryPresenter CreateNewInstance(IUnityContainer unityC,
                                                 IMainPresenter mainPresenter,
                                                 IQuotationModel quotationModel);
    }
}