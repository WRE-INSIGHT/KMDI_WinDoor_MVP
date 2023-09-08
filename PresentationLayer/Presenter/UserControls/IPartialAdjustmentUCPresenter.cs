using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IPartialAdjustmentUCPresenter
    {
        IPartialAdjustmentUC GetPartialAdjustmentUC();
        IPartialAdjustmentUCPresenter GetNewInstance(IUnityContainer unityC,
                                                     IQuotationModel quotationModel,
                                                     IWindoorModel windoorModel,
                                                     IMainPresenter mainPresenter,
                                                     IPartialAdjustmentViewPresenter partialAdjustmentViewPresenter);
    }
}