using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IExplosionPresenter
    {
        IExplosionPresenter GetNewInstance(IUnityContainer unityC,
                                           IQuotationModel qoutationModel,
                                           IMainPresenter mainPresenter,
                                           IWindoorModel windoorModel);
        void ShowExplosionView();
    }
}