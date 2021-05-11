using ModelLayer.Model.Quotation;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class ExplosionPresenter : IExplosionPresenter
    {
        IExplosionView _explosionView;

        private IQuotationModel _quotationModel;
        private IMainPresenter _mainPresenter;

        private DataGridView _dgvExplosionMaterialList;

        public ExplosionPresenter(IExplosionView explosionView)
        {
            _explosionView = explosionView;
            _dgvExplosionMaterialList = _explosionView.Get_DgvExplosionMaterialList();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _explosionView.ExplosionViewLoadEventRaised += _explosionView_ExplosionViewLoadEventRaised;
        }

        private void _explosionView_ExplosionViewLoadEventRaised(object sender, EventArgs e)
        {
            _dgvExplosionMaterialList.DataSource = _quotationModel.GetListOfMaterials();
        }
        
        public void ShowExplosionView()
        {
            _explosionView.ShowThisDialog();
        }

        public IExplosionPresenter GetNewInstance(IUnityContainer unityC, IQuotationModel qoutationModel, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IExplosionView, ExplosionView>()
                .RegisterType<IExplosionPresenter, ExplosionPresenter>();
            ExplosionPresenter explosionPresenter = unityC.Resolve<ExplosionPresenter>();
            explosionPresenter._quotationModel = qoutationModel;
            explosionPresenter._mainPresenter = mainPresenter;

            return explosionPresenter;
        }
    }
}
