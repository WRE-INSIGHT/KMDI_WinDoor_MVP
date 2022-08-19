using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class SortItemUCPresenter : ISortItemUCPresenter
    {
        ISortItemUC _sortItemUC;
        private IUnityContainer _unityC;
        private ISortItemPresenter _sortItemPresenter;
        private IWindoorModel _windoorModel;
        public SortItemUCPresenter(ISortItemPresenter sortItemPresenter,
                                   ISortItemUC sortItemUC)
        {
            _sortItemPresenter = sortItemPresenter;
            _sortItemUC = sortItemUC;
            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _sortItemUC.SortItemUCLoadEventRaised += _sortItemUC_SortItemUCLoadEventRaised;
        }

        private void _sortItemUC_SortItemUCLoadEventRaised(object sender, EventArgs e)
        {
            
        }

        public ISortItemUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel)
        {
            unityC
               .RegisterType<ISortItemUCPresenter, SortItemUCPresenter>()
               .RegisterType<ISortItemUC, SortItemUC>();
            SortItemUCPresenter sortItem = unityC.Resolve<SortItemUCPresenter>();
            sortItem._unityC = unityC;
            sortItem._windoorModel = windoorModel;
            return sortItem;
        }

        public ISortItemUC GetSortItemUC()
        {
            return _sortItemUC;
        }
    }
}
