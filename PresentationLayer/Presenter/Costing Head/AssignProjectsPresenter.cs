using CommonComponents;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class AssignProjectsPresenter : IAssignProjectsPresenter
    {
        IAssignProjectsView _assignProjView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IProjectQuoteServices _projQuoteServices;
        private IMainPresenter _mainPresenter;
        private ICostEngrEmployeePresenter _ceEmpPresenter;

        DataGridView _dgvProj;

        public AssignProjectsPresenter(IAssignProjectsView assignProjView, IProjectQuoteServices projQuoteServices,
                                       ICostEngrEmployeePresenter ceEmpPresenter)
        {
            _assignProjView = assignProjView;
            _projQuoteServices = projQuoteServices;
            _ceEmpPresenter = ceEmpPresenter;

            _dgvProj = _assignProjView.DGV_Projects;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _assignProjView.AssignProjectsViewLoadEventRaised += _assignProjView_AssignProjectsViewLoadEventRaised;
            _assignProjView.assignCostEngrToolStripMenuItemClickEventRaised += _assignProjView_assignCostEngrToolStripMenuItemClickEventRaised;
        }

        private void _assignProjView_assignCostEngrToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            if (_dgvProj.SelectedRows.Count > 0)
            {
                ICostEngrEmployeePresenter ceEmpPresenter = _ceEmpPresenter.GetNewInstance(_unityC, this);
                ceEmpPresenter.Set_SelectedRows(_dgvProj.SelectedRows);
                ceEmpPresenter.Set_UserModel(_userModel);
                ceEmpPresenter.ShowThisView();
            }
            else
            {
                MessageBox.Show("Please select project(s)");
            }
        }

        private async void _assignProjView_AssignProjectsViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVProjects("");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                throw new Exception("Error Message: " + ex.Message);
            }
        }

        public async Task Load_DGVProjects(string searchStr)
        {
            DataTable dt = await _projQuoteServices.Get_AssignedProjects(searchStr);
            _dgvProj.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvProj.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _dgvProj.Columns["Id"].Visible = false;
            _dgvProj.Columns["Project_Id"].Visible = false;
            _dgvProj.Columns["Quote_Id"].Visible = false;
            _dgvProj.Columns["Customer_Reference_Id"].Visible = false;

            _dgvProj.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
        }

        public void ShowThisView()
        {
            _assignProjView.ShowThis();
        }

        public void Set_UserModel(IUserModel userModel)
        {
            _userModel = userModel;
        }

        public IAssignProjectsPresenter GetNewInstance(IUnityContainer unityC,
                                                       IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IAssignProjectsView, AssignProjectsView>()
                .RegisterType<IAssignProjectsPresenter, AssignProjectsPresenter>();
            AssignProjectsPresenter presenter = unityC.Resolve<AssignProjectsPresenter>();
            presenter._unityC = unityC;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }
    }
}
