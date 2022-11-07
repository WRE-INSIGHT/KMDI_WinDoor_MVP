using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PricingPresenter : IPricingPresenter
    {
        IPricingView _pricingView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IQuotationModel _quotationModel;

        CommonFunctions commonfunc = new CommonFunctions();

        private DataGridView _dgvPricingList;

        public PricingPresenter(IPricingView pricingView)
        {
            _pricingView = pricingView;
            _dgvPricingList = _pricingView.GetDgvPrice();

            SubcribeToEventSetUp();
        }

        private void SubcribeToEventSetUp()
        {
            _pricingView.PricingViewLoadEventRaised += _pricingView_PricingViewLoadEventRaised;
            _pricingView.dgvPriceListRowPostPaintEventRaised += _pricingView_dgvPriceListRowPostPaintEventRaised;
        }

        private void _pricingView_dgvPriceListRowPostPaintEventRaised(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void _pricingView_PricingViewLoadEventRaised(object sender, EventArgs e)
        {
            _dgvPricingList.DataSource = _quotationModel.ItemCostingPriceAndPoints();
            _dgvPricingList.Columns[0].Width = (int)(_dgvPricingList.Width * 0.5);
            _dgvPricingList.Columns[1].Width = (int)(_dgvPricingList.Width * 0.5);
        }

        public IPricingView GetPricingView()
        {
            return _pricingView;
        }

        public IPricingPresenter CreateNewInstance(IUnityContainer unityC,
                                                   IMainPresenter mainPresenter,
                                                   IQuotationModel quotationModel)
        {
            unityC
                   .RegisterType<IPricingView, PricingView>()
                   .RegisterType<IPricingPresenter, PricingPresenter>();
            PricingPresenter pricing = unityC.Resolve<PricingPresenter>();
            pricing._unityC = unityC;
            pricing._mainPresenter = mainPresenter;
            pricing._quotationModel = quotationModel;

            return pricing;
        }
    }
}
