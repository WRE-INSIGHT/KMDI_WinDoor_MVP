using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface IAddProjectPresenter
    {
        IAddProjectPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter, int projectId, IUserModel userModel);
        void ShowThisView();
        void ClearBinding();
        void ClearProjectModel();
    }
}
