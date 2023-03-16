using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unity;

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
        private List<string> _lstItem;
        public List<string> lstItem
        {
            get
            {
                return _lstItem;
            }

            set
            {
                _lstItem = value;
            }
        }

        public bool DeleteEnable
        {
            set
            {
                _sortItemView.btnDelete().Enabled = value;
            }
        }
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
            _sortItemView.btnDeleteClickRaiseEvent += _sortItemView_btnDeleteClickRaiseEvent;
        }

        private void _sortItemView_btnDeleteClickRaiseEvent(object sender, EventArgs e)
        {
            
            foreach (string item in lstItem)
            {

                _quotationModel.Lst_Windoor.Remove(_quotationModel.Lst_Windoor.Find(wndr => wndr.WD_name == item));
                foreach (IItemInfoUC itemInfo in _mainPresenter.pnlItems_MainPresenter.Controls)
                {
                    if (itemInfo.ItemName == item)
                    {
                        _mainPresenter.pnlItems_MainPresenter.Controls.Remove((UserControl)itemInfo);
                    }

                }
            }

            _mainPresenter.pnlPropertiesBody_MainPresenter.Controls.Clear();
            _mainPresenter.pnlMain_MainPresenter.Controls.Clear();
            //_basePlatformPresenter.getBasePlatformViewUC().GetFlpMain().Controls.Clear();
            int count = 1;
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                wdm.WD_name = "Item " + count;
                wdm.WD_id = count;
                count++;
            }
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
                wdm.WD_id = itemCount;
                wdm.WD_name = "Item " + itemCount;
                itemCount++;
            }
            _sortItemView.GetPnlSortItem().Invalidate();
            _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            LoadSortItem();
            if(_quotationModel.Lst_Windoor.Count > 0)
            {
                _mainPresenter.Load_Windoor_Item(_quotationModel.Lst_Windoor[0]);
            }
            else
            {
                if (_quotationModel.Lst_Windoor.Count == 0)
                {
                    _mainPresenter.Clearing_Operation();
                }
                if (_quotationModel != null)
                {
                    if (_quotationModel.Lst_Windoor.Count != 0)
                    {
                        _mainPresenter.GetCurrentPrice();
                    }
                }
                else
                {
                    _mainPresenter.LblCurrentPrice.Value = 0;
                }
            }
            lstItem.Clear();
            DeleteEnable = false;
        }

        private void _sortItemView_SortItemDragEnterEventRaiseEvent(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void _sortItemView_SortItemDragDropEventRaiseEvent(object sender, DragEventArgs e)
        {
            lstItem.Clear();
            DeleteEnable = false;
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
                    wdm.WD_id = itemCount;
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
            this.lstItem = new List<string>();

        }

        private void LoadSortItem()
        {
            try
            {
                _sortItemView.GetPnlSortItem().Controls.Clear();
                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {
                    IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                    _sortItemUCPresenter = _sortItemUCPresenter.GetNewInstance(_unityC, _windoorModel, this);
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