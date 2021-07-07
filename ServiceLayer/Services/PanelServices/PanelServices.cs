﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.CommonServices;
using ModelLayer.Model.Quotation.Panel;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using static ModelLayer.Model.Quotation.QuotationModel;
using static EnumerationTypeLayer.EnumerationTypes;

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
                                            float panelZoom,
                                            IFrameModel panelFrameModelParent,
                                            IMultiPanelModel panelMultiPanelParent,
                                            GlazingBead_ArticleNo panelGlazingBeadArtNo,
                                            int panelDisplayWidth,
                                            int panelDisplayHeight,
                                            int panelGlassID,
                                            GlassFilm_Types panelGlassFilm,
                                            SashProfile_ArticleNo panelSash,
                                            SashReinf_ArticleNo panelSashReinf,
                                            GlassType panelGlassType,
                                            Espagnolette_ArticleNo panelEspagnoletteArtNo,
                                            Striker_ArticleNo panelStrikerArtno,
                                            MiddleCloser_ArticleNo panelMiddleCloserArtno,
                                            LockingKit_ArticleNo panelLockingKitArtno)
        {
            IPanelModel pnl = new PanelModel(panelID,
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
                                             panelZoom,
                                             panelFrameModelParent,
                                             panelMultiPanelParent,
                                             panelGlazingBeadArtNo,
                                             panelDisplayWidth,
                                             panelDisplayHeight,
                                             panelGlassID,
                                             panelGlassFilm,
                                             panelSash,
                                             panelSashReinf,
                                             panelGlassType,
                                             panelEspagnoletteArtNo,
                                             panelStrikerArtno,
                                             panelMiddleCloserArtno,
                                             panelLockingKitArtno);

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
                                         IFrameModel panelFrameModelParent,
                                         IMultiPanelModel panelMultiPanelParent,
                                         int panelDisplayWidth,
                                         int panelDisplayHeight,
                                         GlazingBead_ArticleNo panelGlazingBeadArtNo,
                                         GlassFilm_Types panelGlassFilm,
                                         SashProfile_ArticleNo panelSash,
                                         SashReinf_ArticleNo panelSashReinf,
                                         GlassType panelGlassType,
                                         Espagnolette_ArticleNo panelEspagnoletteArtNo,
                                         Striker_ArticleNo panelStrikerArtno,
                                         MiddleCloser_ArticleNo panelMiddleCloserArtno,
                                         LockingKit_ArticleNo panelLockingKitArtno,
                                         int panelID = 0,
                                         int panelGlassID = 0,
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
                                                       panelZoom,
                                                       panelFrameModelParent,
                                                       panelMultiPanelParent,
                                                       panelGlazingBeadArtNo,
                                                       panelDisplayWidth,
                                                       panelDisplayHeight,
                                                       panelGlassID,
                                                       panelGlassFilm,
                                                       panelSash,
                                                       panelSashReinf,
                                                       panelGlassType,
                                                       panelEspagnoletteArtNo,
                                                       panelStrikerArtno,
                                                       panelMiddleCloserArtno,
                                                       panelLockingKitArtno);

            return _panelModel;
        }

    }
}
