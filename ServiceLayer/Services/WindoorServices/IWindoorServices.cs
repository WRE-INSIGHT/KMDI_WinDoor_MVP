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
                                    int WD_zoom,
                                    string WD_Profile,
                                    List<IFrameModel> lst_frame);
        void ValidateModel(IWindoorModel windoorModel);
    }
}