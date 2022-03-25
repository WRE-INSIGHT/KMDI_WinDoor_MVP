using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICustomArrowHeadPresenter : IPresenterCommon
    {
        ICustomArrowHeadView GetICustomArrowHeadView(IUnityContainer unityC);
        void Remove_ArrowHeadUCP(ICustomArrowHeadUCPresenter CustomArrowHeadUCP);
        int ArrowWD_Count { get; set; }
        ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC, ICustomArrowHeadUCPresenter customArrowHeadUC, IWindoorModel windoorModel); // 
    }
}
