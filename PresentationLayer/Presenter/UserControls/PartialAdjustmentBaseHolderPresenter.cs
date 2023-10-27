using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
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
    public class PartialAdjustmentBaseHolderPresenter : IPartialAdjustmentBaseHolderPresenter
    {
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IPartialAdjustmentBaseHolderUC _paBaseHolderUC;
        private IPartialAdjustmentViewPresenter _partialAdjustmentViewPresenter;
        private IPartialAdjustmentUCPresenter _partialAdjustmentUCPresenter;

        private bool _isPanelHeightExpanded;
        private int panelTitleHeight = 29;
        private int PA_LstDesignCount = 0;
        private int _panelMaximumHeight = 0, _panelMinimumHeight = 0;
        public int ItemQuantity { get; set; }

        public PartialAdjustmentBaseHolderPresenter(IPartialAdjustmentBaseHolderUC paBaseHolderUC, IPartialAdjustmentUCPresenter partialAdjustmentUCPresenter)
        {
            _paBaseHolderUC = paBaseHolderUC;
            _partialAdjustmentUCPresenter = partialAdjustmentUCPresenter; 
            SubcribeToEventSetup();
        }

        private void SubcribeToEventSetup()
        {
            _paBaseHolderUC.PartialAdjustmentBaseHolderUC_LoadEventRaised += _paBaseHolderUC_PartialAdjustmentBaseHolderUC_LoadEventRaised;
            _paBaseHolderUC.btn_Expnd_ClickEventRaised += _paBaseHolderUC_btn_Expnd_ClickEventRaised;
            _paBaseHolderUC.btn_addItemQty_ClickEventRaised += _paBaseHolderUC_btn_addItemQty_ClickEventRaised;
            _paBaseHolderUC.btn_DeleteItem_ClickEventRaised += _paBaseHolderUC_btn_DeleteItem_ClickEventRaised;
            _paBaseHolderUC.tmr_HeightExpand_TickEventRaised += _paBaseHolderUC_tmr_HeightExpand_TickEventRaised;
        }

        private void _paBaseHolderUC_btn_DeleteItem_ClickEventRaised(object sender, EventArgs e)
        {
            DialogResult DiagRes = MessageBox.Show("Delete " + _windoorModel.WD_name + " ?", "Delete Partial Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DiagRes == DialogResult.Yes)
            {
                foreach (Control itm in _partialAdjustmentViewPresenter.GetPartialAdjustmentView().GetPanelBody().Controls.OfType<Control>().ToList())
                {
                    if (_windoorModel.WD_name == itm.Name)
                    {
                        #region Reset to Default wdm prop
                        _windoorModel.WD_IsSelectedAtPartialAdjusment = false;
                        _windoorModel.WD_IsPartialADPreviousExist = false;
                        _windoorModel.WD_PALst_Description.Clear();
                        _windoorModel.WD_PALst_Designs.Clear();
                        _windoorModel.WD_PALst_Price.Clear();
                        #endregion
                        _partialAdjustmentViewPresenter.GetPartialAdjustmentView().GetPanelBody().Controls.Remove(itm);

                        break;
                    }
                }
            }
        }
        private void _paBaseHolderUC_tmr_HeightExpand_TickEventRaised(object sender, EventArgs e)
        {
            if (_isPanelHeightExpanded)
            {
                _paBaseHolderUC.GetPABaseHolderUC().Height -= 10; // decre


                if(_paBaseHolderUC.GetPABaseHolderUC().Height < _panelMinimumHeight)
                {
                    _paBaseHolderUC.GetPABaseHolderUC().Height = panelTitleHeight;
                    _paBaseHolderUC.HeightExpandTmr().Stop();
                    _isPanelHeightExpanded = false;

                    _panelMinimumHeight = 0;
                }
            }
            else
            {

                _paBaseHolderUC.GetPABaseHolderUC().Height += 10; // inc

                if(_paBaseHolderUC.GetPABaseHolderUC().Height >= _panelMaximumHeight)
                {
                    _paBaseHolderUC.GetPABaseHolderUC().Height = _panelMaximumHeight;
                    _paBaseHolderUC.HeightExpandTmr().Stop();
                    _isPanelHeightExpanded = true;

                    _panelMaximumHeight = 0;
                }
            }
        }
        private void _paBaseHolderUC_btn_addItemQty_ClickEventRaised(object sender, EventArgs e)
        {
            _windoorModel.WD_PALst_Designs.Add(null);
            _windoorModel.WD_PALst_Description.Add(null);
            _windoorModel.WD_PALst_Price.Add(0);

            if(_windoorModel.WD_PALst_Designs.Count != 0)
            {
                PA_LstDesignCount = _windoorModel.WD_PALst_Designs.Count;
                LoadAdjustmentUCPresenter(PA_LstDesignCount,false);
            }

            Btn_ExpandBaseHolderUCHeight(true);

        }

        private void _paBaseHolderUC_btn_Expnd_ClickEventRaised(object sender, EventArgs e)
        {
            //Btn_ExpandBaseHolderUCHeight(false);

            #region ExpandHeightUsingTimer
            foreach (Control uc in _paBaseHolderUC.PABaseHolderPanelBody().Controls)
            {
                uc.Height = panelTitleHeight; // force reset of UCHeight
            }
            if (_windoorModel.WD_PALst_Designs.Count != 0)
            {
                if (_paBaseHolderUC.GetPABaseHolderUC().Height == panelTitleHeight)
                {
                    int height_x_Quantity = (panelTitleHeight * _windoorModel.WD_PALst_Designs.Count) + panelTitleHeight;
                    _panelMaximumHeight =  height_x_Quantity;
                    _isPanelHeightExpanded = false;
                    _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.arrowD_black;
                }
                else
                {
                    _panelMinimumHeight = panelTitleHeight;
                    _isPanelHeightExpanded = true;
                    _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.arrowD_white;
                }
            }

            _paBaseHolderUC.HeightExpandTmr().Start();
            #endregion

        }
        private void Btn_ExpandBaseHolderUCHeight(bool _isFromAddBtn)
        {
            #region ChangePABaseHolderUCHeight
            foreach (Control uc in _paBaseHolderUC.PABaseHolderPanelBody().Controls)
            {
                uc.Height = panelTitleHeight; // force reset of UCHeight
            }
            if (_windoorModel.WD_PALst_Designs.Count != 0)
            {
                if (_paBaseHolderUC.GetPABaseHolderUC().Height == panelTitleHeight || _isFromAddBtn)
                {
                    int height_x_Quantity = (panelTitleHeight * _windoorModel.WD_PALst_Designs.Count) + panelTitleHeight;
                    _paBaseHolderUC.GetPABaseHolderUC().Height = height_x_Quantity;
                    _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.arrowD_black;
                }
                else
                {
                    _paBaseHolderUC.GetPABaseHolderUC().Height = panelTitleHeight;
                    _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.arrowD_white;
                }
            }
            #endregion
        }

        private void _paBaseHolderUC_PartialAdjustmentBaseHolderUC_LoadEventRaised(object sender, EventArgs e)
        {
            PA_LstDesignCount = _windoorModel.WD_PALst_Designs.Count; // Limit for ForLoop

            #region Old Algo For Partial Adjustment Auto
            //for (int i = 1; i <= ItemQuantity; i++)
            //{
            //    _partialAdjustmentUCPresenter = _partialAdjustmentUCPresenter.GetNewInstance(_unityC, _quotationModel, _windoorModel, _mainPresenter, _partialAdjustmentViewPresenter, this);
            //    UserControl partialadjustmentItems = (UserControl)_partialAdjustmentUCPresenter.GetPartialAdjustmentUC();
            //    _paBaseHolderUC.PABaseHolderPanelBody().Controls.Add(partialadjustmentItems);
            //    partialadjustmentItems.Dock = DockStyle.Top;
            //    partialadjustmentItems.BringToFront();
            //    _paBaseHolderUC.PABaseHolderPanelBody().AutoScroll = true;

            //    _partialAdjustmentUCPresenter.PartialAdjusmentUCIndexPlacement = i - 1; // forward index placement of windoor 'add new' or 'update'

            //    if (_windoorModel.WD_PALst_Designs.Count > 0)
            //    {
            //        if (i <= PA_LstDesignCount)
            //        {
            //            _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_PALst_Designs[i - 1];//Get Previous Img
            //            _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_PALst_Description[i - 1];//Get Previous Desc
            //            _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = _windoorModel.WD_PALst_Price[i - 1].ToString("N");//Get Previous Price
            //        }
            //    }
            //    else
            //    {
            //        #region Add Default Value To Image, Description,Price List
            //        for (int j = 1; j <= ItemQuantity; j++)
            //        {
            //            // Always Update in ItemDisabledUC
            //            _windoorModel.WD_PALst_Designs.Add(null);
            //            _windoorModel.WD_PALst_Description.Add(null);
            //            _windoorModel.WD_PALst_Price.Add(0);
            //        }
            //        #endregion
            //    }

            //    if (_windoorModel.WD_IsPartialADPreviousExist == true)
            //    {
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDesignImage().Image = _windoorModel.WD_PAPreviousImage;
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDescription().Text = _windoorModel.WD_PAPreviousDescription;
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemPrice().Text = Math.Round(_windoorModel.WD_PAPreviousPrice).ToString("N");
            //    }
            //    else
            //    {
            //        #region Show Current Design, No Previous Design
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = (i).ToString();
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_image;
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_description;
            //        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = Math.Round(_windoorModel.WD_price, 2).ToString("N");
            //        #endregion
            //    }

            //}
            #endregion

            if (PA_LstDesignCount != 0)
            {
                for (int i = 1; i <= PA_LstDesignCount; i++)
                {
                    LoadAdjustmentUCPresenter(i,true);
                }
            }
            _paBaseHolderUC.GetPABaseHolderUC().Height = panelTitleHeight;
        }

        private void LoadAdjustmentUCPresenter(int indxItemPos,bool _isPrevDesExist)
        {
            #region AddControlForUCPresenter
            _partialAdjustmentUCPresenter = _partialAdjustmentUCPresenter.GetNewInstance(_unityC, _quotationModel, _windoorModel, _mainPresenter, _partialAdjustmentViewPresenter, this);
            UserControl partialadjustmentItems = (UserControl)_partialAdjustmentUCPresenter.GetPartialAdjustmentUC();
            _paBaseHolderUC.PABaseHolderPanelBody().Controls.Add(partialadjustmentItems);
            partialadjustmentItems.Dock = DockStyle.Top;
            partialadjustmentItems.BringToFront();
            _paBaseHolderUC.PABaseHolderPanelBody().AutoScroll = true;

            _partialAdjustmentUCPresenter.PartialAdjusmentUCIndexPlacement = indxItemPos - 1; // forward index placement of windoor 'add new' or 'update'


            if (_isPrevDesExist)
            {
                if(_windoorModel.WD_PALst_Designs[indxItemPos - 1] != null)
                {
                    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = "AD";
                }
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_PALst_Designs[indxItemPos - 1];//Get Previous Img
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_PALst_Description[indxItemPos - 1];//Get Previous Desc
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = _windoorModel.WD_PALst_Price[indxItemPos - 1].ToString("N");//Get Previous Price
            }


            if (_windoorModel.WD_IsPartialADPreviousExist == true)
            {
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDesignImage().Image = _windoorModel.WD_PAPreviousImage;
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemDescription().Text = _windoorModel.WD_PAPreviousDescription;
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetOldItemPrice().Text = Math.Round(_windoorModel.WD_PAPreviousPrice).ToString("N");
            }
            else
            {
                #region Show Current Design, No Previous Design
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = (indxItemPos).ToString();
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_image;
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_description;
                _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = Math.Round(_windoorModel.WD_price, 2).ToString("N");
                #endregion
            }

            BtnColorChanger();
            #endregion
        }

        private void BtnColorChanger()
        {
            if (_windoorModel.WD_IsPartialADPreviousExist)
            {
                _paBaseHolderUC.PABaseHolderAddItemQtyBtn().BackgroundImage = Properties.Resources.add_green;
            }
            else if (_windoorModel.WD_PALst_Description.Count != 0)
            {
                _paBaseHolderUC.PABaseHolderAddItemQtyBtn().BackgroundImage = Properties.Resources.add_black;
            }
            else
            {
                _paBaseHolderUC.PABaseHolderAddItemQtyBtn().BackgroundImage = Properties.Resources.add_trans;
            }
        }

        public IPartialAdjustmentBaseHolderUC GetPABaseHolderUC()   
        {
            return _paBaseHolderUC;
        }
        public void GetPABaseHolderDispose()
        {
           _paBaseHolderUC.PABaseHolderDispose();
        }
        public void GetPABaseHolderBringToFront()
        {
           _paBaseHolderUC.PABaseHolderBringToFront();
        }
        public void GetPABaseHolderSendToBack()
        {
           _paBaseHolderUC.PABaseHolderSendToBack();
        }
        public void GetPABaseHolderInvalidate()
        {
            _paBaseHolderUC.PABaseHolderInvalidate();
        }

        public IPartialAdjustmentBaseHolderPresenter GetNewInstance(IUnityContainer unityC,
                                                                    IMainPresenter mainPresenter, 
                                                                    IWindoorModel windoorModel,
                                                                    IQuotationModel quotationModel,
                                                                    IPartialAdjustmentViewPresenter partialAdjustmentViewPresenter)
        {
            unityC
                 .RegisterType<IPartialAdjustmentBaseHolderPresenter, PartialAdjustmentBaseHolderPresenter>()
                 .RegisterType<IPartialAdjustmentBaseHolderUC, PartialAdjustmentBaseHolderUC>();
            PartialAdjustmentBaseHolderPresenter paBaseHolder = unityC.Resolve<PartialAdjustmentBaseHolderPresenter>();
            paBaseHolder._unityC = unityC;
            paBaseHolder._mainPresenter = mainPresenter;
            paBaseHolder._windoorModel = windoorModel;
            paBaseHolder._quotationModel = quotationModel;
            paBaseHolder._partialAdjustmentViewPresenter = partialAdjustmentViewPresenter;

            return paBaseHolder;
        }


    }
}
