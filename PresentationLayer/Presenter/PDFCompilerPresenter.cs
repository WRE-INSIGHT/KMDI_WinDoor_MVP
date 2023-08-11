using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class PDFCompilerPresenter : IPDFCompilerPresenter
    {

        IPDFCompilerView _pdfCompilerView;
        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private IQuoteItemListUCPresenter _quoteItemListUCPresenter;
        private IMainPresenter _mainPresenter;
        private IQuoteItemListPresenter _quoteItemListPresenter;
        private IRDLCReportCompilerPresenter _rdlcReportCompilerPresenter;

        #region variable
        string MergePath,
               MergePathFullname,
               PDfFileName,
               filename;
        bool CompilePdf = false;
        StringBuilder sb = new StringBuilder();
        Regex regex = new Regex(@"[\\/:""*?<>|]+");
        #endregion

        public IPDFCompilerView GetPDFCompilerView()
        {
            return _pdfCompilerView;
        }

        public PDFCompilerPresenter(IPDFCompilerView pdfCompilerView,
                                    IRDLCReportCompilerPresenter rdlcReportCompilerPresenter)
        {
            _pdfCompilerView = pdfCompilerView; 
            _rdlcReportCompilerPresenter = rdlcReportCompilerPresenter;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _pdfCompilerView.changeSyncDirToolStripMenuItemClickEventRaised += new EventHandler(OnchangeSyncDirToolStripMenuItemClickEventRaised);
            _pdfCompilerView.btnCompileReportsClickEventRaised += new EventHandler(OnbtnCompileReportsClickEventRaised);
            _pdfCompilerView.btnCompilePDFClickEventRaised += new EventHandler(OnbtnCompilePDFClickEventRaised);
            _pdfCompilerView.PDFCompilerViewFormClosedEventRaised += new FormClosedEventHandler(OnPDFCompilerViewFormClosedEventRaised);
       
        }

        private void OnPDFCompilerViewLoadEventRaised(object sender, EventArgs e)
        {
            _pdfCompilerView.GetFileDialog().ShowDialog();
        }

        private void OnbtnCompilePDFClickEventRaised(object sender, EventArgs e)
        {
            _pdfCompilerView.GetFileDialog().FileName = " ";

            if (_pdfCompilerView.GetFileDialog().ShowDialog() == DialogResult.OK)
            {
                MergePath = Properties.Settings.Default.WndrDir + @"\KMDIRDLCMergeFolder";
                DirectoryInfo dirInfo = Directory.CreateDirectory(MergePath);
                dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                _quoteItemListPresenter.QuoteItemList_PrintAnnexRDLC();//add annex rdlc

                foreach (string file in _pdfCompilerView.GetFileDialog().FileNames)
                {
                    PDfFileName = Path.GetFileName(file);
                    MergePathFullname = Path.Combine(MergePath, PDfFileName);                   
                    File.Copy(file, MergePathFullname, true);
                    sb.AppendLine(PDfFileName);
                }

                DialogResult DiagRes = MessageBox.Show(sb.ToString() + "\n" + "Do you want to compile this files ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DiagRes == DialogResult.Yes)
                {
                    do
                    {
                        PDfFileName = Interaction.InputBox("e.g. " + _mainPresenter.inputted_projectName.ToString(), "File Name", _mainPresenter.inputted_projectName.ToString());
                        if(PDfFileName.Length == 0)
                        {
                            DeleteCreatedDir();
                            break;
                        }
                        if (!File.Exists(Properties.Settings.Default.WndrDir + @"\" + PDfFileName + ".PDF"))
                        {
                            var res = regex.IsMatch(PDfFileName, 0);
                            if(res != true)
                            {
                                CompilePdf = true;
                            }
                            else
                            {
                                MessageBox.Show("Filename contains illegal characters","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            DialogResult dg = MessageBox.Show(PDfFileName + ".PDF already Exist, Do you want to replace it? ","Confirm Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if(dg == DialogResult.Yes)
                            {
                                CompilePdf = true;
                            }                        
                        }

                    } while (CompilePdf == false);
                }
                else
                {
                    DeleteCreatedDir();
                }
            }

            if (CompilePdf == true)
            {
                #region pdfcompiler
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

                //save document
                filename = Properties.Settings.Default.WndrDir + @"\" + PDfFileName + ".PDF";
                outputDocument.Save(filename);

                DeleteCreatedDir();         
                DialogResult diagRes = MessageBox.Show("Open "+ PDfFileName + ".PDF File ?", "Report Compilation Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (diagRes == DialogResult.Yes)
                {
                    Process.Start(filename);
                }

                #endregion
            }
            setVariablesToDefault();
        }

        private void setVariablesToDefault()
        {
            sb.Clear();
            CompilePdf = false;
        }

        private void DeleteCreatedDir()
        {
            if (Directory.Exists(MergePath))
            {
                try
                {
                    Directory.Delete(MergePath, true);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string[] GetFiles()
        {         
            DirectoryInfo di = new DirectoryInfo(MergePath);
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

        private void OnPDFCompilerViewFormClosedEventRaised(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.OpenForms["RDLCReportCompilerView"].Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in FormClose " + this + ex.Message);
            }
        }

        private void OnbtnCompileReportsClickEventRaised(object sender, EventArgs e)
        {
            IRDLCReportCompilerPresenter rdlcReportCompiler = _rdlcReportCompilerPresenter.GetNewIntance(_unityC, _quotationModel, _windoorModel, _quoteItemListUCPresenter, this,_quoteItemListPresenter, _mainPresenter);
            rdlcReportCompiler.GetIRDLCReportCompilerView().ShowRDLCReportCompilerView();         
        }

        private void OnchangeSyncDirToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.WndrDir = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                _pdfCompilerView.GetFileDialog().InitialDirectory = Properties.Settings.Default.WndrDir;
            }
        }

        public IPDFCompilerPresenter GetNewInstance(IUnityContainer unityC,
                                                    IQuotationModel quotationModel,
                                                    IQuoteItemListUCPresenter quoteItemListUCPresenter,
                                                    IWindoorModel windoorModel,
                                                    IQuoteItemListPresenter quoteItemListPresenter,
                                                    IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IPDFCompilerView, PDFCompilerView>()
                .RegisterType<IPDFCompilerPresenter, PDFCompilerPresenter>();
            PDFCompilerPresenter pdfcompiler = unityC.Resolve<PDFCompilerPresenter>();
            pdfcompiler._unityC = unityC;
            pdfcompiler._quotationModel = quotationModel;
            pdfcompiler._quoteItemListUCPresenter = quoteItemListUCPresenter;
            pdfcompiler._windoorModel = windoorModel;
            pdfcompiler._quoteItemListPresenter = quoteItemListPresenter;
            pdfcompiler._mainPresenter = mainPresenter;

            return pdfcompiler;
        }

    }
}
