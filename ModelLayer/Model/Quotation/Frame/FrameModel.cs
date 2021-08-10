﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Divider;
using static EnumerationTypeLayer.EnumerationTypes;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Variables;

namespace ModelLayer.Model.Quotation.Frame
{
    public class FrameModel : IFrameModel, INotifyPropertyChanged
    {
        public enum Frame_Padding
        {
            Window = 26,
            Door = 33,
            Concrete
        }

        private static int _frame_basicDeduction = 10;
        public int Frame_BasicDeduction
        {
            get
            {
                return _frame_basicDeduction;
            }
        }

        private ConstantVariables constants = new ConstantVariables();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private int _frameID;
        [Required(ErrorMessage = "Frame_ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value for Frame ID bigger than or equal {1}")]
        public int Frame_ID { get; set; }

        private string _frameName;
        public string Frame_Name
        {
            get { return _frameName; }
            set { _frameName = value; NotifyPropertyChanged(); }
        }

        private int _frameWidth;
        [Required(ErrorMessage = "Frame_Width is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Width bigger than or equal {1}")]
        public int Frame_Width
        {
            get { return _frameWidth; }
            set
            {
                _frameWidth = value;
                FrameImageRenderer_Width = Convert.ToInt32(value * FrameImageRenderer_Zoom);
                Frame_WidthToBind = (int)(value * Frame_Zoom);
                NotifyPropertyChanged();
            }
        }

        private int _frameWidth_toBind;
        public int Frame_WidthToBind
        {
            get
            {
                return _frameWidth_toBind;
            }
            set
            {
                _frameWidth_toBind = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameHeight;
        [Required(ErrorMessage = "Frame_Height is Required")]
        [Range(400, int.MaxValue, ErrorMessage = "Please enter a value for Frame Height bigger than or equal {1}")]
        public int Frame_Height
        {
            get { return _frameHeight; }
            set
            {
                _frameHeight = value;
                FrameImageRenderer_Height = Convert.ToInt32(value * FrameImageRenderer_Zoom);
                Frame_HeightToBind = (int)(value * Frame_Zoom);
                NotifyPropertyChanged();
            }
        }

        private int _frameHeight_toBind;
        public int Frame_HeightToBind
        {
            get
            {
                return _frameHeight_toBind;
            }
            set
            {
                _frameHeight_toBind = value;
                NotifyPropertyChanged();
            }
        }

        private int[] _arr_padding_norm = { 26, 33, 13, 15, 08, 10, 05, 07 }; //even index means window, odd index means door
        private int[] _arr_padding_withmpnl = { 16, 23, 08, 12, 05, 07, 03, 06 }; //even index means window, odd index means door

        public int[] Arr_padding_norm
        {
            get
            {
                return _arr_padding_norm;
            }
        }

        public int[] Arr_padding_withmpnl
        {
            get
            {
                return _arr_padding_withmpnl;
            }
        }

        private Frame_Padding _frameType;
        public Frame_Padding Frame_Type
        {
            get { return _frameType; }
            set
            {
                _frameType = value;

                if (_deductFramePadding_bool)
                {
                    FramePadding_Deduct();
                }
                else
                {
                    FramePadding_Default();
                }
                NotifyPropertyChanged();
            }
        }

        private bool _frameVisible;
        public bool Frame_Visible
        {
            get { return _frameVisible; }
            set { _frameVisible = value; }
            //NotifyPropertyChanged(); }
        }

        private Padding _framePadding;
        public Padding Frame_Padding_int
        {
            get { return _framePadding; }
            set
            {
                if (value.All == 1)
                {
                    _framePadding = new Padding(2);
                }
                else
                {
                    _framePadding = value;
                }
                NotifyPropertyChanged();
            }
        }

        private Padding _frameImagePadding;
        public Padding FrameImageRenderer_Padding_int
        {
            get { return _frameImagePadding; }
            set { _frameImagePadding = value; NotifyPropertyChanged(); }
        }

        private int _framePropHeight;
        public int FrameProp_Height
        {
            get { return _framePropHeight; }
            set { _framePropHeight = value; NotifyPropertyChanged(); }
        }

        public List<IPanelModel> Lst_Panel { get; set; }
        public List<IMultiPanelModel> Lst_MultiPanel { get; set; }
        public List<IDividerModel> Lst_Divider { get; set; }

        private int _frameImage_Height;
        public int FrameImageRenderer_Height
        {
            get
            {
                return _frameImage_Height;
            }

            set
            {
                _frameImage_Height = value;
                NotifyPropertyChanged();
            }
        }

        private int _frameImage_Width;
        public int FrameImageRenderer_Width
        {
            get
            {
                return _frameImage_Width;
            }

            set
            {
                _frameImage_Width = value;
                NotifyPropertyChanged();
            }
        }

        private float _frameImage_Zoom;
        public float FrameImageRenderer_Zoom
        {
            get
            {
                return _frameImage_Zoom;
            }

            set
            {
                _frameImage_Zoom = value;
                FrameImageRenderer_Width = Convert.ToInt32(Frame_Width * value);
                FrameImageRenderer_Height = Convert.ToInt32(Frame_Height * value);

                if (_deductFramePadding_bool)
                {
                    FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type - _frame_basicDeduction) * FrameImageRenderer_Zoom));
                }
                else
                {
                    FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type) * FrameImageRenderer_Zoom));
                }
                NotifyPropertyChanged();
            }
        }

        private float _frameZoom;
        public float Frame_Zoom
        {
            get
            {
                return _frameZoom;
            }

            set
            {
                _frameZoom = value;
                Frame_WidthToBind = (int)(Frame_Width * value);
                Frame_HeightToBind = (int)(Frame_Height * value);

                if (_deductFramePadding_bool)
                {
                    FramePadding_Deduct();
                }
                else
                {
                    FramePadding_Default();
                }

                SetZoom();
            }
        }

        private void SetZoom()
        {
            foreach (IMultiPanelModel mpnl in Lst_MultiPanel)
            {
                mpnl.MPanel_Zoom = Frame_Zoom;
            }

            foreach (IPanelModel pnl in Lst_Panel)
            {
                pnl.Panel_Zoom = Frame_Zoom;
            }
        }

        private int _frameDeduction = 0;
        public int Frame_Deduction
        {
            get
            {
                return _frameDeduction;
            }
        }

        private void FramePadding_Deduct()
        {
            _frameDeduction = (int)(_frame_basicDeduction * Frame_Zoom);
            Frame_Padding_int = new Padding((int)((int)Frame_Type * Frame_Zoom) - _frameDeduction);
            FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type - _frame_basicDeduction) * FrameImageRenderer_Zoom));
        }

        private void FramePadding_Default()
        {
            Frame_Padding_int = new Padding((int)((int)Frame_Type * Frame_Zoom));
            FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type) * FrameImageRenderer_Zoom));
        }

        private bool _deductFramePadding_bool;
        public void SetDeductFramePadding(bool mode)
        {
            _deductFramePadding_bool = mode;
            if (mode == true)
            {
                FramePadding_Deduct();
            }
            else if (mode == false)
            {
                FramePadding_Default();
            }
        }
        
        public IWindoorModel Frame_WindoorModel { get; set; }

        #region Explosion

        private FrameProfile_ArticleNo _frameArtNo;
        public FrameProfile_ArticleNo Frame_ArtNo
        {
            get
            {
                return _frameArtNo;
            }
            set
            {
                _frameArtNo = value;
                if (value == FrameProfile_ArticleNo._7502)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._R676;
                }
                else if (value == FrameProfile_ArticleNo._7507)
                {
                    Frame_ReinfArtNo = FrameReinf_ArticleNo._R677;
                }
                NotifyPropertyChanged();
            }
        }
        public int Frame_ExplosionWidth { get; set; }
        public int Frame_ExplosionHeight { get; set; }

        private FrameReinf_ArticleNo _frameReinfArtNo;
        public FrameReinf_ArticleNo Frame_ReinfArtNo
        {
            get
            {
                return _frameReinfArtNo;
            }
            set
            {
                _frameReinfArtNo = value;
                NotifyPropertyChanged();
            }
        }

        public int Frame_ReinfWidth { get; set; }
        public int Frame_ReinfHeight { get; set; }

        public void SetExplosionValues_Frame()
        {
            Frame_ExplosionWidth = _frameWidth + 5;
            Frame_ExplosionHeight = _frameHeight + 5;

            int reinf_size = 0;
            if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R676)
            {
                reinf_size = 29;
            }
            else if (Frame_ReinfArtNo == FrameReinf_ArticleNo._R677)
            {
                reinf_size = 43;
            }

            Frame_ReinfWidth = _frameWidth - (reinf_size * 2) - 10;
            Frame_ReinfHeight = _frameHeight - (reinf_size * 2) - 10;
        }

        public void AdjustPropertyPanelHeight(string objtype, string mode)
        {
            if (objtype == "Panel")
            {
                if (mode == "add")
                {
                    FrameProp_Height += constants.panel_propertyHeight_default;
                }
                if (mode == "minus")
                {
                    FrameProp_Height -= constants.panel_propertyHeight_default;
                }
                else if (mode == "addRotary")
                {
                    FrameProp_Height += constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "minusRotary")
                {
                    FrameProp_Height -= constants.panel_property_rotaryOptionsheight_default;
                }
                else if (mode == "addRotoswing")
                {
                    FrameProp_Height += constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "minusRotoswing")
                {
                    FrameProp_Height -= constants.panel_property_rotoswingOptionsheight_default;
                }
                else if (mode == "addCmbMotorized")
                {
                    FrameProp_Height += constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "minusCmbMotorized")
                {
                    FrameProp_Height -= constants.panel_property_motorizedCmbOptionsheight;
                }
                else if (mode == "addHandle")
                {
                    FrameProp_Height += constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "minusHandle")
                {
                    FrameProp_Height -= constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "addChkMotorized")
                {
                    FrameProp_Height += constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "minusChkMotorized")
                {
                    FrameProp_Height -= constants.panel_property_motorizedChkOptionsheight;
                }
                else if (mode == "addSash")
                {
                    FrameProp_Height += constants.panel_property_sashPanelHeight;
                }
                else if (mode == "minusSash")
                {
                    FrameProp_Height -= constants.panel_property_sashPanelHeight;
                }
                else if (mode == "addGlass")
                {
                    FrameProp_Height += constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "minusGlass")
                {
                    FrameProp_Height -= constants.panel_property_glassOptionsHeight;
                }
                else if (mode == "addExtension")
                {
                    FrameProp_Height += constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "minusExtension")
                {
                    FrameProp_Height -= constants.panel_property_extensionOptionsheight;
                }
                else if (mode == "addExtensionField")
                {
                    FrameProp_Height += constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "minusExtensionField")
                {
                    FrameProp_Height -= constants.panel_property_extensionFieldsheight;
                }
                else if (mode == "addCornerDrive")
                {
                    FrameProp_Height += constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "minusCornerDrive")
                {
                    FrameProp_Height -= constants.panel_property_cornerDriveOptionsheight_default;
                }
                else if (mode == "addGeorgianBar")
                {
                    FrameProp_Height += constants.panel_property_georgianBarHeight;
                }
                else if (mode == "minusGeorgianBar")
                {
                    FrameProp_Height -= constants.panel_property_georgianBarHeight;
                }
            }
            else if (objtype == "Div")
            {
                if (mode == "delete")
                {
                    FrameProp_Height -= constants.div_propertyheight_default;
                }
                else if (mode == "add")
                {
                    FrameProp_Height += constants.div_propertyheight_default;
                }
                else if (mode == "addCladding")
                {
                    FrameProp_Height += constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "minusCladding")
                {
                    FrameProp_Height -= constants.div_property_claddingOptionsHeight;
                }
                else if (mode == "addPanelAddCladding")
                {
                    FrameProp_Height += constants.div_property_pnlAddcladdingOptionsHeight;
                }
                else if (mode == "minusPanelAddCladding")
                {
                    FrameProp_Height -= constants.div_property_pnlAddcladdingOptionsHeight;
                }
            }
            else if (objtype == "Mpanel")
            {
                if (mode == "delete")
                {
                    FrameProp_Height -= constants.mpnl_propertyHeight_default;
                }
                else if (mode == "add")
                {
                    FrameProp_Height += constants.mpnl_propertyHeight_default;
                }
            }
        }
        #endregion

        public FrameModel(int frameID,
                          string frameName,
                          int frameWd,
                          int frameHt,
                          Frame_Padding frameType,
                          bool frameVisible,
                          List<IPanelModel> lst_panel,
                          List<IMultiPanelModel> lst_mpanel,
                          float frameImagerZoom,
                          List<IDividerModel> lst_divider,
                          float frameZoom,
                          FrameProfile_ArticleNo frameArtNo,
                          IWindoorModel frameWindoorModel)
        {
            Frame_ID = frameID;
            Frame_Name = frameName;
            Frame_Width = frameWd;
            Frame_Height = frameHt;
            Frame_Type = frameType;
            Frame_Visible = frameVisible;
            Lst_Panel = lst_panel;
            Lst_MultiPanel = lst_mpanel;
            FrameImageRenderer_Zoom = frameImagerZoom;
            Lst_Divider = lst_divider;
            Frame_Zoom = frameZoom;
            Frame_ArtNo = frameArtNo;
            Frame_WindoorModel = frameWindoorModel;

            FrameProp_Height = constants.frame_propertyHeight_default - constants.frame_property_concretePanelHeight;
        }
    }
}
