﻿using ModelLayer.Model.Quotation;
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



        private int panelTitleHeight = 29;
        private int PA_LstDesignCount = 0;
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
        }

        private void _paBaseHolderUC_btn_Expnd_ClickEventRaised(object sender, EventArgs e)
        {

            foreach(Control uc in _paBaseHolderUC.PABaseHolderPanelBody().Controls)
            {
                uc.Height = panelTitleHeight; // force reset of UCHeight
            }

            if (_paBaseHolderUC.GetPABaseHolderUC().Height == panelTitleHeight)
            {
                int height_x_Quantity = (panelTitleHeight * ItemQuantity) + panelTitleHeight;
                _paBaseHolderUC.GetPABaseHolderUC().Height = height_x_Quantity;
                _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.down_chevron;
            }
            else
            {
                _paBaseHolderUC.GetPABaseHolderUC().Height = panelTitleHeight;
                _paBaseHolderUC.PABaseHolderExpandBtn().BackgroundImage = Properties.Resources.down_arrow_square_outlined_button;
            }
        }

        private void _paBaseHolderUC_PartialAdjustmentBaseHolderUC_LoadEventRaised(object sender, EventArgs e)
        {
            PA_LstDesignCount = _windoorModel.WD_PALst_Designs.Count; // Limit for ForLoop

            for (int i = 1; i <= ItemQuantity; i++)
            {
                _partialAdjustmentUCPresenter = _partialAdjustmentUCPresenter.GetNewInstance(_unityC, _quotationModel, _windoorModel, _mainPresenter, _partialAdjustmentViewPresenter, this);
                UserControl partialadjustmentItems = (UserControl)_partialAdjustmentUCPresenter.GetPartialAdjustmentUC();
                _paBaseHolderUC.PABaseHolderPanelBody().Controls.Add(partialadjustmentItems);
                partialadjustmentItems.Dock = DockStyle.Top;
                partialadjustmentItems.BringToFront();
                _paBaseHolderUC.PABaseHolderPanelBody().AutoScroll = true;

                _partialAdjustmentUCPresenter.PartialAdjusmentUCIndexPlacement = i - 1; // forward index placement of windoor 'add new' or 'update'

                if(_windoorModel.WD_PALst_Designs.Count > 0)
                {
                    if (i <= PA_LstDesignCount)
                    {
                        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_PALst_Designs[i - 1];//Get Previous Img
                        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_PALst_Description[i - 1];//Get Previous Desc
                        _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = _windoorModel.WD_PALst_Price[i - 1].ToString("N");//Get Previous Price
                    }
                }
                else
                {
                    #region Add Default Value To Image, Description,Price List
                    for (int j = 1; j<= ItemQuantity; j++)
                    {
                        // Always Update in ItemDisabledUC
                        _windoorModel.WD_PALst_Designs.Add(null);
                        _windoorModel.WD_PALst_Description.Add(null);
                        _windoorModel.WD_PALst_Price.Add(0);
                    }
                    #endregion
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
                    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetPAItemNo().Text = (i).ToString();
                    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDesignImage().Image = _windoorModel.WD_image;
                    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemDescription().Text = _windoorModel.WD_description;
                    _partialAdjustmentUCPresenter.GetPartialAdjustmentUC().GetCurrentItemPrice().Text = Math.Round(_windoorModel.WD_price, 2).ToString("N");
                    #endregion
                }

            }
            _paBaseHolderUC.GetPABaseHolderUC().Height = panelTitleHeight;
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
