using CommonComponents;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Views;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CostEngrLandingPresenter : ICostEngrLandingPresenter
    {
        ICostEngrLandingView _CELandingView;

        private IUnityContainer _unityC;
        private IUserModel _userModel;

        private IProjectQuoteServices _projQuoteServices;
        private IMainPresenter _mainPresenter;
        private ICustomerRefNoPresenter _custRefNoPresenter;

        private DataGridView _dgvAssignedProj;
        private DataGridView _dgvCustRefNo;
        private DataGridView _dgvQuoteNo;

        private int _tPageNav_selectedIndex;
        private int _projId, _custRefId;
        private string _projName, _custRefNo;

        public CostEngrLandingPresenter(ICostEngrLandingView CELandingView, IProjectQuoteServices projQuoteServices, ICustomerRefNoPresenter custRefNoPresenter)
        {
            _CELandingView = CELandingView;
            _projQuoteServices = projQuoteServices;
            _custRefNoPresenter = custRefNoPresenter;

            _dgvAssignedProj = _CELandingView.DGV_ASsignedProject;
            _dgvCustRefNo = _CELandingView.DGV_CustRefNo;
            _dgvQuoteNo = _CELandingView.DGV_QuoteNo;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _CELandingView.CostEngrLandingViewLoadEventRaised += _CELandingView_CostEngrLandingViewLoadEventRaised;
            _CELandingView.dgvAssignedProjectsCellMouseDoubleClickEventRaised += _CELandingView_dgvAssignedProjectsCellMouseDoubleClickEventRaised;
            _CELandingView.btnforwardNavClick += _CELandingView_btnforwardNavClick;
            _CELandingView.btnbackNavClickEventRaised += _CELandingView_btnbackNavClickEventRaised;
            _CELandingView.dgvCustRefNoCellMouseDoubleClickEventRaised += _CELandingView_dgvCustRefNoCellMouseDoubleClickEventRaised;
        }

        private async void _CELandingView_dgvCustRefNoCellMouseDoubleClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1 && e.Button == MouseButtons.Left)
                {
                    _custRefId = Convert.ToInt32(_dgvCustRefNo.Rows[e.RowIndex].Cells["Customer_Reference_Id"].Value);
                    _custRefNo = _dgvCustRefNo.Rows[e.RowIndex].Cells["Customer Reference"].Value.ToString();
                    _CELandingView.SetText_LblNav(_projName + @"\" + _custRefNo);

                    int index = _tPageNav_selectedIndex + 1;
                    SetSelectedIndex_TPageNav(index);
                    await Load_DGV_QuoteNo(_projId, _custRefId);
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private void _CELandingView_btnbackNavClickEventRaised(object sender, EventArgs e)
        {
            int index = _tPageNav_selectedIndex - 1;
            SetSelectedIndex_TPageNav(index);
        }

        private void _CELandingView_btnforwardNavClick(object sender, EventArgs e)
        {
            int index = _tPageNav_selectedIndex + 1;
            SetSelectedIndex_TPageNav(index);
        }

        private void SetSelectedIndex_TPageNav(int index)
        {
            if (_CELandingView.SetSelectedIndex_TabpageNav(index))
            {
                _tPageNav_selectedIndex = index;

                if (_tPageNav_selectedIndex == 0)
                {
                    _CELandingView.SetText_LblNav("");
                }
                else if (_tPageNav_selectedIndex == 1)
                {
                    _CELandingView.SetText_LblNav(_projName);
                }
                else if (_tPageNav_selectedIndex == 2)
                {
                    _CELandingView.SetText_LblNav(_projName + @"\" + _custRefNo);
                }
            }
        }

        private async void _CELandingView_dgvAssignedProjectsCellMouseDoubleClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1 && e.Button == MouseButtons.Left)
                {
                    _projId = Convert.ToInt32(_dgvAssignedProj.Rows[e.RowIndex].Cells["Project_Id"].Value);
                    _projName= _dgvAssignedProj.Rows[e.RowIndex].Cells["Project Name"].Value.ToString();
                    _CELandingView.SetText_LblNav(_projName);

                    int index = _tPageNav_selectedIndex + 1;
                    SetSelectedIndex_TPageNav(index);
                    await Load_DGV_CustRefNo(_projId);
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _CELandingView_CostEngrLandingViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGV_AssignedProjects("");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task Load_DGV_AssignedProjects(string searchStr)
        {
            DataTable dt = await _projQuoteServices.Get_ProjectByCostEngrID(searchStr, _userModel.EmployeeID, _userModel.AccountType);
            _dgvAssignedProj.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvAssignedProj.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _dgvAssignedProj.Columns["Project_Id"].Visible = false;

            _dgvAssignedProj.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
        }

        private async Task Load_DGV_CustRefNo(int proj_id)
        {
            DataTable dt = await _projQuoteServices.Get_CustRefNoByProjectID(proj_id, _userModel.EmployeeID, _userModel.AccountType);
            _dgvCustRefNo.DataSource = dt;


            foreach (DataGridViewColumn col in _dgvCustRefNo.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _dgvCustRefNo.Columns["Customer_Reference_Id"].Visible = false;
            _dgvCustRefNo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
        }

        private async Task Load_DGV_QuoteNo(int proj_id, int cust_ref_no)
        {
            DataTable dt = await _projQuoteServices.Get_QuoteNo_ByProjectID_ByCUstRefNo(proj_id, cust_ref_no, _userModel.EmployeeID, _userModel.AccountType);
            _dgvQuoteNo.DataSource = dt;


            foreach (DataGridViewColumn col in _dgvQuoteNo.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _dgvQuoteNo.Columns["Quote_Id"].Visible = false;
            _dgvQuoteNo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
        }

        public void ShowThisView()
        {
            _CELandingView.ShowThis();
        }

        public ICostEngrLandingPresenter GetNewInstance(IUserModel userModel, IMainPresenter mainPresenter, IUnityContainer unityC)
        {
            unityC
                .RegisterType<ICostEngrLandingView, CostEngrLandingView>()
                .RegisterType<ICostEngrLandingPresenter, CostEngrLandingPresenter>();
            CostEngrLandingPresenter presenter = unityC.Resolve<CostEngrLandingPresenter>();
            presenter._unityC = unityC;
            presenter._userModel = userModel;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }
    }
}