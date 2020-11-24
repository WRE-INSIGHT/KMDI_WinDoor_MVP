using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.WinDoor;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class ItemInfoUCPresenter : IItemInfoUCPresenter
    {
        IItemInfoUC _itemInfoUC;
        private IWindoorModel _windoorModel;

        public ItemInfoUCPresenter(IItemInfoUC itemInfoUC)
        {
            _itemInfoUC = itemInfoUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _itemInfoUC.ItemInfoUCLoadEventRaised += new EventHandler(OnItemInfoUCLoadEventRaised);
        }

        private void OnItemInfoUCLoadEventRaised(object sender, EventArgs e)
        {
            _itemInfoUC.dok = System.Windows.Forms.DockStyle.Top;
            _itemInfoUC.ItemName = _windoorModel.WD_name;
            _itemInfoUC.ItemDesc = _windoorModel.WD_description;
            _itemInfoUC.ItemDimension = _windoorModel.WD_width.ToString() + " x " + _windoorModel.WD_height.ToString();
            _itemInfoUC.ItemVisibility = _windoorModel.WD_visibility;
            _itemInfoUC.BringToFrontThis();
        }
        
        public IItemInfoUCPresenter GetNewInstance(IWindoorModel wndr)
        {
            IUnityContainer unityC;
            unityC =
                new UnityContainer()
                .RegisterType<IItemInfoUC, ItemInfoUC>()
                .RegisterType<IItemInfoUCPresenter, ItemInfoUCPresenter>();
            ItemInfoUCPresenter itemInfoUCP = unityC.Resolve<ItemInfoUCPresenter>();
            itemInfoUCP._windoorModel = wndr;

            return itemInfoUCP;
        }

        public IItemInfoUC GetItemInfoUC()
        {
            return _itemInfoUC;
        }
    }
}
