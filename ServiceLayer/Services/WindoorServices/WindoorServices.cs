﻿using ModelLayer.Model.Quotation.Concrete;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using ServiceLayer.CommonServices;
using System.Collections.Generic;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.WindoorServices
{
    public class WindoorServices : IWindoorServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public WindoorServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        private IWindoorModel CreateWindoor(int WD_id,
                                           string WD_name,
                                           string WD_description,
                                           int WD_width,
                                           int WD_height,
                                           decimal WD_price,
                                           int WD_quantity,
                                           decimal WD_discount,
                                           string WD_itemName,
                                           string WD_windoorNumber,
                                           bool WD_visibility,
                                           bool WD_orientation,
                                           float WD_zoom,
                                           string WD_Profile,
                                           List<IFrameModel> lst_frame,
                                           List<IConcreteModel> lst_concrete,
                                           List<Control> lst_Objects,
                                           Base_Color wd_basecolor,
                                           Foil_Color wd_insidecolor,
                                           Foil_Color wd_outisdecolor,
                                           bool isFromLoad,
                                           List<string> lst_TotalPriceHistory,
                                           decimal SystemSuggestedPrice

                                           //int wd_costingPoints
                                           )
        {
            IWindoorModel wndr = new WindoorModel(WD_id,
                                                  WD_name,
                                                  WD_description,
                                                  WD_width,
                                                  WD_height,
                                                  WD_price,
                                                  WD_quantity,
                                                  WD_discount,
                                                  WD_itemName,
                                                  WD_windoorNumber,
                                                  WD_visibility,
                                                  WD_orientation,
                                                  WD_Profile,
                                                  lst_frame,
                                                  lst_concrete,
                                                  lst_Objects,
                                                  wd_basecolor,
                                                  wd_insidecolor,
                                                  wd_outisdecolor,
                                                  isFromLoad,
                                                  lst_TotalPriceHistory,
                                                  SystemSuggestedPrice
                                                  //wd_costingPoints
                                                  );

            ValidateModel(wndr);
            return wndr;
        }

        public IWindoorModel AddWindoorModel(int WD_width,
                                             int WD_height,
                                             string WD_Profile,
                                             int WD_ID,
                                             Base_Color wd_basecolor,
                                             Foil_Color wd_insidecolor,
                                             Foil_Color wd_outisdecolor,
                                             string WD_name = "",
                                             string WD_description = "",
                                             int WD_quantity = 1,
                                             bool WD_visibility = true,
                                             bool WD_orientation = true,
                                             float WD_zoom = 1.0f,
                                             decimal WD_price = 0,
                                             decimal WD_discount = 30.0M,
                                             string WD_itemName = "",
                                             string WD_windoorNumber = "",
                                             List<IFrameModel> lst_frame = null,
                                             List<IConcreteModel> lst_concrete = null,
                                             List<Control> lst_Objects = null,
                                             int wd_costingPoints = 0,
                                             bool isFromLoad = false,
                                             List<string> lst_TotalPriceHistory = null,
                                             decimal SystemSuggestedPrice = 0)
        {
            if (WD_name == "")
            {
                WD_name = "Item " + WD_ID;
            }
            if (WD_description == "")
            {
                WD_description = WD_Profile;
            }
            if (lst_frame == null)
            {
                lst_frame = new List<IFrameModel>();
            }
            if (lst_concrete == null)
            {
                lst_concrete = new List<IConcreteModel>();
            }
            if (lst_Objects == null)
            {
                lst_Objects = new List<Control>();
            }
            if (lst_TotalPriceHistory == null)
            {
                lst_TotalPriceHistory = new List<string>();
            }
            IWindoorModel _windoorModel = CreateWindoor(WD_ID,
                                                        WD_name,
                                                        WD_description,
                                                        WD_width,
                                                        WD_height,
                                                        WD_price,
                                                        WD_quantity,
                                                        WD_discount = 30,
                                                        WD_itemName = "",
                                                        WD_windoorNumber = "",
                                                        WD_visibility,
                                                        WD_orientation,
                                                        WD_zoom,
                                                        WD_Profile,
                                                        lst_frame,
                                                        lst_concrete,
                                                        lst_Objects,
                                                        wd_basecolor,
                                                        wd_insidecolor,
                                                        wd_outisdecolor,
                                                        isFromLoad,
                                                        lst_TotalPriceHistory,
                                                        SystemSuggestedPrice
                                                        //wd_costingPoints
                                                        );

            return _windoorModel;
        }

        public void ValidateModel(IWindoorModel windoorModel)
        {
            _modelCheck.ValidateModelDataAnnotations(windoorModel);
        }
    }
}
