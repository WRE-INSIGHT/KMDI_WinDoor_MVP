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
            foreach(IWindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                _rdlcReportCompilerView.GetChecklistBoxIndex().Items.Add("Item: " + wdm.WD_id);
            }

            _rdlcReportCompilerView.TxtBxOutofTownExpenses = "50,000.00";
        }

        private void OnBtnCompileReportClickEventRaised(object sender, EventArgs e)
        {
            
            foreach(var item in _rdlcReportCompilerView.GetChecklistBoxIndex().CheckedIndices)
            {
                var selectedindex = Convert.ToInt32(item);
                _quoteItemListPresenter.RDLCReportCompilerItemIndexes.Add(selectedindex);
            }
            _quoteItemListPresenter.RenderPDFAtBackGround = true;
            _quoteItemListPresenter.PrintWindoorRDLC();



            MessageBox.Show("Report Compilation Complete"," ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            SetVariablesToDeffault();
        }

        private void SetVariablesToDeffault()
        {
            _quoteItemListPresenter.RenderPDFAtBackGround = false;
            _quoteItemListPresenter.RDLCReportCompilerItemIndexes.Clear();
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
