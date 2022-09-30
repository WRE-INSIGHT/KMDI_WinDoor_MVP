using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface IAssignAEPresenter
    {
        IAssignAEPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter);
        Task Load_DGVClient(string searchStr);

        void ShowThisView();
        void Set_UserModel(IUserModel userModel);
        void SetEnableThisView(bool enable);
    }
}
