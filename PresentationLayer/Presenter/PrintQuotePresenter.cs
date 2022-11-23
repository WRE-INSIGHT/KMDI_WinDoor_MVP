using Microsoft.Reporting.WinForms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                List<string> Lst_BaseColor = new List<string>();
                List<string> Lst_Panel = new List<string>();
                foreach (IWindoorModel wdm in _mainPresenter.qoutationModel_MainPresenter.Lst_Windoor)
                {
                    Lst_BaseColor.Add(wdm.WD_BaseColor.ToString());
                    foreach(IFrameModel frm in wdm.lst_frame)
                    {
                        foreach(IMultiPanelModel mpnl in frm.Lst_MultiPanel)
                        {
                            foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                            {
                                Lst_Panel.Add(pnl.Panel_GlassThicknessDesc.ToString());
                            }
                        }
                        foreach(IPanelModel pnl in frm.Lst_Panel)
                        {
                            Lst_Panel.Add(pnl.Panel_GlassThicknessDesc.ToString());
                        }
                    }
                    

                }

                int GlassCount = 0;
                string GlassThickness = "";
                var q = from x in Lst_Panel
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };
                foreach (var x in q)
                {
                    if(x.Count > GlassCount)
                    {
                        GlassCount = x.Count;
                        GlassThickness = x.Value.ToString();
                    }
                }

                var duplicateBaseColor = Lst_BaseColor.Distinct().ToList();
                string baseColor = "";
                for (int i = 0; i < duplicateBaseColor.Count(); i++)
                {
                    if(i == 0)
                    {
                        baseColor += duplicateBaseColor.ToList()[i];
                    }
                    else if (i == 1)
                    {
                        if (duplicateBaseColor.Count() == 3)
                        {
                            baseColor += ", " + duplicateBaseColor.ToList()[i];

                        }
                        else
                        {
                            baseColor += " & " + duplicateBaseColor.ToList()[i];

                        }
                    }
                    else if (i == 2)
                    {
                        baseColor += " & " + duplicateBaseColor.ToList()[i];
                    }
                }
                if(GlassThickness != "Unglazed" && GlassThickness != "")
                {
                    GlassThickness = GlassThickness.Substring(0, GlassThickness.IndexOf("mm")).Trim() + ".0" + GlassThickness.Substring(GlassThickness.IndexOf("mm")).Trim();
                }
                baseColor = baseColor.Replace("Dark Brown", "WOODGRAIN");
                _printQuoteView.QuotationBody = "Thank you for letting us serve you. Please find herewith our quotation for our world-class uPVC windows and doors from Germany for your requirements on your residence.\n\n"
                                              + "USING "
                                              + baseColor.ToUpper()
                                              + " PROFILES\n"
                                              + "USING "
                                              + GlassThickness.ToUpper()
                                              + " GLASS UNLESS OTHERWISE SPECIFIED\n\n"
                                              + "PRICE VALIDITY: 30 DAYS FROM DATE OF THIS QUOTATION**";
                _printQuoteView.QuotationSalutation = "INITIAL QUOTATION\n\nDear "
                                                    + _mainPresenter.titleLastname
                                                    + ",";
                _printQuoteView.QuotationAddress = "To: \n" + _mainPresenter.inputted_projectName + "\n" + _mainPresenter.projectAddress.Replace(" Luzon", "").Replace(" Visayas", "").Replace(" Mindanao", "");
                _printQuoteView.GetReportViewer().RefreshReport();
                _printQuoteView_btnRefreshClickEventRaised(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Location: " + this + "\n\n" + ex.Message);
            }            
          
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
                if (_mainPresenter.printStatus== "WinDoorItems")
                {
                    _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Quotation.rdlc";
                }
                else if (_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Screen.rdlc";

                }


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
                                                   IMainPresenter mainPresenter)
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

        public IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                                  IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPrintQuoteView, PrintQuoteView>()
                .RegisterType<IPrintQuotePresenter, PrintQuotePresenter>();
            PrintQuotePresenter printQuote = unityC.Resolve<PrintQuotePresenter>();
            printQuote._unityC = unityC;
            printQuote._mainPresenter = mainPresenter;


            return printQuote;
        }
    }
}
