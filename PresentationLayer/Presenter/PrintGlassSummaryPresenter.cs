using Microsoft.Reporting.WinForms;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PrintGlassSummaryPresenter : IPrintGlassSummaryPresenter
    {
        IPrintGlassSummaryView _printGlassSummary;

        private IUnityContainer _unityC;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IMainPresenter _mainPresenter;

        DateTimePicker _dtpGlassSummary;

        public PrintGlassSummaryPresenter(IPrintGlassSummaryView printGlassSummary)
        {
            _printGlassSummary = printGlassSummary;
            _dtpGlassSummary = _printGlassSummary.GetDateTimePicker();

            SubscribrToEventSetup();
        }

        private void SubscribrToEventSetup()
        {
            _printGlassSummary.PringGlassSummaryViewLoadEventRaised += _printGlassSummary_PringGlassSummaryViewLoadEventRaised;
            _printGlassSummary.btnRefreshClickEventRaised += _printGlassSummary_btnRefreshClickEventRaised;
        }

        private void _printGlassSummary_btnRefreshClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource RDSGlassSummary = new ReportDataSource();
                RDSGlassSummary.Name = "DataSet1";
                RDSGlassSummary.Value = _printGlassSummary.GetBindingSource();

                _printGlassSummary.GetReportViewer().LocalReport.DataSources.Add(RDSGlassSummary);
                _printGlassSummary.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.GlassSummary.rdlc";


                ReportParameter[] RParam = new ReportParameter[3];
                RParam[0] = new ReportParameter("deyt1", _dtpGlassSummary.Value.ToString("MM/dd/yyyy"));
                RParam[1] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);
                RParam[2] = new ReportParameter("ProjectName", _mainPresenter.inputted_projectName);

                _printGlassSummary.GetReportViewer().LocalReport.SetParameters(RParam);
                _printGlassSummary.GetReportViewer().SetDisplayMode(DisplayMode.PrintLayout);
                _printGlassSummary.GetReportViewer().ZoomMode = ZoomMode.Percent;
                _printGlassSummary.GetReportViewer().ZoomPercent = 75;
                _printGlassSummary.GetReportViewer().RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Console.WriteLine(_dtpGlassSummary.Value.ToString("MM/dd/yyyy"));
        }

        private void _printGlassSummary_PringGlassSummaryViewLoadEventRaised(object sender, EventArgs e)
        {
            _printGlassSummary_btnRefreshClickEventRaised(sender, e);
        }

        public IPrintGlassSummaryView GetPrintGlassSummaryView()
        {
            return _printGlassSummary;
        }

        public IPrintGlassSummaryPresenter GetNewInstance(IUnityContainer unityC,
                                                          IQuoteItemListPresenter quoteItemListPresenter,
                                                          IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<IPrintGlassSummaryView, PrintGlassSummaryView>()
                  .RegisterType<IPrintGlassSummaryPresenter, PrintGlassSummaryPresenter>();
            PrintGlassSummaryPresenter PrintGlass = unityC.Resolve<PrintGlassSummaryPresenter>();
            PrintGlass._unityC = unityC;
            PrintGlass._quoteItemListPresenter = quoteItemListPresenter;
            PrintGlass._mainPresenter = mainPresenter;

            return PrintGlass;
        }
    }
}
