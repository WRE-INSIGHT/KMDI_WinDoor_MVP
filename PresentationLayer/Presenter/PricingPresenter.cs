using ModelLayer.Model.Quotation;
using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

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
            _pricingView.cmbFilterSelectedValueChangedEventRaised += _pricingView_cmbFilterSelectedValueChangedEventRaised;
        }

        private void _pricingView_cmbFilterSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            _quotationModel.BOM_Filter = (BillOfMaterialsFilter)((ComboBox)sender).SelectedValue;
            _quotationModel.ItemCostingPriceAndPoints();
            _dgvPricingList.DataSource = _quotationModel.ItemCostingPriceAndPoints();

            if (_quotationModel.BOM_Filter == BillOfMaterialsFilter._PriceBreakDown)
            {
                _pricingView.GetDgvPrice().Columns[1].Visible = false;

                _pricingView.GetDgvPrice().Columns[3].Visible = true;
                _pricingView.GetDgvPrice().Columns[4].Visible = true;
            }
            else
            {
                _pricingView.GetDgvPrice().Columns[1].Visible = true;

                _pricingView.GetDgvPrice().Columns[3].Visible = false;
                _pricingView.GetDgvPrice().Columns[4].Visible = false;
            }
        }

        private void _pricingView_dgvPriceListRowPostPaintEventRaised(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void _pricingView_PricingViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                _quotationModel.BOM_Status = true;
                _dgvPricingList.DataSource = _quotationModel.ItemCostingPriceAndPoints();
                _pricingView.GetDgvPrice().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _pricingView.GetDgvPrice().Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _pricingView.GetDgvPrice().Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _pricingView.GetDgvPrice().Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _pricingView.GetDgvPrice().Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _pricingView.GetDgvPrice().Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                _pricingView.GetDgvPrice().Columns[1].Visible = false;
                _pricingView.GetDgvPrice().Columns[5].Visible = false;

                _dgvPricingList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _dgvPricingList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _dgvPricingList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                _dgvPricingList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
