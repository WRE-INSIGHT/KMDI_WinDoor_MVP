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

        private IMainPresenter _mainPresenter;

        public ItemInfoUCPresenter(IItemInfoUC itemInfoUC)
        {
            _itemInfoUC = itemInfoUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _itemInfoUC.ItemInfoUCLoadEventRaised += new EventHandler(OnItemInfoUCLoadEventRaised);
            _itemInfoUC.lblItemMouseDoubleClickEventRaised += _itemInfoUC_lblItemMouseDoubleClickEventRaised;
        }

        private void _itemInfoUC_lblItemMouseDoubleClickEventRaised(object sender, MouseEventArgs e)
        {
            try
            {
                _mainPresenter.Load_Windoor_Item(_windoorModel);
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

            return itemInfoUCP;
        }

        public IItemInfoUC GetItemInfoUC()
        {
            return _itemInfoUC;
        }
    }
}
