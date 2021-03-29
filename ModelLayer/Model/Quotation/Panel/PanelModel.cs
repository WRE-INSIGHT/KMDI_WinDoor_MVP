using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelLayer.Model.Quotation.Panel
{
    public class PanelModel : IPanelModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _panelID;
        public int Panel_ID
        {
            get
            {
                return _panelID;
            }
            set
            {
                _panelID = value;
            }
        }

        private string _panelName;
        public string Panel_Name
        {
            get
            {
                return _panelName;
            }
            set
            {
                _panelName = value;
                NotifyPropertyChanged();
            }
        }

        private DockStyle _panelDock;
        public DockStyle Panel_Dock
        {
            get
            {
                return _panelDock;
            }
            set
            {
                _panelDock = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelWidth;
        public int Panel_Width
        {
            get
            {
                return _panelWidth;
            }
            set
            {
                _panelWidth = value;
                PanelImageRenderer_Width = Convert.ToInt32(value * PanelImageRenderer_Zoom);
                NotifyPropertyChanged();
            }
        }

        private int _panelHeight;
        public int Panel_Height
        {
            get
            {
                return _panelHeight;
            }
            set
            {
                _panelHeight = value;
                PanelImageRenderer_Height = Convert.ToInt32(value * PanelImageRenderer_Zoom);
                NotifyPropertyChanged();
            }
        }

        private string _panelType;
        public string Panel_Type
        {
            get
            {
                return _panelType;
            }
            set
            {
                if (value.Contains("Fixed"))
                {
                    if (_panelOrient == true)
                    {
                        _panelChkText = "dSash";
                    }
                    else if (_panelOrient == false)
                    {
                        _panelChkText = "Norm";
                    }
                }
                _panelType = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelOrient;
        public bool Panel_Orient
        {
            get
            {
                return _panelOrient;
            }
            set
            {
                if (_panelType.Contains("Fixed"))
                {
                    if (value == true)
                    {
                        _panelChkText = "dSash";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "None";
                    }
                }
                else if (_panelType.Contains("Casement"))
                {
                    if (value == true)
                    {
                        _panelChkText = "L";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "R";
                    }
                }
                else if (_panelType.Contains("Awning"))
                {
                    if (value == true)
                    {
                        _panelChkText = "Invrt";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "Norm";
                    }
                }
                else if (_panelType.Contains("Sliding"))
                {
                    if (value == true)
                    {
                        _panelChkText = "L";
                    }
                    else if (value == false)
                    {
                        _panelChkText = "R";
                    }
                }
                _panelOrient = value;
                NotifyPropertyChanged();
            }
        }

        private string _panelChkText;
        public string Panel_ChkText
        {
            get
            {
                return _panelChkText;
            }
            set
            {
                _panelChkText = value;
                NotifyPropertyChanged();
            }
        }

        private Control _panelParent;
        public Control Panel_Parent
        {
            get
            {
                return _panelParent;
            }
            set
            {
                if (value.Name.Contains("Frame"))
                {
                    _panelPNumEnable = false;
                }
                else
                {
                    _panelPNumEnable = true;
                }
                _panelParent = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _panelFrameGroup;
        public UserControl Panel_FrameGroup
        {
            get
            {
                return _panelFrameGroup;
            }
            set
            {
                _panelFrameGroup = value;
            }
        }

        private UserControl _panelFramePropertiesGroup;
        public UserControl Panel_FramePropertiesGroup
        {
            get
            {
                return _panelFramePropertiesGroup;
            }
            set
            {
                _panelFramePropertiesGroup = value;
            }
        }

        private bool _panelVisibility;
        public bool Panel_Visibility
        {
            get
            {
                return _panelVisibility;
            }

            set
            {
                _panelVisibility = value;
                NotifyPropertyChanged();
            }
        }

        private bool _panelPNumEnable;
        public bool Panel_PNumEnable
        {
            get
            {
                return _panelPNumEnable;
            }
            set
            {
                _panelPNumEnable = value;
                NotifyPropertyChanged();
            }
        }

        private float _panelImage_Zoom;
        public float PanelImageRenderer_Zoom
        {
            get
            {
                return _panelImage_Zoom;
            }

            set
            {
                _panelImage_Zoom = value;
                PanelImageRenderer_Width = Convert.ToInt32(Panel_Width * value);
                PanelImageRenderer_Height = Convert.ToInt32(Panel_Height * value);
                NotifyPropertyChanged();
            }
        }

        private int _panelImage_Height;
        public int PanelImageRenderer_Height
        {
            get
            {
                return _panelImage_Height;
            }

            set
            {
                _panelImage_Height = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelImage_Width;
        public int PanelImageRenderer_Width
        {
            get
            {
                return _panelImage_Width;
            }

            set
            {
                _panelImage_Width = value;
                NotifyPropertyChanged();
            }
        }

        private Padding _panelMargin;
        public Padding Panel_Margin
        {
            get
            {
                return _panelMargin;
            }

            set
            {
                _panelMargin = value;
                NotifyPropertyChanged();
            }
        }

        private UserControl _panelMultiPanelGroup;
        public UserControl Panel_MultiPanelGroup
        {
            get
            {
                return _panelMultiPanelGroup;
            }

            set
            {
                _panelMultiPanelGroup = value;
                NotifyPropertyChanged();
            }
        }

        private int _panelIndexInsideMPanel;
        public int Panel_Index_Inside_MPanel //Always be 0 if its inside frame
        {
            get
            {
                return _panelIndexInsideMPanel;
            }

            set
            {
                _panelIndexInsideMPanel = value;
                NotifyPropertyChanged();
            }
        }

        private string _panelPlacement;
        public string Panel_Placement
        {
            get
            {
                return _panelPlacement;
            }

            set
            {
                _panelPlacement = value;
            }
        }

        public PanelModel(int panelID,
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
                          float panelImageRendererZoom)
        {
            Panel_ID = panelID;
            Panel_Name = panelName;
            Panel_Width = panelWd;
            Panel_Height = panelHt;
            Panel_Dock = panelDock;
            Panel_Type = panelType;
            Panel_Orient = panelOrient;
            Panel_Parent = panelParent;
            Panel_FrameGroup = panelFrameGroup;
            Panel_Visibility = panelVisibility;
            Panel_FramePropertiesGroup = panelFramePropertiesGroup;
            Panel_MultiPanelGroup = panelMultiPanelGroup;
            Panel_Index_Inside_MPanel = panelIndexInsideMPanel;
            PanelImageRenderer_Zoom = panelImageRendererZoom;
        }
    }
}
