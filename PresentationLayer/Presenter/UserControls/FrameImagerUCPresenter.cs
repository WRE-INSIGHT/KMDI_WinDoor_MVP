using CommonComponents;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls
{
    public class FrameImagerUCPresenter : IFrameImagerUCPresenter, IPresenterCommon
    {
        IFrameImagerUC _frameImagerUC;
        private IUnityContainer _unityC;

        private IFrameModel _frameModel;

        public FrameImagerUCPresenter(IFrameImagerUC frameImagerUC)
        {
            _frameImagerUC = frameImagerUC;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            
        }

        public IFrameImagerUC GetFrameImagerUC()
        {
            _frameImagerUC.ThisBinding(CreateBindingDictionary());
            return _frameImagerUC;
        }

        public IFrameImagerUCPresenter GetNewInstance(IUnityContainer unityC, IFrameModel frameModel)//, IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IFrameImagerUC, FrameImagerUC>()
                .RegisterType<IFrameImagerUCPresenter, FrameImagerUCPresenter>();
            FrameImagerUCPresenter frameImagerPresenter = unityC.Resolve<FrameImagerUCPresenter>();
            frameImagerPresenter._frameModel = frameModel;
            //framePresenter._mainPresenter = mainPresenter;
            frameImagerPresenter._unityC = unityC;

            return frameImagerPresenter;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("FrameImageRenderer_Width", new Binding("Width", _frameModel, "FrameImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("FrameImageRenderer_Height", new Binding("Height", _frameModel, "FrameImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Padding", new Binding("Padding", _frameModel, "Frame_Padding_int", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_ID", new Binding("frameID", _frameModel, "Frame_ID", true, DataSourceUpdateMode.OnPropertyChanged));

            return frameBinding;
        }
    }
}
