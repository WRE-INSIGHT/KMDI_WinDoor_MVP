using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
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
        string MergePath;
        string PDfFileName;
        bool CompilePdf = false;
        StringBuilder sb = new StringBuilder();
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

        private void OnbtnCompilePDFClickEventRaised(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                MergePath = fbd.SelectedPath;

                DirectoryInfo list = new DirectoryInfo(MergePath);
                FileInfo[] files =  list.GetFiles("*.pdf");

                foreach(FileInfo i in files)
                {
                    sb.AppendFormat("{0}{1}", i.Name, Environment.NewLine);
                }
                
                DialogResult diagRes = MessageBox.Show(sb.ToString() + "\n" + "Do you want to Compile this Files ?","List of Files",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(diagRes == DialogResult.Yes)
                {
                    CompilePdf = true;                  
                }
                sb.Clear();                                                        
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
                PDfFileName = Interaction.InputBox("e.g. " + _mainPresenter.inputted_projectName.ToString(), "File Name", _mainPresenter.inputted_projectName.ToString());
                if(PDfFileName.Length <= 0)
                {
                    PDfFileName = _mainPresenter.inputted_projectName;
                }
                string filename = MergePath + @"\" + PDfFileName + ".pdf";
                outputDocument.Save(filename);

                DialogResult diagRes = MessageBox.Show("Do you want to Open PDF File ?","Report Compilation Complete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(diagRes == DialogResult.Yes)
                {
                    Process.Start(filename);
                }
                #endregion
            }
            _pdfCompilerView.ClosePDFCompilerView();
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
