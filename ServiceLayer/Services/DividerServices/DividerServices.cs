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
                                                //UserControl divFrameGroup,
                                                string divFrameType)
        {
            DividerModel div = new DividerModel(divID,
                                                divName,
                                                divWD,
                                                divHT,
                                                divVisibility,
                                                divType,
                                                divParent,
                                                //divFrameGroup,
                                                divFrameType);

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
                                             //UserControl divFrameGroup,
                                             DividerType divType,
                                             bool divVisibility,
                                             int divID = 0,
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
                                                         //divFrameGroup,
                                                         divFrameType);

            return _divModel;
        }
    }
}
