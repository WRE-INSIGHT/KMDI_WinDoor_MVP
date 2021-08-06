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

namespace PresentationLayer.Presenter.UserControls.DividerPropertiesUCPresenter_Modules
{
    public class DP_CladdingPropertyUCPresenter : IDP_CladdingPropertyUCPresenter
    {
        IDP_CladdingPropertyUC _dp_claddingPropertyUC;

        private IUnityContainer _unityC;
        private IDividerModel _dividerModel;

        public DP_CladdingPropertyUCPresenter(IDP_CladdingPropertyUC dp_claddingPropertyUC)
        {
            _dp_claddingPropertyUC = dp_claddingPropertyUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _dp_claddingPropertyUC.DPCladdingPropertyUCLoadEventRaised += _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised;
        }

        private void _dp_claddingPropertyUC_DPCladdingPropertyUCLoadEventRaised(object sender, EventArgs e)
        {
        }

        public IDP_CladdingPropertyUC GetCladdingPropertyUC()
        {
            return _dp_claddingPropertyUC;
        }

        public IDP_CladdingPropertyUCPresenter GetNewInstance(IUnityContainer unityC, IDividerModel divModel)
        {
            unityC
                .RegisterType<IDP_CladdingPropertyUC, DP_CladdingPropertyUC>()
                .RegisterType<IDP_CladdingPropertyUCPresenter, DP_CladdingPropertyUCPresenter>();
            DP_CladdingPropertyUCPresenter presenter = unityC.Resolve<DP_CladdingPropertyUCPresenter>();
            presenter._unityC = unityC;
            presenter._dividerModel = divModel;

            return presenter;
        }
    }
}
