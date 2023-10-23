using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IPartialAdjustmentItemDisabledUCPresenter
    {
        string UserControlBackground { get; set; }
        int PartialAdjusmentItemDisabledUCIndexPlacement { get; set; }
        IPartialAdjustmentItemDisabledUCPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, 
                                                                IWindoorModel windoorModel, IQuotationModel quotationModel);
        IPartialAdjustmenItemDisabledUC GetPartialAdjustmentItemDisablepdUC();

        void paItemDisableUCPresenter_BringToFront();
        void paItemDisableUCPresenter_SendToBack();
        void paItemDisableUCPresenter_Invalidatethis();
       
    }
}