using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class PartialAdjustmentUCPresenter : IPartialAdjustmentUCPresenter
    {
        private IUnityContainer _unityC;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IMainPresenter _mainPresenter;
        private IPartialAdjustmentUC _partialAdjustmenUC;
        private IPartialAdjustmentViewPresenter _partialAdjustmentViewPresenter;
        private IPartialAdjustmentItemDisabledUCPresenter _paAdjustmentItemDisabledUCPresenter;
        private IPartialAdjustmentBaseHolderPresenter _paBaseHolderPresenter;

        Panel PanelBody;
        PictureBox OldItemPB, CurrentItemPB;
        RichTextBox OLDItemDesc, CurrentItemDesc;
        Label OldItemPrice, CurrentItemPrice;

        private string BGColor = "#2596be";
        private int BaseHolderHeight = 0;

        public int PartialAdjusmentUCIndexPlacement { get; set; }

        public PartialAdjustmentUCPresenter(IPartialAdjustmentUC partialAdjustmentUC, IPartialAdjustmentItemDisabledUCPresenter paAdjustmentItemDisabledUCPresenter)
        {
            _partialAdjustmenUC = partialAdjustmentUC;
            _paAdjustmentItemDisabledUCPresenter = paAdjustmentItemDisabledUCPresenter;
            PanelBody = _partialAdjustmenUC.GetCurrentItemMainPanel();
            OldItemPB = _partialAdjustmenUC.GetOldItemDesignImage();
            CurrentItemPB = _partialAdjustmenUC.GetCurrentItemDesignImage();
            OLDItemDesc = _partialAdjustmenUC.GetOldItemDescription();
            CurrentItemDesc = _partialAdjustmenUC.GetCurrentItemDescription();
            OldItemPrice = _partialAdjustmenUC.GetOldItemPrice();
            CurrentItemPrice = _partialAdjustmenUC.GetCurrentItemPrice();
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _partialAdjustmenUC.partialAdjustmentUC_LoadEventRaised += _partialAdjustmenUC_artialAdjustmentUC_LoadEventRaised;
            _partialAdjustmenUC.paPnlAfter_ResizeEventRaised += _partialAdjustmenUC_paPnlAfter_ResizeEventRaised;
            _partialAdjustmenUC.btn_HideAndShow_ClickEventRaised += _partialAdjustmenUC_btn_HideAndShow_ClickEventRaised;
            _partialAdjustmenUC.btn_UsePartialAdjustment_ClickEventRaised += _partialAdjustmenUC_btn_UsePartialAdjustment_ClickEventRaised;
        }

        private void _partialAdjustmenUC_btn_UsePartialAdjustment_ClickEventRaised(object sender, EventArgs e)
        {

            _mainPresenter.Load_Windoor_Item(_windoorModel);

            _mainPresenter.GetMainView().GetMNSMainMenu().Enabled = false;
            //_mainPresenter.GetMainView().GetTSMain().Enabled = false;
            _mainPresenter.GetMainView().SpecificToolStripEnable = false;
            _mainPresenter.GetMainView().GetPanelItems().Enabled = false;

            _mainPresenter.GetMainView().GetMNSMainMenu().BackColor = System.Drawing.ColorTranslator.FromHtml(BGColor);
            _mainPresenter.GetMainView().GetTSMain().BackColor = System.Drawing.ColorTranslator.FromHtml(BGColor);

            _paAdjustmentItemDisabledUCPresenter = _paAdjustmentItemDisabledUCPresenter.GetNewInstance(_unityC, _mainPresenter, _windoorModel, _quotationModel);
             UserControl paUC = (UserControl)_paAdjustmentItemDisabledUCPresenter.GetPartialAdjustmentItemDisablepdUC();
            _paAdjustmentItemDisabledUCPresenter.UserControlBackground = BGColor;
            _paAdjustmentItemDisabledUCPresenter.PartialAdjusmentItemDisabledUCIndexPlacement = PartialAdjusmentUCIndexPlacement; // send index placement to itemdisabled


            _mainPresenter.GetMainView().GetThis().Controls.Add(paUC);

            _partialAdjustmentViewPresenter.GetPartialAdjustmentView().ClosePartialAdjustmentView();

        } 

        private void _partialAdjustmenUC_btn_HideAndShow_ClickEventRaised(object sender, EventArgs e)
        {
            BaseHolderHeight = 0;
            int BHHModulo,
                Height;
            Height = _partialAdjustmenUC.GetAdjustmentUCForm().Size.Height;

            #region 1stAlgo For UCSize
            //if (PanelBody.Visible == true)
            //{
            //    PanelBody.Visible = false;
            //    _partialAdjustmenUC.GetAdjustmentUCForm().Size = new System.Drawing.Size(732, 29);
            //}
            //else
            //{
            //    PanelBody.Visible = true;
            //    _partialAdjustmenUC.GetAdjustmentUCForm().Size = new System.Drawing.Size(732, 200);
            //}
            #endregion

            if (Height == 200)
            {
                PanelBody.Visible = false;
                _partialAdjustmenUC.GetAdjustmentUCForm().Size = new System.Drawing.Size(732, 29);
            }
            else
            {
                PanelBody.Visible = true;
                _partialAdjustmenUC.GetAdjustmentUCForm().Size = new System.Drawing.Size(732, 200);
            }

            foreach (Control uc in _paBaseHolderPresenter.GetPABaseHolderUC().PABaseHolderPanelBody().Controls)
            {
                BaseHolderHeight = BaseHolderHeight + uc.Height;
            }

            BHHModulo = BaseHolderHeight % 29;
            //if(BHHModulo == 0)
            //{
            //    BaseHolderHeight = BaseHolderHeight + 29;
            //}
            BaseHolderHeight = BaseHolderHeight + 29; // add for panelTitle_HeightBHP

            _paBaseHolderPresenter.GetPABaseHolderUC().GetPABaseHolderUC().Height = BaseHolderHeight;
        }

        private void _partialAdjustmenUC_paPnlAfter_ResizeEventRaised(object sender, EventArgs e)
        {
            decimal _pBody = Convert.ToDecimal(PanelBody.Size.Width);
            int _pBAndDescWidthSize = (Convert.ToInt32(_pBody) / 2) - (OLDItemDesc.Width + CurrentItemDesc.Width) / 2;
            int _PrevAndCurrLabelPos = Convert.ToInt32(_pBody) / 4;
            
            OldItemPB.Width = _pBAndDescWidthSize;
            OLDItemDesc.Location = new System.Drawing.Point(_pBAndDescWidthSize);
            OldItemPrice.Location = new System.Drawing.Point(_pBAndDescWidthSize, 178);
            CurrentItemPB.Location = new System.Drawing.Point(_pBAndDescWidthSize + OLDItemDesc.Width);
            CurrentItemPB.Width = _pBAndDescWidthSize;
            CurrentItemDesc.Location = new System.Drawing.Point(_pBAndDescWidthSize * 2 + OLDItemDesc.Width);
            CurrentItemPrice.Location = new System.Drawing.Point(_pBAndDescWidthSize * 2 + OLDItemDesc.Width, 178);
                      
            
            _partialAdjustmentViewPresenter.GetPartialAdjustmentView().GetPrevItemLbl().Location = new System.Drawing.Point(_PrevAndCurrLabelPos - 50);
            _partialAdjustmentViewPresenter.GetPartialAdjustmentView().GetCurrItemLbl().Location = new System.Drawing.Point((_PrevAndCurrLabelPos * 3) - 50); 
        }

        private void _partialAdjustmenUC_artialAdjustmentUC_LoadEventRaised(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            PanelBody.Visible = false;
            _partialAdjustmenUC.GetAdjustmentUCForm().Size = new System.Drawing.Size(732, 29);
        }

        public IPartialAdjustmentUC GetPartialAdjustmentUC()
        {
            return _partialAdjustmenUC;
        }

        public IPartialAdjustmentUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IQuotationModel quotationModel,
                                                            IWindoorModel windoorModel,
                                                            IMainPresenter mainPresenter,
                                                            IPartialAdjustmentViewPresenter partialAdjustmentViewPresenter,
                                                            IPartialAdjustmentBaseHolderPresenter paBaseHolderPresenter)
        {
            unityC
                .RegisterType<IPartialAdjustmentUC, PartialAdjustmentUC>()
                .RegisterType<IPartialAdjustmentUCPresenter, PartialAdjustmentUCPresenter>();
            PartialAdjustmentUCPresenter partialAdjustmentUC = unityC.Resolve<PartialAdjustmentUCPresenter>();
            partialAdjustmentUC._unityC = unityC;
            partialAdjustmentUC._quotationModel = quotationModel;
            partialAdjustmentUC._windoorModel = windoorModel;
            partialAdjustmentUC._mainPresenter = mainPresenter;
            partialAdjustmentUC._partialAdjustmentViewPresenter = partialAdjustmentViewPresenter;
            partialAdjustmentUC._paBaseHolderPresenter = paBaseHolderPresenter;

            return partialAdjustmentUC;
        }


    }
}
