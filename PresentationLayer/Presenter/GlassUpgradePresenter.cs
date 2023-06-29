using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class GlassUpgradePresenter
    {
        private IGlassUpgradeView _glassUpgradeView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;

        private DataGridView _dgv_GlassUpgrade;
        private DataTable _glassUpgrageDT = new DataTable();
        private NumericUpDown _glassUpgradeDiscount;
                
        public GlassUpgradePresenter(IGlassUpgradeView glassUpgradeView)
        {
            _glassUpgradeView = glassUpgradeView;

            _dgv_GlassUpgrade = _glassUpgradeView.GlassUpgradeDGView();
            _glassUpgradeDiscount = _glassUpgradeView.DiscountNum;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _glassUpgradeView.GlassUpgradeView_LoadEventRaised += new EventHandler(OnGlassUpgradeViewLoadEventRaised);
        }

        private void OnGlassUpgradeViewLoadEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
