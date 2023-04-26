﻿using Microsoft.Reporting.WinForms;
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
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private IQuotationModel _quotationModel;
        bool showImage, 
            chklist_exist = false,
            checklist_raised = false,
            _rdlcHeaderIsPresent = false;
        string GlassThickness_key,
               basecolor_key,
               QuotationBody_key,
               QuotationSalutation_key,
               QuotationAddress_key,
               VatPercentage_key,
               QuotationOuofTownExpenses_key,
               GlassThickness,
               baseColor;






        public PrintQuotePresenter(IPrintQuoteView printQuoteView)
        {
            _printQuoteView = printQuoteView;
            SubscribrToEventSetup();
        }

        private void SubscribrToEventSetup()
        {
            _printQuoteView.btnRefreshClickEventRaised += _printQuoteView_btnRefreshClickEventRaised;
            _printQuoteView.PrintQuoteViewLoadEventRaised += _printQuoteView_PrintQuoteViewLoadEventRaised;
            _printQuoteView.SelectedIndexChangeEventRaised += _printQuoteView_SelectedIndexChangeEventRaised;
            _printQuoteView.txtoftexpensesKeyPressEventRaised += _printQuoteView_txtoftexpensesKeyPressEventRaised;
            _printQuoteView.chkboxLnMCheckedChangedEventRaised += _printQuoteView_chkboxLnMCheckedChangedEventRaised;
            _printQuoteView.chkboxFCCheckedChangedEventRaised += _printQuoteView_chkboxFCCheckedChangedEventRaised;
            _printQuoteView.chkboxVATCheckedChangedEventRaised += _printQuoteView_chkboxVATCheckedChangedEventRaised;
            _printQuoteView.PrintQuoteViewFormClosingEventRaised += _printQuoteView_PrintQuoteViewFormClosingEventRaised;
        }



        private void _printQuoteView_chkboxVATCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_printQuoteView.GetVatChkbox().Checked)
            {
                if (_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.GetVatTxtbox().Visible = true;
                    _printQuoteView.GetVatTxtbox().Location = new System.Drawing.Point(330, 88);
                }
                else if (_mainPresenter.printStatus == "ContractSummary")
                {
                    _printQuoteView.GetVatTxtbox().Visible = true;

                    var Curr_X_Location = _printQuoteView.GetVatChkbox().Location.X;
                    int converted_XLoc = Convert.ToInt32(Curr_X_Location);
                    int Vat_X_Loc = converted_XLoc + 130;
                    _printQuoteView.GetVatTxtbox().Location = new System.Drawing.Point(Vat_X_Loc, 90);
                    _printQuoteView.GetVatTxtbox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                }
            }
            else
            {
                _printQuoteView.GetVatTxtbox().Visible = false;
            }
        }

        private void _printQuoteView_chkboxFCCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_printQuoteView.GetFreightChargesChkbox().Checked)
            {
                if (_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.GetFreightChargeTxtBox().Visible = true;
                    _printQuoteView.GetFreightChargeTxtBox().Location = new System.Drawing.Point(330, 59);
                }
                else if (_mainPresenter.printStatus == "ContractSummary")
                {
                    _printQuoteView.GetFreightChargeTxtBox().Visible = true;

                    var Curr_X_Location = _printQuoteView.GetFreightChargesChkbox().Location.X;            
                    int converted_XLoc = Convert.ToInt32(Curr_X_Location);
                    int FreightC_X_Loc = converted_XLoc + 130;
                    _printQuoteView.GetFreightChargeTxtBox().Location = new System.Drawing.Point(FreightC_X_Loc, 59);
                    _printQuoteView.GetFreightChargeTxtBox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                }
            }
            else
            {
                _printQuoteView.GetFreightChargeTxtBox().Visible = false;
            }
        }

        private void _printQuoteView_chkboxLnMCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_printQuoteView.GetLabor_N_MobiChkbox().Checked)
            {
                if(_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.GetLabor_N_MobiTxtBox().Visible = true;
                    _printQuoteView.GetLabor_N_MobiTxtBox().Location = new System.Drawing.Point(330,28);
                }
                else if(_mainPresenter.printStatus == "ContractSummary")
                {                                    
                    _printQuoteView.GetLabor_N_MobiTxtBox().Visible = true;

                    var Curr_X_Location = _printQuoteView.GetLabor_N_MobiChkbox().Location.X;
                    int converted_XLoc = Convert.ToInt32(Curr_X_Location);
                    int LnMMobiTxtBox_X_Loc = converted_XLoc + 130 ;                                  
                    _printQuoteView.GetLabor_N_MobiTxtBox().Location = new System.Drawing.Point(LnMMobiTxtBox_X_Loc, 28);
                    _printQuoteView.GetLabor_N_MobiTxtBox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    
                }
            }
            else
            {
                _printQuoteView.GetLabor_N_MobiTxtBox().Visible = false;
            }
        }

        private void _printQuoteView_PrintQuoteViewFormClosingEventRaised(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("closing na yung form ng print ");
           // GlassThickness_key = _mainPresenter.printStatus + "_" + "GlassThickness";
           // basecolor_key = _mainPresenter.printStatus + "_" + "basecolor";
            QuotationBody_key = _mainPresenter.printStatus + "_" + "QuotationBody";
            QuotationSalutation_key = _mainPresenter.printStatus + "_" + "QuotationSalutation";
            QuotationAddress_key = _mainPresenter.printStatus + "_" + "QuotationAddress";
            VatPercentage_key = _mainPresenter.printStatus + "_" + "VatPercentage";
            QuotationOuofTownExpenses_key = _mainPresenter.printStatus + "_" + "QuotationOuofTownExpenses_key";

            if (_rdlcHeaderIsPresent == true)
            {
                //_mainPresenter.RDLCHeader[GlassThickness_key] = GlassThickness;
                //_mainPresenter.RDLCHeader[basecolor_key] = baseColor;
                _mainPresenter.RDLCHeader[QuotationBody_key] = _printQuoteView.QuotationBody;
                _mainPresenter.RDLCHeader[QuotationSalutation_key] = _printQuoteView.QuotationSalutation;
                _mainPresenter.RDLCHeader[QuotationAddress_key] = _printQuoteView.QuotationAddress;
                _mainPresenter.RDLCHeader[VatPercentage_key] = _printQuoteView.VatPercentage;
                _mainPresenter.RDLCHeader[QuotationOuofTownExpenses_key] = _printQuoteView.QuotationOuofTownExpenses;
            }
            else
            {            
                //_mainPresenter.RDLCHeader.Add(GlassThickness_key,GlassThickness);
                //_mainPresenter.RDLCHeader.Add(basecolor_key,baseColor);
                _mainPresenter.RDLCHeader.Add(QuotationBody_key, _printQuoteView.QuotationBody);
                _mainPresenter.RDLCHeader.Add(QuotationSalutation_key, _printQuoteView.QuotationSalutation);
                _mainPresenter.RDLCHeader.Add(QuotationAddress_key, _printQuoteView.QuotationAddress);
                _mainPresenter.RDLCHeader.Add(VatPercentage_key, _printQuoteView.VatPercentage);
                _mainPresenter.RDLCHeader.Add(QuotationOuofTownExpenses_key,_printQuoteView.QuotationOuofTownExpenses);

            }
        }
        public void EventLoad()
        {
           
           List<string> Lst_BaseColor = new List<string>();
           List<string> Lst_Panel = new List<string>();
           foreach (IWindoorModel wdm in _mainPresenter.qoutationModel_MainPresenter.Lst_Windoor)
           {
               Lst_BaseColor.Add(wdm.WD_BaseColor.ToString());

               _printQuoteView.GetChkLstBox().Items.Add("Item: " + wdm.WD_id);


               foreach (IFrameModel frm in wdm.lst_frame)
               {
                   foreach (IMultiPanelModel mpnl in frm.Lst_MultiPanel)
                   {
                       foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                       {
                           Lst_Panel.Add(pnl.Panel_GlassThicknessDesc.ToString());
                       }
                   }
                   foreach (IPanelModel pnl in frm.Lst_Panel)
                   {
                       Lst_Panel.Add(pnl.Panel_GlassThicknessDesc.ToString());
                   }
               }


           }


           int GlassCount = 0;
            GlassThickness = "";
           var q = from x in Lst_Panel
                   group x by x into g
                   let count = g.Count()
                   orderby count descending
                   select new { Value = g.Key, Count = count };
           foreach (var x in q)
           {
               if (x.Count > GlassCount)
               {
                   GlassCount = x.Count;
                   GlassThickness = x.Value.ToString();
               }
           }

           var duplicateBaseColor = Lst_BaseColor.Distinct().ToList();
            baseColor = "";
           for (int i = 0; i < duplicateBaseColor.Count(); i++)
           {
               if (i == 0)
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
                      
            foreach (var headers_keys in _mainPresenter.RDLCHeader)
            {
                if (headers_keys.Key.Contains(_mainPresenter.printStatus))
                {
                    _rdlcHeaderIsPresent = true;
                    break;
                }
            }

            if (_rdlcHeaderIsPresent == true)
            {
                foreach(var headers in _mainPresenter.RDLCHeader)
                {
                    if(headers.Key.Contains(_mainPresenter.printStatus))
                    {
                        if (headers.Key.Contains("GlassThickness"))
                        {
                            GlassThickness = headers.Value;
                        }
                        else if (headers.Key.Contains("baseColor"))
                        {
                            baseColor = headers.Value;
                        }
                        else if (headers.Key.Contains("QuotationBody"))
                        {
                            _printQuoteView.QuotationBody = headers.Value;
                        }
                        else if (headers.Key.Contains("QuotationSalutation"))
                        {
                            _printQuoteView.QuotationSalutation = headers.Value;
                        }
                        else if (headers.Key.Contains("QuotationAddress"))
                        {
                            _printQuoteView.QuotationAddress = headers.Value;
                        }
                        else if (headers.Key.Contains("VatPercentage"))
                        {
                            _printQuoteView.VatPercentage = headers.Value;
                        }
                        else if (headers.Key.Contains("QuotationOuofTownExpenses"))
                        {
                            _printQuoteView.QuotationOuofTownExpenses = headers.Value;
                        }
                                                 
                    }
                }
            }
            else
            {

                if (GlassThickness != "Unglazed" && GlassThickness != "")
                {
                    GlassThickness = GlassThickness.Substring(0, GlassThickness.IndexOf("mm")).Trim() + ".0" + GlassThickness.Substring(GlassThickness.IndexOf("mm")).Trim();
                }
                baseColor = baseColor.Replace("Dark Brown", "WOODGRAIN");
                if (_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.QuotationBody = "Thank you for letting us serve you. Please find herewith our quotation for the Insect Screens corresponding to our world-class PVC-u windows and doors from Germany for your requirements on your residence.";
                }
                else
                {
                    _printQuoteView.QuotationBody = "Thank you for letting us serve you. Please find herewith our quotation for our world-class uPVC windows and doors from Germany for your requirements on your residence.\n\n"
                                                              + "USING "
                                                              + baseColor.ToUpper()
                                                              + " PROFILES\n"
                                                              + "USING " 
                                                              + GlassThickness.ToUpper()
                                                              + " GLASS UNLESS OTHERWISE SPECIFIED\n\n"
                                                              + "PRICE VALIDITY: 30 DAYS FROM DATE OF THIS QUOTATION";
                }

                _printQuoteView.QuotationSalutation = "INITIAL QUOTATION\n\nDear "
                                                    + _mainPresenter.titleLastname
                                                    + ",";
                _printQuoteView.QuotationAddress = "To: \n" + _mainPresenter.inputted_projectName + "\n" + _mainPresenter.projectAddress.Replace(", Luzon", "").Replace(", Visayas", "").Replace(", Mindanao", "");
                _printQuoteView.QuotationOuofTownExpenses = "0";
                _printQuoteView.VatPercentage = "12";
            }
            _printQuoteView.GetDTPDate().Value = DateTime.Now;
        }
        private void _printQuoteView_PrintQuoteViewLoadEventRaised(object sender, System.EventArgs e)
        {
            try
            {
                EventLoad();
                //_printQuoteView.GetShowPageNum().Checked = true; //Showpagenum checked on load     
                _printQuoteView.GetReportViewer().RefreshReport();
                _printQuoteView_btnRefreshClickEventRaised(sender, e);           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Location: " + this + "\n\n" + ex.Message);
            }
        }
        int count = 0,
            newlinecount = 0;
        bool change_desc_format = false;
        string separete_descFormat = null;
        List<string> description_string_list = new List<string>();
        private void ShowItemImage()
        {
            foreach (var item in _printQuoteView.GetChkLstBox().CheckedIndices)
            {
                chklist_exist = true;
                break;
            }
                      
                #region ShowItemImage 

                DSQuotation _dsq = new DSQuotation();

                for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
                {

                    MemoryStream mstream = new MemoryStream();
                    MemoryStream mstream2 = new MemoryStream();
                    Image itemImage = _quotationModel.Lst_Windoor[i].WD_image,
                          topView = _quotationModel.Lst_Windoor[i].WD_SlidingTopViewImage;

                    itemImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);

                    if (topView != null)
                    {
                        topView.Save(mstream2, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    byte[] arrimageForItemImage = mstream.ToArray();
                    byte[] arrimageForTopView = mstream2.ToArray();

                    string byteToStrForItemImage = Convert.ToBase64String(arrimageForItemImage);
                    string byteToStrForTopView = Convert.ToBase64String(arrimageForTopView);

                    IQuoteItemListUCPresenter lstQuoteUC = _quoteItemListPresenter.LstQuoteItemUC[i];

                if(chklist_exist == true)
                {
                    foreach (var item in _printQuoteView.GetChkLstBox().CheckedIndices)
                    {
                        showImage = false;

                        var itemToIndx = Convert.ToInt32(item);
                        if (i == itemToIndx)
                        {
                            showImage = true;

                            #region separate Item description
                            for (int j = 0; j < lstQuoteUC.GetiQuoteItemListUC().itemDesc.Length; j++)
                            {
                                if (lstQuoteUC.GetiQuoteItemListUC().itemDesc[j] == '\n')
                                {
                                    count++;
                                }

                            }
                            if (count >= 5)
                            {
                                change_desc_format = true;
                                string[] splitted_string = lstQuoteUC.GetiQuoteItemListUC().itemDesc.Split('\n');
                                foreach (var split in splitted_string)
                                {
                                    description_string_list.Add(split);
                                }
                                // for(int arr =0; arr <15; arr++)
                                //{
                                //    if(splitted_string.Count() > description_string_list.Count())
                                //    {
                                //        description_string_list.Add(splitted_string[arr]);
                                //    }
                                //    else
                                //    {
                                //        description_string_list.Add(" ");
                                //    }
                                //}
                            }
                            else
                            {
                                change_desc_format = false;
                                count = 0;
                            }

                            if (change_desc_format == true)
                            {
                                for (int x = 0; x < description_string_list.Count; x++)
                                {
                                    newlinecount++;
                                    if (newlinecount == 3)
                                    {
                                        newlinecount = 0;
                                        separete_descFormat = separete_descFormat + "  " + description_string_list[x] + "," + "\n";

                                    }
                                    else
                                    {
                                        separete_descFormat = separete_descFormat + "  " + description_string_list[x];
                                    }
                                }
                                Console.WriteLine(separete_descFormat.TrimEnd().Replace(" +", ""));
                            }
                            else
                            {
                                description_string_list.Clear();
                                count = 0;
                            }

                            if (separete_descFormat == null)
                            {
                                separete_descFormat = lstQuoteUC.GetiQuoteItemListUC().itemDesc;
                            }

                            #endregion



                            break;
                        }
                    }
                }
                else
                {
                    showImage = false;
                }


                _dsq.dtQuote.dtTopViewImageColumn.AllowDBNull = true;

                    _dsq.dtQuote.Rows.Add(lstQuoteUC.GetiQuoteItemListUC().ItemName,
                                          lstQuoteUC.GetiQuoteItemListUC().itemDesc,
                                          lstQuoteUC.GetiQuoteItemListUC().itemWindoorNumber,
                                          byteToStrForItemImage,
                                          lstQuoteUC.GetiQuoteItemListUC().itemQuantity.Value,
                                          lstQuoteUC.GetiQuoteItemListUC().itemPrice.Value.ToString("N", new CultureInfo("en-US")),
                                          lstQuoteUC.GetiQuoteItemListUC().itemDiscount.Value,
                                          Convert.ToDecimal(lstQuoteUC.GetiQuoteItemListUC().GetLblNetPrice().Text),
                                          i + 1,
                                          byteToStrForTopView,
                                          showImage,
                                          separete_descFormat
                                          );


                description_string_list.Clear();
                count = 0;
                newlinecount = 0;
                separete_descFormat = null;
            }

            #endregion

            this.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtQuote.DefaultView;
                chklist_exist = false;           
        }

        private void _printQuoteView_SelectedIndexChangeEventRaised(object sender, EventArgs e)
        {
            checklist_raised = true;
        }
        private void _printQuoteView_btnRefreshClickEventRaised(object sender, System.EventArgs e)
        {

            PrintRDLCReport();

            _printQuoteView.GetReportViewer().SetDisplayMode(DisplayMode.PrintLayout);
            _printQuoteView.GetReportViewer().ZoomMode = ZoomMode.Percent;
            _printQuoteView.GetReportViewer().ZoomPercent = 100;
            _printQuoteView.GetReportViewer().RefreshReport();
        }

        private void _printQuoteView_txtoftexpensesKeyPressEventRaised(object sender, EventArgs e)
        {
            try
            {
                decimal OOTValue = Convert.ToDecimal(_printQuoteView.QuotationOuofTownExpenses);
                string formattedOOTVal = OOTValue.ToString("N2");
                _printQuoteView.QuotationOuofTownExpenses = formattedOOTVal;
                _printQuoteView_btnRefreshClickEventRaised(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in "  + this + ex.Message);
            }
        }

        public void PrintRDLCReport()
        {
            try
            {

                if (checklist_raised == true)
                {
                    ShowItemImage();
                }
                Console.WriteLine("Checklist_Raise.: " + checklist_raised.ToString());

                ReportDataSource RDSQuote = new ReportDataSource();
                RDSQuote.Name = "DataSet1";
                RDSQuote.Value = _printQuoteView.GetBindingSource();
                _printQuoteView.GetReportViewer().LocalReport.DataSources.Add(RDSQuote);

                //_printQuoteView.GetReportViewer().ProcessingMode = ProcessingMode.Local;
                if (_mainPresenter.printStatus == "WinDoorItems")
                {
                    _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Quotation.rdlc";
                }
                else if (_mainPresenter.printStatus == "ScreenItem")
                {
                    _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Screen.rdlc";
                }
                else if (_mainPresenter.printStatus == "ContractSummary")
                {
                    _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.SummaryOfContract.rdlc";
                    //_printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Annex.rdlc";
                }

                if (_mainPresenter.printStatus == "ScreenItem")
                {
                    #region Screen RDLC
                    _printQuoteView.GetRefreshBtn().Location = new System.Drawing.Point(38, 109);
                    _printQuoteView.GetRefreshBtn().Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                    _printQuoteView.GetOutofTownExpenses().Visible = false;
                    _printQuoteView.GetChkLstBox().Visible = false;

                    #region label,TextBox & Rtextbox  new loc         
                    _printQuoteView.GetQuotationBody().Location = new System.Drawing.Point(845, 26);
                    _printQuoteView.GetQuotationSalutation().Location = new System.Drawing.Point(639, 26);
                    _printQuoteView.GetQuotationAddress().Location = new System.Drawing.Point(433, 26);

                    _printQuoteView.GetBodyLabel().Location = new System.Drawing.Point(845, 3);
                    _printQuoteView.GetSalutationLabel().Location = new System.Drawing.Point(639, 3);
                    _printQuoteView.GetAddressLabel().Location = new System.Drawing.Point(433, 3);

                    _printQuoteView.GetQuotationBody().Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    _printQuoteView.GetQuotationBody().Size = new System.Drawing.Size(620, 118);
                    _printQuoteView.GetQuotationBody().Width = _printQuoteView.GetQuotationBody().Width - 120;




                    #endregion

                    #region Visibility Additional info
                    _printQuoteView.GetAdditionalInfoLabel().Visible = false;
                    _printQuoteView.GetLabor_N_MobiChkbox().Visible = false;
                    _printQuoteView.GetFreightChargesChkbox().Visible = false;
                    _printQuoteView.GetVatChkbox().Visible = false;
                    _printQuoteView.GetAdditionalInfoLabel().Location = new System.Drawing.Point(265, 3);
                    _printQuoteView.GetLabor_N_MobiChkbox().Location = new System.Drawing.Point(205, 26);
                    _printQuoteView.GetFreightChargesChkbox().Location = new System.Drawing.Point(205, 59);
                    _printQuoteView.GetVatChkbox().Location = new System.Drawing.Point(205, 88);
                    #endregion

                    #region save files without pos in AEIC
                    if (_mainPresenter.position == null || _mainPresenter.position == " " || _mainPresenter.position == "")
                    {
                        _mainPresenter.position = " ";
                    }
                    #endregion

                    ReportParameter[] RParam = new ReportParameter[10];
                    RParam[0] = new ReportParameter("deyt", _printQuoteView.GetDTPDate().Value.ToString("MM/dd/yyyy"));
                    RParam[1] = new ReportParameter("Address", _printQuoteView.QuotationAddress);
                    RParam[2] = new ReportParameter("Salutation", _printQuoteView.QuotationSalutation);
                    RParam[3] = new ReportParameter("Body", _printQuoteView.QuotationBody);
                    RParam[4] = new ReportParameter("CustomerRef", _mainPresenter.inputted_custRefNo);
                    RParam[5] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);
                    RParam[6] = new ReportParameter("ASPersonnel", Convert.ToString(_mainPresenter.aeic).ToUpper());
                    RParam[7] = new ReportParameter("ASPosition", _mainPresenter.position);

                    if (_printQuoteView.ShowLastPage().Checked)
                    {
                        RParam[8] = new ReportParameter("ListScreen", "True");
                    }
                    else
                    {
                        RParam[8] = new ReportParameter("ListScreen", "False");
                    }

                    if (_printQuoteView.GetShowPageNum().Checked)
                    {
                        RParam[9] = new ReportParameter("ShowPageNum", "True");
                    }
                    else
                    {
                        RParam[9] = new ReportParameter("ShowPageNum", "False");
                    }

                    _printQuoteView.GetReportViewer().LocalReport.SetParameters(RParam);

                    try
                    {
                        #region RenderPDFAtBackground
                        if (_quoteItemListPresenter.RenderPDFAtBackGround == true)
                        {
                            Warning[] warnings;
                            string[] streamIds;
                            string mimeType = string.Empty;
                            string encoding = string.Empty;
                            string extension = string.Empty;

                            byte[] bytes = _printQuoteView.GetReportViewer().LocalReport.Render
                               ("PDF",
                               null,
                               out mimeType,
                               out encoding,
                               out extension,
                               out streamIds,
                               out warnings
                               );

                            string defDir = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder\Screen.PDF";
                            using (FileStream fs = new FileStream(defDir, FileMode.Create))
                            {
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("quoteitemlistpresenter is not used" + ex);
                    }



                    #endregion
                }
                else if (_mainPresenter.printStatus == "WinDoorItems")
                {
                    #region Windoor RDLC

                    #region  label & Rtextbox new location
                    _printQuoteView.GetAddressLabel().Location = new System.Drawing.Point(205, 3);
                    _printQuoteView.GetSalutationLabel().Location = new System.Drawing.Point(416, 3);
                    _printQuoteView.GetBodyLabel().Location = new System.Drawing.Point(627, 3);

                    _printQuoteView.GetQuotationBody().Location = new System.Drawing.Point(627,26);
                    _printQuoteView.GetQuotationSalutation().Location = new System.Drawing.Point(416, 26);
                    _printQuoteView.GetQuotationAddress().Location = new System.Drawing.Point(205, 26);

                    _printQuoteView.GetQuotationBody().Size = new System.Drawing.Size(620,118);
                    #endregion

                    _printQuoteView.ShowLastPage().Visible = false;
                    _printQuoteView.GetUniversalLabel().Visible = false;
                    _printQuoteView.GetOutofTownExpenses().Visible = false;

                    foreach (var item in _quoteItemListPresenter.ShowItemImage_CheckList.ToArray())
                    {
                        _printQuoteView.GetChkLstBox().SetItemChecked(item.ItemIndex, item.ItemboolImage);
                    }
                    _quoteItemListPresenter.ShowItemImage_CheckList.Clear();

                    ReportParameter[] RParam = new ReportParameter[8];
                    RParam[0] = new ReportParameter("deyt", _printQuoteView.GetDTPDate().Value.ToString("MM/dd/yyyy"));
                    RParam[1] = new ReportParameter("Address", _printQuoteView.QuotationAddress);
                    RParam[2] = new ReportParameter("Salutation", _printQuoteView.QuotationSalutation);
                    RParam[3] = new ReportParameter("Body", _printQuoteView.QuotationBody);
                    RParam[4] = new ReportParameter("CustomerRef", _mainPresenter.inputted_custRefNo);
                    RParam[5] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);

                    if (checklist_raised == true)
                    {
                        bool indexes_exist = false;
                        foreach (var item in _printQuoteView.GetChkLstBox().CheckedIndices)
                        {
                            //check checklist for indexes
                            indexes_exist = true;
                            break;
                        }

                        if (indexes_exist == true)
                        {
                            RParam[6] = new ReportParameter("ShowItemImage", "True");
                        }
                        else
                        {
                            RParam[6] = new ReportParameter("ShowItemImage", "False");
                        }
                    }
                    else if (_quoteItemListPresenter.GetQuoteItemListView().GetChkboxSelectAll().Checked)
                    {
                        RParam[6] = new ReportParameter("ShowItemImage", "True");
                    }
                    else if (_quoteItemListPresenter.GetQuoteItemListView().GetItemListUC_CheckBoxState == true)
                    {
                        RParam[6] = new ReportParameter("ShowItemImage", "True");
                    }
                    else if (_quoteItemListPresenter.RenderPDFAtBackGround == true && _quoteItemListPresenter.RDLCReportCompilerItemIndexes.Count != 0)
                    {
                        RParam[6] = new ReportParameter("ShowItemImage", "True");
                    }
                    else
                    {
                        RParam[6] = new ReportParameter("ShowItemImage", "False");
                    }


                    if (_printQuoteView.GetShowPageNum().Checked)
                    {
                        RParam[7] = new ReportParameter("ShowPageNum", "True");
                    }
                    else
                    {
                        RParam[7] = new ReportParameter("ShowPageNum", "False");
                    }

                    _printQuoteView.GetReportViewer().LocalReport.SetParameters(RParam);
                    _quoteItemListPresenter.GetQuoteItemListView().GetItemListUC_CheckBoxState = false;
                    checklist_raised = false;

                    #region RenderPDFAtBackground
                    if (_quoteItemListPresenter.RenderPDFAtBackGround == true)
                    {
                        Warning[] warnings;
                        string[] streamIds;
                        string mimeType = string.Empty;
                        string encoding = string.Empty;
                        string extension = string.Empty;

                        byte[] bytes = _printQuoteView.GetReportViewer().LocalReport.Render
                           ("PDF",
                           null,
                           out mimeType,
                           out encoding,
                           out extension,
                           out streamIds,
                           out warnings
                           );

                        string defDir = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder\Quotation.PDF";
                        using (FileStream fs = new FileStream(defDir, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    #endregion

                    #endregion
                }
                else if (_mainPresenter.printStatus == "ContractSummary")
                {
                    #region Contract Summary RDLC 

                    #region  label & Rtextbox new location
                    _printQuoteView.GetAddressLabel().Location = new System.Drawing.Point(205, 3);
                    _printQuoteView.GetSalutationLabel().Location = new System.Drawing.Point(416, 3);
                    _printQuoteView.GetBodyLabel().Location = new System.Drawing.Point(627, 3);

                    _printQuoteView.GetQuotationBody().Location = new System.Drawing.Point(627, 26);
                    _printQuoteView.GetQuotationSalutation().Location = new System.Drawing.Point(416, 26);
                    _printQuoteView.GetQuotationAddress().Location = new System.Drawing.Point(205, 26);

                    _printQuoteView.GetQuotationBody().Size = new System.Drawing.Size(500,118);

                    #endregion
                    #region Visibility Additional Info
                    _printQuoteView.GetAdditionalInfoLabel().Visible = true;
                    _printQuoteView.GetLabor_N_MobiChkbox().Visible = true;
                    _printQuoteView.GetFreightChargesChkbox().Visible = true;
                    _printQuoteView.GetVatChkbox().Visible = true;
                    _printQuoteView.GetAdditionalInfoLabel().Location = new System.Drawing.Point(1200, 5);
                    _printQuoteView.GetAdditionalInfoLabel().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    _printQuoteView.GetLabor_N_MobiChkbox().Location = new System.Drawing.Point(1130, 28);
                    _printQuoteView.GetLabor_N_MobiChkbox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    _printQuoteView.GetFreightChargesChkbox().Location = new System.Drawing.Point(1130, 59);
                    _printQuoteView.GetFreightChargesChkbox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    _printQuoteView.GetVatChkbox().Location = new System.Drawing.Point(1130, 88);
                    _printQuoteView.GetVatChkbox().Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    #endregion

                    _printQuoteView.GetChkLstBox().Visible = false;
                    _printQuoteView.ShowLastPage().Visible = false;
                    _printQuoteView.GetUniversalLabel().Text = "Out Of Town Expenses";
                    _printQuoteView.GetOutofTownExpenses().Location = new System.Drawing.Point(38, 81);
                    _printQuoteView.GetRefreshBtn().Location = new System.Drawing.Point(38, 109);
                    _printQuoteView.GetRefreshBtn().Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;

                    //string trimmedamount = new string(_printQuoteView.QuotationOuofTownExpenses.Where(Char.IsDigit).ToArray());
                    //int oftexpenses = Convert.ToInt32(trimmedamount);

                    #region save files without pos in AEIC
                    if (_mainPresenter.position == null || _mainPresenter.position == " " || _mainPresenter.position == "")
                    {
                        _mainPresenter.position = " ";
                    }
                    #endregion
                    ReportParameter[] RParam = new ReportParameter[7];
                    RParam[0] = new ReportParameter("QuoteNumber", _mainPresenter.inputted_quotationRefNo);
                    RParam[1] = new ReportParameter("ASPersonnel", Convert.ToString(_mainPresenter.aeic).ToUpper());                 
                    RParam[2] = new ReportParameter("ASPosition", _mainPresenter.position);
                    RParam[3] = new ReportParameter("OutofTownExpenses", ("PHP " + _printQuoteView.QuotationOuofTownExpenses));
                    RParam[6] = new ReportParameter("VatPercentage",_printQuoteView.VatPercentage);

                    if (_printQuoteView.GetShowPageNum().Checked)
                    {
                        RParam[4] = new ReportParameter("ShowPageNum", "True");
                    }
                    else
                    {
                        RParam[4] = new ReportParameter("ShowPageNum", "False");
                    }

                    if (_printQuoteView.GetVatChkbox().Checked)
                    {
                        RParam[5] = new ReportParameter("ShowVat", "True");
                    }
                    else
                    {
                        RParam[5] = new ReportParameter("ShowVat", "False");
                    }

                    _printQuoteView.GetReportViewer().LocalReport.SetParameters(RParam);
                    //_printQuoteView.QuotationOuofTownExpenses = oftexpenses.ToString("n");

                    #region RenderPDFAtBackground
                    if (_quoteItemListPresenter.RenderPDFAtBackGround == true)
                    {
                        Warning[] warnings;
                        string[] streamIds;
                        string mimeType = string.Empty;
                        string encoding = string.Empty;
                        string extension = string.Empty;

                        byte[] bytes = _printQuoteView.GetReportViewer().LocalReport.Render
                           ("PDF",
                           null,
                           out mimeType,
                           out encoding,
                           out extension,
                           out streamIds,
                           out warnings
                           );

                        string defDir = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder\SummaryOfContract.PDF";
                        using (FileStream fs = new FileStream(defDir, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }
                        printAnnexRDLC();
                    }
                    #endregion

                    #endregion
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine(this + " error in  print" + ex.Message);
            }
        }
        
        public void printAnnexRDLC()
        {
            _printQuoteView.GetReportViewer().LocalReport.ReportEmbeddedResource = @"PresentationLayer.Reports.Annex.rdlc";

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = _printQuoteView.GetReportViewer().LocalReport.Render
               ("PDF",
               null,
               out mimeType,
               out encoding,
               out extension,
               out streamIds,
               out warnings
               );

            string defDir = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder\X.PDF";
            using (FileStream fs = new FileStream(defDir, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
        public IPrintQuoteView GetPrintQuoteView()
        {
            return _printQuoteView;
        }


        public IPrintQuotePresenter GetNewInstance(IUnityContainer unityC,
                                                   IQuoteItemListPresenter quoteItemListPresenter,
                                                   IMainPresenter mainPresenter,
                                                   IQuotationModel quotationModel
                                                   )
        {
            unityC
                .RegisterType<IPrintQuoteView, PrintQuoteView>()
                .RegisterType<IPrintQuotePresenter, PrintQuotePresenter>();
            PrintQuotePresenter printQuote = unityC.Resolve<PrintQuotePresenter>();
            printQuote._unityC = unityC;
            printQuote._quoteItemListPresenter = quoteItemListPresenter;
            printQuote._mainPresenter = mainPresenter;
            printQuote._quotationModel = quotationModel;


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
