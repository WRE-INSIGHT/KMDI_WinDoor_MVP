using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ServiceLayer.Services.MultiPanelServices;
using ServiceLayer.Services.PanelServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels
{
    public class MultiPanelMullionUCPresenter : IMultiPanelMullionUCPresenter, IPresenterCommon
    {
        IMultiPanelMullionUC _multiPanelMullionUC;

        private IUnityContainer _unityC;

        private IMultiPanelModel _multiPanelModel;
        private IPanelModel _panelModel;
        private IFrameModel _frameModel;

        private IMainPresenter _mainPresenter;
        private IFixedPanelUCPresenter _fixedUCP;
        private IFixedPanelImagerUCPresenter _fixedImagerUCP;
        private IPanelPropertiesUCPresenter _panelPropertiesUCP;
        private IfrmDimensionPresenter _frmDimensionPresenter;

        private IPanelServices _panelServices;
        private IMultiPanelServices _multipanelServices;

        public MultiPanelMullionUCPresenter(IMultiPanelMullionUC multiPanelMullionUC,
                                            IFixedPanelUCPresenter fixedUCP,
                                            IPanelServices panelServices,
                                            IMultiPanelServices multipanelServices,
                                            IPanelPropertiesUCPresenter panelPropertiesUCP,
                                            IfrmDimensionPresenter frmDimensionPresenter,
                                            IFixedPanelImagerUCPresenter fixedImagerUCP)
        {
            _multiPanelMullionUC = multiPanelMullionUC;
            _fixedUCP = fixedUCP;
            _panelServices = panelServices;
            _multipanelServices = multipanelServices;
            _panelPropertiesUCP = panelPropertiesUCP;
            _frmDimensionPresenter = frmDimensionPresenter;
            _fixedImagerUCP = fixedImagerUCP;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _multiPanelMullionUC.flpMulltiPaintEventRaised += _multiPanelMullionUC_flpMulltiPaintEventRaised;
            _multiPanelMullionUC.flpMultiMouseEnterEventRaised += _multiPanelMullionUC_flpMultiMouseEnterEventRaised;
            _multiPanelMullionUC.flpMultiMouseLeaveEventRaised += _multiPanelMullionUC_flpMultiMouseLeaveEventRaised;
            _multiPanelMullionUC.divCountClickedEventRaised += _multiPanelMullionUC_divCountClickedEventRaised;
            _multiPanelMullionUC.deleteClickedEventRaised += _multiPanelMullionUC_deleteClickedEventRaised;
            _multiPanelMullionUC.flpMultiDragDropEventRaised += _multiPanelMullionUC_flpMultiDragDropEventRaised;
        }

        private int _frmDmRes_Width;
        private int _frmDmRes_Height;

        private void _multiPanelMullionUC_flpMultiDragDropEventRaised(object sender, DragEventArgs e)
        {
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender; //Control na babagsakan
            string data = e.Data.GetData(e.Data.GetFormats()[0]) as string;

            int panelID = _mainPresenter.GetPanelCount() + 1;
            int multiID = _mainPresenter.GetMultiPanelCount() + 1;

            IFramePropertiesUC framePropUC = _mainPresenter.GetFrameProperties(_frameModel.Frame_ID);
            if (data.Contains("Multi-Panel"))
            {

            }
            else
            {
                int divSize = 0;
                if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Window)
                {
                    divSize = 10;
                }
                else if (_frameModel.Frame_Type == FrameModel.Frame_Padding.Door)
                {
                    divSize = 20;
                }

                int suggest_Wd = (fpnl.Width - (divSize * _multiPanelModel.MPanel_Divisions)) / (_multiPanelModel.MPanel_Divisions + 1);

                _frmDimensionPresenter.SetPresenters(this);
                _frmDimensionPresenter.purpose = frmDimensionPresenter.Show_Purpose.AddPanelIntoMultiPanel;
                _frmDimensionPresenter.SetHeight();
                _frmDimensionPresenter.SetValues(suggest_Wd, fpnl.Height);
                _frmDimensionPresenter.GetDimensionView().ShowfrmDimension();

                _panelModel = _panelServices.AddPanelModel(_frmDmRes_Width,
                                                           _frmDmRes_Height,
                                                           fpnl,
                                                           (UserControl)fpnl.Parent,
                                                           (UserControl)framePropUC,
                                                           data,
                                                           true,
                                                           panelID,
                                                           DockStyle.None);
                _frameModel.Lst_Panel.Add(_panelModel);

                IPanelPropertiesUCPresenter panelPropUCP = _panelPropertiesUCP.GetNewInstance(_unityC, _panelModel, _mainPresenter);
                framePropUC.GetFramePropertiesFLP().Controls.Add((UserControl)panelPropUCP.GetPanelPropertiesUC());
                _frameModel.FrameProp_Height += 148;

                if (data == "Fixed Panel")
                {
                    IFixedPanelUCPresenter fixedUCP = _fixedUCP.GetNewInstance(_unityC, _panelModel, _frameModel, _mainPresenter);
                    IFixedPanelUC fixedUC = fixedUCP.GetFixedPanelUC();
                    fpnl.Controls.Add((UserControl)fixedUC);
                    fixedUCP.SetInitialLoadFalse();

                    //IFixedPanelImagerUCPresenter fixedImagerUCP = _fixedImagerUCP.GetNewInstance(_unityC, _panelModel);
                    //IFixedPanelImagerUC fixedImagerUC = fixedImagerUCP.GetFixedPanelImagerUC();
                    //pnl_inner_willRenderImg.Controls.Add((UserControl)fixedImagerUC);
                }
            }
        }

        private void _multiPanelMullionUC_deleteClickedEventRaised(object sender, EventArgs e)
        {
            _multiPanelModel.MPanel_Visibility = false;
            if (_frameModel.Frame_Type.ToString().Contains("Window"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Window;
            }
            else if (_frameModel.Frame_Type.ToString().Contains("Door"))
            {
                _frameModel.Frame_Type = FrameModel.Frame_Padding.Door;
            }
        }

        private void _multiPanelMullionUC_divCountClickedEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input no. of division", "WinDoor Maker", "1");
            if (input != "" && input != "0")
            {
                try
                {
                    int int_input = Convert.ToInt32(input);
                    if (int_input > 0)
                    {
                        _multiPanelModel.MPanel_Divisions = int_input;
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }
        }

        private void _multiPanelMullionUC_flpMultiMouseLeaveEventRaised(object sender, EventArgs e)
        {
            color = Color.Black;
            _multiPanelMullionUC.InvalidateFlp();
        }

        private void _multiPanelMullionUC_flpMultiMouseEnterEventRaised(object sender, EventArgs e)
        {
            color = Color.Blue;
            _multiPanelMullionUC.InvalidateFlp();
        }

        Color color = Color.Black;
        private void _multiPanelMullionUC_flpMulltiPaintEventRaised(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FlowLayoutPanel fpnl = (FlowLayoutPanel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pInnerX = 10,
            pInnerY = 10,
            pInnerWd = fpnl.ClientRectangle.Width - 20,
            pInnerHt = fpnl.ClientRectangle.Height - 20;

            Point[] corner_points = new[]
            {
                    new Point(0,0),
                    new Point(pInnerX, pInnerY),
                    new Point(fpnl.ClientRectangle.Width, 0),
                    new Point(pInnerX + pInnerWd, pInnerY),
                    new Point(0, fpnl.ClientRectangle.Height),
                    new Point(pInnerX, pInnerY + pInnerHt),
                    new Point(fpnl.ClientRectangle.Width, fpnl.ClientRectangle.Height),
                    new Point(pInnerX + pInnerWd, pInnerY + pInnerHt)
                };

            for (int i = 0; i < corner_points.Length - 1; i += 2)
            {
                g.DrawLine(Pens.Black, corner_points[i], corner_points[i + 1]);
            }


            Rectangle bounds = new Rectangle(new Point(10, 10),
                                             new Size(fpnl.ClientRectangle.Width - 20, fpnl.ClientRectangle.Height - 20));
            g.FillRectangle(new SolidBrush(SystemColors.ActiveCaption), bounds);
            g.DrawRectangle(new Pen(color, 1), bounds);

            Font drawFont = new Font("Segoe UI", 12); //* zoom);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Near;
            g.DrawString("Multi_Panel: " + _multiPanelModel.MPanel_Type + "(" + _multiPanelModel.MPanel_Divisions + ")", drawFont, new SolidBrush(Color.Black), 10, 10);

            //int w = 1;
            //int w2 = Convert.ToInt32(Math.Floor(w / (double)2));
            //g.DrawRectangle(new Pen(color, w), new Rectangle(0,
            //                                                 0,
            //                                                 pnl.ClientRectangle.Width - w,
            //                                                 pnl.ClientRectangle.Height - w));

        }

        public IMultiPanelMullionUC GetMultiPanel()
        {
            _multiPanelMullionUC.ThisBinding(CreateBindingDictionary());
            return _multiPanelMullionUC;
        }

        public IMultiPanelMullionUCPresenter GetNewInstance(IUnityContainer unityC,
                                                            IMultiPanelModel multiPanelModel,
                                                            IFrameModel frameModel, 
                                                            IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IMultiPanelMullionUC, MultiPanelMullionUC>()
                .RegisterType<IMultiPanelMullionUCPresenter, MultiPanelMullionUCPresenter>();
            MultiPanelMullionUCPresenter multiMullionUCP = unityC.Resolve<MultiPanelMullionUCPresenter>();
            multiMullionUCP._unityC = unityC;
            multiMullionUCP._multiPanelModel = multiPanelModel;
            multiMullionUCP._frameModel = frameModel;
            multiMullionUCP._mainPresenter = mainPresenter;

            return multiMullionUCP;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> multiPanelBinding = new Dictionary<string, Binding>();
            multiPanelBinding.Add("MPanel_ID", new Binding("MPanel_ID", _multiPanelModel, "MPanel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Dock", new Binding("Dock", _multiPanelModel, "MPanel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Width", new Binding("Width", _multiPanelModel, "MPanel_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Height", new Binding("Height", _multiPanelModel, "MPanel_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            multiPanelBinding.Add("MPanel_Visibility", new Binding("Visible", _multiPanelModel, "MPanel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return multiPanelBinding;
        }

        public void frmDimensionResults(int frmDimension_numWd, int frmDimension_numHt)
        {
            //_panelModel.Panel_Width = frmDimension_numWd;
            //_panelModel.Panel_Height = frmDimension_numHt;
            _frmDmRes_Width = frmDimension_numWd;
            _frmDmRes_Height = frmDimension_numHt;
            _frmDimensionPresenter.GetDimensionView().ClosefrmDimension();
        }
    }
}
