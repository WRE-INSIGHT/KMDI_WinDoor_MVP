using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using ModelLayer.Model.Quotation.WinDoor;

namespace PresentationLayer.Presenter
{
    public interface IMainPresenter
    {
        string inputted_quotationRefNo { get; set; }
        IMainView GetMainView();
        void SetValues(IUserModel userModel, ILoginView loginView);
        void AddBasePlatform(IBasePlatformUC basePlatform);
        void AddQuotationModel(string quotation_ref_no);
        void AddWndrList_QuotationModel(IWindoorModel wndr);
        IWindoorModel AddWindoorModel(int WD_width,
                                      int WD_height,
                                      string WD_Profile,
                                      string WD_name = "",
                                      string WD_description = "",
                                      int WD_quantity = 1,
                                      bool WD_visibility = true,
                                      bool WD_orientation = true,
                                      int WD_zoom = 1,
                                      int WD_price = 0,
                                      decimal WD_discount = 0.0M);
        void AddItemInfoUC(IWindoorModel wndr);
        void ItemToolStrip_Enable();
        void SetMainViewTitle(string qrefno, string itemname, string profiletype, bool saved);
    }
}