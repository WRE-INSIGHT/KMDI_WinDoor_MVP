using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IItemInfoUCPresenter
    {
        void SetValues(IWindoorModel windoorModel);
        IItemInfoUC GetItemInfoUC();
        IItemInfoUCPresenter GetNewInstance(IWindoorModel wndr);
    }
}