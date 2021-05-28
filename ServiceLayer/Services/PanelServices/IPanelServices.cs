﻿using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using static ModelLayer.Model.Quotation.QuotationModel;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.PanelServices
{
    public interface IPanelServices
    {
        void ValidateModel(IPanelModel panelModel);
        IPanelModel AddPanelModel(int panelWd,
                                  int panelHt,
                                  Control panelParent,
                                  UserControl panelFrameGroup,
                                  UserControl panelFramePropertiesGroup,
                                  UserControl panelMultiPanelGroup,
                                  string panelType,
                                  bool panelVisibility,
                                  float panelZoom,
                                  IFrameModel panelFrameModelParent,
                                  IMultiPanelModel panelMultiPanelParent,
                                  int panelDisplayWidth,
                                  int panelDisplayHeight,
                                  Glass_Thickness panelGlassThickness,
                                  GlazingBead_ArticleNo panelGlazingBeadArtNo = null,
                                  int panelID = 0,
                                  int panelGlassID = 0,
                                  float panelImageRendererZoom = 1,
                                  int panelIndexInsideMPanel = 0,
                                  DockStyle panelDock = DockStyle.Fill,
                                  string panelName = "",
                                  bool panelOrient = false);
    }
}