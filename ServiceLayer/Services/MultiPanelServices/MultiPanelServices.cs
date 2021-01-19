using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.MultiPanel;
using ServiceLayer.CommonServices;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Panel;

namespace ServiceLayer.Services.MultiPanelServices
{
    public class MultiPanelServices : IMultiPanelServices
    {
        private IModelDataAnnotationCheck _modelCheck;

        public MultiPanelServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

        public IMultiPanelModel CreateMultiPanel(int mid,
                                                 string mname,
                                                 int mwidth,
                                                 int mheight,
                                                 DockStyle mdock,
                                                 bool mvisible,
                                                 FlowDirection mflow,
                                                 Control mpanelParent,
                                                 UserControl mpanelFrameGroup,
                                                 int mpanelDivisions,
                                                 List<IPanelModel> mpanelLstPanel)
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
                                                      mpanelLstPanel);

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
                                                   string mname = "",
                                                   DockStyle mdock = DockStyle.Fill,
                                                   int mpanelDivisions = 1,
                                                   List<IPanelModel> mpanelLstPanel = null)
        {
            if (mname == "")
            {
                mname = "MultiPanel " + mid;
            }
            if (mpanelLstPanel == null)
            {
                mpanelLstPanel = new List<IPanelModel>();
            }
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
                                                                 mpanelLstPanel);

            return _multipanelModel;
        }
    }
}
