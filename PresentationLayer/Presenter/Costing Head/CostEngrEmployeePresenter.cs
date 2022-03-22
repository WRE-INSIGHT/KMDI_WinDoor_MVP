using CommonComponents;
using ModelLayer.Model.ProjectQuote;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.EmployeeServices;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class CostEngrEmployeePresenter : ICostEngrEmployeePresenter
    {
        ICostEngrEmployeeView _ceEmpView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IEmployeeServices _empServices;
        private IProjectQuoteServices _pqServices;
        private IAssignProjectsPresenter _assignProjPresenter;

        private CheckedListBox _chkCEList;
        private DataGridViewSelectedRowCollection _dgvProjSelectedRows;

        public CostEngrEmployeePresenter(ICostEngrEmployeeView ceEmpView, IEmployeeServices empServices,
                                         IProjectQuoteServices pqServices)
        {
            _ceEmpView = ceEmpView;
            _empServices = empServices;
            _pqServices = pqServices;

            _chkCEList = _ceEmpView.ChkList_CE;

            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _ceEmpView.CostEngrEmployeeViewLoadEventRaised += _ceEmpView_CostEngrEmployeeViewLoadEventRaised;
            _ceEmpView.btnAcceptClickEventRaised += _ceEmpView_btnAcceptClickEventRaised;
        }

        private void _ceEmpView_btnAcceptClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in _dgvProjSelectedRows)
                {
                    _pqServices.Delete_ProjQuote(Convert.ToInt32(row.Cells["Id"].Value), _userModel.UserID);

                    foreach (DataRowView chkListVal in _chkCEList.CheckedItems)
                    {
                        int emp_id = Convert.ToInt32(chkListVal["Id"]);
                        IProjectQuoteModel pqModel = _pqServices.AddProjectQuote(0,
                                                                                 Convert.ToInt32(row.Cells["Project_Id"].Value),
                                                                                 Convert.ToInt32(row.Cells["Customer_Reference_Id"].Value),
                                                                                 emp_id,
                                                                                 Convert.ToInt32(row.Cells["Quote_Id"].Value),
                                                                                 DateTime.Now);

                        _pqServices.Insert_ProjQuote(pqModel, _userModel.UserID);
                    }
                }

                _assignProjPresenter.Load_DGVProjects("");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                throw new Exception("Error Message: " + ex.Message);
            }
        }

        private async void _ceEmpView_CostEngrEmployeeViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_ChkCEList("");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                throw new Exception("Error Message: " + ex.Message);
            }
        }

        private async Task Load_ChkCEList(string searchStr)
        {
            _chkCEList.DataSource = await _empServices.GetCostEngrEmp(searchStr);
            _chkCEList.DisplayMember = "Full_Name";
            _chkCEList.ValueMember = "Id";
        }

        public void ShowThisView()
        {
            _ceEmpView.ShowThis();
        }

        public void Set_SelectedRows(DataGridViewSelectedRowCollection dgvProjSelectedRows)
        {
            _dgvProjSelectedRows = dgvProjSelectedRows;
        }

        public void Set_UserModel(IUserModel userModel)
        {
            _userModel = userModel;
        }

        public ICostEngrEmployeePresenter GetNewInstance(IUnityContainer unityC,
                                                       IAssignProjectsPresenter assignProjPresenter)
        {
            unityC
                .RegisterType<ICostEngrEmployeeView, CostEngrEmployeeView>()
                .RegisterType<ICostEngrEmployeePresenter, CostEngrEmployeePresenter>();
            CostEngrEmployeePresenter presenter = unityC.Resolve<CostEngrEmployeePresenter>();
            presenter._unityC = unityC;
            presenter._assignProjPresenter = assignProjPresenter;

            return presenter;
        }
    }
}
