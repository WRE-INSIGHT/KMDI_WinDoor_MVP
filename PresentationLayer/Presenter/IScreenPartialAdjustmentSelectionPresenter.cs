using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IScreenPartialAdjustmentSelectionPresenter
    {
        IScreenPartialAdjustmentSelectionPresenter CreateNewInstance(IUnityContainer unityC, 
                                                                     IMainPresenter mainPreseter, 
                                                                     IScreenPresenter screenPresenter, 
                                                                     IScreenModel screenModel,
                                                                     IScreenPartialAdjustmentProperties screenPartialAdjustmentProperties);
        IScreenPartialAdjusmentSelectionView GetScreenPartialAdjustmentView();
    }
}