using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System.Collections.Generic;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IPartialAdjustmentBaseHolderPresenter
    {
        void GetPABaseHolderBringToFront();
        void GetPABaseHolderDispose();
        void GetPABaseHolderInvalidate();
        void GetPABaseHolderSendToBack();
        int ItemQuantity { get; set; }
        List<IPartialAdjustmentUCPresenter> PABaseHolderCtrlList { get; set; }
        void ClearAndAddUserControlFromDelete(bool _isRight);
        IPartialAdjustmentBaseHolderUC GetPABaseHolderUC();

        IPartialAdjustmentBaseHolderPresenter GetNewInstance(IUnityContainer unityC,
                                                             IMainPresenter mainPresenter,
                                                             IWindoorModel windoorModel,
                                                             IQuotationModel quotationModel,
                                                             IPartialAdjustmentViewPresenter partialAdjustmentViewPresenter);

    }
}