using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Screen;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        IDictionary<string, string> RDLCHeader { get; set; }
        List<IScreenModel> Screen_List { get; set; }
        List<DataRow> NonUnglazed { get; set; }
        List<DataRow> Unglazed { get; set; }
        Control ControlRaised_forDMSelection { get; }
        IDividerModel DivModel_forDMSelection { get; }
        IPanelModel PrevPnlModel_forDMSelection { get; }
        IPanelModel NxtPnlModel_forDMSelection { get; }
        IPanelModel PnlModel_forGlassSelection();
        DataTable GlassThicknessDT { get; set; }
        DataTable GlassTypeDT { get; set; }
        DataTable GlassColorDT { get; set; }
        DataTable GlassSpacerDT { get; set; }
        int inputted_quoteId { get; set; }
        string inputted_quotationRefNo { get; set; }
        string inputted_projectName { get; set; }
        string inputted_custRefNo { get; set; }
        bool isNewProject { get; set; }
        bool ProvinceIntownOutofTown { get; set; }
        string aeic { get; set; }
        string position { get; set; }
        string projectAddress { get; set; }
        string titleLastname { get; set; }
        DateTime dateAssigned { get; set; }
        void SetPricingFactor();
        DateTime inputted_quoteDate { get; set; }
        IQuotationModel qoutationModel_MainPresenter { get; set; }
        IWindoorModel windoorModel_MainPresenter { get; set; }
        IFrameModel frameModel_MainPresenter { get; set; }
        IScreenModel screenModel_MainPresenter { get; set; }
        string printStatus { get; set; }

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

        void DeleteConcrete_OnObjectList_WindoorModel(UserControl _concreteUC);

        DataTable Spacer { get; }
        DataTable Color { get; }
        string wndrFileName { get; set; }
        string wndrFilePath { get; set; }
        NumericUpDown LblCurrentPrice { get; set; }

        IMainView GetMainView();
        IFramePropertiesUC GetFrameProperties(int frameID);

        void SetLblStatus(string status, bool visibility,
                          Control controlRaised = null,
                          IDividerModel divModel = null,
                          IPanelModel prev_pnl = null,
                          IPanelModel nxt_pnl = null,
                          IDividerPropertiesUCPresenter divPropUCP = null);
        void SetValues(IUserModel userModel, ILoginView loginView, IUnityContainer unityC);
        void AddBasePlatform(IBasePlatformUC basePlatform);
        void AddWndrList_QuotationModel(IWindoorModel wndr);
        void AddFrameList_WindoorModel(IFrameModel frameModel);
        void DeleteFrame_OnFrameList_WindoorModel(IFrameModel frameModel);
        void DeleteConcrete_OnConcreteList_WindoorModel(IConcreteModel concreteModel);
        int GetPanelCount();
        int GetMultiPanelCount();
        int GetDividerCount();
        int GetPanelGlassID();
        void DeductPanelGlassID();
        void SetPanelGlassID();

        void AddItemInfoUC(IWindoorModel wndr);
        List<IMultiPanelModel> Arrange_Frame_MultiPanelModel(IFrameModel frmModel);
        void Invalidate_pnlMain();
        void Scenario_Quotation(bool QoutationInputBox_OkClicked,
                                bool NewItem_OkClicked,
                                bool AddedFrame,
                                bool AddedConcrete,
                                bool OpenWindoorFile,
                                bool Duplicate,
                                frmDimensionPresenter.Show_Purpose purpose,
                                int frmDimension_numWd,
                                int frmDimension_numHt,
                                string frmDimension_profileType,
                                string frmDimension_baseColor);
        void Clearing_Operation();
        void frmDimensionResults(frmDimensionPresenter.Show_Purpose purpose,
                                 int frmDimension_numWd,
                                 int frmDimension_numHt);
        void SetSelectedDivider(IDividerModel divModel,
                                ITransomUCPresenter transomUCP = null,
                                IMullionUCPresenter mullionUCP = null);
        void SetSelectedPanel(IPanelModel _panelModel,
                              ISlidingPanelUCPresenter slidingPanelUCPresenter,
                              ICasementPanelUCPresenter casementPanelUCPresenter,
                              IFixedPanelUCPresenter fixedPanelUCPresenter);
        void DeselectPanel();
        void DeselectDivider();
        void Run_GetListOfMaterials_SpecificItem();
        void Set_User_View();
        void DeleteMultiPanelPropertiesUC(int multiPanelID);
        void DeleteDividerPropertiesUC(int divID);
        void DeletePanelPropertiesUC(int panelID);
        void DeleteFramePropertiesUC(int frameID);
        void DeleteConcretePropertiesUC(int concreteID);
        void Fit_MyControls_byControlsLocation();
        void Fit_MyImager_byImagersLocation();
        void Set_pnlPropertiesBody_ScrollView(int addTo_scroll_value);
        void Load_Windoor_Item(IWindoorModel item);
        void SetChangesMark();
        void SaveChanges();
        void SaveAs();
        void itemDescription();
        void GetCurrentPrice();
        void updatePriceFromMainViewToItemList();
        void updatePriceOfMainView();
        int PropertiesScroll { get; set; }
        int ItemScroll { get; set; }
        int FrameIteration { get; set; }
        bool ItemLoad { get; set; }
        void AddSlidingScreentoScreenList();
        int ForceRestartAndLoadFile();
    }
}