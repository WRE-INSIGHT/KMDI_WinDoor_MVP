using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _isMouseHover;
        private bool _isFromMouseRightDown;

        public bool IsSelectedForDelete { get; set; }
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
            _partialAdjustmenUC.tmr_BGChange_TickEventRaised += _partialAdjustmenUC_tmr_BGChange_TickEventRaised;

            _partialAdjustmenUC.pnl_Header_MouseLeaveEventRaised += _partialAdjustmenUC_pnl_Header_MouseLeaveEventRaised;
            _partialAdjustmenUC.pnl_Header_MouseEnterEventRaised += _partialAdjustmenUC_pnl_Header_MouseEnterEventRaised;
            _partialAdjustmenUC.btn_HideAndShow_MouseEnterEventRaised += _partialAdjustmenUC_btn_HideAndShow_MouseEnterEventRaised;
            _partialAdjustmenUC.btn_HideAndShow_MouseLeaveEventRaised += _partialAdjustmenUC_btn_HideAndShow_MouseLeaveEventRaised;
            _partialAdjustmenUC.btn_UsePartialAdjustment_MouseEnterEventRaised += _partialAdjustmenUC_btn_UsePartialAdjustment_MouseEnterEventRaised;
            _partialAdjustmenUC.btn_UsePartialAdjustment_MouseLeaveEventRaised += _partialAdjustmenUC_btn_UsePartialAdjustment_MouseLeaveEventRaised;

            _partialAdjustmenUC.pnl_Header_LeftMouseDownEventRaised += _partialAdjustmenUC_pnl_Header_LeftMouseDownEventRaised;
            _partialAdjustmenUC.pnl_Header_RightMouseDownClickEventRaised += _partialAdjustmenUC_pnl_Header_RightMouseDownClickEventRaised;
            _partialAdjustmenUC.RightMouseDownLeaveExceptionEventRaised += _partialAdjustmenUC_RightMouseDownLeaveExceptionEventRaised;
        }

        private void _partialAdjustmenUC_RightMouseDownLeaveExceptionEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = true;
            _isFromMouseRightDown = true;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }
        int i;
        private void _partialAdjustmenUC_pnl_Header_RightMouseDownClickEventRaised(object sender, EventArgs e)
        {           
            _windoorModel.WD_PALst_Designs.RemoveAt(PartialAdjusmentUCIndexPlacement);               
            _windoorModel.WD_PALst_Description.RemoveAt(PartialAdjusmentUCIndexPlacement);               
            _windoorModel.WD_PALst_Price.RemoveAt(PartialAdjusmentUCIndexPlacement); 
           _paBaseHolderPresenter.GetPABaseHolderUC().PABaseHolderPanelBody().Controls.RemoveAt(PartialAdjusmentUCIndexPlacement);

        }

        private void _partialAdjustmenUC_pnl_Header_LeftMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            if (IsSelectedForDelete)
            {
                IsSelectedForDelete = false;
                Color loc = System.Drawing.Color.FromArgb(240, 240, 240);
                _partialAdjustmenUC.GetHeaderPanel().BackColor = loc;
            }
            else
            {
                IsSelectedForDelete = true;
                //255, 127, 127 light red for delete 
                Color loc = System.Drawing.Color.FromArgb(255, 127, 127);
                _partialAdjustmenUC.GetHeaderPanel().BackColor = loc;
            }
        }

        #region BG Changed Timer
        private void _partialAdjustmenUC_btn_UsePartialAdjustment_MouseLeaveEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = false;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }

        private void _partialAdjustmenUC_btn_UsePartialAdjustment_MouseEnterEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = true;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }
        private void _partialAdjustmenUC_btn_HideAndShow_MouseLeaveEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = false;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }

        private void _partialAdjustmenUC_btn_HideAndShow_MouseEnterEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = true;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }

        private void _partialAdjustmenUC_pnl_Header_MouseEnterEventRaised(object sender, EventArgs e)
        {
            // 240,240,240 default control color // 184 205,248 hover color
            //56 35 8
            _isMouseHover = true;
            _isFromMouseRightDown = false;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }
        private void _partialAdjustmenUC_pnl_Header_MouseLeaveEventRaised(object sender, EventArgs e)
        {
            _isMouseHover = false;
            _partialAdjustmenUC.BGChangedTimer().Start();
        }

        private void _partialAdjustmenUC_tmr_BGChange_TickEventRaised(object sender, EventArgs e)
        {
            if (!IsSelectedForDelete)
            {
                if (_isMouseHover)
                {
                    _isMouseHover = false;
                    Color col = System.Drawing.Color.FromArgb(184, 205, 248);
                    _partialAdjustmenUC.GetHeaderPanel().BackColor = col;
                    _partialAdjustmenUC.BGChangedTimer().Stop();
                }
                else
                {
                    //default bg color
                    if (!_isFromMouseRightDown) 
                    {
                        _isMouseHover = true;
                        Color loc = System.Drawing.Color.FromArgb(240, 240, 240);
                        _partialAdjustmenUC.GetHeaderPanel().BackColor = loc;
                        _partialAdjustmenUC.BGChangedTimer().Stop();
                    }
                }
            }
        }
        #endregion

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
