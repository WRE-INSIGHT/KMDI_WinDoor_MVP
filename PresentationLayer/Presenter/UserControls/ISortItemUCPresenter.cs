using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface ISortItemUCPresenter
    {
        ISortItemUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, ISortItemPresenter sortItemPresenter);
        ISortItemUC GetSortItemUC();
    }
}
