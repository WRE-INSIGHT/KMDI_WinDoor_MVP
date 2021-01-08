using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views.UserControls.WinDoorPanels.Imagers;
using ModelLayer.Model.Quotation.Panel;
using Unity;
using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls.WinDoorPanels.Imagers
{
    public class FixedPanelImagerUCPresenter : IFixedPanelImagerUCPresenter, IPresenterCommon
    {
        IFixedPanelImagerUC _fixedPanelImagerUC;
        private IPanelModel _panelModel;

        public FixedPanelImagerUCPresenter(IFixedPanelImagerUC fixedPanelImagerUC)
        {
            _fixedPanelImagerUC = fixedPanelImagerUC;
        }

        public IFixedPanelImagerUCPresenter GetNewInstance(IUnityContainer unityC,
                                                           IPanelModel panelModel)
        {
            unityC
                .RegisterType<IFixedPanelImagerUC, FixedPanelImagerUC>()
                .RegisterType<IFixedPanelImagerUCPresenter, FixedPanelImagerUCPresenter>();
            FixedPanelImagerUCPresenter imagerUCP = unityC.Resolve<FixedPanelImagerUCPresenter>();
            imagerUCP._panelModel = panelModel;

            return imagerUCP;
        }

        public IFixedPanelImagerUC GetFixedPanelImagerUC()
        {
            _fixedPanelImagerUC.ThisBinding(CreateBindingDictionary());
            return _fixedPanelImagerUC;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> panelBinding = new Dictionary<string, Binding>();
            panelBinding.Add("Panel_ID", new Binding("Panel_ID", _panelModel, "Panel_ID", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Dock", new Binding("Dock", _panelModel, "Panel_Dock", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Width", new Binding("Width", _panelModel, "PanelImageRenderer_Width", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("PanelImageRenderer_Height", new Binding("Height", _panelModel, "PanelImageRenderer_Height", true, DataSourceUpdateMode.OnPropertyChanged));
            panelBinding.Add("Panel_Visibility", new Binding("Visible", _panelModel, "Panel_Visibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return panelBinding;
        }
    }

}
