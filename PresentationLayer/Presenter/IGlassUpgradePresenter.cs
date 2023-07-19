using System.Data;
using ModelLayer.Model.Quotation.WinDoor;
using Unity;
using PresentationLayer.Views;
using ModelLayer.Model.Quotation;

namespace PresentationLayer.Presenter
{
    public interface IGlassUpgradePresenter
    {
        IGlassUpgradeView GetGlassUpgradeView();
        IGlassUpgradePresenter CreateNewIntance(IWindoorModel windoorModel, 
                                                IMainPresenter mainPresenter,
                                                IQuotationModel quotationModel,
                                                IUnityContainer unityC);
        DataTable PopulateDgvGlassUpgrade();
    }
}