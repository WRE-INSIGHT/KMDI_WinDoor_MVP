using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PriceHistoryPresenter : IPriceHistoryPresenter
    {
        IPriceHistoryView _priceHistoryView;
        private IMainPresenter _mainPresenter;
        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;

        private ComboBox _cmbPriceHistory;

        public PriceHistoryPresenter(IPriceHistoryView priceHistoryView)
        {
            _priceHistoryView = priceHistoryView;
            _cmbPriceHistory = _priceHistoryView.cmbPriceHistory;
            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _priceHistoryView.PriceHistoryViewLoadEventRaised += _priceHistoryView_PriceHistoryViewLoadEventRaised;
            _priceHistoryView.cmb_PriceHistorySelectedValueChangedEventRaised += _priceHistoryView_cmb_PriceHistorySelectedValueChangedEventRaised;
        }

        private void _priceHistoryView_cmb_PriceHistorySelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            foreach (IWindoorModel wdr in _quotationModel.Lst_Windoor)
            {
                if (wdr.WD_Selected == true)
                {
                    if (wdr.lst_TotalPriceHistory.Count != 0)
                    {
                        foreach (string item in wdr.lst_TotalPriceHistory)
                        {
                            if (item.Contains(_cmbPriceHistory.SelectedValue.ToString()))
                            {
                                _priceHistoryView.PriceHistory.Text = item;
                            }
                        }
                    }
                }
            }
        }

        private void _priceHistoryView_PriceHistoryViewLoadEventRaised(object sender, EventArgs e)
        {
            List<string> priceHistory = new List<string>();

            foreach (IWindoorModel wdr in _quotationModel.Lst_Windoor)
            {
                if (wdr.WD_Selected == true)
                {
                    if (wdr.lst_TotalPriceHistory.Count != 0)
                    {
                        foreach (string item in wdr.lst_TotalPriceHistory)
                        {
                            if (item != null)
                            {
                                if (item.Contains("` COMPUTATION FOR SAVING `"))
                                {
                                    string computationHistory = item.Replace("` COMPUTATION FOR SAVING `\n", string.Empty);
                                    string deyt = computationHistory.Substring(0, 20).Replace(@"`", string.Empty);
                                    priceHistory.Add(deyt);
                                }
                                else if (item.Contains("Edited Price: "))
                                {
                                    string deyt = item.Substring(0, 20).Replace(@"`", string.Empty);

                                    priceHistory.Add(deyt);
                                }
                            }
                        }
                    }
                }
            }

            priceHistory.Reverse();

            _cmbPriceHistory.DataSource = priceHistory;

            foreach (IWindoorModel wdr in _quotationModel.Lst_Windoor)
            {
                if (wdr.WD_Selected == true)
                { 
                    if (wdr.lst_TotalPriceHistory.Count != 0 && _cmbPriceHistory.Items.Count != 0)
                    {
                        foreach (string item in wdr.lst_TotalPriceHistory)
                        {
                            if (item.Contains(_cmbPriceHistory.SelectedValue.ToString()))
                            {
                                _priceHistoryView.PriceHistory.Text = item;
                            }
                        }
                    }
                }
            }


        }



        public IPriceHistoryView GetPriceHistoryView()
        {
            return _priceHistoryView;
        }

        public IPriceHistoryPresenter CreateNewInstance(IUnityContainer unityC,
                                                        IMainPresenter mainPresenter,
                                                        IQuotationModel quotationModel)
        {
            unityC
                .RegisterType<IPriceHistoryView, PriceHistoryView>()
                .RegisterType<IPriceHistoryPresenter, PriceHistoryPresenter>();
            PriceHistoryPresenter priceHistory = unityC.Resolve<PriceHistoryPresenter>();

            priceHistory._unityC = unityC;
            priceHistory._mainPresenter = mainPresenter;
            priceHistory._quotationModel = quotationModel;

            return priceHistory;
        }
    }
}
