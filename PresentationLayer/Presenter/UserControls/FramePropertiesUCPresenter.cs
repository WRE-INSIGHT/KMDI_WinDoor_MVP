using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public class FramePropertiesUCPresenter : IFramePropertiesUCPresenter
    {
        IFramePropertiesUC _framePropertiesUC;
        private IFrameModel _frameModel;

        public FramePropertiesUCPresenter(IFramePropertiesUC framePropertiesUC)
        {
            _framePropertiesUC = framePropertiesUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _framePropertiesUC.FramePropertiesLoadEventRaised += new EventHandler(OnFramePropertiesLoadEventRaised);
        }

        private void OnFramePropertiesLoadEventRaised(object sender, EventArgs e)
        {
            _framePropertiesUC.Frame_Name = _frameModel.Frame_Name;
            _framePropertiesUC.Frame_Type = _frameModel.Frame_Type;
            _framePropertiesUC.fWidth = _frameModel.Frame_Width;
            _framePropertiesUC.fHeight = _frameModel.Frame_Height;
            _framePropertiesUC.BringToFrontThis();
        }

        public IFramePropertiesUC GetFramePropertiesUC()
        {
            return _framePropertiesUC;
        }

        public IFramePropertiesUCPresenter GetNewInstance(IFrameModel frameModel)
        {
            IUnityContainer unityC;
            unityC =
                new UnityContainer()
                .RegisterType<IFramePropertiesUC, FramePropertiesUC>()
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>();
            FramePropertiesUCPresenter framePropertiesUCP = unityC.Resolve<FramePropertiesUCPresenter>();
            framePropertiesUCP._frameModel = frameModel;

            return framePropertiesUCP;
        }
    }
}
