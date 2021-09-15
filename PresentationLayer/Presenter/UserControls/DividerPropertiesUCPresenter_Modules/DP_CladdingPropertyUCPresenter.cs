using CommonComponents;
using ModelLayer.Model.Quotation.Divider;
using PresentationLayer.Views.UserControls.DividerProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public class DP_CladdingPropertyUCPresenter : IDP_CladdingPropertyUCPresenter
    {
        IDP_CladdingPropertyUC _dp_claddingPropertyUC;

        private IUnityContainer _unityC;
        private IDividerModel _dividerModel;

        private IDividerPropertiesUCPresenter _divPropUCP;
        
        public DP_CladdingPropertyUCPresenter(IDP_CladdingPropertyUC dp_claddingPropertyUC)
        {
            _dp_claddingPropertyUC = dp_claddingPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _dp_claddingPropertyUC.DPCladdingPropertyUCLoadEventRaised += _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised;
            _dp_claddingPropertyUC.numCladdingSizeValueChangedEventRaised += _dp_claddingPropertyUC_numCladdingSizeValueChangedEventRaised;
            _dp_claddingPropertyUC.btnDeleteCladdingClickedEventRaised += _dp_claddingPropertyUC_btnDeleteCladdingClickedEventRaised;
        }

        private void _dp_claddingPropertyUC_btnDeleteCladdingClickedEventRaised(object sender, EventArgs e)
        {
            _dividerModel.AdjustPropertyPanelHeight("minusCladding");
            _dividerModel.Div_MPanelParent.AdjustPropertyPanelHeight("Div", "minusCladding");
            _dividerModel.Div_FrameParent.AdjustPropertyPanelHeight("Div", "minusCladding");

            _divPropUCP.Cladding_Count--;
            _divPropUCP.SetSaveBtnColor(Color.White);

            Control pnl_parent = ((UserControl)_dp_claddingPropertyUC).Parent;
            pnl_parent.Controls.Remove((UserControl)_dp_claddingPropertyUC);
        }

        private void _dp_claddingPropertyUC_numCladdingSizeValueChangedEventRaised(object sender, EventArgs e)
        {
            _divPropUCP.SetSaveBtnColor(Color.White);
        }

        private void _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
            _dp_claddingPropertyUC.Divider_Type = _dividerModel.Div_Type.ToString();
        }

        public IDP_CladdingPropertyUC GetCladdingPropertyUC()
        {
            return _dp_claddingPropertyUC;
        }

        public IDP_CladdingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, 
                                                              IDividerModel divModel, 
                                                              IDividerPropertiesUCPresenter divPropUCP)
        {
            unityC
                .RegisterType<IDP_CladdingPropertyUC, DP_CladdingPropertyUC>()
                .RegisterType<IDP_CladdingPropertyUCPresenter, DP_CladdingPropertyUCPresenter>();
            DP_CladdingPropertyUCPresenter presenter = unityC.Resolve<DP_CladdingPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._dividerModel = divModel;
            presenter._divPropUCP = divPropUCP;

            return presenter;
        }
    }
}
