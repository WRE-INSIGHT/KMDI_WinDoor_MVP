﻿using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ServiceLayer.CommonServices;
using System.Windows.Forms;
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
                                            int panelDisplayWidthDecimal,
                                            int panelDisplayHeight,
                                            int panelDisplayHeightDecimal,
                                            int panelGlassID,
                                            GlassFilm_Types panelGlassFilm,
                                            SashProfile_ArticleNo panelSash,
                                            SashReinf_ArticleNo panelSashReinf,
                                            GlassType panelGlassType,
                                            Espagnolette_ArticleNo panelEspagnoletteArtNo,
                                            Striker_ArticleNo panelStrikerArtno,
                                            MiddleCloser_ArticleNo panelMiddleCloserArtno,
                                            LockingKit_ArticleNo panelLockingKitArtno,
                                            MotorizedMech_ArticleNo panelMotorizedMechArtNo,
                                            Handle_Type panelHandleType,
                                            Extension_ArticleNo paneltopExtArtNo,
                                            Extension_ArticleNo paneltop2ExtArtNo,
                                            Extension_ArticleNo panelbotExtArtNo,
                                            Extension_ArticleNo panelbot2ExtArtNo,
                                            Extension_ArticleNo panelleftExtArtNo,
                                            Extension_ArticleNo panelleft2ExtArtNo,
                                            Extension_ArticleNo panelrightExtArtNo,
                                            Extension_ArticleNo panelright2ExtArtNo,
                                            bool panelExtTopChk,
                                            bool panelExtBotChk,
                                            bool panelExtLeftChk,
                                            bool panelExtRightChk,
                                            int panelExtTopQty,
                                            int panelExtBotQty,
                                            int panelExtLeftQty,
                                            int panelExtRightQty,
                                            int panelExtTop2Qty,
                                            int panelExtBot2Qty,
                                            int panelExtLeft2Qty,
                                            int panelExtRight2Qty,
                                            Rotoswing_HandleArtNo panelRotoswingArtNo,
                                            GeorgianBar_ArticleNo panelGeorgianBarArtNo,
                                            OverlapSash panelOvelapSash,
                                            int panelGeorgianBarVerticalQty,
                                            int panelGeorgianBarHorizontalQty,
                                            bool panelGeorgianBarOptionVisibility,
                                            HingeOption panelHingeOptions,
                                            bool panelSlidingTypeVisibility,
                                            SlidingTypes panelSlidingTypes,
                                            string glasstype_insu_lumi,
                                            decimal glasspricepersqrmeter

                                            )
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
                                             panelDisplayWidthDecimal,
                                             panelDisplayHeight,
                                             panelDisplayHeightDecimal,
                                             panelGlassID,
                                             panelGlassFilm,
                                             panelSash,
                                             panelSashReinf,
                                             panelGlassType,
                                             panelEspagnoletteArtNo,
                                             panelStrikerArtno,
                                             panelMiddleCloserArtno,
                                             panelLockingKitArtno,
                                             panelMotorizedMechArtNo,
                                             panelHandleType,
                                             paneltopExtArtNo,
                                             paneltop2ExtArtNo,
                                             panelbotExtArtNo,
                                             panelbot2ExtArtNo,
                                             panelleftExtArtNo,
                                             panelleft2ExtArtNo,
                                             panelrightExtArtNo,
                                             panelright2ExtArtNo,
                                             panelExtTopChk,
                                             panelExtBotChk,
                                             panelExtLeftChk,
                                             panelExtRightChk,
                                             panelExtTopQty,
                                             panelExtBotQty,
                                             panelExtLeftQty,
                                             panelExtRightQty,
                                             panelExtTop2Qty,
                                             panelExtBot2Qty,
                                             panelExtLeft2Qty,
                                             panelExtRight2Qty,
                                             panelRotoswingArtNo,
                                             panelGeorgianBarArtNo,
                                             panelOvelapSash,
                                             panelGeorgianBarVerticalQty,
                                             panelGeorgianBarHorizontalQty,
                                             panelGeorgianBarOptionVisibility,
                                             panelHingeOptions,
                                             panelSlidingTypeVisibility,
                                             panelSlidingTypes,
                                             glasstype_insu_lumi,
                                             glasspricepersqrmeter
                                             );

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
                                         int panelDisplayWidthDecimal,
                                         int panelDisplayHeight,
                                         int panelDisplayHeightDecimal,
                                         GlazingBead_ArticleNo panelGlazingBeadArtNo,
                                         GlassFilm_Types panelGlassFilm,
                                         SashProfile_ArticleNo panelSash,
                                         SashReinf_ArticleNo panelSashReinf,
                                         GlassType panelGlassType,
                                         Espagnolette_ArticleNo panelEspagnoletteArtNo,
                                         Striker_ArticleNo panelStrikerArtno,
                                         MiddleCloser_ArticleNo panelMiddleCloserArtno,
                                         LockingKit_ArticleNo panelLockingKitArtno,
                                         MotorizedMech_ArticleNo panelMotorizedMechArtNo,
                                         Handle_Type panelHandleType,
                                         Extension_ArticleNo paneltopExtArtNo,
                                         Extension_ArticleNo paneltop2ExtArtNo,
                                         Extension_ArticleNo panelbotExtArtNo,
                                         Extension_ArticleNo panelbot2ExtArtNo,
                                         Extension_ArticleNo panelleftExtArtNo,
                                         Extension_ArticleNo panelleft2ExtArtNo,
                                         Extension_ArticleNo panelrightExtArtNo,
                                         Extension_ArticleNo panelright2ExtArtNo,
                                         bool panelExtTopChk,
                                         bool panelExtBotChk,
                                         bool panelExtLeftChk,
                                         bool panelExtRightChk,
                                         int panelExtTopQty,
                                         int panelExtBotQty,
                                         int panelExtLeftQty,
                                         int panelExtRightQty,
                                         int panelExtTop2Qty,
                                         int panelExtBot2Qty,
                                         int panelExtLeft2Qty,
                                         int panelExtRight2Qty,
                                         Rotoswing_HandleArtNo panelRotoswingArtNo,
                                         GeorgianBar_ArticleNo panelGeorgianBarArtNo,
                                         OverlapSash panelOverlapSash,
                                         int panelGeorgianBarVerticalQty,
                                         int panelGeorgianBarHorizontalQty,
                                         bool panelGeorgianBarOptionVisibility,
                                         int panelID,
                                         int panelGlassID = 0,
                                         float panelImageRendererZoom = 1,
                                         int panelIndexInsideMPanel = 0,
                                         DockStyle panelDock = DockStyle.Fill,
                                         string panelName = "",
                                         bool panelOrient = false,
                                         HingeOption panelHingeOptions = null,
                                         bool panelSlidingTypeVisibility = false,
                                         SlidingTypes panelSlidingTypes = null, 
                                         string glasstype_insu_lumi = null,
                                         decimal glasspricepersqrmeter = 0
                                         )
        {
            if (panelName == "")
            {
                if(panelID == 0)
                {
                    panelID = 1; 
                }
                panelName = panelType.Replace(" Panel", "") + "PanelUC_" + panelID;
            }
            
            if (panelHingeOptions == null)
            {
                panelHingeOptions = HingeOption._FrictionStay;
            }

            if (panelSlidingTypes == null)
            {
                panelSlidingTypes = SlidingTypes._Premiline;
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
                                                       panelDisplayWidthDecimal,
                                                       panelDisplayHeight,
                                                       panelDisplayHeightDecimal,
                                                       panelGlassID,
                                                       panelGlassFilm,
                                                       panelSash,
                                                       panelSashReinf,
                                                       panelGlassType,
                                                       panelEspagnoletteArtNo,
                                                       panelStrikerArtno,
                                                       panelMiddleCloserArtno,
                                                       panelLockingKitArtno,
                                                       panelMotorizedMechArtNo,
                                                       panelHandleType,
                                                       paneltopExtArtNo,
                                                       paneltop2ExtArtNo,
                                                       panelbotExtArtNo,
                                                       panelbot2ExtArtNo,
                                                       panelleftExtArtNo,
                                                       panelleft2ExtArtNo,
                                                       panelrightExtArtNo,
                                                       panelright2ExtArtNo,
                                                       panelExtTopChk,
                                                       panelExtBotChk,
                                                       panelExtLeftChk,
                                                       panelExtRightChk,
                                                       panelExtTopQty,
                                                       panelExtBotQty,
                                                       panelExtLeftQty,
                                                       panelExtRightQty,
                                                       panelExtTop2Qty,
                                                       panelExtBot2Qty,
                                                       panelExtLeft2Qty,
                                                       panelExtRight2Qty,
                                                       panelRotoswingArtNo,
                                                       panelGeorgianBarArtNo,
                                                       panelOverlapSash,
                                                       panelGeorgianBarVerticalQty,
                                                       panelGeorgianBarHorizontalQty,
                                                       panelGeorgianBarOptionVisibility,
                                                       panelHingeOptions,
                                                       panelSlidingTypeVisibility,
                                                       panelSlidingTypes, 
                                                       glasstype_insu_lumi,
                                                       glasspricepersqrmeter);

            return _panelModel;
        }

    }
}
