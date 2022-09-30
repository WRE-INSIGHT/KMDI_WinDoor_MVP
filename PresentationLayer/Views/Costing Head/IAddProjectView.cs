using CommonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.Costing_Head
{
    public interface IAddProjectView : IViewCommon
    {
        event EventHandler cmbProvinceSelectedItemChange;
        event EventHandler AddProjectViewLoadEventRaised;
        event EventHandler btnSaveClickEventRaised;
        ComboBox cmbCity();
        ComboBox cmbProvince();
        ComboBox cmbArea();
        void ShowThisView();
        void CloseThisView();
    }
}
