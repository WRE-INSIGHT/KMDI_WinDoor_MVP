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
   public class PartialAdjustmentViewPresenter : IPartialAdjustmentViewPresenter
    {
        private IPartialAdjustmentView _partialAdjustmentView;

        private IUnityContainer _unityC;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IMainPresenter _mainPresenter;
        private IPrintQuotePresenter _printQuotePresenter;
        private IPartialAdjustmentUCPresenter _partialAdjustmentUCPresenter;
        private IPartialAdjustmentBaseHolderPresenter _partialAdjustmentBaseHolderPresenter;
           

        public PartialAdjustmentViewPresenter(IPartialAdjustmentView partialAdjustmentView,
                                              IPrintQuotePresenter printQuotePresenter)
        {
            _partialAdjustmentView = partialAdjustmentView;
            _printQuotePresenter = printQuotePresenter;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _partialAdjustmentView._printToolStripBtnClickEventRaised += _partialAdjustmentView__printToolStripBtnClickEventRaised;                 
            _partialAdjustmentView._partialAdjustmentViewLoadEventRaised += _partialAdjustmentView__partialAdjustmentViewLoadEventRaised;
        }

        private void _partialAdjustmentView__partialAdjustmentViewLoadEventRaised(object sender, EventArgs e)
        {

            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                
                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];
                #region 1st Algo
                //_partialAdjustmentUCPresenter = _partialAdjustmentUCPresenter.GetNewInstance(_unityC, _quotationModel, wdm, _mainPresenter, this);
                //UserControl partialadjustmentItems = (UserControl)_partialAdjustmentUCPresenter.GetPartialAdjustmentUC();
                //_partialAdjustmentView.GetPanelBody().Controls.Add(partialadjustmentItems);
                //partialadjustmentItems.Dock = DockStyle.Top;
                //partialadjustmentItems.BringToFront();
                //_partialAdjustmentView.GetPanelBody().AutoScroll = true;

                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = "Item No." + (i + 1).ToString();
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = wdm.WD_image;
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = wdm.WD_description;
                //_partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = Math.Round(wdm.WD_price, 2).ToString("N");

                //if (wdm.WD_IsPartialADPreviousExist)
                //{
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDesignImage().Image = wdm.WD_PAPreviousImage;
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDescription().Text = wdm.WD_PAPreviousDescription;
                //    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemPrice().Text = Math.Round(wdm.WD_PAPreviousPrice, 2).ToString("N");
                //}
                #endregion
                _partialAdjustmentBaseHolderPresenter = _partialAdjustmentBaseHolderPresenter.GetNewInstance(_unityC,_mainPresenter,wdm,_quotationModel,this);
                _partialAdjustmentBaseHolderPresenter.ItemQuantity = wdm.WD_quantity;
                _partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC().PABaseHolderItemName().Text ="Item No. "+ wdm.WD_id.ToString();

                if(wdm.WD_PALst_Designs == null)
                {
                    //instantiate
                    wdm.WD_PALst_Designs = new List<System.Drawing.Image>();
                    wdm.WD_PALst_Description = new List<string>();
                    wdm.WD_PALst_Price = new List<decimal>();
                }

                UserControl partialadjustmentItems = (UserControl)_partialAdjustmentBaseHolderPresenter.GetPABaseHolderUC();
                _partialAdjustmentView.GetPanelBody().Controls.Add(partialadjustmentItems);
                partialadjustmentItems.Dock = DockStyle.Top;
                partialadjustmentItems.BringToFront();
                _partialAdjustmentView.GetPanelBody().AutoScroll = true;

            }
        }

        private void _partialAdjustmentView__printToolStripBtnClickEventRaised(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        
        public IPartialAdjustmentView GetPartialAdjustmentView()
        {
            return _partialAdjustmentView;
        }

        public IPartialAdjustmentViewPresenter GetNewInstance(IUnityContainer unityC,
                                                               IQuotationModel quotationModel,
                                                               IWindoorModel windoorModel,
                                                               IMainPresenter mainPresenter,
                                                               IPartialAdjustmentBaseHolderPresenter partialAdjustmentBaseHolder)
        {   
            unityC
                .RegisterType<IPartialAdjustmentViewPresenter, PartialAdjustmentViewPresenter>()
                .RegisterType<IPartialAdjustmentView, PartialAdjustmentView>();
            PartialAdjustmentViewPresenter partialAdjusment = unityC.Resolve<PartialAdjustmentViewPresenter>();
            partialAdjusment._unityC = unityC;
            partialAdjusment._quotationModel = quotationModel;
            partialAdjusment._windoorModel = windoorModel;
            partialAdjusment._mainPresenter = mainPresenter;
            partialAdjusment._partialAdjustmentBaseHolderPresenter = partialAdjustmentBaseHolder;

            return partialAdjusment;
        }
       
    }
}
