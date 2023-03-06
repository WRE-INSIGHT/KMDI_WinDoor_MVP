using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
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


        public  IPDFCompilerView GetPDFCompilerView()
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
        }

        private void OnbtnCompilePDFClickEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnbtnCompileReportsClickEventRaised(object sender, EventArgs e)
        {
            IRDLCReportCompilerPresenter rdlcReportCompiler = _rdlcReportCompilerPresenter.GetNewIntance(_unityC, _quotationModel, _windoorModel, _quoteItemListUCPresenter, this,_quoteItemListPresenter, _mainPresenter);
            rdlcReportCompiler.GetIRDLCReportCompilerView().ShowRDLCReportCompilerView();
            _pdfCompilerView.ClosePDFCompilerView();
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
