using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.User;
using Unity;
using PresentationLayer.Views.Costing_Head;
using CommonComponents;
using System.Data;
using ServiceLayer.Services.ProjectQuoteServices;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class AssignAEPresenter : IAssignAEPresenter
    {
        IAssignAEView _assignAEView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private IProjectQuoteServices _projQuoteServices;
        private IAddProjectPresenter _addProjectPresenter;
        private IMainPresenter _mainPresenter;
        //private ICostEngrEmployeePresenter _ceEmpPresenter;
        //private ICustomerRefNoPresenter _custRefNoPresenter;
        DataGridView _dgvClient, _dgvAEIC, _dgvProject;
        public AssignAEPresenter(IAssignAEView assignAEView
                                ,IProjectQuoteServices projQuoteServices
                                ,IAddProjectPresenter addProjectPresenter)
        {
            _assignAEView = assignAEView;
            _projQuoteServices = projQuoteServices;
            SubscribeToEventsSetup();
            _dgvClient = _assignAEView.DGV_Client;
            _dgvAEIC = _assignAEView.DGV_AEIC;
            _addProjectPresenter = addProjectPresenter;
            _dgvProject = _assignAEView.DGV_Project;
        }

        private void SubscribeToEventsSetup()
        {
            _assignAEView.AssignAEViewLoadEventRaised += _assignAEView_AssignAEViewLoadEventRaised;
            _assignAEView.btnSearchProjClickEventRaised += _assignAEView_btnSearchProjClickEventRaised;
            _assignAEView.btnSearchAEICClickEventRaised += _assignAEView_btnSearchAEICClickEventRaised;
            _assignAEView.btnEqualClickEventRaised += _assignAEView_btnEqualClickEventRaised;
            _assignAEView.DeleteToolStripButtonClickEventRaised += _assignAEView_DeleteToolStripButtonClickEventRaised;
            _assignAEView.btnSaveClickEventRaised += _assignAEView_btnSaveClickEventRaised;
            _assignAEView.AddProjectToolStripButtonClickEventRaised += _assignAEView_AddProjectToolStripButtonClickEventRaised;
        }
        private void _assignAEView_AddProjectToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                IAddProjectPresenter addProj = _addProjectPresenter.GetNewInstance(_unityC, _mainPresenter);
                addProj.ShowThisView();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _assignAEView_btnSaveClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow rowView in _dgvProject.Rows)
                {
                    await SaveAEIC(rowView.Cells["EmployeeId"].Value.ToString(), rowView.Cells["ProjectId"].Value.ToString());
                }
                _dgvProject.Rows.Clear();
                MessageBox.Show("Save Succesfully!");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task SaveAEIC(string empId, string projId)
        {
            await _projQuoteServices.SaveAssignAEIC(empId, projId);
        }

        private void _assignAEView_DeleteToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _dgvProject.SelectedRows)
            {
                _dgvProject.Rows.RemoveAt(row.Index);
            }
        }

       

     
        private void _assignAEView_btnEqualClickEventRaised(object sender, EventArgs e)
        {
            string errorDuplicateInProject = "";
            foreach (DataGridViewRow rowView in _dgvClient.SelectedRows)
            {
                foreach (DataGridViewRow AEICrowView in _dgvAEIC.SelectedRows)
                {
                    string StringCheck = CheckItemTodgvProject(rowView.Cells["Project_Id"].Value.ToString(), AEICrowView.Cells["Employee_Id"].Value.ToString());
                    if (StringCheck == string.Empty)
                    {
                        string TechnicalCombination = _projQuoteServices.CheckProjectAEAssignment(rowView.Cells["Project_Id"].Value.ToString(), AEICrowView.Cells["Employee_Id"].Value.ToString());


                        if (TechnicalCombination == string.Empty)
                        {

                            string ProjectName = "";
                            if(rowView.Cells["File_Label"].Value.ToString() == "Company Name")
                            {
                                ProjectName = rowView.Cells["Company Name"].Value.ToString();
                            }else
                            {
                                ProjectName = rowView.Cells["Client Name"].Value.ToString();
                            }
                            _dgvProject.Rows.Add(ProjectName,
                                                 AEICrowView.Cells["FullName"].Value.ToString(),
                                                 rowView.Cells["Project_Id"].Value.ToString(),
                                                 AEICrowView.Cells["Employee_Id"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show(TechnicalCombination);
                        }
                    }
                    else
                    {
                        if(errorDuplicateInProject != StringCheck.ToString())
                        {
                            MessageBox.Show(StringCheck.ToString());
                            errorDuplicateInProject = StringCheck.ToString();
                        }
                    }
                }
            }
            _dgvProject.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            _dgvProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvProject.Refresh();

        }
        private string CheckItemTodgvProject(string empID, string projectID)
        {
            string ExistStatus = string.Empty;
            foreach (DataGridViewRow row in _dgvProject.Rows)
            {
                if (row.Cells["ProjectId"].Value.ToString() == empID & row.Cells["EmployeeId"].Value.ToString() == projectID)
                {
                    ExistStatus = "Invalid duplicate entry!";
                }


            }
            return ExistStatus;
        }

        private async void _assignAEView_btnSearchAEICClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVAEIC(_assignAEView.SearchAEICStr);
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _assignAEView_btnSearchProjClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVClient(_assignAEView.SearchClientStr);
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _assignAEView_AssignAEViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVClient("");
                await Load_DGVAEIC("");
                _dgvProject.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                _dgvProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task Load_DGVAEIC(string searchStr)
        {
            DataTable dt = await _projQuoteServices.Get_AEICByCostEngrID(searchStr, _userModel.EmployeeID, _userModel.AccountType);
            _dgvAEIC.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvAEIC.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            _dgvAEIC.Columns["Employee_Id"].Visible = false;
            _dgvAEIC.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            _dgvAEIC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private async Task Load_DGVProject(string projectId)
        {
            DataTable dt = await _projQuoteServices.Get_AEICByProjectID(projectId);
            _dgvProject.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvProject.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            _dgvProject.Columns["ProjectID"].Visible = false;
            _dgvProject.Columns["EmployeeID"].Visible = false;
            _dgvProject.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            _dgvProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public IAssignAEPresenter GetNewInstance(IUnityContainer unityC, 
                                                    IMainPresenter mainPresenter)
        {
            unityC
                .RegisterType<IAssignAEView, AssignAEView>()
                .RegisterType<IAssignAEPresenter, AssignAEPresenter>();
            AssignAEPresenter presenter = unityC.Resolve<AssignAEPresenter>();
            presenter._unityC = unityC;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }

      
        public async Task Load_DGVClient(string searchStr)
        {
            DataTable dt = await _projQuoteServices.Get_ProjectByCostEngrID(searchStr, _userModel.EmployeeID, _userModel.AccountType);
            _dgvClient.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvClient.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _dgvClient.Columns["Project_Id"].Visible = false;
            _dgvClient.Columns["File_Label"].Visible = false;
            _dgvClient.Columns["AEIC"].Visible = false;
            _dgvClient.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            _dgvClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //foreach (DataGridViewRow row in _dgvClient.Rows)
            //{
            //    row.HeaderCell.Value = (row.Index + 1).ToString();
            //}
            _dgvClient.Refresh();


        }
        public void SetEnableThisView(bool enable)
        {
            throw new NotImplementedException();
        }

        public void Set_UserModel(IUserModel userModel)
        {
            _userModel = userModel;
        }

        public void ShowThisView()
        {
            _assignAEView.ShowThis();
        }

       
    }
}
