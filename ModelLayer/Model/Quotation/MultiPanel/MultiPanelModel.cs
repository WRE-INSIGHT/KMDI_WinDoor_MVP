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
using ModelLayer.Model.Quotation.Frame;
using static EnumerationTypeLayer.EnumerationTypes;
using static ModelLayer.Model.Quotation.Divider.DividerModel;
using ModelLayer.Variables;

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
        public int MPanel_Width
        {
            get
            {
                return _mpanelWidth;
            }
            set
            {
                int added_width_child_pnls = value - _mpanelWidth;
                if (MPanel_Type == "Transom")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        mpnl.MPanel_Width += added_width_child_pnls;
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_Width += added_width_child_pnls;
                    }
                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_Width += added_width_child_pnls;
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        if (mpnl.MPanel_Placement == "Last")
                        {
                            mpnl.MPanel_Width += added_width_child_pnls;
                        }
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (pnl.Panel_Placement == "Last")
                        {
                            pnl.Panel_Width += added_width_child_pnls;
                        }
                    }
                }
                _mpanelWidth = value;
                MPanelImageRenderer_Width = Convert.ToInt32(value * MPanelImageRenderer_Zoom);
                MPanel_WidthToBind = (int)(value * MPanel_Zoom);
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Width that is dependent on MPanel_Width and MPanel_Zoomand varies accordingly. (not intended for user to use)")]
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
                int added_displaywidth_child_pnls = value - _mpanelDisplayWidth;
                if (MPanel_Type == "Transom")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        mpnl.MPanel_DisplayWidth += added_displaywidth_child_pnls;
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_DisplayWidth += added_displaywidth_child_pnls;
                    }
                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_DisplayWidth += added_displaywidth_child_pnls;
                    }
                }
                else if (MPanel_Type == "Mullion")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        if (mpnl.MPanel_Placement == "Last")
                        {
                            mpnl.MPanel_DisplayWidth += added_displaywidth_child_pnls;
                        }
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (pnl.Panel_Placement == "Last")
                        {
                            pnl.Panel_DisplayWidth += added_displaywidth_child_pnls;
                        }
                    }
                }
                _mpanelDisplayWidth = value;
                NotifyPropertyChanged();
            }
        }

        [Description("Virtual Height that represents the definite given value and used by the program only. (not intended for user to use)")]
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
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        mpnl.MPanel_Height += added_height_child_pnls;
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_Height += added_height_child_pnls;
                    }
                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_Height += added_height_child_pnls;
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        if (mpnl.MPanel_Placement == "Last")
                        {
                            mpnl.MPanel_Height += added_height_child_pnls;
                        }
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (pnl.Panel_Placement == "Last")
                        {
                            pnl.Panel_Height += added_height_child_pnls;
                        }
                    }
                }
                _mpanelHeight = value;
                MPanelImageRenderer_Height = Convert.ToInt32(value * MPanelImageRenderer_Zoom);
                MPanel_HeightToBind = (int)(value * MPanel_Zoom);
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
                int added_displayheight_child_pnls = value - _mpanelDisplayHeight;
                if (MPanel_Type == "Mullion")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        mpnl.MPanel_DisplayHeight += added_displayheight_child_pnls;
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        pnl.Panel_DisplayHeight += added_displayheight_child_pnls;
                    }
                    foreach (IDividerModel div in MPanelLst_Divider)
                    {
                        div.Div_DisplayHeight += added_displayheight_child_pnls;
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                    {
                        if (mpnl.MPanel_Placement == "Last")
                        {
                            mpnl.MPanel_DisplayHeight += added_displayheight_child_pnls;
                        }
                    }
                    foreach (IPanelModel pnl in MPanelLst_Panel)
                    {
                        if (pnl.Panel_Placement == "Last")
                        {
                            pnl.Panel_DisplayHeight += added_displayheight_child_pnls;
                        }
                    }
                }
                _mpanelDisplayHeight = value;
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
                MPanelImageRenderer_Width = Convert.ToInt32(MPanel_Width * value);
                MPanelImageRenderer_Height = Convert.ToInt32(MPanel_Height * value);

                Padding pads = new Padding(Convert.ToInt32(MPanel_Margin.All * value));
                MPanelImageRenderer_Margin = pads;
                SetImageZoomDivider();
                NotifyPropertyChanged();
            }
        }

        private void SetImageZoomDivider()
        {
            foreach (IDividerModel div in MPanelLst_Divider)
            {
                div.DivImageRenderer_Zoom = MPanelImageRenderer_Zoom;
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
                MPanel_WidthToBind = (int)(MPanel_Width * value);
                MPanel_HeightToBind = (int)(MPanel_Height * value);
                SetZoomPanels();
                SetZoomDivider();
                SetZoomMPanels();
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

        private void SetZoomDivider()
        {
            foreach (IDividerModel div in MPanelLst_Divider)
            {
                div.Div_Zoom = MPanel_Zoom;
            }
        }
        private void SetZoomPanels()
        {
            foreach (IPanelModel pnl in MPanelLst_Panel)
            {
                pnl.Panel_Zoom = MPanel_Zoom;
            }
        }
        private void SetZoomMPanels()
        {
            foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
            {
                mpnl.MPanel_Zoom = MPanel_Zoom;
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
                                pnl_margin = new Padding(10, 9, 0, 10);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(0, 9, 10, 10);
                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 9, 0, 10);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Somewhere in Between") //top margin is 9 because of divider on top (8 + 1)
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 9, 0, 0);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(0, 9, 10, 0);
                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(0, 9, 0, 0);
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
                                pnl_margin = new Padding(10, 0, 10, 10);
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
                                pnl_margin = new Padding(8, 10, 0, 0);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(8, 0, 10, 10);
                                pnl.Panel_Placement = "Last";
                            }
                            else
                            {
                                pnl_margin = new Padding(10, 0, 10, 0);
                                pnl.Panel_Placement = "Somewhere in Between";
                            }
                        }
                        else if (MPanel_Placement == "Somewhere in Between")
                        {
                            if (pnl.Panel_Index_Inside_MPanel == 0)
                            {
                                pnl_margin = new Padding(10, 10, 0, 0);
                                pnl.Panel_Placement = "First";
                            }
                            else if ((!MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions) ||
                                     (MPanel_DividerEnabled && pnl.Panel_Index_Inside_MPanel == MPanel_Divisions * 2))
                            {
                                pnl_margin = new Padding(10, 0, 0, 10);
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
                            pnl_margin = new Padding(10, 0, 10, 10);
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

        private int _mpnl_add;
        public int MPanel_AddPixel
        {
            get
            {
                return _mpnl_add;
            }
        }

        public void Resize_MyControls(Control current_control, 
                                      string frameType,
                                      bool if_auto_added = false)
        {
            int indx = MPanelLst_Objects.IndexOf(current_control);

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
                            divModel.Div_Height -= _mpnl_add;
                            //prev_ctrl.Height -= pixels_count;
                            if (indx == MPanel_Divisions * 2) //means LAST OBJECT
                            {
                                //current_control.Height += pixels_count;
                                multiModel.MPanel_Height += _mpnl_add;
                            }
                        }
                        else if (prev_ctrl.Name.Contains("MullionUC"))
                        {
                            divModel.Div_Width -= _mpnl_add;
                            //prev_ctrl.Width -= pixels_count;
                            if (indx == MPanel_Divisions * 2) //means LAST OBJECT
                            {
                                //current_control.Width += pixels_count;
                                multiModel.MPanel_Width += _mpnl_add;
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
                                multiModel.MPanel_Height += _mpnl_add;
                                //prev_ctrl.Height += pixels_count;
                            }
                            divModel.Div_Height -= _mpnl_add;
                            //current_control.Height -= pixels_count;
                        }
                        else if (current_control.Name.Contains("MullionUC"))
                        {
                            if (!if_auto_added)
                            {
                                multiModel.MPanel_Width += _mpnl_add;
                                //prev_ctrl.Width += pixels_count;
                            }
                            divModel.Div_Width -= _mpnl_add;
                            //current_control.Width -= pixels_count;
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
            Resize_MyControls(control, frameType, if_auto_added);
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
                if (MPanelLst_Objects[previous_indx].Name.Contains("MullionUC"))
                {
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_Width += pixel_count;
                    //MPanelLst_Objects[previous_indx].Width += pixel_count;
                }
                else if (MPanelLst_Objects[previous_indx].Name.Contains("TransomUC"))
                {
                    MPanelLst_Divider.Find(div => div.Div_Name == MPanelLst_Objects[previous_indx].Name).Div_Height += pixel_count;
                    //MPanelLst_Objects[previous_indx].Height += pixel_count;
                }
            }
        }

        public void Fit_MyControls_ToBindDimensions()
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHeight_Controls = MPanelLst_Panel.Sum(pnl => pnl.Panel_HeightToBind + pnl.Panel_MarginToBind.Top + pnl.Panel_MarginToBind.Bottom) +
                                               MPanelLst_Divider.Sum(div => div.Div_HeightToBind) +
                                               MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_HeightToBind);
                    int diff_MPanelHt_VS_MyCtrlsHeight = MPanel_HeightToBind - totalHeight_Controls;

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
            }
        }
        
        public void Fit_MyControls_Dimensions()
        {
            if (MPanelLst_Objects.Count() > 0)
            {
                if (MPanel_Type == "Transom")
                {
                    int totalHeight_Controls = MPanelLst_Panel.Sum(pnl => pnl.Panel_HeightToBind + pnl.Panel_MarginToBind.Top + pnl.Panel_MarginToBind.Bottom) +
                                               MPanelLst_Divider.Sum(div => div.Div_HeightToBind) +
                                               MPanelLst_MultiPanel.Sum(mpnl => mpnl.MPanel_HeightToBind);
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

            for (int i = 0; i < visible_obj.Count() ; i++)
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

        #region Explosion

        public int MPanel_OriginalDisplayWidth { get; set; }
        public int MPanel_OriginalDisplayHeight { get; set; }
        public int MPanel_OriginalGlassWidth { get; set; }
        public int MPanel_OriginalGlassHeight { get; set; }

        public void SetEqualGlassDimension(string mode)
        {
            int Equal_GlassSize = 0,
                div_deduction = 0,
                frame_deduction = 0,
                totalPanels = MPanel_Divisions + 1;


            if (mode == "noSash")
            {
                if (MPanel_Type == "Mullion")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            frame_deduction = 33;
                        }
                        else if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            frame_deduction = 47;
                        }

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536)
                            {
                                div_deduction += 42;
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += 72;
                            }
                        }

                        Equal_GlassSize = (((MPanel_DisplayWidth - (frame_deduction * 2) - div_deduction)) / totalPanels) - 6;

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            pnl.Panel_DisplayWidth = pnl.Panel_OriginalDisplayWidth + (Equal_GlassSize - pnl.Panel_OriginalGlassWidth);
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            mpnl.MPanel_DisplayWidth = mpnl.MPanel_OriginalDisplayWidth + (Equal_GlassSize - mpnl.MPanel_OriginalGlassWidth);
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            frame_deduction = 33;
                        }
                        else if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            frame_deduction = 47;
                        }

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536)
                            {
                                div_deduction += 42;
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += 72;
                            }
                        }

                        Equal_GlassSize = (((MPanel_DisplayHeight - (frame_deduction * 2) - div_deduction)) / totalPanels) - 6;

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            pnl.Panel_DisplayHeight = pnl.Panel_OriginalDisplayHeight + (Equal_GlassSize - pnl.Panel_OriginalGlassHeight);
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            mpnl.MPanel_DisplayHeight = mpnl.MPanel_OriginalDisplayHeight + (Equal_GlassSize - mpnl.MPanel_OriginalGlassHeight);
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
                        if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            frame_deduction = 26;
                        }
                        else if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            frame_deduction = 40;
                        }

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536)
                            {
                                div_deduction += (42 - 14);
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += (72 - 14);
                            }
                        }

                        Equal_GlassSize = (((MPanel_DisplayWidth - (frame_deduction * 2) - div_deduction)) / totalPanels) + 5;

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            pnl.Panel_DisplayWidth = pnl.Panel_OriginalDisplayWidth + (Equal_GlassSize - pnl.Panel_OriginalSashWidth);
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            mpnl.MPanel_DisplayWidth = mpnl.MPanel_OriginalDisplayWidth + (Equal_GlassSize - mpnl.MPanel_OriginalGlassWidth);
                        }
                    }
                }
                else if (MPanel_Type == "Transom")
                {
                    if (MPanel_Divisions >= 2)
                    {
                        if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7502)
                        {
                            frame_deduction = 26;
                        }
                        else if (MPanel_FrameModelParent.Frame_ArtNo == FrameProfile_ArticleNo._7507)
                        {
                            frame_deduction = 40;
                        }

                        foreach (IDividerModel div in MPanelLst_Divider)
                        {
                            if (div.Div_ArtNo == Divider_ArticleNo._7536)
                            {
                                div_deduction += (42 - 14);
                            }
                            else if (div.Div_ArtNo == Divider_ArticleNo._7538)
                            {
                                div_deduction += (72 - 14);
                            }
                        }

                        Equal_GlassSize = (((MPanel_DisplayHeight - (frame_deduction * 2) - div_deduction)) / totalPanels) + 5;

                        foreach (IPanelModel pnl in MPanelLst_Panel)
                        {
                            pnl.Panel_DisplayHeight = pnl.Panel_OriginalDisplayHeight + (Equal_GlassSize - pnl.Panel_OriginalSashHeight);
                        }
                        foreach (IMultiPanelModel mpnl in MPanelLst_MultiPanel)
                        {
                            mpnl.MPanel_DisplayHeight = mpnl.MPanel_OriginalDisplayHeight + (Equal_GlassSize - mpnl.MPanel_OriginalGlassHeight);
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
                    MPanelProp_Height += constants.panel_propertyHeight_default
                                         - constants.panel_property_motorizedOptionsheight;
                }
                if (mode == "deleteMotorized")
                {
                    MPanelProp_Height -= constants.panel_propertyHeight_default
                                        - constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "addRotary")
                {
                    MPanelProp_Height += constants.panel_property_rotaryOptionsheight_default; //(39 + 1); //+1 on margin (PanelProperties)
                }
                else if (mode == "minusRotary")
                {
                    MPanelProp_Height -= constants.panel_property_rotaryOptionsheight_default; //(39 + 1); //+1 on margin (PanelProperties)
                }
                else if (mode == "addRotoswing")
                {
                    MPanelProp_Height += constants.panel_property_rotoswingOptionsheight_default; //(85 + 1); //+1 on margin (PanelProperties)
                }
                else if (mode == "minusRotoswing")
                {
                    MPanelProp_Height -= constants.panel_property_rotoswingOptionsheight_default; //(85 + 1); //+1 on margin (PanelProperties)
                }
                else if (mode == "addHandle")
                {
                    MPanelProp_Height += constants.panel_property_handleOptionsHeight;
                }
                else if (mode == "minusHandle")
                {
                    MPanelProp_Height -= constants.panel_property_handleOptionsHeight;
                }
            }
            else if (objtype == "FxdNone")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= ((((constants.panel_propertyHeight_default
                                        - constants.panel_property_sashPanelHeight)
                                        - constants.panel_property_handleOptionsHeight)
                                        - constants.panel_property_pnlmotorizedheight)
                                        - constants.panel_property_motorizedOptionsheight);
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += ((((constants.panel_propertyHeight_default
                                        - constants.panel_property_sashPanelHeight)
                                        - constants.panel_property_handleOptionsHeight)
                                        - constants.panel_property_pnlmotorizedheight)
                                        - constants.panel_property_motorizedOptionsheight);
                }
            }
            else if (objtype == "FxdSash")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= (((constants.panel_propertyHeight_default
                                        - constants.panel_property_handleOptionsHeight)
                                        - constants.panel_property_pnlmotorizedheight)
                                        - constants.panel_property_motorizedOptionsheight);
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += (((constants.panel_propertyHeight_default
                                        - constants.panel_property_handleOptionsHeight)
                                        - constants.panel_property_pnlmotorizedheight)
                                        - constants.panel_property_motorizedOptionsheight);
                }
            }
            else if (objtype == "SashProp")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= constants.panel_property_sashPanelHeight;
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += constants.panel_property_sashPanelHeight;
                }
            }
            else if (objtype == "Div")
            {
                if (mode == "delete")
                {
                    MPanelProp_Height -= constants.div_propertyheight_default; // (173 + 1); //+1 on margin (divProperties)
                }
                else if (mode == "add")
                {
                    MPanelProp_Height += constants.div_propertyheight_default; //(173 + 1); //+1 on margin (divProperties)
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

        public void AdjustPropertyPanelHeight(string objtype, string mode, Handle_Type handleType)
        {
            if (objtype == "Panel")
            {
                if (mode == "delete")
                {
                    if (handleType == Handle_Type._Rotoswing)
                    {
                        MPanelProp_Height -= constants.panel_propertyHeight_default
                                            - constants.panel_property_rotaryOptionsheight_default
                                            - constants.panel_property_motorizedOptionsheight;
                    }
                    else if (handleType == Handle_Type._Rotary)
                    {
                        MPanelProp_Height -= constants.panel_propertyHeight_default
                                            - constants.panel_property_rotaryOptionsheight_default
                                            - constants.panel_property_motorizedOptionsheight;
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
                               IMultiPanelModel mpanelParentModel,
                               float mpanelImageRendererZoom,
                               float mpanelZoom,
                               IFrameModel mpanelFrameModelParent,
                               int mpanelDisplayWidth,
                               int mpanelDisplayHeight,
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
            MPanel_ParentModel = mpanelParentModel;
            MPanel_DividerEnabled = true;
            MPanelImageRenderer_Zoom = mpanelImageRendererZoom;
            MPanel_Zoom = mpanelZoom;
            MPanel_FrameModelParent = mpanelFrameModelParent;
            MPanel_DisplayWidth = mpanelDisplayWidth;
            MPanel_DisplayHeight = mpanelDisplayHeight;
            MPanel_OriginalDisplayWidth = mpanelDisplayWidth;
            MPanel_OriginalDisplayHeight = mpanelDisplayHeight;
            MPanel_StackNo = mpanelStackNo;

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
