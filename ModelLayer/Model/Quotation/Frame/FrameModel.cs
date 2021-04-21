using System;
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

        private static int Frame_basicDeduction = 10;

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

        private int[] _arr_padding_norm     = { 26, 33, 13, 15, 08, 10, 05, 07 }; //even index means window, odd index means door
        private int[] _arr_padding_withmpnl = { 16, 23, 08, 12, 05, 07, 03, 06}; //even index means window, odd index means door

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
            set { _frameVisible = value; NotifyPropertyChanged(); }
        }

        private Padding _framePadding;
        public Padding Frame_Padding_int
        {
            get { return _framePadding; }
            set
            {
                _framePadding = value;

                //SetFramePadding_ImageRenderer();
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
                    FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type - Frame_basicDeduction) * FrameImageRenderer_Zoom));
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
                //Frame_Padding_int = new Padding((int)((int)Frame_Type * Frame_Zoom) - _frameDeduction);
                //Frame_Padding_int = new Padding((int)((int)Frame_Type * value));
                //SetFramePadding();
            }
        }

        public void SetFramePadding(bool has_deleteMpnl)
        {
            int ndx_padding_norm = -1, // -1 meaning index was not found on array
                ndx_padding_withmpnl = -1,
                ndx_padding_toBeUsed = -1;

            if (!has_deleteMpnl)
            {
                if (_framePadding != new Padding(0))
                {
                    ndx_padding_norm = Array.IndexOf(_arr_padding_norm, _framePadding.All);
                    ndx_padding_withmpnl = Array.IndexOf(_arr_padding_withmpnl, _framePadding.All);

                    if (_array_Used == "_arr_padding_norm")
                    {
                        ndx_padding_toBeUsed = ndx_padding_norm;
                        //_array_Used = "_arr_padding_norm";
                    }
                    else if (_array_Used == "_arr_padding_withmpnl")
                    {
                        ndx_padding_toBeUsed = ndx_padding_withmpnl;
                        //_array_Used = "_arr_padding_withmpnl";
                    }

                    if (Frame_Type == Frame_Padding.Door && ndx_padding_toBeUsed % 2 == 0) //Even
                    {
                        ndx_padding_toBeUsed++;
                        if (_array_Used == "_arr_padding_norm")
                        {
                            Frame_Padding_int = new Padding(_arr_padding_norm[ndx_padding_toBeUsed]);
                        }
                        else if (_array_Used == "_arr_padding_withmpnl")
                        {
                            Frame_Padding_int = new Padding(_arr_padding_withmpnl[ndx_padding_toBeUsed]);
                        }
                    }
                    else if (Frame_Type == Frame_Padding.Window && ndx_padding_toBeUsed % 2 != 0) //Odd
                    {
                        ndx_padding_toBeUsed--;
                        if (_array_Used == "_arr_padding_norm")
                        {
                            Frame_Padding_int = new Padding(_arr_padding_norm[ndx_padding_toBeUsed]);
                        }
                        else if (_array_Used == "_arr_padding_withmpnl")
                        {
                            Frame_Padding_int = new Padding(_arr_padding_withmpnl[ndx_padding_toBeUsed]);
                        }
                    }
                }
                else if (_framePadding == new Padding(0))
                {
                    if (Frame_Type == Frame_Padding.Window)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[0]);
                    }
                    else if (Frame_Type == Frame_Padding.Door)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[1]);
                    }
                    _array_Used = "_arr_padding_norm";
                }
            }
            else if (has_deleteMpnl)
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    Frame_Padding_int = new Padding(_arr_padding_norm[0]);
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    Frame_Padding_int = new Padding(_arr_padding_norm[1]);
                }
                _array_Used = "_arr_padding_norm";
            }
        }

        private string _array_Used = "";
        public void SetFramePadding()
        {
            if (_array_Used == "_arr_padding_withmpnl")
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[0]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[2]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[4]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[6]);
                    }
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[1]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[3]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[5]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_withmpnl[7]);
                    }
                }
            }
            else if (_array_Used == "_arr_padding_norm")
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[0]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[2]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[4]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[6]);
                    }
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[1]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[3]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[5]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        Frame_Padding_int = new Padding(_arr_padding_norm[7]);
                    }
                }
            }
        }

        private void SetFramePadding_ImageRenderer()
        {
            if (_array_Used == "_arr_padding_withmpnl")
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[0]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[2]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[4]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[6]);
                    }
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[1]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[3]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[5]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_withmpnl[7]);
                    }
                }
            }
            else if (_array_Used == "_arr_padding_norm")
            {
                if (Frame_Type == Frame_Padding.Window)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[0]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[2]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[4]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[6]);
                    }
                }
                else if (Frame_Type == Frame_Padding.Door)
                {
                    if (Frame_Zoom == 1.0f || Frame_Zoom == 0.50f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[1]);
                    }
                    else if (Frame_Zoom == 0.28f || Frame_Zoom == 0.19f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[3]);
                    }
                    else if (Frame_Zoom == 0.14f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[5]);
                    }
                    else if (Frame_Zoom == 0.10f)
                    {
                        FrameImageRenderer_Padding_int = new Padding(_arr_padding_norm[7]);
                    }
                }
            }
        }

        public void SetArrayUsed(string arrayUsed)
        {
            _array_Used = arrayUsed;
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
            _frameDeduction = (int)(Frame_basicDeduction * Frame_Zoom);
            Frame_Padding_int = new Padding((int)((int)Frame_Type * Frame_Zoom) - _frameDeduction);
            FrameImageRenderer_Padding_int = new Padding((int)(((int)Frame_Type - Frame_basicDeduction) * FrameImageRenderer_Zoom));
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
                          float frameZoom)
        {
            Frame_ID = frameID;
            Frame_Name = frameName;
            Frame_Width = frameWd;
            Frame_Height = frameHt;
            Frame_Type = frameType;
            Frame_Visible = frameVisible;
            FrameProp_Height = 183;
            Lst_Panel = lst_panel;
            Lst_MultiPanel = lst_mpanel;
            FrameImageRenderer_Zoom = frameImagerZoom;
            Lst_Divider = lst_divider;
            Frame_Zoom = frameZoom;

            //if (frameType == Frame_Padding.Window)
            //{
            //    Frame_Padding_int = new Padding(26);
            //}
            //else if (frameType == Frame_Padding.Door)
            //{
            //    Frame_Padding_int = new Padding(33);
            //}
        }
    }
}
