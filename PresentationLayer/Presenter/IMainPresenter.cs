using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        string inputted_quotationRefNo { get; set; }
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView);
        void AddBasePlatform(IBasePlatformUC basePlatform);
        void AddQuotationModel(string quotation_ref_no, List<IWindoorModel> lst_wndr = null);
        void AddWndrList_QuotationModel(IWindoorModel wndr);
        void AddFrameList_WindoorModel(IFrameModel frameModel);
        IWindoorModel AddWindoorModel(int WD_width,
                                      int WD_height,
                                      string WD_Profile,
                                      int WD_ID = 0,
                                      string WD_name = "",
                                      string WD_description = "",
                                      int WD_quantity = 1,
                                      bool WD_visibility = true,
                                      bool WD_orientation = true,
                                      int WD_zoom = 1,
                                      int WD_price = 0,
                                      decimal WD_discount = 0.0M,
                                      List<IFrameModel> lst_frame = null);
        IFrameModel AddFrameModel(int frame_width,
                                  int frame_height,
                                  FrameModel.Frame_Padding frame_type,
                                  int frame_id = 0,
                                  string frame_name = "");
        void AddItemInfoUC(IWindoorModel wndr);
        void AddFrameUC(IFrameModel frameModel);
        void AddFramePropertiesUC(IFrameModel frameModel);
        void Invalidate_pnlMain();
        //void SetMainViewTitle(string qrefno, string itemname, string profiletype, bool saved);
        void Extends_frmDimensionOKClicked_Quotations(int numWidth, int numHeight, string profileType);
        void Extends_frmDimensionOKClicked_CreateNewItem(int numWidth, int numHeight, string profileType);
        void Extends_frmDimensionOKClicked_CreateNewFrame(int numWidth, int numHeight, string profileType);
    }
}