using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.WinDoor;
using System.Collections.Generic;

namespace ServiceLayer.Services.WindoorServices
{
    public interface IWindoorServices
    {
        IWindoorModel CreateWindoor(int WD_id,
                                    string WD_name,
                                    string WD_description,
                                    int WD_width,
                                    int WD_height,
                                    int WD_price,
                                    int WD_quantity,
                                    decimal WD_discount,
                                    bool WD_visibility,
                                    bool WD_orientation,
                                    float WD_zoom,
                                    string WD_Profile,
                                    List<IFrameModel> lst_frame);
        void ValidateModel(IWindoorModel windoorModel);
        IWindoorModel AddWindoorModel(int WD_width,
                                      int WD_height,
                                      string WD_Profile,
                                      int WD_ID,
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