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
using System.Drawing;
using PresentationLayer.Views.UserControls;
using System.Text.RegularExpressions;

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
            _sortItemView.SortItemDragDropEventRaiseEvent += _sortItemView_SortItemDragDropEventRaiseEvent;
            _sortItemView.SortItemDragEnterEventRaiseEvent += _sortItemView_SortItemDragEnterEventRaiseEvent;
        }
        private void _sortItemView_SortItemDragEnterEventRaiseEvent(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void _sortItemView_SortItemDragDropEventRaiseEvent(object sender, DragEventArgs e)
        {
            Point p = _sortItemView.GetPnlSortItem().PointToClient(new Point(e.X, e.Y));
            var item = _sortItemView.GetPnlSortItem().GetChildAtPoint(p);
            int index = _sortItemView.GetPnlSortItem().Controls.GetChildIndex(item, false);
            if (item != e.Data.GetData(e.Data.GetFormats()[0]))
            {
                _sortItemView.GetPnlSortItem().Controls.SetChildIndex((UserControl)e.Data.GetData(e.Data.GetFormats()[0]), index);
                //Get All WindoorModel by name
                List<IWindoorModel> lstwndr = new List<IWindoorModel>();
                foreach (UserControl uc in _sortItemView.GetPnlSortItem().Controls)
                {
                    for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                    {
                        IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                        if (uc.Name == wdm.WD_name)
                        {
                            lstwndr.Add(wdm);
                        }
                    }
                }
                lstwndr.Reverse();
                _quotationModel.Lst_Windoor.Clear();
                _quotationModel.Lst_Windoor = lstwndr;
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    foreach (UserControl uc in _mainPresenter.GetMainView().GetPanelItems().Controls)
                    {
                        foreach (Control lbl in uc.Controls)
                        {
                            if (lbl.Text == wdm.WD_name)
                            {
                                uc.BringToFront();
                            }
                        }
                    }
                }
                int itemCount = 1;
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {

                    wdm.WD_name = "Item " + itemCount;
                    itemCount++;
                }
                _sortItemView.GetPnlSortItem().Invalidate();
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
                LoadSortItem();
            }
        }

        private void _sortItemView_SortItemViewLoadEventRaised(object sender, EventArgs e)
        {
            LoadSortItem();
        }

        private void LoadSortItem()
        {
            try
            {
                _sortItemView.GetPnlSortItem().Controls.Clear();
                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                    _sortItemUCPresenter = _sortItemUCPresenter.GetNewInstance(_unityC, _windoorModel);
                    UserControl sortItem = (UserControl)_sortItemUCPresenter.GetSortItemUC();
                    sortItem.Name = wdm.WD_name;
                    _sortItemView.GetPnlSortItem().Controls.Add(sortItem);
                    sortItem.Dock = DockStyle.Top;
                    sortItem.BringToFront();
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