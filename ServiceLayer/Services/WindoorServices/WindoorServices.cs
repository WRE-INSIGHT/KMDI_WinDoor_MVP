using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.WinDoor;
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
                                           int WD_zoom)
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
            wndr.WD_zoom = WD_zoom;

            //ValidateModel(wndr);
            return wndr;
        }

        public void ValidateModel(IWindoorModel windoorModel)
        {
            _modelCheck.ValidateModelDataAnnotations(windoorModel);
        }
    }
}
