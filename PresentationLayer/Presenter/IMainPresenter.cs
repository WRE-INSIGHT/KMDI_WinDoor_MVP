using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Presenter.UserControls;
using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using System.Windows.Forms;
using Unity;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.MultiPanel;
using System.Drawing;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Presenter.UserControls.Dividers;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        string inputted_quotationRefNo { get; set; }
        IQuotationModel qoutationModel_MainPresenter { get; set; }
        IWindoorModel windoorModel_MainPresenter { get; set; }
        IFrameModel frameModel_MainPresenter { get; set; }
        IBasePlatformPresenter basePlatform_MainPresenter { get; set; }
        IBasePlatformImagerUCPresenter basePlatformWillRenderImg_MainPresenter { get; set; }
        IfrmDimensionPresenter frmDimension_MainPresenter { get; set; }
        IItemInfoUC itemInfoUC_MainPresenter { get; set; }
        IFrameUC frameUC_MainPresenter { get; set; }
        IFramePropertiesUC framePropertiesUC_MainPresenter { get; set; }
        FrameModel.Frame_Padding frameType_MainPresenter { get; set; }
        Panel pnlMain_MainPresenter { get; set; }
        Panel pnlItems_MainPresenter { get; set; }
        Panel pnlPropertiesBody_MainPresenter { get; set; }
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC);
        void AddBasePlatform(IBasePlatformUC basePlatform);
        void AddQuotationModel(string quotation_ref_no, List<IWindoorModel> lst_wndr = null);
        void AddWndrList_QuotationModel(IWindoorModel wndr);
        void AddFrameList_WindoorModel(IFrameModel frameModel);
        void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel);
        IWindoorModel AddWindoorModel(int WD_width,
                                      int WD_height,
                                      string WD_Profile,
                                      int WD_ID = 0,
                                      string WD_name = "",
                                      string WD_description = "",
                                      int WD_quantity = 1,
                                      bool WD_visibility = true,
                                      bool WD_orientation = true,
                                      float WD_zoom = 1.0f,
                                      int WD_price = 0,
                                      decimal WD_discount = 0.0M,
                                      List<IFrameModel> lst_frame = null);
        IFramePropertiesUC GetFrameProperties(int frameID);
        int GetPanelCount();
        int GetMultiPanelCount();
        int GetDividerCount();
        void AddItemInfoUC(IWindoorModel wndr);
        void AddFrameUC(IFrameModel frameModel);
        void AddFramePropertiesUC(IFrameModel frameModel);
        void Invalidate_pnlMain();
        void Scenario_Quotation(bool QoutationInputBox_OkClicked,
                                bool NewItem_OkClicked,
                                bool AddedFrame,
                                frmDimensionPresenter.Show_Purpose purpose,
                                int frmDimension_numWd,
                                int frmDimension_numHt,
                                string frmDimension_profileType);
        void frmDimensionResults(frmDimensionPresenter.Show_Purpose purpose,
                                 int frmDimension_numWd,
                                 int frmDimension_numHt);
        void SetSelectedDivider(IDividerModel divModel,
                                ITransomUCPresenter transomUCP = null,
                                IMullionUCPresenter mullionUCP = null);
        void DeselectDivider();
    }
}