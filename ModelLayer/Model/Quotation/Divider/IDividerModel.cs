﻿using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ModelLayer.Model.Quotation.Divider
{
    public interface IDividerModel
    {
        int Div_Height { get; set; }
        int DivImageRenderer_Height { get; set; }
        int Div_ID { get; set; }
        string Div_Name { get; set; }
        Control Div_Parent { get; set; }
        DividerModel.DividerType Div_Type { get; set; }
        bool Div_Visible { get; set; }
        int Div_Width { get; set; }
        int DivImageRenderer_Width { get; set; }
        string Div_FrameType { get; set; }
        float DivImageRenderer_Zoom { get; set; }
        float Div_Zoom { get; set; }
        int Div_WidthToBind { get; set; }
        int Div_HeightToBind { get; set; }
        int Div_DisplayWidth { get; set; }
        int Div_DisplayHeight { get; set; }
        int Div_PropHeight { get; set; }
        int Div_CladdingBracketForUPVCQTY { get; set; }
        int Div_CladdingBracketForConcreteQTY { get; set; }
        bool Div_claddingBracketVisibility { get; set; }
        bool Div_CladdingProfileArtNoVisibility { get; set; }

        DummyMullion_ArticleNo Div_DMArtNo { get; set; }
        int Div_AlumSpacer50Qty { get; set; }
        EndcapDM_ArticleNo Div_EndcapDM { get; set; }
        FixedCam_ArticleNo Div_FixedCamDM { get; set; }
        SnapInKeep_ArticleNo Div_SnapNKeepDM { get; set; }
        bool Div_ChkDM { get; set; }
        bool Div_ChkDMVisibility { get; set; }
        bool Div_ArtVisibility { get; set; }
        IMultiPanelModel Div_MPanelParent { get; set; }
        IFrameModel Div_FrameParent { get; set; }
        IPanelModel Div_DMPanel { get; set; }
        bool Div_LeverEspagVisibility { get; set; }
        LeverEspagnolette_ArticleNo Div_LeverEspagArtNo { get; set; }
        ShootboltStriker_ArticleNo Div_ShootboltStrikerArtNo { get; set; }
        ShootboltNonReverse_ArticleNo Div_ShootboltNonReverseArtNo { get; set; }
        ShootboltReverse_ArticleNo Div_ShootboltReverseArtNo { get; set; }
        DummyMullionStriker_ArticleNo Div_DMStrikerArtNo { get; set; }

        void SetDimensionsToBind_using_DivZoom();
        void SetDimensionsToBind_using_DivZoom_Imager();
        void SetDimensionsToBind_using_DivZoom_Imager_Initial();

        #region Explosion

        Divider_ArticleNo Div_ArtNo { get; set; }
        DividerReinf_ArticleNo Div_ReinfArtNo { get; set; }
        Divider_MechJointArticleNo Div_MechJoinArtNo { get; set; }

        int Div_ExplosionWidth { get; set; }
        int Div_ExplosionHeight { get; set; }
        int Div_ReinfWidth { get; set; }
        int Div_ReinfHeight { get; set; }
        string Div_Bounded { get; set; }


        CladdingProfile_ArticleNo Div_CladdingProfileArtNo { get; set; }
        CladdingReinf_ArticleNo Div_CladdingReinfArtNo { get; set; }
        Dictionary<int, int> Div_CladdingSizeList { get; set; }
        int Div_CladdingCount { get; set; }

        void SetExplosionValues_Div();
        void AdjustPropertyPanelHeight(string mode);

        void Insert_DivProfile_DivReinf_Info_MaterialList(DataTable tbl_explosion);
        void Insert_MechJoint_MaterialList(DataTable tbl_explosion);
        void Insert_CladdingProfile_MaterialList(DataTable tbl_explosion);
        void Insert_CladdingBracket4Concrete_MaterialList(DataTable tbl_explosion);
        void Insert_CladdingBracket4UPVC_MaterialList(DataTable tbl_explosion);
        void Insert_DummyMullion_MaterialList(DataTable tbl_explosion);
        void Insert_Endcap4DM_MaterialList(DataTable tbl_explosion);
        void Insert_DMStriker_MaterialList(DataTable tbl_explosion);
        void Insert_FixedCam_MaterialList(DataTable tbl_explosion);
        void Insert_SnapNKeep_MaterialList(DataTable tbl_explosion);
        void Insert_AlumSpacer_MaterialList(DataTable tbl_explosion);
        void Insert_LeverEspag_MaterialList(DataTable tbl_explosion);
        void Insert_ShootboltStriker_MaterialList(DataTable tbl_explosion);
        void Insert_ShootboltReverse_MaterialList(DataTable tbl_explosion);
        void Insert_ShootboltNonReverse_MaterialList(DataTable tbl_explosion);


        int Add_ExplosionLength_screws4fab();
        int Add_MechJoint_screws4fab();
        int Add_TotalCladdingSize_Screws4Cladding();
        int Add_CladdingBracket4Concrete_screws4fab();
        int Add_CladdingBracket4UPVC_screws4fab();
        int Add_DMStriker_screws4fab();
        int Add_EndCapDM_screws4fab();
        int Add_SnapNKeep_screws4fab();
        int Add_AlumSpacer_screws4fab();
        int Add_LeverEspag_screws4fab();



        int Add_CladdBracket4Concrete_expbolts();
        int Add_CladdBracket4UPVC_expbolts();

        #endregion
    }
}