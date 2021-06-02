using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.MultiPanel;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using static ModelLayer.Model.Quotation.QuotationModel;

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
                                                float divZoom,
                                                Divider_ArticleNo divArtNo,
                                                int divDisplayWidth,
                                                int divDisplayHeight,
                                                IMultiPanelModel divMPanelParent)
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
                                                divZoom,
                                                divArtNo,
                                                divDisplayWidth,
                                                divDisplayHeight,
                                                divMPanelParent);

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
                                             Divider_ArticleNo divArtNo,
                                             int divDisplayWidth,
                                             int divDisplayHeight,
                                             IMultiPanelModel divMPanelParent,
                                             int divID = 0,
                                             float divImageRendererZoom = 1,
                                             string divFrameType = "",
                                             string divName = "")
        {
            if (divName == "")
            {
                divName = divType.ToString() + "UC_" + divID;
            }

            if (divType == DividerType.Mullion)
            {
                divDisplayWidth = 0;
            }
            else if (divType == DividerType.Transom)
            {
                divDisplayHeight = 0;
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
                                                         divZoom,
                                                         divArtNo,
                                                         divDisplayWidth,
                                                         divDisplayHeight,
                                                         divMPanelParent);

            return _divModel;
        }
    }
}
