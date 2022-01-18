using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls.FrameProperties_Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter.UserControls.FramePropertiesUCPresenter_Modules
{
    public class FP_BottomFramePropertyUCPresenter : IFP_BottomFramePropertyUCPresenter
    {
        IFP_BottomFramePropertyUC _fp_bottomFramePropertiesUC;

        private IFrameModel _frameModel;

        public FP_BottomFramePropertyUCPresenter(IFP_BottomFramePropertyUC fp_bottomFramePropertiesUC)
        {
            _fp_bottomFramePropertiesUC = fp_bottomFramePropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            
        }


        public IFP_BottomFramePropertyUC GetFP_BottomFramePropertiesUC()
        {
            return _fp_bottomFramePropertiesUC;
        }

        public IFP_BottomFramePropertyUCPresenter GetNewInstance(IFrameModel frameModel,
                                                                 IUnityContainer unityC)
        {
            unityC
                .RegisterType<IFP_BottomFramePropertyUC, FP_BottomFramePropertyUC>()
                .RegisterType<IFP_BottomFramePropertyUCPresenter, FP_BottomFramePropertyUCPresenter>();
            FP_BottomFramePropertyUCPresenter fp_bottomframePropertiesUCP = unityC.Resolve<FP_BottomFramePropertyUCPresenter>();
            fp_bottomframePropertiesUCP._frameModel = frameModel;

            return fp_bottomframePropertiesUCP;
        }
    }
}