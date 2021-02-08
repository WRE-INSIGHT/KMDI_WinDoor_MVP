using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.MultiPanel;
using ServiceLayer.CommonServices;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.Divider;

namespace ServiceLayer.Services.MultiPanelServices
{
    public class MultiPanelServices : IMultiPanelServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public MultiPanelServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        private IMultiPanelModel CreateMultiPanel(int mid,
                                                 string mname,
                                                 int mwidth,
                                                 int mheight,
                                                 DockStyle mdock,
                                                 bool mvisible,
                                                 FlowDirection mflow,
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
            MultiPanelModel mp = new MultiPanelModel(mid,
                                                     mname,
                                                     mwidth,
                                                     mheight,
                                                     mdock,
                                                     mvisible,
                                                     mflow,
                                                     mpanelParent,
                                                     mpanelFrameGroup,
                                                     mpanelDivisions,
                                                     mpanelLstPanel,
                                                     mpanelLstDivider,
                                                     mpanelLstMultiPanel,
                                                     mpanelIndexInsideMPanel,
                                                     mpanelLstObjects,
                                                     mpanelParentModel);

            return mp;
        }

        public void ValidateModel(IMultiPanelModel multiPanelModel)
        {
            _modelCheck.ValidateModelDataAnnotations(multiPanelModel);
        }

        public IMultiPanelModel AddMultiPanelModel(int mwidth,
                                                   int mheight,
                                                   Control mpanelParent,
                                                   UserControl mpanelFrameGroup,
                                                   bool mvisible,
                                                   FlowDirection mflow,
                                                   int mid = 0,
                                                   DockStyle mdock = DockStyle.Fill,
                                                   int mpanelIndexInsideMPanel = 0,
                                                   IMultiPanelModel mpanelParentModel = null,
                                                   string mname = "",
                                                   int mpanelDivisions = 1,
                                                   List<IPanelModel> mpanelLstPanel = null,
                                                   List<IDividerModel> mpanelLstDivider = null,
                                                   List<IMultiPanelModel> mpanelLstMultiPanel = null)
        {
            if (mname == "")
            {
                if (mflow == FlowDirection.LeftToRight)
                {
                    mname = "MultiMullion_" + mid;
                }
                else if (mflow == FlowDirection.TopDown)
                {
                    mname = "MultiTransom_" + mid;
                }
            }
            if (mpanelLstPanel == null)
            {
                mpanelLstPanel = new List<IPanelModel>();
            }
            if (mpanelLstDivider == null)
            {
                mpanelLstDivider = new List<IDividerModel>();
            }
            if (mpanelLstMultiPanel == null)
            {
                mpanelLstMultiPanel = new List<IMultiPanelModel>();
            }
            //if (mpanelLstObjects == null)
            //{
            //    mpanelLstObjects = new List<Control>();
            //}
            IMultiPanelModel _multipanelModel = CreateMultiPanel(mid,
                                                                 mname,
                                                                 mwidth,
                                                                 mheight,
                                                                 mdock,
                                                                 mvisible,
                                                                 mflow,
                                                                 mpanelParent,
                                                                 mpanelFrameGroup,
                                                                 mpanelDivisions,
                                                                 mpanelLstPanel,
                                                                 mpanelLstDivider,
                                                                 mpanelLstMultiPanel,
                                                                 mpanelIndexInsideMPanel,
                                                                 new List<Control>(),
                                                                 mpanelParentModel);

            return _multipanelModel;
        }
    }
}
