using ModelLayer.Model.Quotation.Divider;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Presenter.UserControls.Dividers;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views.UserControls.Dividers;
using ServiceLayer.Services.DividerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.CommonMethods
{
    public class CommonFunctions
    {
        public void Automatic_Div_Addition(IFrameModel frameModel,
                                           IDividerServices divServices,
                                           //IFrameUCPresenter frameUCP,
                                           ITransomUCPresenter _transomUCP,
                                           IUnityContainer _unityC,
                                           IMullionUCPresenter _mullionUCP,
                                           int divID,
                                           IMultiPanelModel multiPanelModel = null,
                                           IPanelModel panelModel = null,
                                           IMultiPanelTransomUCPresenter multiTransomUCP = null,
                                           IMultiPanelMullionUCPresenter multiMullionUCP = null)
        {
            FlowLayoutPanel parentfpnl = new FlowLayoutPanel();
            IMultiPanelModel parentModel = null;

            if (panelModel == null)
            {
                parentfpnl = (FlowLayoutPanel)multiPanelModel.MPanel_Parent;
                parentModel = multiPanelModel.MPanel_ParentModel;
            }
            else if (panelModel != null)
            {
                parentfpnl = (FlowLayoutPanel)panelModel.Panel_Parent;
                parentModel = multiPanelModel;
            }

            int divSize = 0;

            if (frameModel.Frame_Type.ToString().Contains("Window"))
            {
                divSize = 26;
            }
            else if (frameModel.Frame_Type.ToString().Contains("Door"))
            {
                divSize = 33;
            }

            Control last_ctrl = null;
            if (parentModel.MPanelLst_Objects.Count() >= 1)
            {
                last_ctrl = parentModel.MPanelLst_Objects.Last();
            }

            if (last_ctrl != null && !last_ctrl.Name.Contains("TransomUC") && !last_ctrl.Name.Contains("MullionUC"))
            {
                int divHT = 0, divWd = 0;
                DividerModel.DividerType divType = DividerModel.DividerType.Mullion;
                if (parentModel.MPanel_Type == "Transom")
                {
                    divType = DividerModel.DividerType.Transom;
                    divHT = divSize;
                    divWd = parentfpnl.Width;
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    divType = DividerModel.DividerType.Mullion;
                    divHT = parentfpnl.Height;
                    divWd = divSize;
                }

                IDividerModel divModel = divServices.AddDividerModel(divWd,
                                                                     divHT,
                                                                     parentfpnl,
                                                                     //(UserControl)frameUCP.GetFrameUC(),
                                                                     divType,
                                                                     true,
                                                                     divID,
                                                                     frameModel.Frame_Type.ToString());

                frameModel.Lst_Divider.Add(divModel);
                parentModel.MPanelLst_Divider.Add(divModel);

                if (parentModel.MPanel_Type == "Transom")
                {
                    ITransomUCPresenter transomUCP = null;
                    if (multiTransomUCP != null)
                    {
                        transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiTransomUCP,
                                                                frameModel);
                    }
                    else if (multiMullionUCP != null)
                    {
                        transomUCP = _transomUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiMullionUCP,
                                                                frameModel);
                    }

                    ITransomUC transomUC = transomUCP.GetTransom();
                    parentfpnl.Controls.Add((UserControl)transomUC);
                    transomUCP.SetInitialLoadFalse();//SetInitialLoadFalse para magresize yung div
                    parentModel.AddControl_MPanelLstObjects((UserControl)transomUC, frameModel.Frame_Type.ToString());
                }
                else if (parentModel.MPanel_Type == "Mullion")
                {
                    IMullionUCPresenter mullionUCP = null;

                    if (multiTransomUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiTransomUCP,
                                                                frameModel);
                    }
                    else if (multiMullionUCP != null)
                    {
                        mullionUCP = _mullionUCP.GetNewInstance(_unityC,
                                                                divModel,
                                                                parentModel,
                                                                multiMullionUCP,
                                                                frameModel);
                    }

                    IMullionUC mullionUC = mullionUCP.GetMullion();
                    parentfpnl.Controls.Add((UserControl)mullionUC);
                    mullionUCP.SetInitialLoadFalse();//SetInitialLoadFalse para magresize yung div
                    parentModel.AddControl_MPanelLstObjects((UserControl)mullionUC, frameModel.Frame_Type.ToString());
                }
            }
        }
    }
}
