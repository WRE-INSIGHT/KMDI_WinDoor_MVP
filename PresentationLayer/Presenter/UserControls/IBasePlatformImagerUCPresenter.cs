using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IBasePlatformImagerUCPresenter
    {
        IBasePlatformImagerUC GetBasePlatformImagerUC();
        IBasePlatformImagerUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel);
        void InvalidateBasePlatform();
        void AddFrame(IFrameImagerUC frameImagerUC);
    }
}