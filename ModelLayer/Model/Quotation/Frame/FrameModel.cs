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
                NotifyPropertyChanged();
            }
        }

        private Frame_Padding _frameType;
        public Frame_Padding Frame_Type
        {
            get { return _frameType; }
            set { _frameType = value;
                if (value == Frame_Padding.Window)
                {
                    if (_framePadding == new Padding(23)) //ibig sabihin nito galing Door
                    {
                        Frame_Padding_int = new Padding(16);
                    }
                    else if(_framePadding == new Padding(33))
                    {
                        Frame_Padding_int = new Padding(26);
                    }
                    else if (_framePadding == new Padding(0))
                    {
                        Frame_Padding_int = new Padding(26);
                    }
                }
                else if (value == Frame_Padding.Door)
                {
                    if (_framePadding == new Padding(16)) //ibig sabihin nito galing Window
                    {
                        Frame_Padding_int = new Padding(23);
                    }
                    else if (_framePadding == new Padding(26))
                    {
                        Frame_Padding_int = new Padding(33);
                    }
                    else if (_framePadding == new Padding(0))
                    {
                        Frame_Padding_int = new Padding(33);
                    }
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
            set { _framePadding = value; NotifyPropertyChanged(); }
        }

        private int _framePropHeight;
        public int FrameProp_Height
        {
            get { return _framePropHeight; }
            set { _framePropHeight = value; NotifyPropertyChanged(); }
        }

        public List<IPanelModel> Lst_Panel { get; set; }
        public List<IMultiPanelModel> Lst_MultiPanel { get; set; }

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
                NotifyPropertyChanged();
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
                          float frameImagerZoom)
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
            
            if (frameType == Frame_Padding.Window)
            {
                Frame_Padding_int = new Padding(26);
            }
            else if (frameType == Frame_Padding.Door)
            {
                Frame_Padding_int = new Padding(33);
            }
        }
    }
}
