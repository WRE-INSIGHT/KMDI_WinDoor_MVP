using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface ISortItemPresenter
    {
        ISortItemView GetSortItemView();
        ISortItemPresenter GetNewInstance(IUnityContainer unityC,
                                               IQuotationModel quotationModel,
                                               ISortItemUCPresenter sortItemUCPresenter,
                                               IWindoorModel windoorModel,
                                               IMainPresenter mainPresenter);
    }
}
