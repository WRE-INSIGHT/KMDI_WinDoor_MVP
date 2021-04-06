using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.CommonServices;
using ModelLayer.Model.Quotation.Panel;
using System.Windows.Forms;

namespace ServiceLayer.Services.PanelServices
{
    public class PanelServices : IPanelServices
    {

        private IModelDataAnnotationCheck _modelCheck;

        public PanelServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        private IPanelModel CreatePanelModel(int panelID,
                                            string panelName,
                                            int panelWd,
                                            int panelHt,
                                            DockStyle panelDock,
                                            string panelType,
                                            bool panelOrient,
                                            Control panelParent,
                                            UserControl panelFrameGroup,
                                            bool panelVisibility,
                                            UserControl panelFramePropertiesGroup,
                                            UserControl panelMultiPanelGroup,
                                            int panelIndexInsideMPanel,
                                            float panelImageRendererZoom,
                                            float panelZoom)
        {
            PanelModel pnl = new PanelModel(panelID,
                                            panelName,
                                            panelWd,
                                            panelHt,
                                            panelDock,
                                            panelType,
                                            panelOrient,
                                            panelParent,
                                            panelFrameGroup,
                                            panelVisibility,
                                            panelFramePropertiesGroup,
                                            panelMultiPanelGroup,
                                            panelIndexInsideMPanel,
                                            panelImageRendererZoom,
                                            panelZoom);

            ValidateModel(pnl);
            return pnl;
        }

        public void ValidateModel(IPanelModel panelModel)
        {
            _modelCheck.ValidateModelDataAnnotations(panelModel);
        }

        public IPanelModel AddPanelModel(int panelWd,
                                         int panelHt,
                                         Control panelParent,
                                         UserControl panelFrameGroup,
                                         UserControl panelFramePropertiesGroup,
                                         UserControl panelMultiPanelGroup,
                                         string panelType,
                                         bool panelVisibility,
                                         float panelZoom,
                                         int panelID = 0,
                                         float panelImageRendererZoom = 1,
                                         int panelIndexInsideMPanel = 0,
                                         DockStyle panelDock = DockStyle.Fill,
                                         string panelName = "",
                                         bool panelOrient = false)
        {
            if (panelName == "")
            {
                panelName = panelType.Replace(" Panel", "") + "PanelUC_" + panelID;
            }

            IPanelModel _panelModel = CreatePanelModel(panelID,
                                                       panelName,
                                                       panelWd,
                                                       panelHt,
                                                       panelDock,
                                                       panelType,
                                                       panelOrient,
                                                       panelParent,
                                                       panelFrameGroup,
                                                       panelVisibility,
                                                       panelFramePropertiesGroup,
                                                       panelMultiPanelGroup,
                                                       panelIndexInsideMPanel,
                                                       panelImageRendererZoom,
                                                       panelZoom);

            return _panelModel;
        }

    }
}
