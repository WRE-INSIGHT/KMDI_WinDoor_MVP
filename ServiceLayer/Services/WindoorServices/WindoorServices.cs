using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using ServiceLayer.CommonServices;

namespace ServiceLayer.Services.WindoorServices
{
    public class WindoorServices : IWindoorServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public WindoorServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        public IWindoorModel CreateWindoor(int WD_id, 
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
                                           List<IFrameModel> lst_frame)
        {
            WindoorModel wndr = new WindoorModel();
            wndr.WD_id = WD_id;
            wndr.WD_name = WD_name;
            wndr.WD_description = WD_description;
            wndr.WD_width = WD_width;
            wndr.WD_height = WD_height;
            wndr.WD_price = WD_price;
            wndr.WD_quantity = WD_quantity;
            wndr.WD_discount = WD_discount;
            wndr.WD_visibility = WD_visibility;
            wndr.WD_orientation = WD_orientation;
            //wndr.WD_zoom = WD_zoom;
            wndr.WD_profile = WD_Profile;
            wndr.lst_frame = lst_frame;

            ValidateModel(wndr);
            return wndr;
        }

        public IWindoorModel AddWindoorModel(int WD_width,
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
                                             List<IFrameModel> lst_frame = null)
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

            IWindoorModel _windoorModel = CreateWindoor(WD_ID,
                                                        WD_name,
                                                        WD_description,
                                                        WD_width,
                                                        WD_height,
                                                        WD_price,
                                                        WD_quantity,
                                                        WD_discount,
                                                        WD_visibility,
                                                        WD_orientation,
                                                        WD_zoom,
                                                        WD_Profile,
                                                        lst_frame);

            return _windoorModel;
        }

        public void ValidateModel(IWindoorModel windoorModel)
        {
            _modelCheck.ValidateModelDataAnnotations(windoorModel);
        }
    }
}
