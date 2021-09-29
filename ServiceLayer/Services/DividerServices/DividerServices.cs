using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
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
                                                IMultiPanelModel divMPanelParent,
                                                Dictionary<int, int> divCladdingSizeList,
                                                IFrameModel divFrameParent,
                                                bool divChkDM,
                                                bool divArtVisibility,
                                                DummyMullion_ArticleNo divDMArtNo,
                                                IPanelModel divDMPanel,
                                                bool divLeverEspagVisibility)
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
                                                divMPanelParent,
                                                divCladdingSizeList,
                                                divFrameParent,
                                                divChkDM,
                                                divArtVisibility,
                                                divDMArtNo,
                                                divDMPanel,
                                                divLeverEspagVisibility);

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
                                             IFrameModel divFrameParent,
                                             int divID = 0,
                                             float divImageRendererZoom = 1,
                                             string divFrameType = "",
                                             string divName = "",
                                             Dictionary<int, int> divCladdingSizeList = null,
                                             bool divChkDM = false,
                                             bool divArtVisibility = true,
                                             DummyMullion_ArticleNo divDMArtNo = null,
                                             IPanelModel divDMPanel = null,
                                             bool divLeverEspagVisibility = false)
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

            if (divCladdingSizeList == null)
            {
                divCladdingSizeList = new Dictionary<int, int>();
            }

            if (divDMArtNo == null)
            {
                divDMArtNo = DummyMullion_ArticleNo._7533;
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
                                                         divMPanelParent,
                                                         divCladdingSizeList,
                                                         divFrameParent,
                                                         divChkDM,
                                                         divArtVisibility,
                                                         divDMArtNo,
                                                         divDMPanel,
                                                         divLeverEspagVisibility);

            return _divModel;
        }
    }
}
