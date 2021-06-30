﻿using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Presenter.UserControls;
using ModelLayer.Model.User;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using System.Windows.Forms;
using Unity;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Presenter.UserControls.Dividers;
using System.Data;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        DataTable GlassThicknessDT { get; set; }
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
        IDividerPropertiesUCPresenter divPropertiesUCP { get; }
        DataTable Glass_Type { get; }
        DataTable Spacer { get; }
        DataTable Color { get; }

        IMainView GetMainView();
        IFramePropertiesUC GetFrameProperties(int frameID);

        void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC);
        void AddBasePlatform(IBasePlatformUC basePlatform);
        void AddWndrList_QuotationModel(IWindoorModel wndr);
        void AddFrameList_WindoorModel(IFrameModel frameModel);
        void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel);
        int GetPanelCount();
        int GetMultiPanelCount();
        int GetDividerCount();
        int GetPanelGlassID();
        void DeductPanelGlassID();
        void SetPanelGlassID();
        void AddItemInfoUC(IWindoorModel wndr);
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
        void Run_GetListOfMaterials_SpecificItem();
        void DeleteMultiPanelPropertiesUC(int multiPanelID);
        void DeleteDividerPropertiesUC(int divID);
        void DeletePanelPropertiesUC(int panelID);
        void DeleteFramePropertiesUC(int frameID);
    }
}