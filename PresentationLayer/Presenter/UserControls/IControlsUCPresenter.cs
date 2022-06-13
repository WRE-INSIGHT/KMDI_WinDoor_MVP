using ModelLayer.Model.Quotation;
using PresentationLayer.Views.UserControls;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IControlsUCPresenter
    {
        IControlsUC GetControlUC();
        IControlsUCPresenter GetNewInstance(IUnityContainer unityC, IQuotationModel quotationModel, string customtext, UserControl usercontrol); //
        List<string> Lst_PanelType { get; set; }
    }
}