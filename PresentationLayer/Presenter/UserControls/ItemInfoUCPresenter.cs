using CommonComponents;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ItemInfoUCPresenter : IItemInfoUCPresenter
    {
        IItemInfoUC _itemInfoUC;
        private IWindoorModel _windoorModel;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private bool _isDragging = false;
        private int _mX = 0;
        private int _mY = 0;
        private int _DDradius = 40;
        public ItemInfoUCPresenter(IItemInfoUC itemInfoUC)
        {
            _itemInfoUC = itemInfoUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _itemInfoUC.ItemInfoUCLoadEventRaised += new EventHandler(OnItemInfoUCLoadEventRaised);
            _itemInfoUC.lblItemMouseDoubleClickEventRaised += _itemInfoUC_lblItemMouseDoubleClickEventRaised;
            _itemInfoUC.lblItemMouseDownEventRaised += _itemInfoUC_lblItemMouseDownEventRaised;
            _itemInfoUC.lblItemMouseMoveEventRaised += _itemInfoUC_lblItemMouseMoveEventRaised;
            _itemInfoUC.lblItemMouseUpEventRaised += _itemInfoUC_lblItemMouseUpEventRaised;
            _itemInfoUC.DefaultDescriptionClickEventRaised += _itemInfoUC_DefaultDescriptionClickEventRaised;
        }

        private void _itemInfoUC_DefaultDescriptionClickEventRaised(object sender, EventArgs e)
        {
            _mainPresenter.itemDescription();
        }

        private void _itemInfoUC_lblItemMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void _itemInfoUC_lblItemMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            //if (!_isDragging)
            //{
            //    This is a check to see if the mouse is moving while pressed.
            //    Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
            //    if (e.Button == MouseButtons.Left && _DDradius > 0)
            //    {
            //        int num1 = _mX - e.X;
            //        int num2 = _mY - e.Y;
            //        if (((num1 * num1) + (num2 * num2)) > _DDradius)
            //        {

            //            _itemInfoUC.GetItemInfo().DoDragDrop(_itemInfoUC.GetItemInfo(), DragDropEffects.All);
            //            _isDragging = true;
            //            return;
            //        }
            //    }
            //}
        }

        private void _itemInfoUC_lblItemMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            _mX = e.X;
            _mY = e.Y;
            this._isDragging = false;
        }

        private void _itemInfoUC_lblItemMouseDoubleClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                Console.WriteLine("item info:" + _windoorModel.TotalPriceHistoryStatus);
                _mainPresenter.ItemLoad = true;
                int itemscroll = _mainPresenter.ItemScroll;
                _mainPresenter.Load_Windoor_Item(_windoorModel);
                _mainPresenter.qoutationModel_MainPresenter.itemSelectStatus = true;
                _itemInfoUC.WD_Selected = true;
                if (_windoorModel.WD_fileLoad)
                {
                    _mainPresenter.updatePriceOfMainView();
                }
                else
                {
                    if (_windoorModel.TotalPriceHistoryStatus == "System Generated Price") //|| _windoorModel.TotalPriceHistoryStatus == "Change Factor"
                    {
                        _mainPresenter.LblCurrentPrice.Value = _windoorModel.WD_currentPrice;
                    }
                    else if (_windoorModel.TotalPriceHistoryStatus == "Edited Price")
                    {
                        _mainPresenter.LblCurrentPrice.Value = _windoorModel.WD_price;
                    }
                }
               // _mainPresenter.ItemScroll = itemscroll;
                //_mainPresenter.ItemLoad = false;
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OnItemInfoUCLoadEventRaised(object sender, EventArgs e)
        {
            _itemInfoUC.ThisBinding(CreateBindingDictionary_ItemInfoUCP());
            _itemInfoUC.BringToFrontThis();
        }

        private Dictionary<string, Binding> CreateBindingDictionary_ItemInfoUCP()
        {
            Dictionary<string, Binding> windoorBinding = new Dictionary<string, Binding>();
            windoorBinding.Add("WD_name", new Binding("Text", _windoorModel, "WD_name", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_Dimension", new Binding("Text", _windoorModel, "WD_Dimension", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_description", new Binding("Text", _windoorModel, "WD_description", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_visibility", new Binding("Visible", _windoorModel, "WD_visibility", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_image", new Binding("Image", _windoorModel, "WD_image", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_Selected", new Binding("WD_Selected", _windoorModel, "WD_Selected", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_SlidingTopViewVisibility", new Binding("Visible", _windoorModel, "WD_SlidingTopViewVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            windoorBinding.Add("WD_SlidingTopViewImage", new Binding("Image", _windoorModel, "WD_SlidingTopViewImage", true, DataSourceUpdateMode.OnPropertyChanged));
            //windoorBinding.Add("WD_pboxImagerHeight", new Binding("Height", _windoorModel, "WD_pboxImagerHeight", true, DataSourceUpdateMode.OnPropertyChanged));


            return windoorBinding;
        }

        public IItemInfoUCPresenter GetNewInstance(IWindoorModel wndr, IUnityContainer unityC, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IItemInfoUC, ItemInfoUC>()
                .RegisterType<IItemInfoUCPresenter, ItemInfoUCPresenter>();
            ItemInfoUCPresenter itemInfoUCP = unityC.Resolve<ItemInfoUCPresenter>();
            itemInfoUCP._windoorModel = wndr;
            itemInfoUCP._mainPresenter = mainPresenter;
            itemInfoUCP._unityC = unityC;
            return itemInfoUCP;
        }

        public IItemInfoUC GetItemInfoUC()
        {
            return _itemInfoUC;
        }
    }
}
