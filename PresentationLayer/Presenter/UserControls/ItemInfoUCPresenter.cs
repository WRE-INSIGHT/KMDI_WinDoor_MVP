using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.Quotation.WinDoor;
using Unity;
using System.Windows.Forms;

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
            //_itemInfoUC.dok = System.Windows.Forms.DockStyle.Top;
            //_itemInfoUC.ItemName = _windoorModel.WD_name;
            //_itemInfoUC.ItemDesc = _windoorModel.WD_description;
            //_itemInfoUC.ItemDimension = _windoorModel.WD_width.ToString() + " x " + _windoorModel.WD_height.ToString();
            //_itemInfoUC.ItemVisibility = _windoorModel.WD_visibility;
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

            return windoorBinding;
        }

        public IItemInfoUCPresenter GetNewInstance(IWindoorModel wndr, IUnityContainer unityC)
        {
            unityC
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
