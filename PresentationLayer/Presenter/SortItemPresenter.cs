using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        Dictionary<string, string[]> cloneDic = new Dictionary<string, string[]>();
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

        private bool _isCheked;
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
            _sortItemView.chkbox_SelectAll_CheckedChangedEventRaised += _sortItemView_chkbox_SelectAll_CheckedChangedEventRaised;
        }

        private void _sortItemView_chkbox_SelectAll_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_sortItemView.GetSelectAllCheckBox().Checked)
            {
                _isCheked = true;
            }
            else
            {
                _isCheked = false;
            }

            foreach (ISortItemUC sortItemUC in _sortItemView.GetPnlSortItem().Controls)
            {
                sortItemUC.GetCheckBox().Checked = _isCheked;
            }
        }


        private void _sortItemView_btnDeleteClickRaiseEvent(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, do you want to delete selected items?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                //Dipose Selected Windoor 
                _mainPresenter.DisposeDrawingandProperties();

                bool itemSelected = false;
                foreach (string item in lstItem)
                {                 
                    _quotationModel.Lst_Windoor.Remove(_quotationModel.Lst_Windoor.Find(wndr => wndr.WD_name == item));
                    foreach (IItemInfoUC itemInfo in _mainPresenter.pnlItems_MainPresenter.Controls)
                    {
                        if (itemInfo.ItemName == item)
                        {
                            if (itemInfo.WD_Selected)
                            {
                                itemSelected = true;
                            }
                            _mainPresenter.pnlItems_MainPresenter.Controls.Remove((UserControl)itemInfo);
                        }

                    }
                    foreach (ISortItemUC sortItemUC in _sortItemView.GetPnlSortItem().Controls)
                    {
                        if (sortItemUC.ItemName == item)
                        {
                            _sortItemView.GetPnlSortItem().Controls.Remove((UserControl)sortItemUC);
                        }
                    }

                    if (_mainPresenter.Pbl_WindoorModel_FileLines_Dictionary != null || _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.Count != 0)
                    {
                        if (_mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.ContainsKey(item))
                        {
                            _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.Remove(item);
                        }
                    }


                }
                if (itemSelected)
                {
                    _mainPresenter.pnlPropertiesBody_MainPresenter.Controls.Clear();
                    _mainPresenter.pnlMain_MainPresenter.Controls.Clear();
                }

               

                int itemcount = 0;
                cloneDic = new Dictionary<string, string[]>();
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    itemcount++;
                    if (_mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.ContainsKey(wdm.WD_name))
                    {
                        cloneDic.Add("Item " + itemcount, _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary[wdm.WD_name]);  // renaming item name in for load using dispose
                    }
                    wdm.WD_name = "Item " + itemcount;
                    wdm.WD_id = itemcount;
                }

                InsertClonedDictionayrWithNewItemName();

                foreach (ISortItemUC sortItemUC in _sortItemView.GetPnlSortItem().Controls)
                {
                    sortItemUC.ItemName = "Item " + itemcount;
                    itemcount--;
                    sortItemUC.itemDesc = _quotationModel.Lst_Windoor[itemcount].WD_description;
                }

                if (_quotationModel.Lst_Windoor.Count > 0)
                {
                    if (itemSelected)
                    {
                        _mainPresenter.Load_Windoor_Item(_quotationModel.Lst_Windoor[0]);
                        foreach (ISortItemUC siUC in _sortItemView.GetPnlSortItem().Controls)
                        {
                            if (siUC.ItemName == _quotationModel.Lst_Windoor[0].WD_name)
                            {
                                siUC.itemSelected = true;
                            }
                        }
                    }
                    else
                    {
                        foreach(IWindoorModel wdm in _quotationModel.Lst_Windoor)
                        {
                            #region Search selected item in Lst_windoor 
                            // Force to Dispose,Copy and Load
                            if (wdm.WD_Selected)
                            {                              
                                if (!wdm.WD_IsObjectCopied)
                                {
                                    wdm.WD_IsObjectCopied = true;
                                }
                                if (!_mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.ContainsKey(wdm.WD_name))
                                {
                                    _mainPresenter.CopyObjectsPerWindoorModel();
                                }                              
                                _mainPresenter.Load_Windoor_Item(wdm);                            
                                break;
                            }
                            #endregion
                        }
                    }
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
                _sortItemView.GetSelectAllCheckBox().Checked = false;
            }
                      
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
            if (item != e.Data.GetData(e.Data.GetFormats()[0]) && item != null)
            {
                lstItem.Clear();
                //DeleteEnable = false;
                //Set index of dragged sort item.
                _sortItemView.GetPnlSortItem().Controls.SetChildIndex((UserControl)e.Data.GetData(e.Data.GetFormats()[0]), index);
                //Set index of ItemInfo based on sortitem index
                List<IWindoorModel> lstwndr = new List<IWindoorModel>();
                foreach (ISortItemUC sortItemuc in  _sortItemView.GetPnlSortItem().Controls)
                {
                    foreach (IItemInfoUC itemInfouc in _mainPresenter.GetMainView().GetPanelItems().Controls)
                    {
                        if(sortItemuc.ItemName == itemInfouc.ItemName)
                        {
                            int sortItemIndex = _sortItemView.GetPnlSortItem().Controls.GetChildIndex((UserControl)sortItemuc);
                            _mainPresenter.GetMainView().GetPanelItems().Controls.SetChildIndex((UserControl)itemInfouc, sortItemIndex);
                        }
                    }
                }
                //remove the windoor model of dragged item and add with new index.
                foreach(IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if(wdm.WD_name == ((ISortItemUC)e.Data.GetData(e.Data.GetFormats()[0])).ItemName)
                    {
                        _quotationModel.Lst_Windoor.Remove(wdm);
                        _quotationModel.Lst_Windoor.Insert(_quotationModel.Lst_Windoor.Count - index, wdm);
                        break;
                    }
                }
                int itemCount = 0;
                //rename all windoor WD_name.
                cloneDic = new Dictionary<string, string[]>();
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    itemCount++;
                    if (_mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.ContainsKey(wdm.WD_name))
                    {
                        cloneDic.Add("Item " + itemCount, _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary[wdm.WD_name]);  // renaming item name in for load using dispose
                    }
                    wdm.WD_id = itemCount;
                    wdm.WD_name = "Item " + itemCount;
                }

                InsertClonedDictionayrWithNewItemName();

                //rename all sortItem.
                foreach (ISortItemUC sortItemUC in _sortItemView.GetPnlSortItem().Controls)
                {
                    sortItemUC.ItemName = "Item " + itemCount;
                    itemCount--;
                    sortItemUC.itemDesc = _quotationModel.Lst_Windoor[itemCount].WD_description;
                    if (sortItemUC.itemChecked)
                    {
                        lstItem.Add(sortItemUC.ItemName);
                    }
                }
                //rename all itemInfo.
                itemCount = _mainPresenter.GetMainView().GetPanelItems().Controls.Count;
                foreach (IItemInfoUC itemInfouc in _mainPresenter.GetMainView().GetPanelItems().Controls)
                {
                    itemInfouc.ItemName = "Item " + itemCount;
                    itemCount--;
                    //itemInfouc.item = _quotationModel.Lst_Windoor[itemCount].WD_description;
                }
                _mainPresenter.basePlatform_MainPresenter.InvalidateBasePlatform();
            }


        }

        private void InsertClonedDictionayrWithNewItemName()
        {
            //insert to mainPresenter Dictionary
            _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary.Clear();  // clear dictionary before adding
            _mainPresenter.Pbl_WindoorModel_FileLines_Dictionary = cloneDic.ToDictionary(entry => entry.Key, entry => entry.Value); // insert new item name with corresponding values
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
                    _sortItemUCPresenter.GetSortItemUC().itemSelected = wdm.WD_Selected;
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