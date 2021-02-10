using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Divider;

namespace ModelLayer.Model.Quotation.MultiPanel
{
    public class MultiPanelModel : IMultiPanelModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        private int _mpanelWidth;
        public int MPanel_Width
        {
            get
            {
                return _mpanelWidth;
            }
            set
            {
                _mpanelWidth = value;
                MPanelImageRenderer_Width = Convert.ToInt32(value * MPanelImageRenderer_Zoom);
                NotifyPropertyChanged();
            }
        }

        private int _mpanelHeight;
        public int MPanel_Height
        {
            get
            {
                return _mpanelHeight;
            }
            set
            {
                int added_height_child_pnls = value - _mpanelHeight;
                if (MPanel_Type == "Mullion")
                {
                    foreach (IPanelModel pnl in MPanelLst_Panel.Where(pnl => pnl.Panel_Visibility == true))
                    {
                        pnl.Panel_Height += added_height_child_pnls;
                    }
                    foreach (IDividerModel div in MPanelLst_Divider.Where(div => div.Div_Visible == true))
                    {
                        div.Div_Height += added_height_child_pnls;
                    }
                }
                _mpanelHeight = value;
                MPanelImageRenderer_Height = Convert.ToInt32(value * MPanelImageRenderer_Zoom);
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                MPanelImageRenderer_Width = Convert.ToInt32(MPanel_Width * value);
                MPanelImageRenderer_Height = Convert.ToInt32(MPanel_Height * value);
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
            }
        }

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

        public void Reload_PanelMargin()
        {
            List<IPanelModel> Lst_visiblePnl = MPanelLst_Panel.Where(pnl => pnl.Panel_Visibility == true).ToList();
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
                            }
                            else if (pnl.Panel_Index_Inside_MPanel == MPanel_Divisions)
                            {
                                pnl_margin = new Padding(0, 10, 10, 10);
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 10, 0, 10);
                            }
                        }
                        else if (MPanel_Placement == "Last")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 8, 0, 10);
                            }
                            else if (pnl.Panel_Index_Inside_MPanel == MPanel_Divisions)
                            {
                                pnl_margin = new Padding(0, 8, 10, 10);
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 8, 0, 10);
                            }
                        }
                    }
                    else if (pnl.Panel_Parent.Parent.Parent.Name.Contains("Frame")) //if Parent.Parent Frame
                    {
                        if (pnl.Panel_Index_Inside_MPanel == 0)
                        {
                            pnl_margin = new Padding(10, 10, 0, 10);
                        }
                        else if (pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2)
                        {
                            pnl_margin = new Padding(0, 10, 10, 10);
                        }
                        else
                        {
                            pnl_margin = new Padding(0, 10, 0, 10);
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (pnl.Panel_Index_Inside_MPanel == 0)
                    {
                        pnl_margin = new Padding(10, 10, 10, 0);
                    }
                    else if (pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2)
                    {
                        pnl_margin = new Padding(10, 0, 10, 10);
                    }
                    else
                    {
                        pnl_margin = new Padding(10, 0, 10, 0);
                    }
                }
                pnl.Panel_Margin = pnl_margin;
            }
        }

        public void Reload_MultiPanelMargin()
        {
            List<IMultiPanelModel> Lst_visibleMPanel = MPanelLst_MultiPanel.Where(mpnl => mpnl.MPanel_Visibility == true).ToList();
            int visibleMPnl_count = Lst_visibleMPanel.Count();

            foreach (IMultiPanelModel mpnl in Lst_visibleMPanel)
            {
                Padding pnl_margin = new Padding(0);
                if (MPanel_Type == "Mullion")
                {
                    if (mpnl.MPanel_Index_Inside_MPanel == 0)
                    {
                        pnl_margin = new Padding(10, 10, 0, 10);
                        mpnl.MPanel_Placement = "First";
                    }
                    else if (mpnl.MPanel_Index_Inside_MPanel == MPanel_Divisions)
                    {
                        pnl_margin = new Padding(0, 10, 10, 10);
                        mpnl.MPanel_Placement = "Last";
                    }
                    else
                    {
                        pnl_margin = new Padding(0, 10, 0, 10);
                        mpnl.MPanel_Placement = "Somewhere in Between";
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (mpnl.MPanel_Index_Inside_MPanel == 0)
                    {
                        pnl_margin = new Padding(0, 0, 0, 0);
                        mpnl.MPanel_Placement = "First";
                    }
                    else if (mpnl.MPanel_Index_Inside_MPanel == MPanel_Divisions * 2)
                    {
                        pnl_margin = new Padding(0, 0, 0, 0);
                        mpnl.MPanel_Placement = "Last";
                    }
                    else
                    {
                        pnl_margin = new Padding(10, 0, 10, 0);
                        mpnl.MPanel_Placement = "Somewhere in Between";
                    }
                }
                mpnl.MPanel_Margin = pnl_margin;
            }
        }

        public int GetNextIndex()
        {
            int visiblePanelCount = MPanelLst_Panel.Count(pnl => pnl.Panel_Visibility == true),
                visibleMPanelCount = MPanelLst_MultiPanel.Count(mpnl => mpnl.MPanel_Visibility == true),
                visibleDivider = MPanelLst_Divider.Count(div => div.Div_Visible == true);

            return visiblePanelCount + visibleMPanelCount + visibleDivider;
        }

        public void Resize_MyControls(Control current_control)
        {
            int indx = MPanelLst_Objects.IndexOf(current_control);
            if (current_control.Name.Contains("MultiPanel")) //MultiPanel Block
            {
                if (indx > 0 && indx % 2 == 0) //indx > 0 && indx == 'Even'
                {
                    Control prev_ctrl = MPanelLst_Objects[indx - 1];
                    if (!prev_ctrl.Name.Contains("MultiPanel") && prev_ctrl.Name.Contains(MPanel_Type)) //means Divider
                    {
                        prev_ctrl.Height -= 8;
                        if (indx == MPanel_Divisions * 2) //means LAST OBJECT
                        {
                            current_control.Height += 8;
                        }
                    }
                }
            }
            else if (!current_control.Name.Contains("MultiPanel") && current_control.Name.Contains(MPanel_Type)) //Divider Block
            {
                if (indx % 2 != 0) //means Odd
                {
                    Control prev_ctrl = MPanelLst_Objects[indx - 1];
                    if (prev_ctrl.Name.Contains("MultiPanel"))
                    {
                        prev_ctrl.Height += 8;
                        current_control.Height -= 8;
                    }
                }
            }
        }

        public void AddControl_MPanelLstObjects(Control control)
        {
            MPanelLst_Objects.Add(control);
            Resize_MyControls(control);
        }

        public int GetCount_MPanelLst_Object()
        {
            return MPanelLst_Objects.Count();
        }

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
                               IMultiPanelModel mpanelParentModel)
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
            MPanel_ParentModel = mpanelParentModel;
        }
    }
}
