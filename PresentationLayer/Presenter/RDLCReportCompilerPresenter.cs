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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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

        #region variables 
        private bool CompileRDLC;     
        #endregion
        public RDLCReportCompilerPresenter(IRDLCReportCompilerView rdlcReportCompilerView,
                                           IPrintQuotePresenter printQuotePresenter)
        {
            _rdlcReportCompilerView = rdlcReportCompilerView;
            _printQuotePresenter = printQuotePresenter;
            SubScribeToEventSetup();
        }

        public IRDLCReportCompilerView GetIRDLCReportCompilerView()
        {
            return _rdlcReportCompilerView;
        }
        private void SubScribeToEventSetup()
        {
            _rdlcReportCompilerView.BtnCompileReportClickEventRaised += new EventHandler(OnBtnCompileReportClickEventRaised);
            _rdlcReportCompilerView.RDLCReportCompilerViewLoadEventRaise += new EventHandler(OnRDLCReportCompilerViewLoadEventRaise);
        }

        private void OnRDLCReportCompilerViewLoadEventRaise(object sender, EventArgs e)
        {
            foreach (IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Add("Item: " + wdm.WD_id);
            }

            //_rdlcReportCompilerView.TxtBxOutofTownExpenses = "0.00";
        }

        private void OnBtnCompileReportClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_rdlcReportCompilerView.TxtBxOutofTownExpenses))
                {
                    int num;
                    if (int.TryParse(_rdlcReportCompilerView.TxtBxOutofTownExpenses, out num))
                    {
                        if (num > 0)
                        {
                            string projname = _mainPresenter.inputted_projectName;
                            string filename = Properties.Settings.Default.WndrDir + @"\" + projname + ".PDF";
                            string targetpath = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder";
                            Directory.CreateDirectory(targetpath);
                            _quoteItemListPresenter.RenderPDFAtBackGround = true;

                            if (File.Exists(filename))
                            {
                                DialogResult dlgRes = MessageBox.Show(projname + ".PDF already Exist, Do you want to Replace It ?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if(dlgRes == DialogResult.Yes)
                                {
                                    CompileRDLC = true;
                                }
                                else
                                {
                                    CompileRDLC = false;
                                }
                            }
                            else
                            {
                                CompileRDLC = true;
                            }

                            if (CompileRDLC == true)
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
                                _quoteItemListPresenter.PrintContractSummaryRDLC();
                                #endregion
                                #region Screen
                                if (_mainPresenter.Screen_List.Count != 0)
                                {
                                    _quoteItemListPresenter.PrintScreenRDLC();
                                }
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

                                outputDocument.Save(filename);
                                DialogResult dialogresult = MessageBox.Show("Open " + projname + ".PDF File ?", "Report Compilation Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogresult == DialogResult.Yes)
                                {
                                    Process.Start(filename);
                                }


                                #endregion
                            }

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
                            SetVariablesToDefault();
                        }
                        else
                        {
                            MessageBox.Show("Error Negative Value Detected", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Expenses Must Be A Valid Number", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Out of Town Expenses is Required", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compiler Error" + " " + this + ex.Message);
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
