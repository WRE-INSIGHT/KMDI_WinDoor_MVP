using ModelLayer.Model.Quotation;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPricingPresenter
    {
        IPricingView GetPricingView();
        IPricingPresenter CreateNewInstance(IUnityContainer unityC,
                                            IMainPresenter mainPresenter,
                                            IQuotationModel quotationModel);
    }
}