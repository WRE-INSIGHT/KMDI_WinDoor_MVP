using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
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
        void remove_Lst_arrowHt(ICustomArrowHeadUC customArrowHeadUc);
        void remove_Lst_arrowWd(ICustomArrowHeadUC customArrowHeadUc);

        ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC,
                                                 ICustomArrowHeadUCPresenter customArrowHeadUC,
                                                 IWindoorModel windoorModel,
                                                 IMainPresenter mainPresenter); // 
    }
}
