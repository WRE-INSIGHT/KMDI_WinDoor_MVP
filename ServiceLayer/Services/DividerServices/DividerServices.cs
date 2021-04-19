using ModelLayer.Model.Quotation.Divider;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

namespace ServiceLayer.Services.DividerServices
{
    public class DividerServices : IDividerServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public DividerServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        private IDividerModel CreateDividerModel(int divID,
                                                string divName,
                                                int divWD,
                                                int divHT,
                                                bool divVisibility,
                                                DividerType divType,
                                                Control divParent,
                                                string divFrameType,
                                                float divImageRendererZoom,
                                                float divZoom)
        {
            DividerModel div = new DividerModel(divID,
                                                divName,
                                                divWD,
                                                divHT,
                                                divVisibility,
                                                divType,
                                                divParent,
                                                divFrameType,
                                                divImageRendererZoom,
                                                divZoom);

            ValidateModel(div);
            return div;
        }

        private void ValidateModel(IDividerModel divModel)
        {
            _modelCheck.ValidateModelDataAnnotations(divModel);
        }

        public IDividerModel AddDividerModel(int divWD,
                                             int divHT,
                                             Control divParent,
                                             DividerType divType,
                                             bool divVisibility,
                                             float divZoom,
                                             int divID = 0,
                                             float divImageRendererZoom = 1,
                                             string divFrameType = "",
                                             string divName = "")
        {
            if (divName == "")
            {
                divName = divType.ToString() + "UC_" + divID;
            }

            IDividerModel _divModel = CreateDividerModel(divID,
                                                         divName,
                                                         divWD,
                                                         divHT,
                                                         divVisibility,
                                                         divType,
                                                         divParent,
                                                         divFrameType,
                                                         divImageRendererZoom,
                                                         divZoom);

            return _divModel;
        }
    }
}
