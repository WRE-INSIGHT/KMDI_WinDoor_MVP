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
                                  int panelGeorgianBarVerticalQty,
                                  int panelGeorgianBarHorizontalQty,
                                  bool panelGeorgianBarOptionVisibility,
                                  int panelID = 0,
                                  int panelGlassID = 0,
                                  float panelImageRendererZoom = 1,
                                  int panelIndexInsideMPanel = 0,
                                  DockStyle panelDock = DockStyle.Fill,
                                  string panelName = "",
                                  bool panelOrient = false);
    }
}