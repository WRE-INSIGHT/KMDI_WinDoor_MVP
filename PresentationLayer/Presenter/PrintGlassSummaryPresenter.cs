using Microsoft.Reporting.WinForms;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;

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

        private void UpdateRDLC()
        {
            try
            {
                ReportDataSource RDSGlassSummary = new ReportDataSource();
                RDSGlassSummary.Name = "DataSet1";
                RDSGlassSummary.Value = _printGlassSummary.GetBindingSource();

                _printGlassSummary.GetReportViewer().LocalReport.DataSources.Add(RDSGlassSummary);
                _printGlassSummary.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.GlassSummary.rdlc";
                
                ReportParameter[] RParam = new ReportParameter[4];
                RParam[0] = new ReportParameter("deyt1", _dtpGlassSummary.Value.ToString("MM/dd/yyyy"));
                RParam[1] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);
                RParam[2] = new ReportParameter("ProjectName", _mainPresenter.inputted_projectName);
                RParam[3] = new ReportParameter("GlassPrice", "False");
                            
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

        private void _printGlassSummary_btnRefreshClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource RDSGlassSummary = new ReportDataSource();
                RDSGlassSummary.Name = "DataSet1";
                RDSGlassSummary.Value = _printGlassSummary.GetBindingSource();

                _printGlassSummary.GetReportViewer().LocalReport.DataSources.Add(RDSGlassSummary);
                _printGlassSummary.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.GlassSummary.rdlc";

                ReportParameter[] RParam = new ReportParameter[4];
                RParam[0] = new ReportParameter("deyt1", _dtpGlassSummary.Value.ToString("MM/dd/yyyy"));
                RParam[1] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);
                RParam[2] = new ReportParameter("ProjectName", _mainPresenter.inputted_projectName);

                if(_printGlassSummary.ShowPrice().Checked == true)
                {
                    RParam[3] = new ReportParameter("GlassPrice", "True");
                }
                else
                {
                    RParam[3] = new ReportParameter("GlassPrice", "False");
                }
             
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
            UpdateRDLC();
        }

        public IPrintGlassSummaryView GetPrintGlassSummaryView()
        {
            return _printGlassSummary;
        }

        public IPrintGlassSummaryPresenter GetNewInstance(IUnityContainer unityC,
                                                          IQuoteItemListPresenter quoteItemListPresenter,
                                                          IMainPresenter mainPresenter,
                                                          IWindoorModel windoorModel,
                                                          IQuotationModel quotationModel)
        {
            unityC
                  .RegisterType<IPrintGlassSummaryView, PrintGlassSummaryView>()
                  .RegisterType<IPrintGlassSummaryPresenter, PrintGlassSummaryPresenter>();
            PrintGlassSummaryPresenter PrintGlass = unityC.Resolve<PrintGlassSummaryPresenter>();
            PrintGlass._unityC = unityC;
            PrintGlass._quoteItemListPresenter = quoteItemListPresenter;
            PrintGlass._mainPresenter = mainPresenter;
            PrintGlass._windoorModel = windoorModel;
            PrintGlass._quotationModel = quotationModel;

            return PrintGlass;
        }
    }
}
