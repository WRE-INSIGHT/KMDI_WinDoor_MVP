using CommonComponents;
using ModelLayer.Model.ProjectQuote;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private ICustomerRefNoPresenter _custRefNoPresenter;

        DataGridView _dgvProj;

        public AssignProjectsPresenter(IAssignProjectsView assignProjView, IProjectQuoteServices projQuoteServices,
                                       ICostEngrEmployeePresenter ceEmpPresenter, ICustomerRefNoPresenter custRefNoPresenter)
        {
            _assignProjView = assignProjView;
            _projQuoteServices = projQuoteServices;
            _ceEmpPresenter = ceEmpPresenter;
            _custRefNoPresenter = custRefNoPresenter;

            _dgvProj = _assignProjView.DGV_Projects;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _assignProjView.AssignProjectsViewLoadEventRaised += _assignProjView_AssignProjectsViewLoadEventRaised;
            _assignProjView.assignCostEngrToolStripMenuItemClickEventRaised += _assignProjView_assignCostEngrToolStripMenuItemClickEventRaised;
            _assignProjView.btnSearchProjClickEventRaised += _assignProjView_btnSearchProjClickEventRaised;
            _assignProjView.customerRefNoToolStripMenuItemClickEventRaised += _assignProjView_customerRefNoToolStripMenuItemClickEventRaised;
            _assignProjView.clearToolStripMenuItemClickEventRaised += _assignProjView_clearToolStripMenuItemClickEventRaised;
        }

        private async void _assignProjView_clearToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Clear Assigned", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (DataGridViewRow row in _dgvProj.SelectedRows)
                    {
                        await _projQuoteServices.Delete_ProjQuote(Convert.ToInt32(row.Cells["Project_Id"].Value), _userModel.UserID);

                        IProjectQuoteModel pqModel = _projQuoteServices.AddProjectQuote(0,
                                                                                        Convert.ToInt32(row.Cells["Project_Id"].Value),
                                                                                        null,
                                                                                        null,
                                                                                        Convert.ToInt32(row.Cells["Quote_Id"].Value),
                                                                                        null);

                        await _projQuoteServices.Insert_ProjQuote(pqModel, _userModel.UserID);
                    }

                    await Load_DGVProjects("");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _assignProjView_customerRefNoToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            if (_dgvProj.SelectedRows.Count > 0)
            {
                bool has_emp_id = false;

                if (_dgvProj.SelectedRows.Count > 1)
                {

                    foreach (DataGridViewRow row in _dgvProj.SelectedRows)
                    {
                        if (row.Cells["Emp_Id"].Value.ToString() != "")
                        {
                            has_emp_id = true;
                            break;
                        }
                    }
                }

                if (!has_emp_id)
                {
                    ICustomerRefNoPresenter custrefnoPresenter = _custRefNoPresenter.GetNewInstance(_unityC, this);
                    custrefnoPresenter.Set_SelectedRows(_dgvProj.SelectedRows);
                    custrefnoPresenter.Set_UserModel(_userModel);
                    custrefnoPresenter.ShowThisView();

                    _assignProjView.SetEnableThis(false);
                }
                else
                {
                    MessageBox.Show("Invalid selection");
                }
            }
            else
            {
                MessageBox.Show("Please select project(s)");
            }
        }

        private async void _assignProjView_btnSearchProjClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVProjects(_assignProjView.SearchProjStr);
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _assignProjView_assignCostEngrToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _dgvProj.SelectedRows)
            {
                // Console.WriteLine("customer ref id: " + row.Cells["Customer_Reference_Id"].Value);

                if (row.Cells["Customer_Reference_Id"].Value.ToString() == "0")
                {
                    MessageBox.Show("Please add customer reference before assigning Cost Engineer","Window Maker",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if(_dgvProj.SelectedRows.Count > 0)
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
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        public async Task Load_DGVProjects(string searchStr)
        {
            DataTable dt = await _projQuoteServices.Get_AssignedProjects(searchStr);
            _dgvProj.DataSource = dt;



            //var x = (from r in dt.AsEnumerable()
            //         select r["Project Name"])
            //         .Select(m => new { m.CategoryId, m.CategoryName })
            //         .Distinct().ToList();


            foreach (DataGridViewColumn col in _dgvProj.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               
            }
            //for (int i = 0; i <= 3; i++)  // output:
            //{                           //	0
            //    if (_dgvProj.Columns(i).Header.Contains("_") == true)
            //    {
            //        _dgvProj.Columns(i).visible = false;
            //    }

            //    Console.WriteLine(i);       //	1
            //}

            _dgvProj.Columns["Id"].Visible = false;
            _dgvProj.Columns["Project_Id"].Visible = false;
            _dgvProj.Columns["Customer_Reference_Id"].Visible = false;
            _dgvProj.Columns["Emp_Id"].Visible = false;
            //foreach(Data)
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

        public void SetEnableThisView(bool enable)
        {
            _assignProjView.SetEnableThis(enable);
        }
    }
}
