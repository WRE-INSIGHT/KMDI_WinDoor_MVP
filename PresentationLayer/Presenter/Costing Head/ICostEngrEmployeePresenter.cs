using ModelLayer.Model.User;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public interface ICostEngrEmployeePresenter
    {
        ICostEngrEmployeePresenter GetNewInstance(IUnityContainer unityC, IAssignProjectsPresenter assignProjPresenter);
        void ShowThisView();
        void Set_SelectedRows(DataGridViewSelectedRowCollection dgvProjSelectedRows);
        void Set_UserModel(IUserModel userModel);
    }
}