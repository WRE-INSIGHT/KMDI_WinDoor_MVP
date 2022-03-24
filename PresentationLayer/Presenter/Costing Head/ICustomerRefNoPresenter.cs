using System.Windows.Forms;
using ModelLayer.Model.User;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface ICustomerRefNoPresenter
    {
        ICustomerRefNoPresenter GetNewInstance(IUnityContainer unityC, IAssignProjectsPresenter assignProjPresenter);
        void Set_SelectedRows(DataGridViewSelectedRowCollection dgvProjSelectedRows);
        void Set_UserModel(IUserModel userModel);
        void ShowThisView();
    }
}