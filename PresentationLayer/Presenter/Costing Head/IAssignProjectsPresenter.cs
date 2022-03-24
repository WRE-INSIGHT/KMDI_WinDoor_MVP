using ModelLayer.Model.User;
using System.Threading.Tasks;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface IAssignProjectsPresenter
    {
        IAssignProjectsPresenter GetNewInstance(IUnityContainer unityC, IMainPresenter mainPresenter);
        Task Load_DGVProjects(string searchStr);

        void ShowThisView();
        void Set_UserModel(IUserModel userModel);
        void SetEnableThisView(bool enable);
    }
}