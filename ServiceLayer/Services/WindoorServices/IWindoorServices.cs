﻿using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.WindoorServices
{
    public interface IWindoorServices
    {
        void ValidateModel(IWindoorModel windoorModel);
        IWindoorModel AddWindoorModel(int WD_width,
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
                                      int WD_price = 0,
                                      decimal WD_discount = 0.0M,
                                      List<IFrameModel> lst_frame = null);
    }
}