using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
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
    public class PartialAdjustmentItemDisabledUCPresenter : IPartialAdjustmentItemDisabledUCPresenter
    {
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IPartialAdjustmenItemDisabledUC _pAItemDisabledUC;

        private UserControl _paUCView;

        private string _userControlBackground;     
        public string UserControlBackground
        {
            get
            {
                return _userControlBackground;
            }
            set
            {
                _userControlBackground = value;
            }
        }

        private Image PaCurrentDesignImgHolder { get; set; }
        private string PaCurrentDesignDescHolder { get; set; }
        private decimal PACurrentDesignPrice { get; set; }

        public int PartialAdjusmentItemDisabledUCIndexPlacement { get; set; }

        public PartialAdjustmentItemDisabledUCPresenter(IPartialAdjustmenItemDisabledUC pAItemDisabledUC)
        {
            _pAItemDisabledUC = pAItemDisabledUC;
            _paUCView = _pAItemDisabledUC.GetPartialAdjustmentItemDisableUC();

            SubscribeToEventSetup();
        }
        
        private void SubscribeToEventSetup()
        {
            _pAItemDisabledUC.btn_Cancel_ClickEventRaised += _pAItemDisabledUC_btn_Cancel_ClickEventRaised;
            _pAItemDisabledUC.btn_Yes_ClickEventRaised += _pAItemDisabledUC_btn_Yes_ClickEventRaised;
            _pAItemDisabledUC.PartialAdjustmenItemDisabledUC_LoadEventRaised += _pAItemDisabledUC_PartialAdjustmenItemDisabledUC_LoadEventRaised;
            _pAItemDisabledUC.PartialAdjustmenItemDisabledUC_ResizeEventRaised += _pAItemDisabledUC_PartialAdjustmenItemDisabledUC_ResizeEventRaised;
        }

        private void ResizeAndRePosition()
        {
            int mainViewWidth = _mainPresenter.GetMainView().GetThis().Width;
            int mainViewPnlItemWidth = _mainPresenter.pnlItems_MainPresenter.Width;

            _paUCView.BackColor = System.Drawing.ColorTranslator.FromHtml(_userControlBackground);

            _paUCView.Width = mainViewPnlItemWidth;
            _paUCView.Location = new System.Drawing.Point((mainViewWidth - mainViewPnlItemWidth) - 18, _mainPresenter.pnlItems_MainPresenter.Location.Y + 28);
            _paUCView.Height = _mainPresenter.pnlItems_MainPresenter.Height + 30;

            _paUCView.Dock = DockStyle.Right;

        }
        private void _pAItemDisabledUC_PartialAdjustmenItemDisabledUC_ResizeEventRaised(object sender, EventArgs e)
        {
            ResizeAndRePosition();
            _pAItemDisabledUC.InvalidateItemDisabled();
            paItemDisableUCPresenter_BringToFront();
        }

        private void _pAItemDisabledUC_PartialAdjustmenItemDisabledUC_LoadEventRaised(object sender, EventArgs e)
        {
            ResizeAndRePosition();
            paItemDisableUCPresenter_Invalidatethis();

            PaCurrentDesignImgHolder = _windoorModel.WD_image;
            PaCurrentDesignDescHolder = _windoorModel.WD_description;
            PACurrentDesignPrice = _windoorModel.WD_price;

        }

        private void _pAItemDisabledUC_btn_Yes_ClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                _windoorModel.WD_PALst_Designs.Insert(PartialAdjusmentItemDisabledUCIndexPlacement, _windoorModel.WD_image);
                _windoorModel.WD_PALst_Designs.RemoveAt(PartialAdjusmentItemDisabledUCIndexPlacement + 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Problem at WD_PALstDesign" + this);
            }


            if(_windoorModel.WD_IsPartialADPreviousExist == false) 
            {
                _windoorModel.WD_IsPartialADPreviousExist = true;
                _windoorModel.WD_PAPreviousImage = PaCurrentDesignImgHolder;
                _windoorModel.WD_PAPreviousDescription = PaCurrentDesignDescHolder;
                _windoorModel.WD_PAPreviousPrice = PACurrentDesignPrice;
            }
            MainPresenterPanelsEnabled();
        }

        private void _pAItemDisabledUC_btn_Cancel_ClickEventRaised(object sender, EventArgs e)
        {
            MainPresenterPanelsEnabled();
        }

        private void MainPresenterPanelsEnabled()
        {
          
          _mainPresenter.GetMainView().GetMNSMainMenu().Enabled = true;
          //_mainPresenter.GetMainView().GetTSMain().Enabled = true;
          _mainPresenter.GetMainView().SpecificToolStripEnable = true;
          _mainPresenter.GetMainView().GetPanelItems().Enabled = true;


          _mainPresenter.GetMainView().GetMNSMainMenu().BackColor = System.Drawing.SystemColors.Control;
          _mainPresenter.GetMainView().GetTSMain().BackColor = System.Drawing.SystemColors.Control;
          _mainPresenter.GetMainView().GetPanelItems().BackColor = System.Drawing.SystemColors.Control;

          _pAItemDisabledUC.DisposeThis();
         
        }


        public IPartialAdjustmentItemDisabledUCPresenter GetNewInstance(IUnityContainer unityC,IMainPresenter mainPresenter,IWindoorModel windoorModel,
                                                              IQuotationModel quotationModel)
        {
            unityC
                .RegisterType<IPartialAdjustmenItemDisabledUC, PartialAdjustmenItemDisabledUC>()
                .RegisterType<IPartialAdjustmentItemDisabledUCPresenter, PartialAdjustmentItemDisabledUCPresenter>();
            PartialAdjustmentItemDisabledUCPresenter PAItemDisablePresenter = unityC.Resolve<PartialAdjustmentItemDisabledUCPresenter>();
            PAItemDisablePresenter._unityC = unityC;
            PAItemDisablePresenter._mainPresenter = mainPresenter;
            PAItemDisablePresenter._windoorModel = windoorModel;
            PAItemDisablePresenter._quotationModel = quotationModel;

            return PAItemDisablePresenter;

        }

        public IPartialAdjustmenItemDisabledUC GetPartialAdjustmentItemDisablepdUC()
        {
            return _pAItemDisabledUC;
        }
        public void paItemDisableUCPresenter_BringToFront()
        {
            _pAItemDisabledUC.ItemInfoDisabledBringToFront();
        }

        public void paItemDisableUCPresenter_SendToBack()
        {
            _pAItemDisabledUC.ItemInfoDisabledSendToBack();
        }
        public void paItemDisableUCPresenter_Invalidatethis()
        {
            _pAItemDisabledUC.InvalidateItemDisabled();
        }
        
    }
}
