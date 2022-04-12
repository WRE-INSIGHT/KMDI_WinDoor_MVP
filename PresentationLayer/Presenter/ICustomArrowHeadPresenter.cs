using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ICustomArrowHeadPresenter : IPresenterCommon
    {
        ICustomArrowHeadView GetICustomArrowHeadView();
        void Remove_ArrowHeadUCP(ICustomArrowHeadUCPresenter CustomArrowHeadUCP);
        int ArrowWD_Count { get; set; }
        int ArrowHT_Count { get; set; }
        void ComputeTotalArrowLenght();
        ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC,
                                                 ICustomArrowHeadUCPresenter customArrowHeadUC,
                                                 IWindoorModel windoorModel,
                                                 IMainPresenter mainPresenter); // 
    }
}
