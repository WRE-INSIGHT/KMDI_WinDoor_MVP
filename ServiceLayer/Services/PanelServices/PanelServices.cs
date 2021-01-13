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

        public IPanelModel CreatePanelModel(int panelID,
                                            string panelName,
                                            int panelWd,
                                            int panelHt,
                                            DockStyle panelDock,
                                            string panelType,
                                            bool panelOrient,
                                            Control panelParent,
                                            UserControl panelFrameGroup,
                                            bool panelVisibility,
                                            UserControl panelFramePropertiesGroup)
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
                                            panelFramePropertiesGroup);

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
                                         string panelType,
                                         bool panelVisibility,
                                         int panelID = 0,
                                         DockStyle panelDock = DockStyle.Fill,
                                         string panelName = "",
                                         bool panelOrient = false)
        {
            if (panelName == "")
            {
                panelName = "Panel " + panelID;
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
                                                       panelFramePropertiesGroup);

            return _panelModel;
        }

    }
}
