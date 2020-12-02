using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.FrameServices;
using Unity;
using System.Windows.Forms;
using CommonComponents;

namespace PresentationLayer.Presenter.UserControls
{
    public class FramePropertiesUCPresenter : IFramePropertiesUCPresenter
    {
        IFramePropertiesUC _framePropertiesUC;
        private IFrameModel _frameModel;

        private IFrameServices _frameServices;

        public FramePropertiesUCPresenter(IFramePropertiesUC framePropertiesUC,
                                          IFrameServices frameServices)
        {
            _framePropertiesUC = framePropertiesUC;
            _frameServices = frameServices;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _framePropertiesUC.FramePropertiesLoadEventRaised += new EventHandler(OnFramePropertiesLoadEventRaised);
            _framePropertiesUC.NumFHeightValueChangedEventRaised += new EventHandler(OnNumFHeightValueChangedEventRaised);
        }

        private void OnNumFHeightValueChangedEventRaised(object sender, EventArgs e)
        {
            NumericUpDown numH = (NumericUpDown)sender;
            _frameModel.Frame_Height = Convert.ToInt32(numH.Value);
        }

        private Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> frameBinding = new Dictionary<string, Binding>();
            frameBinding.Add("Frame_Name", new Binding("Text", _frameModel, "Frame_Name", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Visible", new Binding("Visible", _frameModel, "Frame_Visible", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Width", new Binding("Value", _frameModel, "Frame_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Height", new Binding("Value", _frameModel, "Frame_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            frameBinding.Add("Frame_Type_Window", AddRadioCheckedBinding(_frameModel, "Frame_Type", FrameModel.Frame_Padding.Window));
            frameBinding.Add("Frame_Type_Door", AddRadioCheckedBinding(_frameModel, "Frame_Type", FrameModel.Frame_Padding.Door));
            frameBinding.Add("Frame_Type_Concrete", AddRadioCheckedBinding(_frameModel, "Frame_Type", FrameModel.Frame_Padding.Concrete));

            return frameBinding;
        }
        private Binding AddRadioCheckedBinding<T>(object dataSource, string dataMember, T trueValue)
        {
            var binding = new Binding(nameof(RadioButton.Checked), dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (s, a) => { if ((bool)a.Value) a.Value = trueValue; };
            binding.Format += (s, a) => a.Value = ((T)a.Value).Equals(trueValue);
            return binding;
        }

        private void OnFramePropertiesLoadEventRaised(object sender, EventArgs e)
        {
            //_framePropertiesUC.Frame_Name = _frameModel.Frame_Name;
            //_framePropertiesUC.Frame_Type = _frameModel.Frame_Type;
            //_framePropertiesUC.fWidth = _frameModel.Frame_Width;
            //_framePropertiesUC.fHeight = _frameModel.Frame_Height;
            //_framePropertiesUC.ThisVisibility = _frameModel.Frame_Visible;

            _framePropertiesUC.ThisBinding(CreateBindingDictionary());
            _framePropertiesUC.BringToFrontThis();
        }

        public IFramePropertiesUC GetFramePropertiesUC()
        {
            return _framePropertiesUC;
        }

        public IFramePropertiesUCPresenter GetNewInstance(IFrameModel frameModel, IUnityContainer unityC)
        {
            unityC
                .RegisterType<IFramePropertiesUC, FramePropertiesUC>()
                .RegisterType<IFramePropertiesUCPresenter, FramePropertiesUCPresenter>();
            FramePropertiesUCPresenter framePropertiesUCP = unityC.Resolve<FramePropertiesUCPresenter>();
            framePropertiesUCP._frameModel = frameModel;

            return framePropertiesUCP;
        }
    }
}
