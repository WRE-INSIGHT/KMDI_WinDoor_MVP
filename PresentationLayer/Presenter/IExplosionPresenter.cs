using ModelLayer.Model.Quotation;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IExplosionPresenter
    {
        IExplosionPresenter GetNewInstance(IUnityContainer unityC, IQuotationModel qoutationModel, IMainPresenter mainPresenter);
        void ShowExplosionView();
    }
}