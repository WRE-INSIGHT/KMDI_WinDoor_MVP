using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;

namespace ModelLayer.Model.Quotation.MultiPanel
{
    public class MultiPanelModel : IMultiPanelModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ConstantVariables constants = new ConstantVariables();

        private int _mpanelID;
        public int MPanel_ID
        {
            get
            {
                return _mpanelID;
            }
            set
            {
                _mpanelID = value;
            }
        }

        private string _mpanelName;
        public string MPanel_Name
        {
            get
            {
                return _mpanelName;
            }
            set
            {
                _mpanelName = value;
                NotifyPropertyChanged();
            }
        }

        private DockStyle _mpanelDock;
        public DockStyle MPanel_Dock
        {
            get
            {
                return _mpanelDock;
            }
            set
            {
                _mpanelDock = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that represents the definite given value and used by the program only. (not intended for user to use)")]
        private int _mpanelWidth;
        public int MPanel_Width //Original Width of the control
        {
            get
            {
                return _mpanelWidth;
            }
            set
            {
                _mpanelWidth = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that is dependent on MPanel_Width and MPanel_Zoom and varies accordingly. (not intended for user to use)")]
        private int _mpanelWidthToBind;
        public int MPanel_WidthToBind
        {
            get
            {
                return _mpanelWidthToBind;
            }
            set
            {
                _mpanelWidthToBind = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelWidthToBind_prev;
        public int MPanel_WidthToBindPrev
        {
            get
            {
                return _mpanelWidthToBind_prev;
            }
            set
            {
                _mpanelWidthToBind_prev = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelWidthToBind_prev_imager;
        public int MPanelImager_WidthToBindPrev
        {
            get
            {
                return _mpanelWidthToBind_prev_imager;
            }
            set
            {
                _mpanelWidthToBind_prev_imager = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that is used for user's output")]
        private int _mpanelDisplayWidth;
        public int MPanel_DisplayWidth
        {
            get
            {
                return _mpanelDisplayWidth;
            }
            set
            {
                _mpanelDisplayWidth = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelDisplayWidthDecimal;
        public int MPanel_DisplayWidthDecimal
        {
            get
            {
                return _mpanelDisplayWidthDecimal;
            }
            set
            {
                _mpanelDisplayWidthDecimal = value;
            }
        }

        [Description("Virtual Height that represents the definite given value and used by the program only. (not intended for user to use)")]
        private int _mpanelHeight;
        public int MPanel_Height //Original Height of the control
        {
            get
            {
                return _mpanelHeight;
            }
            set
            {
                _mpanelHeight = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Height that is dependent on MPanel_Height and MPanel_Zoom and varies accordingly. (not intended for user to use)")]
        private int _mpanelHeightToBind;
        public int MPanel_HeightToBind
        {
            get
            {
                return _mpanelHeightToBind;
            }
            set
            {
                _mpanelHeightToBind = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelHeightToBind_prev;
        public int MPanel_HeightToBindPrev
        {
            get
            {
                return _mpanelHeightToBind_prev;
            }
            set
            {
                _mpanelHeightToBind_prev = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelHeightToBind_prev_imager;
        public int MPanelImager_HeightToBindPrev
        {
            get
            {
                return _mpanelHeightToBind_prev_imager;
            }
            set
            {
                _mpanelHeightToBind_prev_imager = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Height that is used for user's output")]
        private int _mpanelDisplayHeight;
        public int MPanel_DisplayHeight
        {
            get
            {
                return _mpanelDisplayHeight;
            }
            set
            {
                _mpanelDisplayHeight = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelDisplayHeightDecimal;
        public int MPanel_DisplayHeightDecimal
        {
            get
            {
                return _mpanelDisplayHeightDecimal;
            }
            set
            {
                _mpanelDisplayHeightDecimal = value;
            }
        }

        private string _mpanelType;
        public string MPanel_Type
        {
            get
            {
                return _mpanelType;
            }
            set
            {
                _mpanelType = value;
                NotifyPropertyChanged();
            }
        }

        private FlowDirection _mpanelFlowDirection;
        public FlowDirection MPanel_FlowDirection
        {
            get
            {
                return _mpanelFlowDirection;
            }

            set
            {
                _mpanelFlowDirection = value;
                if (value == FlowDirection.LeftToRight)
                {
                    MPanel_Type = "Mullion";
                }
                else if (value == FlowDirection.TopDown)
                {
                    MPanel_Type = "Transom";
                }
                NotifyPropertyChanged();
            }
        }

        private bool _mpanelVisible;
        public bool MPanel_Visibility
        {
            get
            {
                return _mpanelVisible;
            }

            set
            {
                _mpanelVisible = value;
                //NotifyPropertyChanged();
            }
        }

        private float _mpanelImage_Zoom;
        public float MPanelImageRenderer_Zoom
        {
            get
            {
                return _mpanelImage_Zoom;
            }

            set
            {
                _mpanelImage_Zoom = value;
                //MPanelImageRenderer_Width = Convert.ToInt32(MPanel_Width * value);
                //MPanelImageRenderer_Height = Convert.ToInt32(MPanel_Height * value);

                //Padding pads = new Padding(Convert.ToInt32(MPanel_Margin.All * value));
                //MPanelImageRenderer_Margin = pads;
                SetImageZoomDivider();
                NotifyPropertyChanged();
            }
        }

        private int _mpanelImage_Height;
        public int MPanelImageRenderer_Height
        {
            get
            {
                return _mpanelImage_Height;
            }

            set
            {
                _mpanelImage_Height = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelImage_Width;
        public int MPanelImageRenderer_Width
        {
            get
            {
                return _mpanelImage_Width;
            }

            set
            {
                _mpanelImage_Width = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelDiv;
        public int MPanel_Divisions
        {
            get
            {
                return _mpanelDiv;
            }

            set
            {
                _mpanelDiv = value;
            }
        }

        private Control _mpanelParent;
        public Control MPanel_Parent
        {
            get
            {
                return _mpanelParent;
            }
            set
            {
                if (value.Name.Contains("Frame"))
                {
                    _mpanelNumEnable = false;
                }
                else
                {
                    _mpanelNumEnable = true;
                }
                _mpanelParent = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _mpanelFrameGroup;
        public UserControl MPanel_FrameGroup
        {
            get
            {
                return _mpanelFrameGroup;
            }
            set
            {
                _mpanelFrameGroup = value;
            }
        }

        public IFrameModel MPanel_FrameModelParent { get; set; }

        private Padding _mpanelMargin;
        public Padding MPanel_Margin
        {
            get
            {
                return _mpanelMargin;
            }

            set
            {
                _mpanelMargin = value;
                NotifyPropertyChanged();
            }
        }

        private Padding _mpanelImageMargin;
        public Padding MPanelImageRenderer_Margin
        {
            get
            {
                return _mpanelImageMargin;
            }

            set
            {
                _mpanelImageMargin = value;
                NotifyPropertyChanged();
            }
        }

        private int _mpanelIndexInsideMpanel;
        public int MPanel_Index_Inside_MPanel
        {
            get
            {
                return _mpanelIndexInsideMpanel;
            }

            set
            {
                _mpanelIndexInsideMpanel = value;
                NotifyPropertyChanged();
            }
        }

        public List<IPanelModel> MPanelLst_Panel { get; set; }
        public List<IDividerModel> MPanelLst_Divider { get; set; }
        public List<IMultiPanelModel> MPanelLst_MultiPanel { get; set; }

        private List<Control> _mpanelLstObjects;
        public List<Control> MPanelLst_Objects
        {
            get
            {
                return _mpanelLstObjects;
            }
            set
            {
                _mpanelLstObjects = value;
                NotifyPropertyChanged();
            }
        }

        public List<Control> MPanelLst_Imagers { get; set; }

        private int _mpanelPropHeight;
        public int MPanelProp_Height
        {
            get
            {
                return _mpanelPropHeight;
            }

            set
            {
                int total = value - _mpanelPropHeight;
                if (MPanel_ParentModel != null)
                {
                    MPanel_ParentModel.MPanelProp_Height += total;
                }
                _mpanelPropHeight = value;
                NotifyPropertyChanged();
            }
        }

        private bool _mpanelNumEnable;
        public bool MPanel_NumEnable
        {
            get
            {
                return _mpanelNumEnable;
            }

            set
            {
                _mpanelNumEnable = value;
                NotifyPropertyChanged();
            }
        }

        private string _mpanelPlacement;
        public string MPanel_Placement
        {
            get
            {
                return _mpanelPlacement;
            }

            set
            {
                _mpanelPlacement = value;
            }
        }

        public IMultiPanelModel MPanel_ParentModel { get; set; }

        private bool _mpanelDividerEnabled;
        public bool MPanel_DividerEnabled
        {
            get
            {
                return _mpanelDividerEnabled;
            }

            set
            {
                _mpanelDividerEnabled = value;
            }
        }

        private float _mpanelZoom;
        public float MPanel_Zoom
        {
            get
            {
                return _mpanelZoom;
            }

            set
            {
                _mpanelZoom = value;
            }
        }

        private int mpanelStackNo;
        public int MPanel_StackNo
        {
            get
            {
                return mpanelStackNo;
            }

            set
            {
                mpanelStackNo = value;
            }
        }

        private int _mpnl_add;
        public int MPanel_AddPixel
        {
            get
            {
                return _mpnl_add;
            }
        }


        #region Methods

        public void Fit_My2ndLvlControls_Dimensions()

        {
            if (MPanelLst_MultiPanel.Count > 0)
            {
                foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                {
                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                    {
                        pnl.SetDimensionToBind_2ndlvl_using_BaseDimension();
                    }
                }
            }
            else
            {
                foreach (IPanelModel pnl in MPanelLst_Panel)
                {
                    pnl.SetDimensionToBind_2ndlvl_using_BaseDimension();
                }
            }

        }

        public void SetDimensions_PanelObjs_of_3rdLevelMPanel(int divmovement, string prevOrNxt)
        {
            if (MPanel_ParentModel != null)
            {
                if (MPanel_Type == "Mullion")
                {
                    if (MPanel_ParentModel.MPanel_Placement == "First")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "Last")
                            {
                                pnl.Panel_Width += divmovement;
                                pnl.Panel_DisplayWidth += divmovement;
                                pnl.Panel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;
                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.Panel_WidthToBind += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlwdToBind = MPanel_WidthToBind - MPanel_WidthToBindPrev;
                                    pnl.Panel_WidthToBind += pnlwdToBind;
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (prevOrNxt == "nxt")
                            {
                                if (pnl.Panel_Placement == "First")
                                {
                                    pnl.Panel_Width += divmovement;
                                    pnl.Panel_DisplayWidth += divmovement;
                                    pnl.Panel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.Panel_WidthToBind += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlwdToBind = MPanel_WidthToBind - MPanel_WidthToBindPrev;
                                        pnl.Panel_WidthToBind += pnlwdToBind;
                                    }
                                }
                            }
                            else if (prevOrNxt == "prev")
                            {
                                if (pnl.Panel_Placement == "Last")
                                {
                                    pnl.Panel_Width += divmovement;
                                    pnl.Panel_DisplayWidth += divmovement;
                                    pnl.Panel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.Panel_WidthToBind += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlwdToBind = MPanel_WidthToBind - MPanel_WidthToBindPrev;
                                        pnl.Panel_WidthToBind += pnlwdToBind;
                                    }
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Last")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "First")
                            {
                                pnl.Panel_Width += divmovement;
                                pnl.Panel_DisplayWidth += divmovement;
                                pnl.Panel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;
                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.Panel_WidthToBind += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlwdToBind = MPanel_WidthToBind - MPanel_WidthToBindPrev;
                                    pnl.Panel_WidthToBind += pnlwdToBind;
                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_ParentModel.MPanel_Placement == "First")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "Last")
                            {
                                pnl.Panel_Height += divmovement;
                                pnl.Panel_DisplayHeight += divmovement;
                                pnl.Panel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.Panel_HeightToBind += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlhtToBind = MPanel_HeightToBind - MPanel_HeightToBindPrev;
                                    pnl.Panel_HeightToBind += pnlhtToBind;
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (prevOrNxt == "nxt")
                            {
                                if (pnl.Panel_Placement == "First")
                                {
                                    pnl.Panel_Height += divmovement;
                                    pnl.Panel_DisplayHeight += divmovement;
                                    pnl.Panel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.Panel_HeightToBind += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlhtToBind = MPanel_HeightToBind - MPanel_HeightToBindPrev;
                                        pnl.Panel_HeightToBind += pnlhtToBind;
                                    }
                                }
                            }
                            else if (prevOrNxt == "prev")
                            {
                                if (pnl.Panel_Placement == "Last")
                                {
                                    pnl.Panel_Height += divmovement;
                                    pnl.Panel_DisplayHeight += divmovement;
                                    pnl.Panel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.Panel_HeightToBind += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlhtToBind = MPanel_HeightToBind - MPanel_HeightToBindPrev;
                                        pnl.Panel_HeightToBind += pnlhtToBind;
                                    }
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Last")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "First")
                            {
                                pnl.Panel_Height += divmovement;
                                pnl.Panel_DisplayHeight += divmovement;
                                pnl.Panel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.Panel_HeightToBind += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlhtToBind = MPanel_HeightToBind - MPanel_HeightToBindPrev;
                                    pnl.Panel_HeightToBind += pnlhtToBind;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(int divmovement, string prevOrNxt)
        {
            if (MPanel_ParentModel != null)
            {
                if (MPanel_Type == "Mullion")
                {
                    if (MPanel_ParentModel.MPanel_Placement == "First")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "Last")
                            {
                                if (MPanelImageRenderer_Zoom == 1.0f)
                                {
                                    pnl.PanelImageRenderer_Width += divmovement;
                                }
                                else if (MPanelImageRenderer_Zoom <= 0.50f)
                                {
                                    int pnlwdToBind = MPanelImageRenderer_Width - MPanelImager_WidthToBindPrev;
                                    pnl.PanelImageRenderer_Width += pnlwdToBind;
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (prevOrNxt == "nxt")
                            {
                                if (pnl.Panel_Placement == "First")
                                {
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.PanelImageRenderer_Width += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlwdToBind = MPanelImageRenderer_Width - MPanelImager_WidthToBindPrev;
                                        pnl.PanelImageRenderer_Width += pnlwdToBind;
                                    }
                                }
                            }
                            else if (prevOrNxt == "prev")
                            {
                                if (pnl.Panel_Placement == "Last")
                                {
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.PanelImageRenderer_Width += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlwdToBind = MPanelImageRenderer_Width - MPanelImager_WidthToBindPrev;
                                        pnl.PanelImageRenderer_Width += pnlwdToBind;
                                    }
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Last")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "First")
                            {
                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.PanelImageRenderer_Width += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlwdToBind = MPanelImageRenderer_Width - MPanelImager_WidthToBindPrev;
                                    pnl.PanelImageRenderer_Width += pnlwdToBind;
                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_ParentModel.MPanel_Placement == "First")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "Last")
                            {
                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.PanelImageRenderer_Height += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlhtToBind = MPanelImageRenderer_Height - MPanelImager_HeightToBindPrev;
                                    pnl.PanelImageRenderer_Height += pnlhtToBind;
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Somewhere in Between")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (prevOrNxt == "nxt")
                            {
                                if (pnl.Panel_Placement == "First")
                                {
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.PanelImageRenderer_Height += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlhtToBind = MPanelImageRenderer_Height - MPanelImager_HeightToBindPrev;
                                        pnl.PanelImageRenderer_Height += pnlhtToBind;
                                    }
                                }
                            }
                            else if (prevOrNxt == "prev")
                            {
                                if (pnl.Panel_Placement == "Last")
                                {
                                    if (MPanel_Zoom == 1.0f)
                                    {
                                        pnl.PanelImageRenderer_Height += divmovement;
                                    }
                                    else if (MPanel_Zoom <= 0.50f)
                                    {
                                        int pnlhtToBind = MPanelImageRenderer_Height - MPanelImager_HeightToBindPrev;
                                        pnl.PanelImageRenderer_Height += pnlhtToBind;
                                    }
                                }
                            }
                        }
                    }
                    else if (MPanel_ParentModel.MPanel_Placement == "Last")
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (pnl.Panel_Placement == "First")
                            {
                                if (MPanel_Zoom == 1.0f)
                                {
                                    pnl.PanelImageRenderer_Height += divmovement;
                                }
                                else if (MPanel_Zoom <= 0.50f)
                                {
                                    int pnlhtToBind = MPanelImageRenderer_Height - MPanelImager_HeightToBindPrev;
                                    pnl.PanelImageRenderer_Height += pnlhtToBind;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void SetDimensions_childPanelObjs(int divmovement)
        {
            if (MPanel_ParentModel != null)
            {
                int mpnlWd_deduct = 0,
                    mpnlHt_deduct = 0;

                if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    mpnlWd_deduct = 10;
                    mpnlHt_deduct = 10;
                }

                if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7507)
                    {
                        mpnlWd_deduct = 16;
                        mpnlHt_deduct = 20;

                        if (MPanel_Placement == "Somewhere in Between")
                        {
                            mpnlWd_deduct = 10;
                            mpnlHt_deduct = 10;
                        }
                        else if (MPanel_Placement == "First" || MPanel_Placement == "Last")
                        {
                            mpnlHt_deduct = 16;
                        }
                    }
                    else if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7502)
                    {
                        mpnlWd_deduct = 15;
                        mpnlHt_deduct = 15;

                        if (MPanel_Placement == "Somewhere in Between")
                        {
                            mpnlWd_deduct = 10;
                            mpnlHt_deduct = 10;
                        }
                        else if (MPanel_Placement == "First" || MPanel_Placement == "Last")
                        {
                            mpnlHt_deduct = 16;
                        }
                    }
                    else if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                             MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                    {
                        mpnlWd_deduct = 15;
                        mpnlHt_deduct = 10;

                        if (MPanel_Placement == "Last")
                        {
                            mpnlHt_deduct = 5;
                        }
                        else if (MPanel_Placement == "First")
                        {
                            mpnlHt_deduct = 15;
                        }
                        else if (MPanel_Placement == "Somewhere in Between")
                        {
                            mpnlWd_deduct = 9;
                        }
                    }
                }

                if (MPanel_Type == "Mullion")
                {
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_Height += divmovement;
                        pnl.Panel_DisplayHeight += divmovement;
                        pnl.Panel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                        if (MPanel_Zoom == 1.0f)
                        {
                            pnl.Panel_HeightToBind += divmovement;
                        }
                        else if (MPanel_Zoom == 0.50f)
                        {
                            int pnlhtToBind = MPanel_HeightToBind - 8;
                            pnl.Panel_HeightToBind = pnlhtToBind;
                        }
                        else if (MPanel_Zoom <= 0.26f)
                        {
                            int pnlhtToBind = MPanel_HeightToBind - mpnlHt_deduct;
                            pnl.Panel_HeightToBind = pnlhtToBind;
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_Width += divmovement;
                        pnl.Panel_DisplayWidth += divmovement;
                        pnl.Panel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;

                        if (MPanel_Zoom == 1.0f)
                        {
                            pnl.Panel_WidthToBind += divmovement;
                        }
                        else if (MPanel_Zoom == 0.50f)
                        {
                            int pnlwdToBind = MPanel_WidthToBind - 10;
                            pnl.Panel_WidthToBind = pnlwdToBind;
                        }
                        else if (MPanel_Zoom <= 0.26f)
                        {
                            int pnlwdToBind = MPanel_WidthToBind - mpnlWd_deduct;
                            pnl.Panel_WidthToBind = pnlwdToBind;
                        }
                    }
                }
            }
        }

        public void ImagerSetDimensions_childPanelObjs(int divmovement)
        {
            if (MPanel_ParentModel != null)
            {
                if (MPanel_Type == "Mullion")
                {
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (MPanelImageRenderer_Zoom == 1.0f)
                        {
                            pnl.PanelImageRenderer_Height += divmovement;
                        }
                        else if (MPanelImageRenderer_Zoom == 0.50f)
                        {
                            int pnlhtToBind = MPanelImageRenderer_Height;
                            pnl.PanelImageRenderer_Height = pnlhtToBind;
                        }
                        else if (MPanelImageRenderer_Zoom <= 0.26f)
                        {
                            int pnlhtToBind = MPanelImageRenderer_Height;
                            pnl.PanelImageRenderer_Height = pnlhtToBind;
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (MPanelImageRenderer_Zoom == 1.0f)
                        {
                            pnl.PanelImageRenderer_Width += divmovement;
                        }
                        else if (MPanelImageRenderer_Zoom == 0.50f)
                        {
                            int pnlwdToBind = MPanelImageRenderer_Width;
                            pnl.PanelImageRenderer_Width = pnlwdToBind;
                        }
                        else if (MPanelImageRenderer_Zoom <= 0.26f)
                        {
                            int pnlwdToBind = MPanelImageRenderer_Width;
                            pnl.PanelImageRenderer_Width = pnlwdToBind;
                        }
                    }
                }
            }
        }
        public void SetDimensions_childObjs(int divmovement = 0, string prevOrNxt = "")
        {
            if (MPanel_ParentModel != null)
            {
                if (MPanel_Type == "Mullion")
                {
                    foreach (IMultiPanelModel mpanels in MPanelLst_MultiPanel)
                    {
                        mpanels.MPanel_Height = MPanel_Height;
                        mpanels.MPanel_DisplayHeight = MPanel_DisplayHeight;
                        mpanels.MPanel_DisplayHeightDecimal = MPanel_DisplayHeightDecimal;

                        mpanels.MPanel_HeightToBindPrev = mpanels.MPanel_HeightToBind;
                        mpanels.MPanel_HeightToBind = MPanel_HeightToBind;

                        mpanels.MPanelImager_HeightToBindPrev = mpanels.MPanelImageRenderer_Height;
                        mpanels.MPanelImageRenderer_Height = MPanelImageRenderer_Height;

                        mpanels.SetDimensions_PanelObjs_of_3rdLevelMPanel(divmovement, prevOrNxt);
                        mpanels.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(divmovement, prevOrNxt);
                    }

                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_Height = MPanel_Height;
                        div.Div_DisplayHeight = MPanel_DisplayHeight;
                        div.Div_HeightToBind = MPanel_HeightToBind;
                        div.SetDimensionsToBind_using_DivZoom_Imager();
                        //div.DivImageRenderer_Height = MPanelImageRenderer_Height;
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    foreach (IMultiPanelModel mpanels in MPanelLst_MultiPanel)
                    {
                        mpanels.MPanel_Width = MPanel_Width;
                        mpanels.MPanel_DisplayWidth = MPanel_DisplayWidth;
                        mpanels.MPanel_DisplayWidthDecimal = MPanel_DisplayWidthDecimal;

                        mpanels.MPanel_WidthToBindPrev = mpanels.MPanel_WidthToBind;
                        mpanels.MPanel_WidthToBind = MPanel_WidthToBind;

                        mpanels.MPanelImager_WidthToBindPrev = mpanels.MPanelImageRenderer_Width;
                        mpanels.MPanelImageRenderer_Width = MPanelImageRenderer_Width;

                        mpanels.SetDimensions_PanelObjs_of_3rdLevelMPanel(divmovement, prevOrNxt);
                        mpanels.Imager_SetDimensions_PanelObjs_of_3rdLevelMPanel(divmovement, prevOrNxt);
                    }

                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_Width = MPanel_Width;
                        div.Div_DisplayWidth = MPanel_DisplayWidth;
                        div.Div_WidthToBind = MPanel_WidthToBind;
                        div.SetDimensionsToBind_using_DivZoom_Imager();
                        //div.DivImageRenderer_Width = MPanelImageRenderer_Width + 6;
                    }
                }
            }
        }

        public void SetDimensionsToBind_MullionDivMovement()
        {
            int parent_wdToBind = MPanel_ParentModel.MPanel_WidthToBind,
                parent_htToBind = MPanel_ParentModel.MPanel_HeightToBind,
                wd = 0, ht = 0;

            if (MPanel_Zoom == 0.50f)
            {
                wd = parent_wdToBind;
                ht = MPanel_HeightToBind;
            }
            else if (MPanel_Zoom == 1.0f)
            {
                wd = MPanel_Width;
                ht = MPanel_Height;
            }

            MPanel_WidthToBindPrev = _mpanelWidthToBind;
            MPanel_WidthToBind = wd;
            MPanel_HeightToBind = ht;
        }

        public void Imager_SetDimensionsToBind_MullionDivMovement(int divMovement)
        {
            int wd = 0, ht = 0;

            if (MPanelImageRenderer_Zoom == 0.50f)
            {
                decimal wd_flt_convert_dec = Convert.ToDecimal((MPanel_Width - 20) * MPanelImageRenderer_Zoom);
                decimal wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                wd = Convert.ToInt32(wd_dec);

                ht = MPanelImageRenderer_Height;
            }
            else if (MPanelImageRenderer_Zoom == 1.0f)
            {
                wd = MPanelImageRenderer_Width + divMovement;
                ht = MPanelImageRenderer_Height;
            }

            MPanelImager_WidthToBindPrev = _mpanelImage_Width;
            MPanelImageRenderer_Width = wd;
            MPanelImageRenderer_Height = ht;
        }

        public void SetDimensionsToBind_TransomDivMovement()
        {
            int parent_wdToBind = MPanel_ParentModel.MPanel_WidthToBind,
                parent_htToBind = MPanel_ParentModel.MPanel_HeightToBind,
                wd = 0, ht = 0;

            if (MPanel_Zoom == 0.50f)
            {
                wd = MPanel_WidthToBind;
                ht = parent_htToBind;
            }
            else if (MPanel_Zoom == 1.0f)
            {
                wd = MPanel_Width;
                ht = MPanel_Height;
            }

            MPanel_HeightToBindPrev = _mpanelHeightToBind;

            MPanel_WidthToBind = wd;
            MPanel_HeightToBind = ht;
        }

        public void Imager_SetDimensionsToBind_TransomDivMovement(int divMovement)
        {
            int parent_wdToBind = MPanel_ParentModel.MPanelImageRenderer_Width,
                parent_htToBind = MPanel_ParentModel.MPanelImageRenderer_Height,
                wd = 0, ht = 0;

            if (MPanelImageRenderer_Zoom == 0.50f)
            {
                wd = MPanelImageRenderer_Width;

                decimal ht_flt_convert_dec = Convert.ToDecimal((MPanel_Height - 20) * MPanel_Zoom);
                decimal ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                ht = Convert.ToInt32(ht_dec);
            }
            else if (MPanelImageRenderer_Zoom == 1.0f)
            {
                wd = MPanelImageRenderer_Width;
                ht = MPanelImageRenderer_Height + divMovement;
            }

            MPanelImager_HeightToBindPrev = _mpanelImage_Height;

            MPanelImageRenderer_Width = wd;
            MPanelImageRenderer_Height = ht;
        }

        public void SetDimensionsToBind_using_ParentMultiPanelModel()
        {
            int parent_wdToBind = MPanel_ParentModel.MPanel_WidthToBind,
                parent_htToBind = MPanel_ParentModel.MPanel_HeightToBind,
                totalpanel_inside_parentMpanel = MPanel_ParentModel.MPanel_Divisions + 1,
                div_count = MPanel_ParentModel.MPanel_Divisions,
                wd = 0, ht = 0, divSize = 0;
            if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                divSize = 13;
            }
            else if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                divSize = 16;
            }

            if (MPanel_Zoom == 0.26f || MPanel_Zoom == 0.17f ||
                MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    int mpanelSize = 0;
                    int totalPanelCount = MPanel_ParentModel.MPanel_Divisions + 1;
                    foreach (IMultiPanelModel mpnl in MPanel_ParentModel.MPanelLst_MultiPanel)
                    {
                        if (mpnl.MPanel_Name != MPanel_Name)
                            mpanelSize += mpnl.MPanel_WidthToBind;
                    }
                    if (MPanel_ParentModel.MPanel_DividerEnabled)
                    {
                        int div_movement = ((MPanel_ParentModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - MPanel_DisplayWidth);
                        decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanel_Zoom);
                        decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                        decimal divMove_dec_times2 = divMove_dec * 2;
                        int divMove_int = Convert.ToInt32(divMove_dec_times2);
                        wd = ((parent_wdToBind - (divSize * div_count) - divMove_int) / totalpanel_inside_parentMpanel);
                        if (MPanel_Placement == "Last")
                        {
                            int totalWd_panelModel = MPanel_ParentModel.MPanelLst_Panel.Sum(pnl => pnl.Panel_WidthToBind + pnl.Panel_MarginToBind.Right + pnl.Panel_MarginToBind.Left),
                                                   totalWd_divModel = MPanel_ParentModel.MPanelLst_Divider.Sum(div => div.Div_WidthToBind),
                                                   totalWd_MpanelModel = MPanel_ParentModel.MPanelLst_MultiPanel.Where(d => d != this).Sum(mpnl => mpnl.MPanel_WidthToBind);

                            int totalWidth_Controls = totalWd_panelModel + totalWd_divModel + totalWd_MpanelModel;

                            wd = MPanel_ParentModel.MPanel_WidthToBind - totalWidth_Controls - 2;
                        }
                        //if(mpanelSize != 0)
                        //{
                        //    mpanelSize -= 2;
                        //}
                        //wd = (parent_wdToBind - (divSize * div_count) - mpanelSize) / (totalpanel_inside_parentMpanel - (MPanel_ParentModel.MPanelLst_MultiPanel.Count - 1));

                    }
                    else
                    {
                        wd = Convert.ToInt32(((Math.Floor(MPanel_ParentModel.MPanel_Width * MPanel_ParentModel.MPanel_Zoom) - mpanelSize) / (totalPanelCount - (MPanel_ParentModel.MPanelLst_MultiPanel.Count - 1))));
                    }


                    //wd = (parent_wdToBind - (divSize * div_count)) / totalpanel_inside_parentMpanel; //13 px first, then the deduction will occur on Adapt_sizeToBind_MPanelDivMPanel_Controls() 
                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;
                    ht = (parent_htToBind - (divSize * div_count)) / totalpanel_inside_parentMpanel;
                }
            }
            else if (MPanel_Zoom == 0.50f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {

                    decimal wd_flt_convert_dec = Convert.ToDecimal(MPanel_Width * MPanel_Zoom);
                    decimal wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    //wd = Convert.ToInt32(wd_dec);
                    wd = (int)(MPanel_Width * MPanel_Zoom);
                    //int div_movement = ((MPanel_ParentModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - MPanel_DisplayWidth);
                    //decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanel_Zoom);
                    //decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                    //decimal divMove_dec_times2 = divMove_dec * 2;
                    //int divMove_int = Convert.ToInt32(divMove_dec_times2);
                    //wd = ((parent_wdToBind - (5 * div_count) - divMove_int) / totalpanel_inside_parentMpanel) - 4;

                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;

                    decimal ht_flt_convert_dec = Convert.ToDecimal(MPanel_Height * MPanel_Zoom);
                    decimal ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    ht = Convert.ToInt32(ht_dec);
                }
            }
            else if (MPanel_Zoom == 1.0f)
            {
                wd = MPanel_Width;

                ht = MPanel_Height;
            }

            MPanel_WidthToBindPrev = _mpanelWidthToBind;
            MPanel_WidthToBind = wd;
            MPanel_HeightToBind = ht;
        }

        public void Imager_SetDimensionsToBind_using_ParentMultiPanelModel()
        {
            int parent_wdToBind = MPanel_ParentModel.MPanelImageRenderer_Width,
                parent_htToBind = MPanel_ParentModel.MPanelImageRenderer_Height,
                totalpanel_inside_parentMpanel = MPanel_ParentModel.MPanel_Divisions + 1,
                div_count = MPanel_ParentModel.MPanel_Divisions,
                wd = 0, ht = 0;

            if (MPanelImageRenderer_Zoom == 0.26f || MPanelImageRenderer_Zoom == 0.17f ||
                MPanelImageRenderer_Zoom == 0.13f || MPanelImageRenderer_Zoom == 0.10f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    wd = (parent_wdToBind - (13 * div_count)) / totalpanel_inside_parentMpanel; //13 px first, then the deduction will occur on Adapt_sizeToBind_MPanelDivMPanel_Controls() 
                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;
                    ht = (parent_htToBind - (13 * div_count)) / totalpanel_inside_parentMpanel;
                }
            }
            else if (MPanelImageRenderer_Zoom == 0.50f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    decimal wd_flt_convert_dec = Convert.ToDecimal(MPanel_Width * MPanelImageRenderer_Zoom);
                    decimal wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    wd = Convert.ToInt32(wd_dec);

                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;

                    decimal ht_flt_convert_dec = Convert.ToDecimal(MPanel_Height * MPanelImageRenderer_Zoom);
                    decimal ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    ht = Convert.ToInt32(ht_dec);
                }
            }
            else if (MPanelImageRenderer_Zoom == 1.0f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    wd = MPanel_Width;
                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;
                    ht = MPanel_Height;
                }
            }

            MPanelImager_WidthToBindPrev = _mpanelImage_Width;
            MPanelImageRenderer_Width = wd;
            MPanelImageRenderer_Height = ht;
        }

        public void Imager_SetDimensionsToBind_using_ParentMultiPanelModel_Initial()
        {
            int parent_wdToBind = MPanel_ParentModel.MPanelImageRenderer_Width,
                parent_htToBind = MPanel_ParentModel.MPanelImageRenderer_Height,
                totalpanel_inside_parentMpanel = MPanel_ParentModel.MPanel_Divisions + 1,
                div_count = MPanel_ParentModel.MPanel_Divisions,
                divSize = (int)MPanel_FrameModelParent.Frame_Type,
                wd = 0, ht = 0;

            if (MPanelImageRenderer_Zoom == 1.0f || MPanelImageRenderer_Zoom == 0.50f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    wd = (((parent_wdToBind) - (Convert.ToInt32(divSize * MPanelImageRenderer_Zoom) * div_count)) / totalpanel_inside_parentMpanel);
                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;
                    ht = (((parent_htToBind) - (Convert.ToInt32(divSize * MPanelImageRenderer_Zoom) * div_count)) / totalpanel_inside_parentMpanel);
                }
            }
            else if (MPanelImageRenderer_Zoom <= 0.26f)
            {
                if (MPanel_ParentModel.MPanel_Type == "Mullion")
                {
                    wd = (((parent_wdToBind) - (13 * div_count)) / totalpanel_inside_parentMpanel);
                    ht = parent_htToBind;
                }
                else if (MPanel_ParentModel.MPanel_Type == "Transom")
                {
                    wd = parent_wdToBind;
                    ht = (((parent_htToBind) - (13 * div_count)) / totalpanel_inside_parentMpanel);
                }
            }

            MPanelImager_WidthToBindPrev = _mpanelImage_Width;
            MPanelImageRenderer_Width = wd;
            MPanelImageRenderer_Height = ht;
        }

        public void SetDimensionsToBind_usingZoom_below26_with_DividerMovement()
        {
            int pnl_wd = 0, pnl_ht = 0, divMove_int = 0, div_movement = 0;

            if (MPanel_ParentModel != null)
            {
                int parent_MpanelWidth = MPanel_ParentModel.MPanel_WidthToBind,
                    parent_MpanelHeight = MPanel_ParentModel.MPanel_HeightToBind,
                    div_count = MPanel_ParentModel.MPanel_Divisions,
                    totalpanel_inside_parentMpanel = MPanel_ParentModel.MPanel_Divisions + 1,
                    div_size = 13;
                if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    div_size = 16;
                }
                if (MPanel_ParentModel != null)
                {
                    if (MPanel_ParentModel.MPanel_Type == "Mullion")
                    {
                        div_movement = ((MPanel_ParentModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - MPanel_DisplayWidth);
                        decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanel_Zoom);
                        decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                        decimal divMove_dec_times2 = divMove_dec * 2;
                        divMove_int = Convert.ToInt32(divMove_dec_times2);
                        pnl_wd = ((parent_MpanelWidth - (div_size * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                        pnl_ht = parent_MpanelHeight;
                    }
                    else if (MPanel_ParentModel.MPanel_Type == "Transom")
                    {
                        div_movement = MPanel_OriginalDisplayHeight - MPanel_DisplayHeight;
                        div_movement = ((MPanel_ParentModel.MPanel_DisplayHeight / totalpanel_inside_parentMpanel) - MPanel_DisplayHeight);

                        decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanel_Zoom);
                        decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                        decimal divMove_dec_times2 = divMove_dec * 2;
                        divMove_int = Convert.ToInt32(divMove_dec_times2);

                        pnl_wd = parent_MpanelWidth;
                        pnl_ht = ((parent_MpanelHeight - (div_size * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                    }
                }
            }
            else if (MPanel_FrameModelParent != null)
            {
                pnl_wd = MPanel_Width;
                pnl_ht = MPanel_Height;
            }

            MPanel_WidthToBindPrev = _mpanelWidthToBind;
            MPanel_WidthToBind = pnl_wd;
            MPanel_HeightToBind = pnl_ht;
        }

        public void Imager_SetDimensionsToBind_usingZoom_below26_with_DividerMovement()
        {
            int pnl_wd = 0, pnl_ht = 0, divMove_int = 0, div_movement = 0;

            if (MPanel_ParentModel != null)
            {
                int parent_MpanelWidth = MPanel_ParentModel.MPanelImageRenderer_Width,
                    parent_MpanelHeight = MPanel_ParentModel.MPanelImageRenderer_Height,
                    div_count = MPanel_ParentModel.MPanel_Divisions,
                    totalpanel_inside_parentMpanel = MPanel_ParentModel.MPanel_Divisions + 1;

                if (MPanel_ParentModel != null)
                {
                    if (MPanel_ParentModel.MPanel_Type == "Mullion")
                    {
                        div_movement = ((MPanel_ParentModel.MPanel_DisplayWidth / totalpanel_inside_parentMpanel) - MPanel_DisplayWidth);

                        decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanelImageRenderer_Zoom);
                        decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                        decimal divMove_dec_times2 = divMove_dec * 2;
                        divMove_int = Convert.ToInt32(divMove_dec_times2);

                        pnl_wd = (((parent_MpanelWidth + 10) - (13 * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                        pnl_ht = parent_MpanelHeight;
                    }
                    else if (MPanel_ParentModel.MPanel_Type == "Transom")
                    {
                        div_movement = MPanel_OriginalDisplayHeight - MPanel_DisplayHeight;

                        decimal divMove_convert_dec = Convert.ToDecimal(div_movement * MPanel_Zoom);
                        decimal divMove_dec = decimal.Round(divMove_convert_dec / 2, 0, MidpointRounding.AwayFromZero);
                        decimal divMove_dec_times2 = divMove_dec * 2;
                        divMove_int = Convert.ToInt32(divMove_dec_times2);

                        pnl_wd = parent_MpanelWidth;
                        pnl_ht = (((parent_MpanelHeight + 10) - (13 * div_count)) / totalpanel_inside_parentMpanel) - divMove_int;
                    }
                }
            }
            else if (MPanel_FrameModelParent != null)
            {
                pnl_wd = MPanel_Width;
                pnl_ht = MPanel_Height;
            }

            MPanelImager_WidthToBindPrev = _mpanelImage_Width;
            MPanelImageRenderer_Width = pnl_wd;
            MPanelImageRenderer_Height = pnl_ht;
        }

        public void Set_DimensionToBind_using_FrameDimensions()
        {
            int wd = 0, ht = 0, wd_deduct = 0, ht_deduct = 0;
            if (MPanel_ParentModel == null)
            {
                if (MPanel_Zoom == 0.26f || MPanel_Zoom == 0.17f || MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
                {
                    wd_deduct = 20;
                    ht_deduct = 20;
                    if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                    {
                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                        {
                            ht_deduct = 10;
                        }
                        else if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7502)
                        {
                            ht_deduct = 15;
                        }
                    }

                    wd = MPanel_FrameModelParent.Frame_WidthToBind - wd_deduct;
                    ht = MPanel_FrameModelParent.Frame_HeightToBind - ht_deduct;
                }
                else if (MPanel_Zoom == 0.50f)
                {
                    decimal wd_flt_convert_dec = Convert.ToDecimal(MPanel_Width * MPanel_Zoom);
                    decimal wd_dec = decimal.Round(wd_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    wd = Convert.ToInt32(wd_dec);

                    decimal ht_flt_convert_dec = Convert.ToDecimal(MPanel_Height * MPanel_Zoom);
                    decimal ht_dec = decimal.Round(ht_flt_convert_dec / 2, 0, MidpointRounding.AwayFromZero) * 2;
                    ht = Convert.ToInt32(ht_dec);
                }
                else if (MPanel_Zoom == 1.0f)
                {
                    wd = Convert.ToInt32(MPanel_Width * MPanel_Zoom);
                    ht = Convert.ToInt32(MPanel_Height * MPanel_Zoom);
                }

                MPanel_WidthToBind = wd;
                MPanel_HeightToBind = ht;
            }
        }

        public void Imager_Set_DimensionToBind_using_FrameDimensions()
        {
            int wd = 0, ht = 0;

            wd = MPanel_FrameModelParent.FrameImageRenderer_Width - (MPanel_FrameModelParent.FrameImageRenderer_Padding_int.Left + MPanel_FrameModelParent.FrameImageRenderer_Padding_int.Right);
            ht = MPanel_FrameModelParent.FrameImageRenderer_Height - (MPanel_FrameModelParent.FrameImageRenderer_Padding_int.Top + MPanel_FrameModelParent.FrameImageRenderer_Padding_int.Bottom);

            MPanelImageRenderer_Width = wd;
            MPanelImageRenderer_Height = ht;
        }

        public void SetImageZoomDivider()
        {
            foreach (IDividerModel div in MPanelLst_Divider)
            {
                div.DivImageRenderer_Zoom = MPanelImageRenderer_Zoom;
            }
        }

        public void SetZoomDivider()
        {
            foreach (IDividerModel div in MPanelLst_Divider)
            {
                div.Div_Zoom = MPanel_Zoom;
                div.SetDimensionsToBind_using_DivZoom();
            }
        }

        public void SetZoomPanels()
        {

            decimal PanelWidthDecimals = 0,
                    PanelHeightDecimals = 0;
            int mpnlOriginalWidth = 0,
                mpnlOriginalHeight = 0;
            foreach (IPanelModel pnl in MPanelLst_Panel)
            {
                pnl.Panel_Zoom = MPanel_Zoom;
                if (MPanel_Zoom == 0.17f || MPanel_Zoom == 0.26f ||
                    MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
                {
                    pnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                    if (MPanel_Type == "Transom")
                    {
                        if (!MPanel_DividerEnabled)
                        {
                            mpnlOriginalHeight = MPanel_Height - 20;
                            PanelHeightDecimals += ((MPanel_HeightToBind - 10) * ((decimal)pnl.Panel_Height / mpnlOriginalHeight)) - Math.Truncate((MPanel_HeightToBind - 10) * ((decimal)pnl.Panel_Height / mpnlOriginalHeight));
                        }
                    }
                    else if (MPanel_Type == "Mullion")
                    {
                        if (!MPanel_DividerEnabled)
                        {
                            mpnlOriginalWidth = MPanel_Width - 20;
                            PanelWidthDecimals += ((MPanel_WidthToBind - 10) * ((decimal)pnl.Panel_Width / mpnlOriginalWidth)) - Math.Truncate((MPanel_WidthToBind - 10) * ((decimal)pnl.Panel_Width / mpnlOriginalWidth));
                        }
                    }


                }
                else
                {
                    pnl.SetDimensionToBind_using_BaseDimension();

                    //if (MPanel_Type == "Transom")
                    //{
                    //    if (!MPanel_DividerEnabled)
                    //    {
                    //        mpnlOriginalHeight = MPanel_Height - 20;
                    //        //PanelDecimals += ((MPanel_WidthToBind - 10) * Double.Parse(((double)pnl.Panel_Width / mpnlOriginalWidth).ToString("0.00"))) - Math.Truncate((MPanel_WidthToBind - 10) * ((double)pnl.Panel_Width / mpnlOriginalWidth));
                    //        decimal PanelHeightDecimal = (decimal)(MPanel_HeightToBind - (pnl.Panel_Zoom * 20)) * ((decimal)pnl.Panel_Height / mpnlOriginalHeight);
                    //        PanelHeightDecimals += PanelHeightDecimal - Math.Truncate(PanelHeightDecimal);
                    //    }
                    //}
                    //else if (MPanel_Type == "Mullion")
                    //{
                    //    if (!MPanel_DividerEnabled)
                    //    {
                    //        mpnlOriginalWidth = MPanel_Width - 20;
                    //        //PanelDecimals += ((MPanel_WidthToBind - 10) * Double.Parse(((double)pnl.Panel_Width / mpnlOriginalWidth).ToString("0.00"))) - Math.Truncate((MPanel_WidthToBind - 10) * ((double)pnl.Panel_Width / mpnlOriginalWidth));
                    //        decimal PanelWidthDecimal = (decimal)(MPanel_WidthToBind - (pnl.Panel_Zoom * 20)) * ((decimal)pnl.Panel_Width / mpnlOriginalWidth);
                    //        PanelWidthDecimals += PanelWidthDecimal - Math.Truncate(PanelWidthDecimal);
                    //    }

                    //}

                }
                pnl.SetPanelMargin_using_ZoomPercentage();
                pnl.SetPanelMarginImager_using_ImageZoomPercentage();
            }
            //if (MPanel_Type == "Transom")
            //{
            //    PanelHeightDecimals = Math.Round(PanelHeightDecimals);
            //    int MPanelCount = MPanelLst_Panel.Count;
            //    foreach (IPanelModel pnlForDecimalDistribution in MPanelLst_Panel)
            //    {
            //        if (PanelHeightDecimals != 0)
            //        {
            //            if (MPanel_Zoom == 0.17f || MPanel_Zoom == 0.26f ||
            //            MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
            //            {
            //                int PanelHeightToBindOriginal = pnlForDecimalDistribution.Panel_HeightToBind;
            //                int PanelHeightToBindConverted = Convert.ToInt32(Math.Round((MPanel_HeightToBind - 10) * ((decimal)pnlForDecimalDistribution.Panel_Height / mpnlOriginalHeight)));
            //                MPanelCount--;
            //                if (PanelHeightToBindConverted > PanelHeightToBindOriginal || (MPanelCount < PanelHeightDecimals))
            //                {
            //                    pnlForDecimalDistribution.Panel_HeightToBind += 1;
            //                    PanelHeightDecimals--;
            //                }
            //            }
            //            else
            //            {
            //                int PanelHeightToBindOriginal = pnlForDecimalDistribution.Panel_HeightToBind;
            //                int PanelHeightToBindConverted = Convert.ToInt32(Math.Round((decimal)(MPanel_HeightToBind - (pnlForDecimalDistribution.Panel_Zoom * 20)) * ((decimal)pnlForDecimalDistribution.Panel_Height / mpnlOriginalHeight)));
            //                MPanelCount--;
            //                if (PanelHeightToBindConverted > PanelHeightToBindOriginal || (MPanelCount <= PanelHeightDecimals))
            //                {
            //                    pnlForDecimalDistribution.Panel_HeightToBind += 1;
            //                    PanelHeightDecimals--;
            //                }
            //            }
            //        }
            //    }
            //}
            //else if (MPanel_Type == "Mullion")
            //{
            //    PanelWidthDecimals = Math.Round(PanelWidthDecimals);
            //    int MPanelCount = MPanelLst_Panel.Count;
            //    foreach (IPanelModel pnlForDecimalDistribution in MPanelLst_Panel)
            //    {
            //        if (PanelWidthDecimals != 0)
            //        {
            //            if (MPanel_Zoom == 0.17f || MPanel_Zoom == 0.26f ||
            //            MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
            //            {
            //                int PanelWidthToBindOriginal = pnlForDecimalDistribution.Panel_WidthToBind;
            //                int PanelWidthToBindConverted = Convert.ToInt32(Math.Round((MPanel_WidthToBind - 10) * ((decimal)pnlForDecimalDistribution.Panel_Width / mpnlOriginalWidth)));
            //                MPanelCount--;
            //                if (PanelWidthToBindConverted > PanelWidthToBindOriginal || (MPanelCount < PanelWidthDecimals))
            //                {
            //                    pnlForDecimalDistribution.Panel_WidthToBind += 1;
            //                    PanelWidthDecimals--;
            //                }
            //            }
            //            else
            //            {
            //                int PanelWidthToBindOriginal = pnlForDecimalDistribution.Panel_WidthToBind;
            //                int PanelWidthToBindConverted = Convert.ToInt32(Math.Round((decimal)(MPanel_WidthToBind - (pnlForDecimalDistribution.Panel_Zoom * 20)) * ((decimal)pnlForDecimalDistribution.Panel_Width / mpnlOriginalWidth)));
            //                MPanelCount--;
            //                if (PanelWidthToBindConverted > PanelWidthToBindOriginal || (MPanelCount <= PanelWidthDecimals))
            //                {
            //                    pnlForDecimalDistribution.Panel_WidthToBind += 1;
            //                    PanelWidthDecimals--;
            //                }
            //            }
            //        }
            //    }
            //}

        }

        public void SetZoomMPanels()
        {
            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
            {
                mpnl.MPanel_Zoom = MPanel_Zoom;
                if (MPanel_Zoom == 0.17f || MPanel_Zoom == 0.26f ||
                    MPanel_Zoom == 0.13f || MPanel_Zoom == 0.10f)
                {
                    mpnl.SetDimensionsToBind_usingZoom_below26_with_DividerMovement();
                }
                else
                {
                    mpnl.SetDimensionsToBind_using_ParentMultiPanelModel();
                }
            }
        }

        public void Reload_PanelMargin()
        {
            List<IPanelModel> Lst_visiblePnl = MPanelLst_Panel;
            int visiblePnl_count = Lst_visiblePnl.Count();

            foreach (IPanelModel pnl in Lst_visiblePnl)
            {
                Padding pnl_margin = new Padding(0);
                if (MPanel_Type == "Mullion")
                {
                    if (pnl.Panel_Parent.Parent.Parent.Name.Contains("Multi")) //if Parent.Parent multi-Panel
                    {
                        if (MPanel_Placement == "First")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 10, 0, 10);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(0, 10, 10, 10);
                                pnl.Panel_Placement = "Last";

                            }
                            else
                            {
                                pnl_margin = new Padding(0, 10, 0, 10);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Last") //top margin is 9 because of divider on top (8 + 1)
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(9, 8, 0, 10);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(0, 8, 10, 0);
                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 8, 0, 10);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Somewhere in Between") //top margin is 9 because of divider on top (8 + 1)
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 8, 0, 0);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(0, 8, 10, 0);
                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 8, 0, 0);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                    }
                    else if (pnl.Panel_Parent.Parent.Parent.Name.Contains("Frame")) //if Parent.Parent Frame
                    {
                        if (pnl.Panel_Index_Inside_MPanel == 0)
                        {
                            pnl_margin = new Padding(10, 10, 0, 10);
                            pnl.Panel_Placement = "First";
                        }
                        else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                 (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                        {
                            pnl_margin = new Padding(0, 10, 10, 10);
                            pnl.Panel_Placement = "Last";
                        }
                        else
                        {
                            pnl_margin = new Padding(0, 10, 0, 10);
                            pnl.Panel_Placement = "Somewhere in Between";
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (pnl.Panel_Parent.Parent.Parent.Name.Contains("Multi")) //if Parent.Parent multi-Panel
                    {
                        if (MPanel_Placement == "First")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 10, 10, 0);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                if (MPanel_ParentModel.MPanel_ParentModel == null)
                                {
                                    if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(10, 0, 10, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(10, 0, 10, 10);
                                        }
                                    }
                                    else
                                    {
                                        pnl_margin = new Padding(10, 0, 10, 10);
                                    }
                                }
                                else if (MPanel_ParentModel.MPanel_ParentModel != null) //3-stack mpanels
                                {
                                    if (MPanel_ParentModel.MPanel_Placement == "Last")
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(10, 0, 10, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(10, 0, 10, 10);
                                        }
                                    }
                                    else if (MPanel_ParentModel.MPanel_Placement != "Last")
                                    {
                                        pnl_margin = new Padding(10, 0, 10, 10);
                                    }
                                }

                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(10, 0, 10, 0);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Last")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                                {
                                    pnl_margin = new Padding(10, 10, 0, 0);

                                }
                                else
                                {
                                    pnl_margin = new Padding(8, 10, 0, 0);

                                }
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                if (MPanel_ParentModel.MPanel_ParentModel == null)
                                {
                                    if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(8, 0, 10, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(10, 0, 10, 10);
                                        }
                                    }
                                    else
                                    {
                                        pnl_margin = new Padding(8, 0, 10, 10);
                                    }
                                }
                                else if (MPanel_ParentModel.MPanel_ParentModel != null)
                                {
                                    if (MPanel_ParentModel.MPanel_Placement == "Last")
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(8, 0, 10, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(8, 0, 10, 10);
                                        }
                                    }
                                    else if (MPanel_ParentModel.MPanel_Placement != "Last")
                                    {
                                        pnl_margin = new Padding(8, 0, 10, 10);
                                    }
                                }

                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(8, 0, 10, 0);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Somewhere in Between")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                                {
                                    pnl_margin = new Padding(10, 10, 0, 0);
                                }
                                else
                                {
                                    pnl_margin = new Padding(8, 10, 0, 0);

                                }
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                if (MPanel_ParentModel.MPanel_ParentModel == null)
                                {
                                    if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(10, 0, 0, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(10, 0, 0, 10);
                                        }
                                    }
                                    else
                                    {
                                        pnl_margin = new Padding(8, 0, 0, 10);
                                    }
                                }
                                else if (MPanel_ParentModel.MPanel_ParentModel != null)
                                {
                                    if (MPanel_ParentModel.MPanel_Placement == "Last")
                                    {
                                        if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                            MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                        {
                                            pnl_margin = new Padding(10, 0, 0, 0);
                                        }
                                        else
                                        {
                                            pnl_margin = new Padding(10, 0, 0, 10);
                                        }
                                    }
                                    else if (MPanel_ParentModel.MPanel_Placement != "Last")
                                    {
                                        pnl_margin = new Padding(10, 0, 0, 10);
                                    }
                                }

                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(10, 0, 0, 0);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                    }
                    else if (pnl.Panel_Parent.Parent.Parent.Name.Contains("Frame")) //if Parent.Parent Frame
                    {
                        if (pnl.Panel_Index_Inside_MPanel == 0)
                        {
                            pnl_margin = new Padding(10, 10, 10, 0);
                            pnl.Panel_Placement = "First";
                        }
                        else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                 (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                        {
                            if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
                            {
                                if (MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._7789 ||
                                    MPanel_FrameModelParent.Frame_BotFrameArtNo == BottomFrameTypes._None)
                                {
                                    pnl_margin = new Padding(10, 0, 10, 0);
                                }
                                else
                                {
                                    pnl_margin = new Padding(10, 0, 10, 10);
                                }
                            }
                            else
                            {
                                pnl_margin = new Padding(10, 0, 10, 10);
                            }
                            pnl.Panel_Placement = "Last";
                        }
                        else
                        {
                            pnl_margin = new Padding(10, 0, 10, 0);
                            pnl.Panel_Placement = "Somewhere in Between";
                        }
                    }
                }
                pnl.Panel_Margin = pnl_margin;
                pnl.SetPanelMargin_using_ZoomPercentage();
                pnl.SetPanelMarginImager_using_ImageZoomPercentage();
            }
        }

        public void Reload_MultiPanelMargin()
        {
            List<IMultiPanelModel> Lst_visibleMPanel = MPanelLst_MultiPanel.ToList();
            int visibleMPnl_count = Lst_visibleMPanel.Count();

            foreach (IMultiPanelModel mpnl in Lst_visibleMPanel)
            {
                Padding pnl_margin = new Padding(0);
                if (MPanel_Type == "Mullion")
                {
                    if (mpnl.MPanel_Index_Inside_MPanel == 0)
                    {
                        mpnl.MPanel_Placement = "First";
                    }
                    else if (mpnl.MPanel_Index_Inside_MPanel == MPanel_Divisions * 2)
                    {
                        mpnl.MPanel_Placement = "Last";
                    }
                    else
                    {
                        mpnl.MPanel_Placement = "Somewhere in Between";
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (mpnl.MPanel_Index_Inside_MPanel == 0)
                    {
                        mpnl.MPanel_Placement = "First";
                    }
                    else if (mpnl.MPanel_Index_Inside_MPanel == MPanel_Divisions * 2)
                    {
                        mpnl.MPanel_Placement = "Last";
                    }
                    else
                    {
                        mpnl.MPanel_Placement = "Somewhere in Between";
                    }
                }
                pnl_margin = new Padding(0, 0, 0, 0);
                mpnl.MPanel_Margin = pnl_margin;
            }
        }

        public int GetNextIndex()
        {
            int visiblePanelCount = MPanelLst_Panel.Count(),
                visibleMPanelCount = MPanelLst_MultiPanel.Count(),
                visibleDivider = MPanelLst_Divider.Count();

            return visiblePanelCount + visibleMPanelCount + visibleDivider;
        }

        public void Adapt_sizeToBind_MPanelDivMPanel_Controls(Control current_control,
                                                              string frameType,
                                                              bool if_auto_added = false)
        {
            int indx = MPanelLst_Objects.IndexOf(current_control),
                div_mpnl_deduct = _mpnl_add,//8
                div_mpnl_deduct_Tobind = 0;

            if (MPanel_Zoom > 0.26f)
            {
                div_mpnl_deduct_Tobind = (int)(_mpnl_add * MPanel_Zoom);//4
            }
            else if (MPanel_Zoom <= 0.26f)
            {
                div_mpnl_deduct_Tobind = 2; //13 - 2 = 11 - 2 = 9px default on div obj for 2-stack multipanel
            }

            if (current_control.Name.Contains("MultiMullion") || current_control.Name.Contains("MultiTransom")) //MultiPanel Block
            {
                if (indx > 0 && indx % 2 == 0) //indx > 0 && indx == 'Even'
                {
                    Control prev_ctrl = MPanelLst_Objects[indx - 1];
                    IDividerModel divModel = MPanelLst_Divider.Find(div => div.Div_Name == prev_ctrl.Name);
                    IMultiPanelModel multiModel = MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == current_control.Name);

                    if (!prev_ctrl.Name.Contains("MultiPanel") && prev_ctrl.Name.Contains(MPanel_Type)) //means Divider
                    {
                        if (prev_ctrl.Name.Contains("TransomUC"))
                        {
                            divModel.Div_Height -= div_mpnl_deduct;
                            divModel.Div_HeightToBind -= div_mpnl_deduct_Tobind;
                            //divModel.DivImageRenderer_Height -= div_mpnl_deduct_Tobind;
                            if (indx == MPanel_Divisions * 2) //means LAST OBJECT
                            {
                                multiModel.MPanel_Height += div_mpnl_deduct;
                                multiModel.MPanel_HeightToBind += div_mpnl_deduct_Tobind;
                                //multiModel.MPanelImageRenderer_Height += div_mpnl_deduct_Tobind;
                            }
                        }
                        else if (prev_ctrl.Name.Contains("MullionUC"))
                        {
                            divModel.Div_Width -= div_mpnl_deduct; // 18 - 8
                            divModel.Div_WidthToBind -= div_mpnl_deduct_Tobind; // 9 - 4
                            //divModel.DivImageRenderer_Width -= div_mpnl_deduct_Tobind;
                            if (indx == MPanel_Divisions * 2) //means LAST OBJECT
                            {
                                multiModel.MPanel_Width += div_mpnl_deduct; // 471 + 8
                                multiModel.MPanel_WidthToBind += div_mpnl_deduct_Tobind; // 235 + 4
                                //multiModel.MPanelImageRenderer_Width += div_mpnl_deduct_Tobind;
                            }
                        }
                    }
                }
            }
            else if (current_control.Name.Contains("TransomUC") || current_control.Name.Contains("MullionUC")) //Divider Block
            {
                if (indx % 2 != 0) //means Odd
                {
                    Control prev_ctrl = MPanelLst_Objects[indx - 1];
                    IDividerModel divModel = MPanelLst_Divider.Find(div => div.Div_Name == current_control.Name);
                    IMultiPanelModel multiModel = MPanelLst_MultiPanel.Find(mpnl => mpnl.MPanel_Name == prev_ctrl.Name);

                    if (prev_ctrl.Name.Contains("MultiMullion") || prev_ctrl.Name.Contains("MultiTransom")) //if prev_ctrl is MultiPanel
                    {
                        if (current_control.Name.Contains("TransomUC"))
                        {
                            if (!if_auto_added)
                            {
                                multiModel.MPanel_Height += div_mpnl_deduct;
                                multiModel.MPanel_HeightToBind += div_mpnl_deduct_Tobind;
                                //multiModel.MPanelImageRenderer_Height += div_mpnl_deduct_Tobind;
                            }
                            divModel.Div_Height -= div_mpnl_deduct;
                            divModel.Div_HeightToBind -= div_mpnl_deduct_Tobind;
                            //divModel.DivImageRenderer_Height -= div_mpnl_deduct_Tobind;
                        }
                        else if (current_control.Name.Contains("MullionUC"))
                        {
                            if (!if_auto_added)
                            {
                                multiModel.MPanel_Width += div_mpnl_deduct;//471 + 8
                                multiModel.MPanel_WidthToBind += div_mpnl_deduct_Tobind;//235 + 4
                                //multiModel.MPanelImageRenderer_Width += div_mpnl_deduct_Tobind;
                            }
                            divModel.Div_Width -= div_mpnl_deduct;//26 - 8
                            divModel.Div_WidthToBind -= div_mpnl_deduct_Tobind;//13 - 4
                            //divModel.DivImageRenderer_Width -= div_mpnl_deduct_Tobind;
                        }
                    }
                }
            }

        }

        public void AddControl_MPanelLstObjects(Control control,
                                                string frameType,
                                                bool if_auto_added = false)
        {
            MPanelLst_Objects.Add(control);
        }

        public int GetCount_MPanelLst_Object()
        {
            return MPanelLst_Objects.Count();
        }

        public void DeleteControl_MPanelLstObjects(Control control, string frameType, string placement = "")
        {
            int prev_indx = MPanelLst_Objects.IndexOf(control) - 1; //get the index of previous control
            int pixels_count = 0;

            if (frameType == "Window")
            {
                pixels_count = 8;
            }
            else if (frameType == "Door")
            {
                pixels_count = 10;
            }

            int next_indx = MPanelLst_Objects.IndexOf(control) + 1; //needed to check if the last object index hits the totalCount of MPanelLst_Objects

            if (prev_indx >= 0 &&
                ((placement == "Somewhere in Between" && MPanelLst_Objects.Count() == next_indx) ||
                  placement == "Last"))
            {
                Adjust_prev_obj_dimension(control, prev_indx, pixels_count);
            }

            MPanelLst_Objects.Remove(control);
        }

        private void Adjust_prev_obj_dimension(Control control,
                                               int previous_indx,
                                               int pixel_count)
        {
            if (control.Name.Contains("MultiMullion") || control.Name.Contains("MultiTransom"))
            {
                int divToBind_add = 0;
                if (MPanel_Zoom >= 0.50f)
                {
                    divToBind_add = (int)(pixel_count * MPanel_Zoom);
                }
                else if (MPanel_Zoom <= 0.26f)
                {
                    divToBind_add = 2;
                }

                if (MPanelLst_Objects[previous_indx].Name.Contains("MullionUC"))
                {
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_Width += pixel_count;
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_WidthToBind += divToBind_add;
                }
                else if (MPanelLst_Objects[previous_indx].Name.Contains("TransomUC"))
                {
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_Height += pixel_count;
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_HeightToBind += divToBind_add;
                }
            }
        }

        public void Fit_MyControls_ToBindDimensions()
        {
            int totalCount_objs_to_accomodate = 0;
            if (MPanel_DividerEnabled)
            {
                totalCount_objs_to_accomodate = (MPanel_Divisions * 2) + 1;
            }
            else
            {
                totalCount_objs_to_accomodate = MPanel_Divisions + 1;
            }

            if (MPanelLst_Objects.Count() > 0 && (MPanelLst_Objects.Count() >= totalCount_objs_to_accomodate))
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHt_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_HeightToBind + pnl.Panel_MarginToBind.Top + pnl.Panel_MarginToBind.Bottom),
                        totalHt_divModel = MPanelLst_Divider.Sum(div => div.Div_HeightToBind),
                        totalHt_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_HeightToBind);

                    int totalHeight_Controls = totalHt_panelModel + totalHt_divModel + totalHt_MpanelModel;
                    int diff_MPanelHt_VS_MyCtrlsHeight = MPanel_HeightToBind - totalHeight_Controls;

                    if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    pnl.Panel_HeightToBind++;
                                    diff_MPanelHt_VS_MyCtrlsHeight--;

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    mpnl.MPanel_HeightToBind++;
                                    diff_MPanelHt_VS_MyCtrlsHeight--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    pnl.Panel_HeightToBind--;
                                    diff_MPanelHt_VS_MyCtrlsHeight++;
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    mpnl.MPanel_HeightToBind--;
                                    diff_MPanelHt_VS_MyCtrlsHeight++;
                                }
                            }
                        }
                    }
                }

                else if (MPanel_Type == "Mullion")

                {
                    int totalWd_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_WidthToBind + pnl.Panel_MarginToBind.Right + pnl.Panel_MarginToBind.Left),
                        totalWd_divModel = MPanelLst_Divider.Sum(div => div.Div_WidthToBind),
                        totalWd_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_WidthToBind);

                    int totalWidth_Controls = totalWd_panelModel + totalWd_divModel + totalWd_MpanelModel;

                    int diff_MPanelWd_VS_MyCtrlsWidth = MPanel_WidthToBind - totalWidth_Controls;

                    if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    pnl.Panel_WidthToBind++;
                                    diff_MPanelWd_VS_MyCtrlsWidth--;
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    mpnl.MPanel_WidthToBind++;
                                    diff_MPanelWd_VS_MyCtrlsWidth--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    pnl.Panel_WidthToBind--;
                                    diff_MPanelWd_VS_MyCtrlsWidth++;
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    mpnl.MPanel_WidthToBind--;
                                    diff_MPanelWd_VS_MyCtrlsWidth++;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Fit_MyControls_ImagersToBindDimensions()
        {
            bool isEqual = isDisplaySizeEqual();
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {

                    int totalHeight_Imagers = MPanelLst_Panel.Sum(pnl => pnl.PanelImageRenderer_Height) +
                                              MPanelLst_Divider.Sum(div => div.DivImageRenderer_Height) +
                                              MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanelImageRenderer_Height);
                    int diff_MPanelImagerHt_VS_MyImagersHeight = MPanelImageRenderer_Height - totalHeight_Imagers;
                    if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                    {
                        while (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                                {

                                    if (isEqual)
                                    {
                                        pnl.PanelImageRenderer_Height++;
                                        diff_MPanelImagerHt_VS_MyImagersHeight--;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.PanelImageRenderer_Height++;
                                            diff_MPanelImagerHt_VS_MyImagersHeight--;
                                        }
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                                {
                                    mpnl.MPanelImageRenderer_Height++;
                                    diff_MPanelImagerHt_VS_MyImagersHeight--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                    {
                        while (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.PanelImageRenderer_Height--;
                                        diff_MPanelImagerHt_VS_MyImagersHeight++;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.PanelImageRenderer_Height--;
                                            diff_MPanelImagerHt_VS_MyImagersHeight++;
                                        }
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                                {
                                    mpnl.MPanelImageRenderer_Height--;
                                    diff_MPanelImagerHt_VS_MyImagersHeight++;
                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalWidth_Imagers = MPanelLst_Panel.Sum(pnl => pnl.PanelImageRenderer_Width) +
                                             MPanelLst_Divider.Sum(div => div.DivImageRenderer_Width) +
                                             MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanelImageRenderer_Width);
                    int diff_MPanelImagerWd_VS_MyImagersWidth = MPanelImageRenderer_Width - totalWidth_Imagers;
                    if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                    {
                        while (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.PanelImageRenderer_Width++;
                                        diff_MPanelImagerWd_VS_MyImagersWidth--;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.PanelImageRenderer_Width++;
                                            diff_MPanelImagerWd_VS_MyImagersWidth--;
                                        }
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                                {
                                    mpnl.MPanelImageRenderer_Width++;
                                    diff_MPanelImagerWd_VS_MyImagersWidth--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                    {
                        while (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.PanelImageRenderer_Width--;
                                        diff_MPanelImagerWd_VS_MyImagersWidth++;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.PanelImageRenderer_Width--;
                                            diff_MPanelImagerWd_VS_MyImagersWidth++;
                                        }
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                                {
                                    mpnl.MPanelImageRenderer_Width--;
                                    diff_MPanelImagerWd_VS_MyImagersWidth++;
                                }
                            }
                        }
                    }

                }
            }
        }

        public void Fit_MyControls_Dimensions()
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHt_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_HeightToBind + pnl.Panel_MarginToBind.Top + pnl.Panel_MarginToBind.Bottom),
                        totalHt_divModel = MPanelLst_Divider.Sum(div => div.Div_HeightToBind),
                        totalHt_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_HeightToBind);

                    int totalHeight_Controls = totalHt_panelModel + totalHt_divModel + totalHt_MpanelModel;
                    int diff_MPanelHt_VS_MyCtrlsHeight = MPanel_HeightToBind - totalHeight_Controls;

                    while (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                            {
                                pnl.Panel_Height++;
                                diff_MPanelHt_VS_MyCtrlsHeight--;
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                            {
                                mpnl.MPanel_Height++;
                                diff_MPanelHt_VS_MyCtrlsHeight--;
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalWidth_Controls = MPanelLst_Panel.Sum(pnl => pnl.Panel_WidthToBind + pnl.Panel_MarginToBind.Right + pnl.Panel_MarginToBind.Left) +
                                              MPanelLst_Divider.Sum(div => div.Div_WidthToBind) +
                                              MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_WidthToBind);
                    int diff_MPanelWd_VS_MyCtrlsWidth = MPanel_WidthToBind - totalWidth_Controls;

                    while (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                            {
                                pnl.Panel_Width++;
                                diff_MPanelWd_VS_MyCtrlsWidth--;
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                            {
                                mpnl.MPanel_Width++;
                                diff_MPanelWd_VS_MyCtrlsWidth--;
                            }
                        }
                    }
                }
            }
        }

        public void Object_Indexer()
        {
            List<Control> visible_obj = MPanelLst_Objects.Where(obj => obj.Visible == true).ToList();

            for (int i = 0; i < visible_obj.Count(); i++)
            {
                Control obj = MPanelLst_Objects[i];

                if (obj.Name.Contains("MultiMullion_") || obj.Name.Contains("MultiTransom_")) //MultiPanel
                {
                    IMultiPanelModel mpnl_model = MPanelLst_MultiPanel.First(mpnl => mpnl.MPanel_Name == obj.Name);
                    mpnl_model.MPanel_Index_Inside_MPanel = i;
                }
                else if (obj.Name.Contains("PanelUC")) //Panel
                {
                    IPanelModel pnl_model = MPanelLst_Panel.First(pnl => pnl.Panel_Name == obj.Name);
                    pnl_model.Panel_Index_Inside_MPanel = i;
                }
            }
        }

        public void Adjust_ControlDisplaySize()
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalDisplayHeight = MPanelLst_Panel.Sum(pnl => pnl.Panel_DisplayHeight) +
                                             MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_DisplayHeight);
                    int diff_DisplayHt_VS_totalDisplayHt = MPanel_DisplayHeight - totalDisplayHeight;

                    while (diff_DisplayHt_VS_totalDisplayHt > 0)
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (diff_DisplayHt_VS_totalDisplayHt > 0)
                            {
                                pnl.Panel_DisplayHeight++;
                                diff_DisplayHt_VS_totalDisplayHt--;
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            if (diff_DisplayHt_VS_totalDisplayHt > 0)
                            {
                                mpnl.MPanel_DisplayHeight++;
                                diff_DisplayHt_VS_totalDisplayHt--;
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalDisplayWidth = MPanelLst_Panel.Sum(pnl => pnl.Panel_DisplayWidth) +
                                             MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_DisplayWidth);
                    int diff_DisplayWd_VS_totalDisplayWd = MPanel_DisplayWidth - totalDisplayWidth;

                    while (diff_DisplayWd_VS_totalDisplayWd > 0)
                    {
                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            if (diff_DisplayWd_VS_totalDisplayWd > 0)
                            {
                                pnl.Panel_DisplayWidth++;
                                diff_DisplayWd_VS_totalDisplayWd--;
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            if (diff_DisplayWd_VS_totalDisplayWd > 0)
                            {
                                mpnl.MPanel_DisplayWidth++;
                                diff_DisplayWd_VS_totalDisplayWd--;
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<Control> GetVisibleObjects()
        {
            return MPanelLst_Objects.Where(obj => obj.Visible == true);
        }

        #endregion

        #region  n
        private int _mPanel_OriginalDisplayWidth;
        public int MPanel_OriginalDisplayWidth
        {
            get
            {
                return _mPanel_OriginalDisplayWidth;
            }
            set {
                _mPanel_OriginalDisplayWidth = value;
            }
        }
        public int MPanel_OriginalDisplayWidthDecimal { get; set; }
        public int MPanel_OriginalDisplayHeight { get; set; }
        public int MPanel_OriginalDisplayHeightDecimal { get; set; }
        public int MPanel_OriginalGlassWidth { get; set; }
        public int MPanel_OriginalGlassWidthDecimal { get; set; }
        public int MPanel_OriginalGlassHeight { get; set; }
        public int MPanel_OriginalGlassHeightDecimal { get; set; }

        private bool _mpanelCmenuDeleteVisibility;
        public bool MPanel_CmenuDeleteVisibility
        {
            get
            {
                return _mpanelCmenuDeleteVisibility;
            }

            set
            {
                _mpanelCmenuDeleteVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public bool MPanel_GlassBalanced { get; set; }

        public void SetEqualGlassDimension(string mode, SashProfile_ArticleNo sash)
        {
            int div_deduction = 0,
                divDM_deduction = 0,
                TM_sashBite_deduction = 0,
                total_frame_deduction = 0,
                frame_thickness = 0,
                sash_bite = 0,
                totalPanels = MPanel_Divisions + 1;

            decimal Equal_GlassSize = 0;

            if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7502 || MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._2060)
            {
                frame_thickness = 33;
            }
            else if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
            {
                frame_thickness = 47;
            }

            if (sash == SashProfile_ArticleNo._7581 || sash == SashProfile_ArticleNo._2067)
            {
                sash_bite = 7;
            }
            else if (sash == SashProfile_ArticleNo._374 || sash == SashProfile_ArticleNo._395)
            {
                sash_bite = 8;
            }

            total_frame_deduction = frame_thickness - sash_bite;

            if (mode == "noSash")
            {
                if (MPanel_Type == "Mullion")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        MPanel_GlassBalanced = true;

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ChkDM == false)
                            {
                                if (div.Div_ArtNo == Divider_ArticleNo._7536 || div.Div_ArtNo == Divider_ArticleNo._2069)
                                {
                                    div_deduction += 42;
                                }
                                else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                {
                                    div_deduction += 72;
                                }
                            }
                        }

                        decimal disp_wd_dec = Convert.ToDecimal(MPanel_DisplayWidth + "." + MPanel_DisplayWidthDecimal);

                        Equal_GlassSize = (((disp_wd_dec - (total_frame_deduction * 2) - div_deduction)) / totalPanels) - 6;
                        Equal_GlassSize = Math.Round(Equal_GlassSize, 1, MidpointRounding.AwayFromZero);

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            decimal orig_disp_wd_dec = Convert.ToDecimal(pnl.Panel_OriginalDisplayWidth + "." + pnl.Panel_OriginalDisplayWidthDecimal);
                            decimal orig_glass_wd_dec = Convert.ToDecimal(pnl.Panel_OriginalGlassWidth + "." + pnl.Panel_OriginalGlassWidthDecimal);

                            decimal panel_disp_wd_dec = orig_disp_wd_dec + (Equal_GlassSize - orig_glass_wd_dec);

                            int panel_disp_wd = (int)Math.Truncate(panel_disp_wd_dec);
                            pnl.Panel_DisplayWidth = panel_disp_wd;

                            string[] DisplayWD_dec_split = decimal.Round(panel_disp_wd_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayWD_dec_split.Count() > 1)
                            {
                                pnl.Panel_DisplayWidthDecimal = Convert.ToInt32(DisplayWD_dec_split[1]);
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            decimal orig_disp_wd_dec = Convert.ToDecimal(mpnl.MPanel_OriginalDisplayWidth + "." + mpnl.MPanel_OriginalDisplayWidthDecimal);
                            decimal orig_glass_wd_dec = Convert.ToDecimal(mpnl.MPanel_OriginalGlassWidth + "." + mpnl.MPanel_OriginalGlassWidthDecimal);

                            decimal mpanel_disp_wd_dec = orig_disp_wd_dec + (Equal_GlassSize - orig_glass_wd_dec);

                            int mpanel_disp_wd = (int)Math.Truncate(mpanel_disp_wd_dec);
                            mpnl.MPanel_DisplayWidth = mpanel_disp_wd;

                            string[] DisplayWD_dec_split = decimal.Round(mpanel_disp_wd_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayWD_dec_split.Count() > 1)
                            {
                                mpnl.MPanel_DisplayWidthDecimal = Convert.ToInt32(DisplayWD_dec_split[1]);
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        MPanel_GlassBalanced = true;

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536 || div.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                div_deduction += 42;
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += 72;
                            }
                        }

                        decimal disp_ht_dec = Convert.ToDecimal(MPanel_DisplayHeight + "." + MPanel_DisplayHeightDecimal);
                        Equal_GlassSize = (((disp_ht_dec - (total_frame_deduction * 2) - div_deduction)) / totalPanels) - 6;
                        Equal_GlassSize = Math.Round(Equal_GlassSize, 1, MidpointRounding.AwayFromZero);

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            decimal orig_disp_ht_dec = Convert.ToDecimal(pnl.Panel_OriginalDisplayHeight + "." + pnl.Panel_OriginalDisplayHeightDecimal);
                            decimal orig_glass_ht_dec = Convert.ToDecimal(pnl.Panel_OriginalGlassHeight + "." + pnl.Panel_OriginalGlassHeightDecimal);

                            decimal panel_disp_ht_dec = orig_disp_ht_dec + (Equal_GlassSize - orig_glass_ht_dec);

                            int panel_disp_ht = (int)Math.Truncate(panel_disp_ht_dec);
                            pnl.Panel_DisplayWidth = panel_disp_ht;

                            string[] DisplayHT_dec_split = decimal.Round(panel_disp_ht_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayHT_dec_split.Count() > 1)
                            {
                                pnl.Panel_DisplayWidthDecimal = Convert.ToInt32(DisplayHT_dec_split[1]);
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            decimal orig_disp_ht_dec = Convert.ToDecimal(mpnl.MPanel_OriginalDisplayHeight + "." + mpnl.MPanel_OriginalDisplayHeightDecimal);
                            decimal orig_glass_ht_dec = Convert.ToDecimal(mpnl.MPanel_OriginalGlassHeight + "." + mpnl.MPanel_OriginalGlassHeightDecimal);

                            decimal mpanel_disp_ht_dec = orig_disp_ht_dec + (Equal_GlassSize - orig_glass_ht_dec);

                            int mpanel_disp_ht = (int)Math.Truncate(mpanel_disp_ht_dec);
                            mpnl.MPanel_DisplayHeight = mpanel_disp_ht;

                            string[] DisplayHT_dec_split = decimal.Round(mpanel_disp_ht_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayHT_dec_split.Count() > 1)
                            {
                                mpnl.MPanel_DisplayHeightDecimal = Convert.ToInt32(DisplayHT_dec_split[1]);
                            }
                        }
                    }
                }
            }
            else if (mode == "withSash")
            {
                if (MPanel_Type == "Mullion")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        MPanel_GlassBalanced = true;

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ChkDM == false)
                            {
                                if (div.Div_ArtNo == Divider_ArticleNo._7536 || div.Div_ArtNo == Divider_ArticleNo._2069)
                                {
                                    div_deduction += 42;
                                    if (sash == SashProfile_ArticleNo._7581 || sash == SashProfile_ArticleNo._2067)
                                    {
                                        TM_sashBite_deduction += 14;
                                    }
                                    else if (sash == SashProfile_ArticleNo._374 ||
                                             sash == SashProfile_ArticleNo._395 ||
                                             sash == SashProfile_ArticleNo._373)
                                    {
                                        TM_sashBite_deduction += 16;
                                    }
                                }
                                else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                                {
                                    div_deduction += 72;
                                    if (sash == SashProfile_ArticleNo._7581)
                                    {
                                        TM_sashBite_deduction += 14;
                                    }
                                    else if (sash == SashProfile_ArticleNo._374 ||
                                             sash == SashProfile_ArticleNo._395 ||
                                             sash == SashProfile_ArticleNo._373)
                                    {
                                        TM_sashBite_deduction += 16;
                                    }
                                }
                            }
                            else if (div.Div_ChkDM == true)
                            {
                                if (div.Div_DMArtNo == DummyMullion_ArticleNo._7533)
                                {
                                    divDM_deduction += 16;
                                }
                                else if (div.Div_DMArtNo == DummyMullion_ArticleNo._385P)
                                {
                                    divDM_deduction += 8;
                                }
                            }
                        }

                        decimal disp_wd_dec = Convert.ToDecimal(MPanel_DisplayWidth + "." + MPanel_DisplayWidthDecimal);
                        Equal_GlassSize = (((disp_wd_dec - (total_frame_deduction * 2) - divDM_deduction - (div_deduction - TM_sashBite_deduction))) / totalPanels) + 5;
                        Equal_GlassSize = Math.Round(Equal_GlassSize, 1, MidpointRounding.AwayFromZero);

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            decimal orig_disp_wd_dec = Convert.ToDecimal(pnl.Panel_OriginalDisplayWidth + "." + pnl.Panel_OriginalDisplayWidthDecimal);
                            decimal orig_sash_wd_dec = Convert.ToDecimal(pnl.Panel_OriginalSashWidth + "." + pnl.Panel_OriginalSashWidthDecimal);

                            decimal panel_disp_wd_dec = orig_disp_wd_dec + (Equal_GlassSize - orig_sash_wd_dec);

                            int panel_disp_wd = (int)Math.Truncate(panel_disp_wd_dec);
                            pnl.Panel_DisplayWidth = panel_disp_wd;

                            string[] DisplayWD_dec_split = decimal.Round(panel_disp_wd_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayWD_dec_split.Count() > 1)
                            {
                                pnl.Panel_DisplayWidthDecimal = Convert.ToInt32(DisplayWD_dec_split[1]);
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            decimal orig_disp_wd_dec = Convert.ToDecimal(mpnl.MPanel_OriginalDisplayWidth + "." + mpnl.MPanel_OriginalDisplayWidthDecimal);
                            decimal orig_glass_wd_dec = Convert.ToDecimal(mpnl.MPanel_OriginalGlassWidth + "." + mpnl.MPanel_OriginalGlassWidthDecimal);

                            decimal mpanel_disp_wd_dec = orig_disp_wd_dec + (Equal_GlassSize - orig_glass_wd_dec);

                            int mpanel_disp_wd = (int)Math.Truncate(mpanel_disp_wd_dec);
                            mpnl.MPanel_DisplayWidth = mpanel_disp_wd;

                            string[] DisplayWD_dec_split = decimal.Round(mpanel_disp_wd_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayWD_dec_split.Count() > 1)
                            {
                                mpnl.MPanel_DisplayWidthDecimal = Convert.ToInt32(DisplayWD_dec_split[1]);
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        MPanel_GlassBalanced = true;

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536 || div.Div_ArtNo == Divider_ArticleNo._2069)
                            {
                                div_deduction += (42 - 14);
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += (72 - 14);
                            }
                        }

                        decimal disp_ht_dec = Convert.ToDecimal(MPanel_DisplayHeight + "." + MPanel_DisplayHeightDecimal);
                        Equal_GlassSize = (((disp_ht_dec - (total_frame_deduction * 2) - div_deduction)) / totalPanels) - 6;
                        Equal_GlassSize = Math.Round(Equal_GlassSize, 1, MidpointRounding.AwayFromZero);

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            decimal orig_disp_ht_dec = Convert.ToDecimal(pnl.Panel_OriginalDisplayHeight + "." + pnl.Panel_OriginalDisplayHeightDecimal);
                            decimal orig_glass_ht_dec = Convert.ToDecimal(pnl.Panel_OriginalGlassHeight + "." + pnl.Panel_OriginalGlassHeightDecimal);

                            decimal panel_disp_ht_dec = orig_disp_ht_dec + (Equal_GlassSize - orig_glass_ht_dec);

                            int panel_disp_ht = (int)Math.Truncate(panel_disp_ht_dec);
                            pnl.Panel_DisplayWidth = panel_disp_ht;

                            string[] DisplayHT_dec_split = decimal.Round(panel_disp_ht_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayHT_dec_split.Count() > 1)
                            {
                                pnl.Panel_DisplayWidthDecimal = Convert.ToInt32(DisplayHT_dec_split[1]);
                            }
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            decimal orig_disp_ht_dec = Convert.ToDecimal(mpnl.MPanel_OriginalDisplayHeight + "." + mpnl.MPanel_OriginalDisplayHeightDecimal);
                            decimal orig_glass_ht_dec = Convert.ToDecimal(mpnl.MPanel_OriginalGlassHeight + "." + mpnl.MPanel_OriginalGlassHeightDecimal);

                            decimal mpanel_disp_ht_dec = orig_disp_ht_dec + (Equal_GlassSize - orig_glass_ht_dec);

                            int mpanel_disp_ht = (int)Math.Truncate(mpanel_disp_ht_dec);
                            mpnl.MPanel_DisplayHeight = mpanel_disp_ht;

                            string[] DisplayHT_dec_split = decimal.Round(mpanel_disp_ht_dec, 1, MidpointRounding.AwayFromZero).ToString().Split('.');

                            if (DisplayHT_dec_split.Count() > 1)
                            {
                                mpnl.MPanel_DisplayHeightDecimal = Convert.ToInt32(DisplayHT_dec_split[1]);
                            }
                        }
                    }
                }
            }
        }
        public void SetMPanelExplosionValues_Panel(Divider_ArticleNo divNxt_artNo,
                                                   Divider_ArticleNo divPrev_artNo,
                                                   DividerType div_type,
                                                   Divider_ArticleNo divArtNo_LeftorTop = null,
                                                   Divider_ArticleNo divArtNo_RightorBot = null,
                                                   string div_type_lvl3 = "",
                                                   Divider_ArticleNo divArtNo_LeftorTop_lvl3 = null,
                                                   Divider_ArticleNo divArtNo_RightorBot_lvl3 = null,
                                                   string panel_placement = "",
                                                   string mpanel_placement = "", //1st level
                                                   string mpanelparent_placement = "") //2nd level
        {
            int GB_deduction_forLeftorTopRightorBot = 0,
                GB_deduction_forNxtPrev = 0,
                GB_deduction_lvl3 = 0,
                deduction_for_wd = 0,
                deduction_for_ht = 0;

            if (divNxt_artNo == Divider_ArticleNo._7536)
            {
                GB_deduction_forNxtPrev += (42 / 2);
            }
            else if (divNxt_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
            }
            else if (divNxt_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "Last" && mpanelparent_placement == "")
                {
                    GB_deduction_forNxtPrev += 33;
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                }
            }

            if (divPrev_artNo == Divider_ArticleNo._7536)
            {
                GB_deduction_forNxtPrev += (42 / 2);
            }
            else if (divPrev_artNo == Divider_ArticleNo._7538)
            {
                GB_deduction_forNxtPrev += (72 / 2);
            }
            else if (divPrev_artNo == Divider_ArticleNo._None)
            {
                if (panel_placement == "First" && mpanelparent_placement == "")
                {
                    GB_deduction_forNxtPrev += 33;
                }
                if (mpanelparent_placement == "First")
                {
                    if (panel_placement == "First")
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                }
                else if (mpanelparent_placement == "Last")
                {
                    if (panel_placement == "Last")
                    {
                        GB_deduction_forNxtPrev += 33;
                    }
                }
            }

            if (divArtNo_LeftorTop == Divider_ArticleNo._7536)
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._7538)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
            }
            else if (divArtNo_LeftorTop == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    GB_deduction_forLeftorTopRightorBot += 33;
                }
            }

            if (divArtNo_RightorBot == Divider_ArticleNo._7536)
            {
                GB_deduction_forLeftorTopRightorBot += (42 / 2);
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._7538)
            {
                GB_deduction_forLeftorTopRightorBot += (72 / 2);
            }
            else if (divArtNo_RightorBot == Divider_ArticleNo._None)
            {
                if (mpanel_placement == "First" ||
                    mpanel_placement == "Last" ||
                    mpanel_placement == "")
                {
                    GB_deduction_forLeftorTopRightorBot += 33;
                }
            }

            if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7536)
            {
                GB_deduction_lvl3 += (42 / 2);
            }
            else if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._7538)
            {
                GB_deduction_lvl3 += (72 / 2);
            }
            else if (divArtNo_LeftorTop_lvl3 == Divider_ArticleNo._None)
            {
                //if (mpanelparent_placement == "Last")
                //{
                //    GB_deduction_lvl3 += 33;
                //}
            }

            if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._7536)
            {
                GB_deduction_lvl3 += (42 / 2);
            }
            else if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._7538)
            {
                GB_deduction_lvl3 += (72 / 2);
            }
            else if (divArtNo_RightorBot_lvl3 == Divider_ArticleNo._None)
            {
                //if (mpanelparent_placement == "First")
                //{
                //    GB_deduction_lvl3 += 33;
                //}
            }

            if (div_type == DividerType.Mullion)
            {
                deduction_for_wd = GB_deduction_forNxtPrev;
                deduction_for_ht = GB_deduction_forLeftorTopRightorBot;
            }
            else if (div_type == DividerType.Transom)
            {
                deduction_for_wd = GB_deduction_forLeftorTopRightorBot;
                deduction_for_ht = GB_deduction_forNxtPrev;
            }

            if (div_type_lvl3 == DividerType.Mullion.ToString())
            {
                deduction_for_wd += GB_deduction_lvl3;
            }
            else if (div_type_lvl3 == DividerType.Transom.ToString())
            {
                deduction_for_ht += GB_deduction_lvl3;
            }

            MPanel_OriginalGlassWidth = (MPanel_OriginalDisplayWidth - deduction_for_wd) - 6;
            MPanel_OriginalGlassHeight = (MPanel_OriginalDisplayHeight - deduction_for_ht) - 6;
        }

        public void AdjustPropertyPanelHeight(string objtype, string mode)
        {
            if (objtype == "Panel")
            {
                if (mode == "add")
                {
                    MPanelProp_Height += constants.panel_propertyHeight_default;
                }
                if (mode == "minus")
                {
                    MPanelProp_Height -= constants.panel_propertyHeight_default;
                }
                else if (mode == "addRotary")
                {
                    MPanelProp_Height += constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "minusRotary")
                {
                    MPanelProp_Height -= constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "addRotoswing")
                {
                    MPanelProp_Height += constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "minusRotoswing")
                {
                    MPanelProp_Height -= constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "addRio")
                {
                    MPanelProp_Height += constants.panel_property_rioOptionsheight_default;
                }
                else if (mode == "minusRio")
                {
                    MPanelProp_Height -= constants.panel_property_rioOptionsheight_default;
                }
                else if (mode == "addRotoline")
                {
                    MPanelProp_Height += constants.panel_property_rotolineOptionsheight_default;
                }
                else if (mode == "minusRotoline")
                {
                    MPanelProp_Height -= constants.panel_property_rotolineOptionsheight_default;
                }
                else if (mode == "addMVD")
                {
                    MPanelProp_Height += constants.panel_property_mvdOptionsheight_default;
                }
                else if (mode == "minusMVd")
                {
                    MPanelProp_Height -= constants.panel_property_mvdOptionsheight_default;
                }
                else if (mode == "addCmbMotorized")
                {
                    MPanelProp_Height += constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "minusCmbMotorized")
                {
                    MPanelProp_Height -= constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "addHandle")
                {
                    MPanelProp_Height += constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "minusHandle")
                {
                    MPanelProp_Height -= constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "addChkMotorized")
                {
                    MPanelProp_Height += constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "minusChkMotorized")
                {
                    MPanelProp_Height -= constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "addSash")
                {
                    MPanelProp_Height += constants.panel_property_sashPanelHeight;
                }
                else if (mode == "minusSash")
                {
                    MPanelProp_Height -= constants.panel_property_sashPanelHeight;
                }
                else if (mode == "addGlass")
                {
                    MPanelProp_Height += constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "minusGlass")
                {
                    MPanelProp_Height -= constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "addExtension")
                {
                    MPanelProp_Height += constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "minusExtension")
                {
                    MPanelProp_Height -= constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "addExtensionField")
                {
                    MPanelProp_Height += constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "minusExtensionField")
                {
                    MPanelProp_Height -= constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "addCornerDrive")
                {
                    MPanelProp_Height += constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "minusCornerDrive")
                {
                    MPanelProp_Height -= constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "addGeorgianBar")
                {
                    MPanelProp_Height += constants.panel_property_georgianBarHeight;
                }
                else if (mode == "minusGeorgianBar")
                {
                    MPanelProp_Height -= constants.panel_property_georgianBarHeight;
                }
                else if (mode == "addEspagnolette")
                {
                    MPanelProp_Height += constants.panel_property_espagnoletteOptionsheight_default;
                }
                else if (mode == "minusEspagnolette")
                {
                    MPanelProp_Height -= constants.panel_property_espagnoletteOptionsheight_default;
                }
                else if (mode == "addHinge")
                {
                    MPanelProp_Height += constants.panel_property_HingeOptionsheight;
                }
                else if (mode == "minusHinge")
                {
                    MPanelProp_Height -= constants.panel_property_HingeOptionsheight;
                }
                else if (mode == "addCenterHinge")
                {
                    MPanelProp_Height += constants.panel_property_CenterHingeOptionsheight;
                }
                else if (mode == "minusCenterHinge")
                {
                    MPanelProp_Height -= constants.panel_property_CenterHingeOptionsheight;
                }
                else if (mode == "addNTCenterHinge")
                {
                    MPanelProp_Height += constants.panel_property_NTCenterHingeOptionsheight;
                }
                else if (mode == "minusNTCenterHinge")
                {
                    MPanelProp_Height -= constants.panel_property_NTCenterHingeOptionsheight;
                }
                else if (mode == "add2dHingeField")
                {
                    MPanelProp_Height += constants.panel_property_2dHingeOptionsheight;
                }
                else if (mode == "minus2dHingeField")
                {
                    MPanelProp_Height -= constants.panel_property_2dHingeOptionsheight;
                }
                else if (mode == "add3dHinge")
                {
                    MPanelProp_Height += constants.panel_property_3dHingeOptionsheight;
                }
                else if (mode == "minus3dHinge")
                {
                    MPanelProp_Height -= constants.panel_property_3dHingeOptionsheight;
                }
                else if (mode == "addMC")
                {
                    MPanelProp_Height += constants.panel_property_MiddleCloserOptionsheight;
                }
                else if (mode == "minusMC")
                {
                    MPanelProp_Height -= constants.panel_property_MiddleCloserOptionsheight;
                }
                else if (mode == "addSlidingType")
                {
                    MPanelProp_Height += constants.panel_property_SlidingTypeOptionsheight;
                }
                else if (mode == "minusSlidingType")
                {
                    MPanelProp_Height -= constants.panel_property_SlidingTypeOptionsheight;
                }
                else if (mode == "addRollerType")
                {
                    MPanelProp_Height += constants.panel_property_RollerTypeOptionsheight;
                }
                else if (mode == "minusRollerType")
                {
                    MPanelProp_Height -= constants.panel_property_RollerTypeOptionsheight;
                }
                else if (mode == "addAluminumTrackQty")
                {
                    MPanelProp_Height += constants.panel_property_AluminumTrackQtyOptionsheight;
                }
                else if (mode == "minusAluminumTrackQty")
                {
                    MPanelProp_Height -= constants.panel_property_AluminumTrackQtyOptionsheight;
                }
                else if (mode == "addDHandle")
                {
                    MPanelProp_Height += constants.panel_property_DHandleOptionsheight;
                }
                else if (mode == "minusDHandle")
                {
                    MPanelProp_Height -= constants.panel_property_DHandleOptionsheight;
                }
                else if (mode == "addDHandleIOLocking")
                {
                    MPanelProp_Height += constants.panel_property_DhandleIOLockingOptionsheight;
                }
                else if (mode == "minusDHandleIOLocking")
                {
                    MPanelProp_Height -= constants.panel_property_DhandleIOLockingOptionsheight;
                }
                else if (mode == "addDummyDHandle")
                {
                    MPanelProp_Height += constants.panel_property_DummyDHandleOptionsheight;
                }
                else if (mode == "minusDummyDHandle")
                {
                    MPanelProp_Height -= constants.panel_property_DummyDHandleOptionsheight;
                }
                else if (mode == "addPopUpHandle")
                {
                    MPanelProp_Height += constants.panel_property_PopUpHandleOptionsheight;
                }
                else if (mode == "minusPopUpHandle")
                {
                    MPanelProp_Height -= constants.panel_property_PopUpHandleOptionsheight;
                }
                else if (mode == "addRotoswingForSliding")
                {
                    MPanelProp_Height += constants.panel_property_RotoswingForSlidingOptionsheight;
                }
                else if (mode == "minusRotoswingForSliding")
                {
                    MPanelProp_Height -= constants.panel_property_RotoswingForSlidingOptionsheight;
                }
                else if (mode == "addLouverBlades")
                {
                    MPanelProp_Height += constants.panel_property_LouverBladesOptionsheight;
                }
                else if (mode == "minusLouverBlades")
                {
                    MPanelProp_Height -= constants.panel_property_LouverBladesOptionsheight;
                }
            }
            else if (objtype == "Div")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= constants.div_propertyheight_default;
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += constants.div_propertyheight_default;
                }
                else if (mode == "addCladding")
                {
                    MPanelProp_Height += constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "minusCladding")
                {
                    MPanelProp_Height -= constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "addPanelAddCladding")
                {
                    MPanelProp_Height += constants.div_property_pnlAddcladdingOptionsHeight;
                }
                else if (mode == "minusPanelAddCladding")
                {
                    MPanelProp_Height -= constants.div_property_pnlAddcladdingOptionsHeight;
                }
                else if (mode == "addDivArt")
                {
                    MPanelProp_Height += constants.div_property_divArtOptionsHeight;
                }
                else if (mode == "minusDivArt")
                {
                    MPanelProp_Height -= constants.div_property_divArtOptionsHeight;
                }
                else if (mode == "addDM")
                {
                    MPanelProp_Height += constants.div_property_DMArtOptionsHeight;
                }
                else if (mode == "minusDM")
                {
                    MPanelProp_Height -= constants.div_property_DMArtOptionsHeight;
                }
                else if (mode == "addLeverEspag")
                {
                    MPanelProp_Height += constants.div_property_leverEspagOptionsHeight;
                }
                else if (mode == "minusLeverEspag")
                {
                    MPanelProp_Height -= constants.div_property_leverEspagOptionsHeight;
                }
                else if (mode == "addCladdingBracket")
                {
                    MPanelProp_Height += constants.div_property_claddingBracketOptionsHeight;
                }
                else if (mode == "minusCladdingBracket")
                {
                    MPanelProp_Height -= constants.div_property_claddingBracketOptionsHeight;
                }
                else if (mode == "addSlidingType")
                {
                    MPanelProp_Height += constants.panel_property_SlidingTypeOptionsheight;
                }
                else if (mode == "minusSlidingType")
                {
                    MPanelProp_Height -= constants.panel_property_SlidingTypeOptionsheight;
                }

            }
            else if (objtype == "Mpanel")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= constants.mpnl_propertyHeight_default; // (129 + 3); // +3 for MultiPanelProperties' Margin
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += constants.mpnl_propertyHeight_default; // (129 + 3); // +3 for MultiPanelProperties' Margin
                }
            }
        }

        public void DeductPropertyPanelHeight(int propertyHeight)
        {
            MPanelProp_Height -= propertyHeight;
        }

        public void Fit_MyControls_ToBindDimensions(IMultiPanelModel prev_mpanel, IMultiPanelModel nxt_mpnl, IPanelModel prev_pnl, IPanelModel nxt_pnl)
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHt_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_HeightToBind + pnl.Panel_MarginToBind.Top + pnl.Panel_MarginToBind.Bottom),
                        totalHt_divModel = MPanelLst_Divider.Sum(div => div.Div_HeightToBind),
                        totalHt_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_HeightToBind);

                    int totalHeight_Controls = totalHt_panelModel + totalHt_divModel + totalHt_MpanelModel;
                    int diff_MPanelHt_VS_MyCtrlsHeight = MPanel_HeightToBind - totalHeight_Controls;

                    if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.Panel_HeightToBind++;
                                        diff_MPanelHt_VS_MyCtrlsHeight--;
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanel_HeightToBind++;
                                        diff_MPanelHt_VS_MyCtrlsHeight--;
                                    }

                                }
                            }
                        }
                    }
                    else if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.Panel_HeightToBind--;
                                        diff_MPanelHt_VS_MyCtrlsHeight++;
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanel_HeightToBind--;
                                        diff_MPanelHt_VS_MyCtrlsHeight++;
                                    }

                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalWd_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_WidthToBind + pnl.Panel_MarginToBind.Right + pnl.Panel_MarginToBind.Left),
                        totalWd_divModel = MPanelLst_Divider.Sum(div => div.Div_WidthToBind),
                        totalWd_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_WidthToBind);

                    int totalWidth_Controls = totalWd_panelModel + totalWd_divModel + totalWd_MpanelModel;

                    int diff_MPanelWd_VS_MyCtrlsWidth = MPanel_WidthToBind - totalWidth_Controls;

                    if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.Panel_WidthToBind++;
                                        diff_MPanelWd_VS_MyCtrlsWidth--;
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanel_WidthToBind++;
                                        diff_MPanelWd_VS_MyCtrlsWidth--;
                                    }

                                }
                            }
                        }
                    }
                    else if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.Panel_WidthToBind--;
                                        diff_MPanelWd_VS_MyCtrlsWidth++;
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanel_WidthToBind--;
                                        diff_MPanelWd_VS_MyCtrlsWidth++;
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        public void Fit_EqualPanel_ToBindDimensions()
        {
            bool isEqual = isDisplaySizeEqual();
            int totalCount_objs_to_accomodate = 0;
            if (MPanel_DividerEnabled)
            {
                totalCount_objs_to_accomodate = (MPanel_Divisions * 2) + 1;
            }
            else
            {
                totalCount_objs_to_accomodate = MPanel_Divisions + 1;
            }


          
            if (isEqual && (MPanelLst_Objects.Count() >= totalCount_objs_to_accomodate))
            {
                int divSize = 0;
                if (MPanel_FrameModelParent.Frame_Type.ToString().Contains("Window"))
                {
                    divSize = 26;
                }
                else if (MPanel_FrameModelParent.Frame_Type.ToString().Contains("Door"))
                {
                    divSize = 33;
                }
                int totalPanelCount = MPanel_Divisions + 1;
                foreach (IPanelModel pnl in MPanelLst_Panel)
                {
                    if (MPanel_Type == "Mullion")
                    {
                        string disp_wd_decimal = MPanel_DisplayWidth + "." + MPanel_DisplayWidthDecimal;
                        decimal displayWidthDecimal = 0;
                        decimal displayWidth = 0;
                        displayWidth += Convert.ToDecimal(pnl.Panel_DisplayWidth + "." + pnl.Panel_DisplayWidthDecimal);
                        displayWidthDecimal = Convert.ToDecimal("0." + pnl.Panel_DisplayWidthDecimal);

                        decimal DisplayWD_dec;
                        DisplayWD_dec = Convert.ToDecimal(disp_wd_decimal) / totalPanelCount;
                        //DisplayWD_dec = displayWidthDecimal;
                        int suggest_DisplayWD = (int)Math.Truncate(DisplayWD_dec);
                        int EqualDisplayWD = (int)MPanel_DisplayWidth / totalPanelCount;

                        if (MPanel_DividerEnabled)
                        {
                            int EqualPanelWD = (((MPanel_Width - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                            pnl.Panel_Width = EqualPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                            //pnl.Panel_Width = (((MPanel_Width - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                        }
                        else if (!MPanel_DividerEnabled)
                        {
                            int EqualPanelWD = ((MPanel_Width - 20) / totalPanelCount);
                            pnl.Panel_Width = EqualPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                        }
                    }
                    else if (MPanel_Type == "Transom")
                    {
                        string disp_ht_decimal = MPanel_DisplayHeight + "." + MPanel_DisplayHeightDecimal;
                        decimal displayHeightDecimal = 0;
                        decimal displayHeight = 0;
                        displayHeight += Convert.ToDecimal(pnl.Panel_DisplayHeight + "." + pnl.Panel_DisplayHeightDecimal);
                        displayHeightDecimal = Convert.ToDecimal("0." + pnl.Panel_DisplayHeightDecimal);

                        decimal DisplayHT_dec;
                        DisplayHT_dec = Convert.ToDecimal(disp_ht_decimal) / totalPanelCount;
                        //DisplayHT_dec += displayHeightDecimal;
                        int suggest_DisplayHT = (int)Math.Truncate(DisplayHT_dec);
                        int EqualDisplayHT = (int)MPanel_DisplayHeight / totalPanelCount;

                        if (MPanel_DividerEnabled)
                        {
                            int EqualPanelHT = (((MPanel_Height - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                            pnl.Panel_Height = EqualPanelHT - (EqualDisplayHT - suggest_DisplayHT);
                            //pnl.Panel_Height = (((MPanel_Height - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                        }
                        else if (!MPanel_DividerEnabled)
                        {
                            int EqualPanelHT = ((MPanel_Height - 20) / totalPanelCount);
                            pnl.Panel_Height = EqualPanelHT - (EqualDisplayHT - suggest_DisplayHT);
                        }
                    }

                }

                //Multi
                foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                {
                    if (MPanel_Type == "Mullion")
                    {
                        string disp_wd_decimal = MPanel_DisplayWidth + "." + MPanel_DisplayWidthDecimal;
                        decimal displayWidthDecimal = 0;
                        decimal displayWidth = 0;
                        displayWidth += Convert.ToDecimal(mpnl.MPanel_DisplayWidth + "." + mpnl.MPanel_DisplayWidthDecimal);
                        displayWidthDecimal = Convert.ToDecimal("0." + mpnl.MPanel_DisplayWidthDecimal);

                        decimal DisplayWD_dec;
                        DisplayWD_dec = Convert.ToDecimal(disp_wd_decimal) / totalPanelCount;
                        DisplayWD_dec += displayWidthDecimal;
                        int suggest_DisplayWD = (int)Math.Truncate(DisplayWD_dec);
                        int EqualDisplayWD = (int)MPanel_DisplayWidth / totalPanelCount;

                        if (MPanel_DividerEnabled)
                        {
                            int EqualMPanelWD = ((MPanel_Width) - (divSize * MPanel_Divisions)) / totalPanelCount;
                            mpnl.MPanel_Width = EqualMPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                            //pnl.MPanel_Width = (((MPanel_Width - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                        }
                        else if (!MPanel_DividerEnabled)
                        {
                            int EqualMPanelWD = (MPanel_Width / totalPanelCount);
                            mpnl.MPanel_Width = EqualMPanelWD - (EqualDisplayWD - suggest_DisplayWD);
                        }
                    }
                    else if (MPanel_Type == "Transom")
                    {
                        string disp_ht_decimal = MPanel_DisplayHeight + "." + MPanel_DisplayHeightDecimal;
                        decimal displayHeightDecimal = 0;
                        decimal displayHeight = 0;
                        displayHeight += Convert.ToDecimal(mpnl.MPanel_DisplayHeight + "." + mpnl.MPanel_DisplayHeightDecimal);
                        displayHeightDecimal = Convert.ToDecimal("0." + mpnl.MPanel_DisplayHeightDecimal);

                        decimal DisplayHT_dec;
                        DisplayHT_dec = Convert.ToDecimal(disp_ht_decimal) / totalPanelCount;
                        DisplayHT_dec += displayHeightDecimal;
                        int suggest_DisplayHT = (int)Math.Truncate(DisplayHT_dec);
                        int EqualDisplayHT = (int)MPanel_DisplayHeight / totalPanelCount;

                        if (MPanel_DividerEnabled)
                        {
                            int EqualMPanelHT = ((MPanel_Height - (divSize * MPanel_Divisions)) / totalPanelCount);
                            mpnl.MPanel_Height = EqualMPanelHT - (EqualDisplayHT - suggest_DisplayHT);
                            //pnl.Panel_Height = (((MPanel_Height - 20) - (divSize * MPanel_Divisions)) / totalPanelCount);
                        }
                        else if (!MPanel_DividerEnabled)
                        {
                            int EqualMPanelHT = (MPanel_Height / totalPanelCount);
                            mpnl.MPanel_Height = EqualMPanelHT - (EqualDisplayHT - suggest_DisplayHT);
                        }
                    }

                }
                Fit_PanelDimensions();
                foreach (IPanelModel pnl in MPanelLst_Panel)
                {
                    pnl.SetDimensionsToBind_using_ZoomPercentage();
                    pnl.Imager_SetDimensionsToBind_using_ZoomPercentage();
                }
                Fit_MyControls_ToBindDimensions();
                Fit_MyControls_ImagersToBindDimensions();
            }

        }

        public void Fit_PanelDimensions()
        {
            bool isEqual = isDisplaySizeEqual();
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHt_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_Height + pnl.Panel_Margin.Top + pnl.Panel_Margin.Bottom),
                        totalHt_divModel = MPanelLst_Divider.Sum(div => div.Div_Height),
                        totalHt_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_Height);

                    int totalHeight_Controls = totalHt_panelModel + totalHt_divModel + totalHt_MpanelModel;
                    int diff_MPanelHt_VS_MyCtrlsHeight = MPanel_Height - totalHeight_Controls;

                    if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.Panel_Height++;
                                        diff_MPanelHt_VS_MyCtrlsHeight--;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.Panel_Height++;
                                            diff_MPanelHt_VS_MyCtrlsHeight--;
                                        }
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight > 0)
                                {
                                    mpnl.MPanel_Height++;
                                    diff_MPanelHt_VS_MyCtrlsHeight--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                    {
                        while (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.Panel_Height--;
                                        diff_MPanelHt_VS_MyCtrlsHeight++;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.Panel_Height--;
                                            diff_MPanelHt_VS_MyCtrlsHeight++;
                                        }
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelHt_VS_MyCtrlsHeight < 0)
                                {
                                    mpnl.MPanel_Height--;
                                    diff_MPanelHt_VS_MyCtrlsHeight++;
                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalWd_panelModel = MPanelLst_Panel.Sum(pnl => pnl.Panel_Width + pnl.Panel_Margin.Right + pnl.Panel_Margin.Left),
                        totalWd_divModel = MPanelLst_Divider.Sum(div => div.Div_Width),
                        totalWd_MpanelModel = MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_Width);

                    int totalWidth_Controls = totalWd_panelModel + totalWd_divModel + totalWd_MpanelModel;

                    int diff_MPanelWd_VS_MyCtrlsWidth = MPanel_Width - totalWidth_Controls;

                    if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.Panel_Width++;
                                        diff_MPanelWd_VS_MyCtrlsWidth--;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.Panel_Width++;
                                            diff_MPanelWd_VS_MyCtrlsWidth--;
                                        }
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth > 0)
                                {
                                    mpnl.MPanel_Width++;
                                    diff_MPanelWd_VS_MyCtrlsWidth--;
                                }
                            }
                        }
                    }
                    else if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                    {
                        while (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    if (isEqual)
                                    {
                                        pnl.Panel_Width--;
                                        diff_MPanelWd_VS_MyCtrlsWidth++;
                                    }
                                    else
                                    {
                                        if (MPanelLst_Panel.LastOrDefault() == pnl)
                                        {
                                            pnl.Panel_Width--;
                                            diff_MPanelWd_VS_MyCtrlsWidth++;
                                        }
                                    }

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelWd_VS_MyCtrlsWidth < 0)
                                {
                                    mpnl.MPanel_Width--;
                                    diff_MPanelWd_VS_MyCtrlsWidth++;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool isDisplaySizeEqual()
        {
            bool isEqual = false;
            if (MPanelLst_Panel.Count == 0 && MPanelLst_MultiPanel.Count > 0 ||
               MPanelLst_Panel.Count > 0 && MPanelLst_MultiPanel.Count == 0)
            {

                if (MPanel_Type == "Mullion")
                {
                    if (MPanelLst_Panel.Count > 0)
                    {
                        if (MPanelLst_Panel.TrueForAll(i => i.Panel_DisplayWidth.Equals(MPanelLst_Panel.FirstOrDefault().Panel_DisplayWidth)))
                        {
                            isEqual = true;
                        }
                    }

                    if (MPanelLst_MultiPanel.Count > 0)
                    {
                        if (MPanelLst_MultiPanel.TrueForAll(i => i.MPanel_DisplayWidth.Equals(MPanelLst_MultiPanel.FirstOrDefault().MPanel_DisplayWidth)))
                        {
                            isEqual = true;
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanelLst_Panel.Count > 0)
                    {
                        if (MPanelLst_Panel.TrueForAll(i => i.Panel_DisplayHeight.Equals(MPanelLst_Panel.FirstOrDefault().Panel_DisplayHeight)))
                        {
                            isEqual = true;
                        }
                    }
                    if (MPanelLst_MultiPanel.Count > 0)
                    {
                        if (MPanelLst_MultiPanel.TrueForAll(i => i.MPanel_DisplayHeight.Equals(MPanelLst_MultiPanel.FirstOrDefault().MPanel_DisplayHeight)))
                        {
                            isEqual = true;
                        }
                    }
                }
            }
            return isEqual;
        }

        public void Fit_MyControls_ImagersToBindDimensions(IMultiPanelModel prev_mpanel, IMultiPanelModel nxt_mpnl, IPanelModel prev_pnl, IPanelModel nxt_pnl)
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {

                    int totalHeight_Imagers = MPanelLst_Panel.Sum(pnl => pnl.PanelImageRenderer_Height) +
                                              MPanelLst_Divider.Sum(div => div.DivImageRenderer_Height) +
                                              MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanelImageRenderer_Height);
                    int diff_MPanelImagerHt_VS_MyImagersHeight = MPanelImageRenderer_Height - totalHeight_Imagers;
                    if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                    {
                        while (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.PanelImageRenderer_Height++;
                                        diff_MPanelImagerHt_VS_MyImagersHeight--;
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight > 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanelImageRenderer_Height++;
                                        diff_MPanelImagerHt_VS_MyImagersHeight--;
                                    }
                                   
                                }
                            }
                        }
                    }
                    else if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                    {
                        while (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.PanelImageRenderer_Height--;
                                        diff_MPanelImagerHt_VS_MyImagersHeight++;
                                    }
                                   
                                   

                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerHt_VS_MyImagersHeight < 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanelImageRenderer_Height--;
                                        diff_MPanelImagerHt_VS_MyImagersHeight++;
                                    }
                                   
                                }
                            }
                        }
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    int totalWidth_Imagers = MPanelLst_Panel.Sum(pnl => pnl.PanelImageRenderer_Width) +
                                             MPanelLst_Divider.Sum(div => div.DivImageRenderer_Width) +
                                             MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanelImageRenderer_Width);
                    int diff_MPanelImagerWd_VS_MyImagersWidth = MPanelImageRenderer_Width - totalWidth_Imagers;
                    if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                    {
                        while (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.PanelImageRenderer_Width++;
                                        diff_MPanelImagerWd_VS_MyImagersWidth--;
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth > 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanelImageRenderer_Width++;
                                        diff_MPanelImagerWd_VS_MyImagersWidth--;
                                    }
                                    
                                }
                            }
                        }
                    }
                    else if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                    {
                        while (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                        {
                            foreach (IPanelModel pnl in MPanelLst_Panel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                                {
                                    if (prev_pnl == pnl || nxt_pnl == pnl)
                                    {
                                        pnl.PanelImageRenderer_Width--;
                                        diff_MPanelImagerWd_VS_MyImagersWidth++;
                                    }
                                }
                            }
                            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                            {
                                if (diff_MPanelImagerWd_VS_MyImagersWidth < 0)
                                {
                                    if (prev_mpanel == mpnl || nxt_mpnl == mpnl)
                                    {
                                        mpnl.MPanelImageRenderer_Width--;
                                        diff_MPanelImagerWd_VS_MyImagersWidth++;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        #endregion

        public MultiPanelModel(int mpanelID,
                               string mpanelName,
                               int mpanelWd,
                               int mpanelHt,
                               DockStyle mpanelDock,
                               bool mpanelVisible,
                               FlowDirection mpanelFlowDirection,
                               Control mpanelParent,
                               UserControl mpanelFrameGroup,
                               int mpanelDivisions,
                               List<IPanelModel> mpanelLstPanel,
                               List<IDividerModel> mpanelLstDivider,
                               List<IMultiPanelModel> mpanelLstMultiPanel,
                               int mpanelIndexInsideMPanel,
                               List<Control> mpanelLstObjects,
                               List<Control> mpanelLstImagers,
                               IMultiPanelModel mpanelParentModel,
                               float mpanelImageRendererZoom,
                               float mpanelZoom,
                               IFrameModel mpanelFrameModelParent,
                               int mpanelDisplayWidth,
                               int mpanelDisplayWidthDecimal,
                               int mpanelDisplayHeight,
                               int mpanelDisplayHeightDecimal,
                               int mpanelStackNo)
        {
            MPanel_ID = mpanelID;
            MPanel_Name = mpanelName;
            MPanel_Width = mpanelWd;
            MPanel_Height = mpanelHt;
            MPanel_Dock = mpanelDock;
            MPanel_Visibility = mpanelVisible;
            MPanel_FlowDirection = mpanelFlowDirection;
            MPanel_Parent = mpanelParent;
            MPanel_FrameGroup = mpanelFrameGroup;
            MPanel_Divisions = mpanelDivisions;
            MPanelLst_Panel = mpanelLstPanel;
            MPanelLst_Divider = mpanelLstDivider;
            MPanelLst_MultiPanel = mpanelLstMultiPanel;
            MPanel_Index_Inside_MPanel = mpanelIndexInsideMPanel;
            MPanelProp_Height = 129;
            MPanelLst_Objects = mpanelLstObjects;
            MPanelLst_Imagers = mpanelLstImagers;
            MPanel_ParentModel = mpanelParentModel;
            MPanel_DividerEnabled = true;
            MPanelImageRenderer_Zoom = mpanelImageRendererZoom;
            MPanel_Zoom = mpanelZoom;
            MPanel_FrameModelParent = mpanelFrameModelParent;
            MPanel_DisplayWidth = mpanelDisplayWidth;
            MPanel_DisplayWidthDecimal = mpanelDisplayWidthDecimal;
            MPanel_DisplayHeight = mpanelDisplayHeight;
            MPanel_DisplayHeightDecimal = mpanelDisplayHeightDecimal;
            MPanel_OriginalDisplayWidth = mpanelDisplayWidth;
            MPanel_OriginalDisplayWidthDecimal = mpanelDisplayWidthDecimal;
            MPanel_OriginalDisplayHeight = mpanelDisplayHeight;
            MPanel_OriginalDisplayHeightDecimal = mpanelDisplayHeightDecimal;
            MPanel_StackNo = mpanelStackNo;
            MPanel_CmenuDeleteVisibility = true;

            if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Window)
            {
                _mpnl_add = 8;
            }
            else if (MPanel_FrameModelParent.Frame_Type == FrameModel.Frame_Padding.Door)
            {
                _mpnl_add = 10;
            }
        }
    }
}
