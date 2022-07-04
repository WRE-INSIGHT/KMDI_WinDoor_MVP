﻿using Microsoft.Reporting.WinForms;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PrintQuotePresenter : IPrintQuotePresenter
    {
        IPrintQuoteView _printQuoteView;

        private IUnityContainer _unityC;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IMainPresenter _mainPresenter;

        public PrintQuotePresenter(IPrintQuoteView printQuoteView)
        {
            _printQuoteView = printQuoteView;


            SubscribrToEventSetup();
        }

        private void SubscribrToEventSetup()
        {
            _printQuoteView.btnRefreshClickEventRaised += _printQuoteView_btnRefreshClickEventRaised;
            _printQuoteView.PrintQuoteViewLoadEventRaised += _printQuoteView_PrintQuoteViewLoadEventRaised;
        }

        private void _printQuoteView_PrintQuoteViewLoadEventRaised(object sender, System.EventArgs e)
        {
            // _printQuoteView.GetReportViewer().RefreshReport();
            _printQuoteView_btnRefreshClickEventRaised(sender, e);
        }

        private void _printQuoteView_btnRefreshClickEventRaised(object sender, System.EventArgs e)
        {
            try
            {
                ReportDataSource RDSQuote = new ReportDataSource();
                RDSQuote.Name = "DataSet1";
                RDSQuote.Value = _printQuoteView.GetBindingSource();

                _printQuoteView.GetReportViewer().LocalReport.DataSources.Add(RDSQuote);
                //_printQuoteView.GetReportViewer().ProcessingMode = ProcessingMode.Local;
                _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Quotation.rdlc";


                ReportParameter[] RParam = new ReportParameter[6];
                RParam[0] = new ReportParameter("deyt", _printQuoteView.GetDTPDate().Value.ToString("MM/dd/yyyy"));
                RParam[1] = new ReportParameter("Address", _printQuoteView.QuotationAddress);
                RParam[2] = new ReportParameter("Salutation", _printQuoteView.QuotationSalutation);
                RParam[3] = new ReportParameter("Body", _printQuoteView.QuotationBody);
                RParam[4] = new ReportParameter("CustomerRef", _mainPresenter.inputted_custRefNo);
                RParam[5] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);


                _printQuoteView.GetReportViewer().LocalReport.SetParameters(RParam);
                _printQuoteView.GetReportViewer().SetDisplayMode(DisplayMode.PrintLayout);
                _printQuoteView.GetReportViewer().ZoomMode = ZoomMode.Percent;
                _printQuoteView.GetReportViewer().ZoomPercent = 75;
                _printQuoteView.GetReportViewer().RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IPrintQuoteView GetPrintQuoteView()
        {
            return _printQuoteView;
        }


        public IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                                   IQuoteItemListPresenter quoteItemListPresenter,
                                                    IMainPresenter mainPresenter
                                                    )
        {
            unityC
                .RegisterType<IPrintQuoteView, PrintQuoteView>()
                .RegisterType<IPrintQuotePresenter, PrintQuotePresenter>();
            PrintQuotePresenter printQuote = unityC.Resolve<PrintQuotePresenter>();
            printQuote._unityC = unityC;
            printQuote._quoteItemListPresenter = quoteItemListPresenter;
            printQuote._mainPresenter = mainPresenter;


            return printQuote;
        }
    }
}