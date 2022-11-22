using CommonComponents;
using Microsoft.VisualBasic;
using ModelLayer.Model.ProjectQuote;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.User;
using PresentationLayer.Presenter.Costing_Head;
using PresentationLayer.Views;
using ServiceLayer.Services.ProjectQuoteServices;
using ServiceLayer.Services.QuotationServices;
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
        private IQuotationServices _quotationServices;
        private IMainPresenter _mainPresenter;
        private ICustomerRefNoPresenter _custRefNoPresenter;

        private DataGridView _dgvAssignedProj;
        private DataGridView _dgvCustRefNo;
        private DataGridView _dgvQuoteNo;

        private int _tPageNav_selectedIndex;
        private int _projId, _custRefId;
        private string _projName, _custRefNo;
        private DateTime _dateAssigned;

        public CostEngrLandingPresenter(ICostEngrLandingView CELandingView, IProjectQuoteServices projQuoteServices, ICustomerRefNoPresenter custRefNoPresenter,
                                        IQuotationServices quotationServices)
        {
            _CELandingView = CELandingView;
            _projQuoteServices = projQuoteServices;
            _custRefNoPresenter = custRefNoPresenter;
            _quotationServices = quotationServices;

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
            _CELandingView.btnAddNewQuoteClickEventRaised += _CELandingView_btnAddNewQuoteClickEventRaised;
            _CELandingView.dgvQuoteNoCellMouseDoubleClickEventRaised += _CELandingView_dgvQuoteNoCellMouseDoubleClickEventRaised;
        }

        private void _CELandingView_dgvQuoteNoCellMouseDoubleClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1 && e.Button == MouseButtons.Left)
                {
                    int _quoteId = Convert.ToInt32(_dgvQuoteNo.Rows[e.RowIndex].Cells["Quote_Id"].Value);
                    string _quoteNo = _dgvQuoteNo.Rows[e.RowIndex].Cells["Quote Number"].Value.ToString();
                    DateTime _quoteDate = (DateTime)_dgvQuoteNo.Rows[e.RowIndex].Cells["Date"].Value;

                    bool proceed = false;
                    _mainPresenter.isNewProject = true;
                    if (_mainPresenter.qoutationModel_MainPresenter != null)
                    {
                        if (_mainPresenter.GetMainView().GetToolStripButtonSave().Enabled == true)
                        {
                            if (!string.IsNullOrWhiteSpace(_mainPresenter.wndrFileName))
                            {
                                DialogResult dialogResult = MessageBox.Show("Do you want to save changes in " + _mainPresenter.wndrFileName + "?", "Save progress",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                if (dialogResult == DialogResult.Yes ||
                                    dialogResult == DialogResult.No)
                                {
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        _mainPresenter.SaveChanges();

                                    }
                                    proceed = true;
                                    _mainPresenter.Scenario_Quotation(false, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                                }
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Progress will not save, do you wish to proceed?", "Delete progress",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    proceed = true;
                                    _mainPresenter.Scenario_Quotation(false, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                                   
                                }
                            }
                            
                            
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure want to open new Quotation?", "Delete progress",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                proceed = true;
                                _mainPresenter.Scenario_Quotation(false, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                            }
                        }

                       
                    }
                    else
                    {
                        proceed = true;
                    }

                    if (proceed)
                    {
                        _mainPresenter.inputted_quotationRefNo = _quoteNo;
                        _mainPresenter.inputted_quoteId = _quoteId;
                        _mainPresenter.inputted_quoteDate = _quoteDate;
                        _mainPresenter.inputted_projectName = _projName;
                        _mainPresenter.inputted_custRefNo = _custRefNo;
                        _mainPresenter.Scenario_Quotation(true, false, false, false, false, false, frmDimensionPresenter.Show_Purpose.Quotation, 0, 0, "", "");
                        _CELandingView.CloseThis();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _CELandingView_btnAddNewQuoteClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                string input_qrefno = Interaction.InputBox("Quotation Reference No.", "Windoor Maker", "");
                if (input_qrefno != "" && input_qrefno != "0")
                {
                    IQuotationModel quotationModel = _quotationServices.AddQuotationModel(input_qrefno, DateTime.Now);

                    int inserted_quoteId = await _quotationServices.Insert_Quotation(quotationModel, _userModel.UserID);

                    if (inserted_quoteId > 0)
                    {
                        IProjectQuoteModel projectQuoteModel = _projQuoteServices.AddProjectQuote(0,
                                                                                                  _projId,
                                                                                                  _custRefId,
                                                                                                  _userModel.EmployeeID,
                                                                                                  inserted_quoteId,
                                                                                                  _dateAssigned
                                                                                                  );

                        int affected_rows = await _projQuoteServices.Insert_ProjQuote(projectQuoteModel, _userModel.UserID);
                    }

                    await Load_DGV_QuoteNo(_projId, _custRefId);
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
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
                    _CELandingView.resizeForm(800, 600);
                }
                else if (_tPageNav_selectedIndex == 1)
                {
                    _CELandingView.SetText_LblNav(_projName);
                    _CELandingView.resizeForm(376, 600);
                }
                else if (_tPageNav_selectedIndex == 2)
                {
                    _CELandingView.SetText_LblNav(_projName + @"\" + _custRefNo);
                    _CELandingView.resizeForm(376, 600);
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
                    _projName = _dgvAssignedProj.Rows[e.RowIndex].Cells["Client Name"].Value.ToString();
                    _mainPresenter.aeic = _dgvAssignedProj.Rows[e.RowIndex].Cells["AEIC"].Value.ToString();
                    _mainPresenter.projectAddress = _dgvAssignedProj.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                    _mainPresenter.titleLastname = _dgvAssignedProj.Rows[e.RowIndex].Cells["Title Lastname"].Value.ToString();
                    //_dateAssigned = (DateTime)_dgvAssignedProj.Rows[e.RowIndex].Cells["Date Assigned"].Value;
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
            _dgvAssignedProj.Columns["File_Label"].Visible = false;
            _dgvAssignedProj.Columns["AEIC ID"].Visible = false;
            _dgvAssignedProj.Columns["Title Lastname"].Visible = false;
            _dgvAssignedProj.Columns["Factor"].Visible = false;
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

        private async Task Load_DGV_QuoteNo(int proj_id, int cust_ref_id)
        {
            DataTable dt = await _projQuoteServices.Get_QuoteNo_ByProjectID_ByCUstRefNo(proj_id, cust_ref_id, _userModel.EmployeeID, _userModel.AccountType);
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