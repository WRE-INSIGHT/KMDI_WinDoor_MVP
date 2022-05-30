using ModelLayer.Model.Quotation.Concrete;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ConcreteServices
{
    public class ConcreteServices : IConcreteServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public ConcreteServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        private IConcreteModel CreateConcrete(int id, string name, int width, int height, float zoom, float imager_zoom)
        {
            IConcreteModel concreteModel = new ConcreteModel();
            concreteModel.Concrete_Id = id;
            concreteModel.Concrete_Name = name;
            concreteModel.Concrete_Width = width;
            concreteModel.Concrete_Height = height;
            concreteModel.Concrete_Zoom = zoom;
            concreteModel.Concrete_ImagerZoom = imager_zoom;

            ValidateModel(concreteModel);

            return concreteModel;
        }

        private void ValidateModel(IConcreteModel concreteModel)
        {
            _modelCheck.ValidateModelDataAnnotations(concreteModel);
        }

        public IConcreteModel AddConcreteModel(int width, int height,
                                               float zoom, float imager_zoom,
                                               int id = 0, string name = "")
        {
            if (name == "")
            {
                name = "Concrete " + id;
            }

            IConcreteModel concreteModel = CreateConcrete(id, name, width, height, zoom, imager_zoom);

            return concreteModel;
        }
    }
}
