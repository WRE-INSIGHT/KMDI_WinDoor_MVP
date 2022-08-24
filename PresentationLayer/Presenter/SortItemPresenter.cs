using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public class SortItemPresenter : ISortItemPresenter
    {
        ISortItemView _sortItemView;
        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private ISortItemUCPresenter _sortItemUCPresenter;
        private IMainPresenter _mainPresenter;
        #region Variables
        private List<ISortItemUCPresenter> _lstSortItemUC = new List<ISortItemUCPresenter>();
        #endregion
        public SortItemPresenter(ISortItemView sortItemView)
        {
            _sortItemView = sortItemView;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sortItemView.SortItemViewLoadEventRaised += _sortItemView_SortItemViewLoadEventRaised;
        }
        private void _sortItemView_SortItemViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    _sortItemUCPresenter = _sortItemUCPresenter.GetNewInstance(_unityC, _windoorModel);
                    UserControl sortItem = (UserControl)_sortItemUCPresenter.GetSortItemUC();
                    _sortItemView.GetPnlSortItem().Controls.Add(sortItem);
                    sortItem.Dock = DockStyle.Top;
                    sortItem.BringToFront();
                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                    _sortItemUCPresenter.GetSortItemUC().ItemName = wdm.WD_name;
                    _sortItemUCPresenter.GetSortItemUC().itemDimension = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString();
                    _sortItemUCPresenter.GetSortItemUC().itemDesc = wdm.WD_description;
                    _sortItemUCPresenter.GetSortItemUC().GetPboxItemImage().Image = wdm.WD_image;
                    this._lstSortItemUC.Add(_sortItemUCPresenter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ISortItemPresenter GetNewInstance(IUnityContainer unityC, 
                                                IQuotationModel quotationModel, 
                                                ISortItemUCPresenter sortItemUCPresenter, 
                                                IWindoorModel windoorModel, 
                                                IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<ISortItemPresenter, SortItemPresenter>()
                  .RegisterType<ISortItemView, SortItemView>();
            SortItemPresenter sortItemList = unityC.Resolve<SortItemPresenter>();
            sortItemList._unityC = unityC;
            sortItemList._quotationModel = quotationModel;
            sortItemList._sortItemUCPresenter = sortItemUCPresenter;
            sortItemList._windoorModel = windoorModel;
            sortItemList._mainPresenter = mainPresenter;
            return sortItemList;
        }
        public ISortItemView GetSortItemView()
        {
            return _sortItemView;
        }
    }
}