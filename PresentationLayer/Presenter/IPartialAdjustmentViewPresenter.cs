using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IPartialAdjustmentViewPresenter
    {
        IPartialAdjustmentViewPresenter GetNewInstance(IUnityContainer unityC, 
                                                       IQuotationModel quotationModel, 
                                                       IWindoorModel windoorModel, 
                                                       IMainPresenter mainPresenter,
                                                       IPartialAdjustmentUCPresenter partialAdjustmentUCPresenter);
        IPartialAdjustmentView GetPartialAdjustmentView();
    }
}