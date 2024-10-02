using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PresentationLayer.DataTables;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class RDLCReportCompilerPresenter : IRDLCReportCompilerPresenter
    {
        IRDLCReportCompilerView _rdlcReportCompilerView;
        private IUnityContainer _unityC;
        private IPrintQuotePresenter _printQuotePresenter;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private IMainPresenter _mainPresenter;
        private IPDFCompilerPresenter _pdfCompilerPresenter;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IPDFWaitFormPresenter _pdfWaitFormPresenter;


        #region variables 
        BackgroundWorker bgw = new BackgroundWorker();
        private bool CompileRDLC,isLessDiscountChecked;
        string fullname,
               projname,
               targetpath,
               filename;
        Thread _loadingThread;
        private ComboBox _gucmbGlassType,
                         _guCmbReviewedBy,
                         _guCmbNotedBy;
        private TextBox _guTxtBxVat,
                        _specialDiscountTxtBx;
        private CheckBox _guShowReviewedBy,
                         _guShowNotedBy,
                         _guShowVat,
                         _screenNetOfDiscount,
                         _specialDiscountChkbx,
                         _lessDiscountChkBx;
        private CheckedListBox _guGlassListChkLst;

        string[] _officialsName = { "KENNETH G. LAO", "GENALYN C. GARCIA", "STEPHANIE DE LOS SANTOS", "KEVIN CHARLES S. LAO" };
        string[] _officialsPosition = { "President,KMDI", "VP-Sales & Operations", "VP-Marketing & Finance", "Head, Sales & Operations" };
        #endregion

        bool _glassTypeExist = false,
             _partialAdjustmentIsChecked;
        int _loopCounter = 1;

        public RDLCReportCompilerPresenter(IRDLCReportCompilerView rdlcReportCompilerView,
                                           IPrintQuotePresenter printQuotePresenter,
                                           IPDFWaitFormPresenter pdfWaitFormPresenter)
        {
            _rdlcReportCompilerView = rdlcReportCompilerView;
            _printQuotePresenter = printQuotePresenter;
            _pdfWaitFormPresenter = pdfWaitFormPresenter;

            _screenNetOfDiscount = _rdlcReportCompilerView.GetScreenNetOfDiscountChkBox();
            _gucmbGlassType = _rdlcReportCompilerView.GUGlassType();
            _guCmbReviewedBy = _rdlcReportCompilerView.GUReviewedBy();
            _guCmbNotedBy = _rdlcReportCompilerView.GUNotedBy();
            _guTxtBxVat = _rdlcReportCompilerView.GUVat();
            _guShowReviewedBy = _rdlcReportCompilerView.GUShowReviewedBy();
            _guShowNotedBy = _rdlcReportCompilerView.GUShowNotedBy();
            _guShowVat = _rdlcReportCompilerView.GUShowVat();
            _guGlassListChkLst = _rdlcReportCompilerView.GUGlassListChkLst();
            _specialDiscountChkbx = _rdlcReportCompilerView.GetSpecialDiscountChkBx();
            _specialDiscountTxtBx = rdlcReportCompilerView.GetSpecialDiscountTxtBx();
            _lessDiscountChkBx = rdlcReportCompilerView.GetContractSummaryLessDiscountChkBx();


            SubScribeToEventSetup();
        }

        public IRDLCReportCompilerView GetIRDLCReportCompilerView()
        {
            return _rdlcReportCompilerView;
        }
        private void SubScribeToEventSetup()
        {
            _rdlcReportCompilerView.BtnCompileReportClickEventRaised += new EventHandler(OnBtnCompileReportClickEventRaised);
            _rdlcReportCompilerView.RDLCReportCompilerViewLoadEventRaised += new EventHandler(OnRDLCReportCompilerViewLoadEventRaised);
            _rdlcReportCompilerView.chkselectallCheckedChangedEventRaised += new EventHandler(OnchkselectallCheckedChangedEventRaised);
            _rdlcReportCompilerView.chkboxshowVatCheckedChangedEventRaised += new EventHandler(OnchkboxshowVatCheckedChangedEventRaised);
            _rdlcReportCompilerView.chkboxsubtotalCheckedChangedEventRaised += new EventHandler(OnchkboxsubtotalCheckedChangedEventRaised);
            _rdlcReportCompilerView.chkbxguShowReviewedByCheckedChangedEventRaised += new EventHandler(OnchkbxguShowReviewedByCheckedChangedEventRaised);
            _rdlcReportCompilerView.chkbxguShowNotedByCheckedChanged += new EventHandler(OnchkbxguShowNotedByCheckedChanged);
            _rdlcReportCompilerView.chkbxguShowVatCheckedChanged += new EventHandler(OnchkbxguShowVatCheckedChanged);
            _rdlcReportCompilerView.chkbx_SummaryLessD_CheckedChangedEventRaised += new EventHandler(Onchkbx_SummaryLessD_CheckedChangedEventRaised);
            _rdlcReportCompilerView.chkbx_ScreenNetofDiscount_CheckedChangedEventRaised += new EventHandler(Onchkbx_ScreenNetofDiscount_CheckedChangedEventRaised);
            _rdlcReportCompilerView.chkbx_GuSubtotal_CheckedChangedEventRaised += new EventHandler(Onchkbx_GuSubtotal_CheckedChangedEventRaised);
            _rdlcReportCompilerView.chkbx_SpecialDiscount_CheckedChangedEventRaised += new EventHandler(Onchkbx_SpecialDiscount_CheckedChangedEventRaised);

            //bgw.WorkerReportsProgress = true;
            //bgw.WorkerSupportsCancellation = true;
            //bgw.DoWork += Bgw_DoWork;
            //bgw.ProgressChanged += Bgw_ProgressChanged; 
        }

        //iif(Parameters!NetofDiscount.Value,"Total Net Price With VAT*","Total Discounted Price With VAT*"),
        //iif(Parameters!NetofDiscount.Value,"Total Net Price Without VAT*","Total Discounted Price Without VAT*"))

        private void PAContractSummaryTotalTextChanger()
        {
            #region Text Changer 
            if (_rdlcReportCompilerView.GetShowVatCheckBox().Checked)
            {
                if (_screenNetOfDiscount.Checked)
                {
                    //Net Price with Vat*
                    if (_specialDiscountChkbx.Checked)
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Special Discounted Adjustment Net Price with VAT";
                    }
                    else
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Adjustment Net Price With VAT";
                    }
                }
                else
                {
                    //Price with Vat*
                    if (_specialDiscountChkbx.Checked)
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Special Discounted Adjustment Price with VAT";
                    }
                    else
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Adjustment Price With VAT";
                    }
                }
                
            }
            else
            {
                //Net Price without Vat*
                if (_screenNetOfDiscount.Checked)
                {
                    if (_specialDiscountChkbx.Checked)
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Special Discounted Adjustment Net Price without VAT";
                    }
                    else
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Adjustment Net Price Without VAT";
                    }
                }
                else
                {
                  //Price Without Vat*
                    if (_specialDiscountChkbx.Checked)
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Special Discounted Adjustment Price without VAT";
                    }
                    else
                    {
                        _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Adjustment Price Without VAT";
                    }
                }
            }
            #endregion
        }

        private void Onchkbx_SpecialDiscount_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_specialDiscountChkbx.Checked)
            {
                _specialDiscountTxtBx.Enabled = true;
                _quoteItemListPresenter.RDLCPAShowSpecialDiscount = true;
            }
            else
            {
                _specialDiscountTxtBx.Enabled = false;
                _quoteItemListPresenter.RDLCPAShowSpecialDiscount = false;
            }
            PAContractSummaryTotalTextChanger();
        }

        private void Onchkbx_GuSubtotal_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_rdlcReportCompilerView.GetGlassUpgradeSubTotal().Checked)
            {
                _quoteItemListPresenter.RDLCGUShowSubTotal = true;
                _rdlcReportCompilerView.GetGlassUpgradeRowLimitTxtBx().Visible = true;
            }
            else
            {
                _quoteItemListPresenter.RDLCGUShowSubTotal = false;
                _rdlcReportCompilerView.GetGlassUpgradeRowLimitTxtBx().Visible = false;
            }
        }



        //private delegate void DELEGATE();
        //private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (!bgw.CancellationPending)
        //    {
        //        Delegate del = new DELEGATE(DoCompilePDf);
        //        _rdlcReportCompilerView.GetRDLCReportCompilerForm().Invoke(del);
        //    }
        //}
        //private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{

        //}

        private void Onchkbx_ScreenNetofDiscount_CheckedChangedEventRaised(object sender, EventArgs e)
        {           
            if (_screenNetOfDiscount.Checked)
            {
                _quoteItemListPresenter.RDLCReportCompilerNetOfDiscount = true;
            }
            else
            {
                _quoteItemListPresenter.RDLCReportCompilerNetOfDiscount = false;
            }
            PAContractSummaryTotalTextChanger();
        }

        private void OnchkbxguShowReviewedByCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_guShowReviewedBy.Checked)
            {
                _guCmbReviewedBy.Visible = true;
                _quoteItemListPresenter.RDLCGUShowReviewedBy = true;
            }
            else
            {
                _guCmbReviewedBy.Visible = false;
                _quoteItemListPresenter.RDLCGUShowReviewedBy = false;
            }
        }
        private void OnchkbxguShowNotedByCheckedChanged(object sender, EventArgs e)
        {
            if (_guShowNotedBy.Checked)
            {
                _guCmbNotedBy.Visible = true;
                _quoteItemListPresenter.RDLCGUShowNotedBy = true;
            }
            else
            {
                _guCmbNotedBy.Visible = false;
                _quoteItemListPresenter.RDLCGUShowNotedBy = false;
            }
        }
        private void OnchkbxguShowVatCheckedChanged(object sender, EventArgs e)
        {
            if (_guShowVat.Checked)
            {
                _guTxtBxVat.Visible = true;
                _quoteItemListPresenter.RDLCGUShowVat = true;
            }
            else
            {
                _guTxtBxVat.Visible = false;
                _quoteItemListPresenter.RDLCGUShowVat = false;
            }
        }
        private void Onchkbx_SummaryLessD_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_rdlcReportCompilerView.GetContractSummaryLessDiscountChkBx().Checked)
            {
                _quoteItemListPresenter.ShowLessDiscountContractSummary = true;
                _rdlcReportCompilerView.GetContractSummaryLessDiscountTxtBx().Visible = true;
            }
            else
            {
                _quoteItemListPresenter.ShowLessDiscountContractSummary = false;
                _rdlcReportCompilerView.GetContractSummaryLessDiscountTxtBx().Visible = false;
            }
            EnableSpecialDiscountButton();

        }

        private void EnableSpecialDiscountButton()
        {
            if (_lessDiscountChkBx.Checked)
            {
                _specialDiscountChkbx.Enabled = true;
            }
            else
            {
                _specialDiscountChkbx.Enabled = false;
                _specialDiscountChkbx.Checked = false;
                _specialDiscountTxtBx.Enabled = false;
                _quoteItemListPresenter.RDLCPAShowSpecialDiscount = false;
            }
        }

        private void OnchkboxsubtotalCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_rdlcReportCompilerView.GetSubTotalCheckBox().Checked)
            {
                _quoteItemListPresenter.RDLCReportCompilerShowSubTotal = true;
            }
            else
            {
                _quoteItemListPresenter.RDLCReportCompilerShowSubTotal = false;
            }
        }
        private void OnchkboxshowVatCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_rdlcReportCompilerView.GetShowVatCheckBox().Checked)
            {
                _quoteItemListPresenter.ShowVatContactSummary = true;
                _rdlcReportCompilerView.GetContracSummaryVatTextBox().Visible = true;
            }
            else
            {
                _quoteItemListPresenter.ShowVatContactSummary = false;
                _rdlcReportCompilerView.GetContracSummaryVatTextBox().Visible = false;
            }
            PAContractSummaryTotalTextChanger();
        }

        private void OnchkselectallCheckedChangedEventRaised(object sender, EventArgs e)
        {
            if (_rdlcReportCompilerView.CheckListSelectAll().Checked)
            {
                for(int i = 0;i< _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Count; i++)
                {
                    _rdlcReportCompilerView.GetChecklistBoxIndex().SetItemChecked(i,true);
                }
            }
            else
            {
                for (int i = 0; i < _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Count; i++)
                {
                    _rdlcReportCompilerView.GetChecklistBoxIndex().SetItemChecked(i, false);
                }
            }
        }

        private void OnRDLCReportCompilerViewLoadEventRaised(object sender, EventArgs e)
        {
            _partialAdjustmentIsChecked = _pdfCompilerPresenter.GetPDFCompilerView().GetPartialAdjustmentCheckbox().Checked;

            if (!_partialAdjustmentIsChecked)
            {
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Add("Item: " + wdm.WD_id);
                }

                _quoteItemListPresenter.CallFrmRDLCCompiler = true;
                _quoteItemListPresenter.PrintContractSummaryRDLC();
                _quoteItemListPresenter.CallFrmRDLCCompiler = false;

                _rdlcReportCompilerView.GetPATotalRtBx().Enabled = false;
                _rdlcReportCompilerView.GetSpecialDiscountChkBx().Enabled = false;
                _rdlcReportCompilerView.GetSpecialDiscountTxtBx().Enabled = false;
            }
            else
            {
                //partial adjustment
                foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if (wdm.WD_IsSelectedAtPartialAdjusment)
                    {
                        _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Add("Item: " + wdm.WD_id);
                    }
                }

                _quoteItemListPresenter.CallFrmRDLCCompiler = true;
                _quoteItemListPresenter.PrintContractSummaryPartialAdjustmentRDLC();
                _quoteItemListPresenter.CallFrmRDLCCompiler = false;

                _rdlcReportCompilerView.GetRDLCReportCompilerForm().Text = "Report Compiler - Partial Adjustment";
                _rdlcReportCompilerView.GetPATotalRtBx().Text = "Total Special Discounted Adjustment Price without VAT";//default

                _rdlcReportCompilerView.GetChecklistBoxIndex().Enabled = false;
                _rdlcReportCompilerView.GetSubTotalCheckBox().Enabled = false;
                _rdlcReportCompilerView.CheckListSelectAll().Enabled = false;
                _rdlcReportCompilerView.GetScreenRowLimitTxtBx().Enabled = false;

                _rdlcReportCompilerView.GetPATotalRtBx().Enabled = true;
                _rdlcReportCompilerView.GetSpecialDiscountChkBx().Enabled = true;
                _rdlcReportCompilerView.GetSpecialDiscountTxtBx().Enabled = false;

            }

            _rdlcReportCompilerView.GetOOTTextBox().Text = _quoteItemListPresenter.OutOfTownCharges.ToString("N2");
            _rdlcReportCompilerView.GetContracSummaryVatTextBox().Visible = false;
            _rdlcReportCompilerView.GetContractSummaryLessDiscountTxtBx().Visible = false;
            _rdlcReportCompilerView.GetContractSummaryLessDiscountTxtBx().Text = _quoteItemListPresenter.ContractSummaryLessDiscount.ToString();

            if(_quotationModel.QuotationModel_RDLCSpecialDiscount == 0)
            {
                _rdlcReportCompilerView.GetSpecialDiscountTxtBx().Text = _quoteItemListPresenter.ContractSummaryLessDiscount.ToString(); // temporarily
            }
            else
            {
                _rdlcReportCompilerView.GetSpecialDiscountTxtBx().Text = _quotationModel.QuotationModel_RDLCSpecialDiscount.ToString(); // temporarily
            }


            _rdlcReportCompilerView.TxtBxContractSummaryVat = "12";
            _rdlcReportCompilerView.TxtBxRowlimit = "100";
            _rdlcReportCompilerView.TxtGlassUpgradeRowLimit = "100";

            LoadSettingsForGlassUpgrade();

        }

        private void LoadSettingsForGlassUpgrade()
        {
            _gucmbGlassType.Items.Add("");
            _gucmbGlassType.Items.Add("Tempered Glass");
            _gucmbGlassType.Items.Add("Insulated Glass Unit (IGU)");
            _gucmbGlassType.Items.Add("Laminated Glass");
            _gucmbGlassType.Items.Add("Tinted Glass");
            _gucmbGlassType.Items.Add("Unglazed");

            foreach (var item in _officialsName)
            {
                _guCmbReviewedBy.Items.Add(item);
                _guCmbNotedBy.Items.Add(item);
            }

            _guCmbReviewedBy.SelectedIndex = 3;
            _guCmbNotedBy.SelectedIndex = 1;
            _guTxtBxVat.Text = "12";

            _guShowReviewedBy.CheckState = CheckState.Checked;
            _guShowNotedBy.CheckState = CheckState.Checked;
            _guTxtBxVat.Visible = false;

            foreach(DataRow dtrow in _quoteItemListPresenter.GlassUpgradeDT.Rows)
            {
                foreach(var item in _guGlassListChkLst.Items)
                {
                    if(dtrow["GlassType"].ToString() == item.ToString())
                    {
                        _glassTypeExist = true;
                    }
                }
                
                if (!_glassTypeExist)
                {
                    _guGlassListChkLst.Items.Add(dtrow["GlassType"].ToString());
                }

                _glassTypeExist = false; // reset boolean to false 
            }
          
        }

        public void Bgw_CompilePDF()
        {
            IPDFWaitFormPresenter waitPresenter = _pdfWaitFormPresenter.GetNewInstance(_unityC, _mainPresenter);
            waitPresenter.GetPDFWaitFormView().ShowPDFwaitFormView(_rdlcReportCompilerView.GetRDLCReportCompilerForm());               
        }

        public async void ShowPDFLoad()
        {
            await Task.Yield();
            IPDFWaitFormPresenter waitPresenter = _pdfWaitFormPresenter.GetNewInstance(_unityC, _mainPresenter);
            waitPresenter.GetPDFWaitFormView().ShowPDFwaitFormView(_rdlcReportCompilerView.GetRDLCReportCompilerForm());
            await Task.Delay(10000);
            waitPresenter.GetPDFWaitFormView().ClosePDFWaitFormView();
        }
              
        private  void OnBtnCompileReportClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_rdlcReportCompilerView.TxtBxOutofTownExpenses))
                {
                               
                    _loadingThread = new Thread(Bgw_CompilePDF);
                    
                    projname = _mainPresenter.inputted_projectName;
                    
                    _rdlcReportCompilerView.GetSaveFileDialog().FileName = projname;
                    _rdlcReportCompilerView.GetSaveFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
                    if (_rdlcReportCompilerView.GetSaveFileDialog().ShowDialog() == DialogResult.OK)
                    {
                        targetpath = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder";
                        DirectoryInfo dirInfo = Directory.CreateDirectory(targetpath);
                        dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                        foreach(FileInfo file in dirInfo.EnumerateFiles())
                        {
                            file.Delete();
                        }
                     
                        fullname = _rdlcReportCompilerView.GetSaveFileDialog().FileName;
                        _quoteItemListPresenter.RenderPDFAtBackGround = true;
                        CompileRDLC = true;
                    }
                    
                    if (CompileRDLC == true)
                    {
                      _loadingThread.Start();

                        if (!_partialAdjustmentIsChecked)
                        {
                            #region Windoor RDLC
                            foreach (var item in _rdlcReportCompilerView.GetChecklistBoxIndex().CheckedIndices)
                            {
                                var selectedindex = Convert.ToInt32(item);
                                _quoteItemListPresenter.RDLCReportCompilerItemIndexes.Add(selectedindex);
                            }
                            _quoteItemListPresenter.PrintWindoorRDLC();
                            #endregion
                            #region Summary Of Contract
                            _quoteItemListPresenter.RDLCReportCompilerOutOfTownExpenses = _rdlcReportCompilerView.TxtBxOutofTownExpenses;
                            _quoteItemListPresenter.RDLCReportCompilerVatContractSummery = _rdlcReportCompilerView.TxtBxContractSummaryVat;
                            decimal _deci = Convert.ToDecimal(_rdlcReportCompilerView.TxtContractSummaryLessDiscount);
                            int _wholeNum = Convert.ToInt32(_deci * 100m);
                            _quoteItemListPresenter.RDLCReportCompilerLessDiscountContractSummary = _wholeNum;
                            //galing quotelist naka decimal gawing whole number 
                            _quoteItemListPresenter.PrintContractSummaryRDLC();
                            #endregion
                            #region Screen
                            if (_mainPresenter.Screen_List.Count != 0)
                            {
                                _quoteItemListPresenter.RDLCReportCompilerRowLimit = _rdlcReportCompilerView.TxtBxRowlimit;
                                _quoteItemListPresenter.PrintScreenRDLC();
                            }
                            #endregion
                        }
                        else
                        {
                            #region P.A. Windoor RDLC
                            _quoteItemListPresenter.PrintWindoorPartialAdjustmentRDLC();
                            #endregion
                            #region P.A. Summary of Contract
                            _quoteItemListPresenter.RDLCReportCompilerOutOfTownExpenses = _rdlcReportCompilerView.TxtBxOutofTownExpenses;
                            _quoteItemListPresenter.RDLCReportCompilerVatContractSummery = _rdlcReportCompilerView.TxtBxContractSummaryVat;
                            decimal _deci = Convert.ToDecimal(_rdlcReportCompilerView.TxtContractSummaryLessDiscount);
                            int _wholeNum = Convert.ToInt32(_deci * 100m);
                            _quoteItemListPresenter.RDLCReportCompilerLessDiscountContractSummary = _wholeNum;
                            _quoteItemListPresenter.RDLCReportCompilerContractSummaryTotalText = _rdlcReportCompilerView.PartialAdjContractSummaryTotalText;

                            decimal Special_dscntDec = Convert.ToDecimal(_rdlcReportCompilerView.PartialAdjSpecialDiscountText);//Convert to decimal frm txtbox
                            CheckSpecialDiscountDiff(Special_dscntDec);//check for specialdiscount difference
                            int Special_dscntInt = Convert.ToInt32(_quotationModel.QuotationModel_RDLCSpecialDiscount * 100m);                  
                            _quoteItemListPresenter.RDLCReportCompilerContractSummarySpecialDiscount = Special_dscntInt;

                            //galing quotelist naka decimal gawing whole number 
                            _quoteItemListPresenter.PrintContractSummaryPartialAdjustmentRDLC();
                            #endregion
                            #region P.A. Screen 
                            if(_mainPresenter.Lst_ScreenPartialAdjustment.Count != 0)
                            {
                                _quoteItemListPresenter.PrintScreenPartialAdjustmentRDLC();
                            }
                            #endregion
                        }

                        #region Glass Upgrade

                        #region algo ver.1
                        //if (_gucmbGlassType.SelectedItem != null)
                        //{
                        //    if (_gucmbGlassType.SelectedItem.ToString() != "")
                        //    {
                        //        _quoteItemListPresenter.RDLCGUGlassType = _gucmbGlassType.SelectedItem.ToString();
                        //        _quoteItemListPresenter.RDLCGUReviewedByOfficial = _guCmbReviewedBy.SelectedItem.ToString();
                        //        int reviewedOfficialPosIndex = _guCmbReviewedBy.SelectedIndex; // indx pos
                        //        _quoteItemListPresenter.RDLCGUReviewedByOfficialPos = reviewedOfficialPosIndex;
                        //        _quoteItemListPresenter.RDLCGUNotedByOfficial = _guCmbNotedBy.SelectedItem.ToString();
                        //        int notedOfficialPosIndex = _guCmbNotedBy.SelectedIndex; // indx pos
                        //        _quoteItemListPresenter.RDLCGUNotedByOfficialPos = notedOfficialPosIndex;
                        //        _quoteItemListPresenter.RDLCGUVatPercentage = _guTxtBxVat.Text;
                        //        _quoteItemListPresenter.PrintGlassUpgrade();
                        //    }
                        //}
                        #endregion

                        #region algo ver.2       
                        foreach (var item in _guGlassListChkLst.CheckedItems)
                        {
                            _quoteItemListPresenter.RDLCGUFileName = _loopCounter.ToString();
                            _quoteItemListPresenter.RDLCGUGlassType = item.ToString();
                            _quoteItemListPresenter.RDLCGUReviewedByOfficial = _guCmbReviewedBy.SelectedItem.ToString();
                            int reviewedOfficialPosIndex = _guCmbReviewedBy.SelectedIndex; // indx pos
                            _quoteItemListPresenter.RDLCGUReviewedByOfficialPos = reviewedOfficialPosIndex;
                            _quoteItemListPresenter.RDLCGUNotedByOfficial = _guCmbNotedBy.SelectedItem.ToString();
                            int notedOfficialPosIndex = _guCmbNotedBy.SelectedIndex; // indx pos
                            _quoteItemListPresenter.RDLCGUNotedByOfficialPos = notedOfficialPosIndex;
                            _quoteItemListPresenter.RDLCGUVatPercentage = _guTxtBxVat.Text;
                            _quoteItemListPresenter.RDLCGURowLimit = _rdlcReportCompilerView.TxtGlassUpgradeRowLimit;
                            _quoteItemListPresenter.PrintGlassUpgrade();

                            _loopCounter++;
                        }
                        #endregion    

                        #endregion
                    
                       #region PDF Compiler

                        string[] files = GetFiles();

                         PdfDocument outputDocument = new PdfDocument();

                         XFont font = new XFont("Segoe UI", 10);
                         XBrush brush = XBrushes.Black;


                         foreach (string file in files)
                         {

                             PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                             int count = inputDocument.PageCount;
                             for (int idx = 0; idx < count; idx++)
                             {
                                 PdfPage page = inputDocument.Pages[idx];
                                 outputDocument.AddPage(page);
                             }

                         }

                         #region page counter
                         string noPages = outputDocument.Pages.Count.ToString();
                         for (int i = 0; i < outputDocument.Pages.Count; ++i)
                         {
                             PdfPage page = outputDocument.Pages[i];

                             // Make a layout rectangle.
                             XRect layoutRectangle = new XRect(0/*X*/, page.Height - 25/*Y*/, page.Width/*Width*/, font.Height/*Height*/);

                             using (XGraphics gfx = XGraphics.FromPdfPage(page))
                             {
                                 gfx.DrawString(
                                     "Page " + (i + 1).ToString() + " of " + noPages,
                                     font,
                                     brush,
                                     layoutRectangle,
                                     XStringFormats.Center);
                             }

                         }
                         #endregion
                         //await Task.Delay(1000);
                         outputDocument.Save(fullname);

                         if (Directory.Exists(targetpath))
                         {
                             try
                             {
                                 Directory.Delete(targetpath, true);
                             }
                             catch (IOException ex)
                             {
                                 MessageBox.Show(ex.Message);
                             }
                         }
                         filename = Path.GetFileName(fullname);
                         DialogResult dialogresult = MessageBox.Show(new Form { TopMost = true }, "Open " + filename + " File ?", "Report Compilation Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                         if (dialogresult == DialogResult.Yes)
                         {
                             Process.Start(fullname);
                         }
                         #endregion      
                    
                      _loadingThread.Abort();                            
                    }                           
                    SetVariablesToDefault();

                }
                else
                {
                    MessageBox.Show("Out of Town Expenses is Required", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compiler Error" + " " + this + ex.Message);
                _loadingThread.Abort();
            }
            
        }

        private void CheckSpecialDiscountDiff(decimal spcl_discount)
        {
            if(_quotationModel.QuotationModel_RDLCSpecialDiscount != spcl_discount)
            {
                _quotationModel.QuotationModel_RDLCSpecialDiscount = spcl_discount;
            }
        }

        private static string[] GetFiles()
        {
            string defDir = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder";
            DirectoryInfo di = new DirectoryInfo(defDir);
            FileInfo[] files = di.GetFiles("*.pdf");
            
            int i = 0;
            string[] names = new string[files.Length];

            foreach (var r in files)
            {
                names[i] = r.FullName;
                i = i + 1;
            }

            return names;
        }

        private void SetVariablesToDefault()
        {
            _quoteItemListPresenter.RenderPDFAtBackGround = false;
            _quoteItemListPresenter.RDLCReportCompilerItemIndexes.Clear();
            CompileRDLC = false;
            _loopCounter = 1;
        }

        public IRDLCReportCompilerPresenter GetNewIntance(IUnityContainer unityC,
                                                          IQuotationModel quotaionModel,
                                                          IWindoorModel windoorModel,
                                                          IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                          IPDFCompilerPresenter pdfCompilerPresenter,
                                                          IQuoteItemListPresenter quoteItemListPresenter,
                                                          IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IRDLCReportCompilerView, RDLCReportCompilerView>()
                .RegisterType<IRDLCReportCompilerPresenter, RDLCReportCompilerPresenter>();
            RDLCReportCompilerPresenter rdlcReportCompiler = unityC.Resolve<RDLCReportCompilerPresenter>();
            rdlcReportCompiler._unityC = unityC;
            rdlcReportCompiler._quotationModel = quotaionModel;
            rdlcReportCompiler._windoorModel = windoorModel;
            rdlcReportCompiler._quoteItemListUCPresenter = quoteItemListUCPresenter;
            rdlcReportCompiler._pdfCompilerPresenter = pdfCompilerPresenter;
            rdlcReportCompiler._quoteItemListPresenter = quoteItemListPresenter;
            rdlcReportCompiler._mainPresenter = mainPresenter;

            return rdlcReportCompiler;
        }
    }
}
