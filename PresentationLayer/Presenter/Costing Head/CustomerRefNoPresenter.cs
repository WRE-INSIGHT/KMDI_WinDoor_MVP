using CommonComponents;
using ModelLayer.Model.CustomerRefNo;
using ModelLayer.Model.ProjectQuote;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.CustomerRefNoServices;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class CustomerRefNoPresenter : ICustomerRefNoPresenter
    {
        ICustomerRefNoView _custRefNoView;

        private IUnityContainer _unityC;

        private IUserModel _userModel;
        private ICustomerRefNoServices _custRefNoServices;
        private IProjectQuoteServices _pqServices;
        private IAssignProjectsPresenter _assignProjPresenter;


        private CheckedListBox _chkListCustRefNo;
        private DataGridViewSelectedRowCollection _dgvProjSelectedRows;
        private Panel _pnlStatus;
        private Label _lblStatus;

        public CustomerRefNoPresenter(ICustomerRefNoView custRefNoView, ICustomerRefNoServices custRefNoServices,
                                      IProjectQuoteServices pqServices)
        {
            _custRefNoView = custRefNoView;
            _custRefNoServices = custRefNoServices;
            _pqServices = pqServices;

            _chkListCustRefNo = _custRefNoView.ChkList_CustRefNo;
            _pnlStatus = _custRefNoView.Pnl_Status;
            _lblStatus = _custRefNoView.Lbl_Status;

            SubscribeToEventsSetup();
        }


        private void SubscribeToEventsSetup()
        {
            _custRefNoView.CustomerRefNoViewLoadEventRaised += _custRefNoView_CustomerRefNoViewLoadEventRaised;
            _custRefNoView.btnAcceptClickEventRaised += _custRefNoView_btnAcceptClickEventRaised;
            _custRefNoView.btnAddCustRefClickEventRaised += _custRefNoView_btnAddCustRefClickEventRaised;
            _custRefNoView.CustomerRefNoViewFormClosedEventRaised += _custRefNoView_CustomerRefNoViewFormClosedEventRaised;
        }

        private void _custRefNoView_CustomerRefNoViewFormClosedEventRaised(object sender, FormClosedEventArgs e)
        {
            _assignProjPresenter.SetEnableThisView(true);
        }

        private async void _custRefNoView_btnAddCustRefClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                ICustomerRefNoModel custRefNoModel = _custRefNoServices.AddCustRefNo(0, _custRefNoView.CustomerReferenceNo);
                int inserted_row = await _custRefNoServices.Insert_CustRefNo(_userModel.UserID, custRefNoModel);
                if (inserted_row > 0)
                {
                    await Load_ChkListCustRefNo("");
                }
                else
                {
                    MessageBox.Show("Save Failed");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }
        private async void _custRefNoView_btnAcceptClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_chkListCustRefNo.CheckedItems.Count >= 1)
                {
                    if (_dgvProjSelectedRows.Count > 1) // project must not already assigned to CEs
                    {
                        bool has_emp_id = false;

                        foreach (DataGridViewRow row in _dgvProjSelectedRows)
                        {
                            if (row.Cells["Emp_Id"].Value.ToString() != "")
                            {
                                has_emp_id = true;
                                break;
                            }
                        }

                        if (!has_emp_id)
                        {
                            //insert ProjectQuote
                            foreach (DataGridViewRow row in _dgvProjSelectedRows)
                            {
                                await _pqServices.Delete_ProjQuote(Convert.ToInt32(row.Cells["Project_Id"].Value), _userModel.UserID);
                                foreach (DataRowView chkListVal in _chkListCustRefNo.CheckedItems)
                                {
                                    int custRefNo_id = Convert.ToInt32(chkListVal["Id"]);
                                    int emp_id = (row.Cells["Emp_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row.Cells["Emp_Id"].Value);
                                    int quote_id = 0; // (row.Cells["Quote_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row.Cells["Quote_Id"].Value);

                                    IProjectQuoteModel pqModel = _pqServices.AddProjectQuote(Convert.ToInt32(row.Cells["Id"].Value),
                                                                                             Convert.ToInt32(row.Cells["Project_Id"].Value),
                                                                                             custRefNo_id,
                                                                                             emp_id,
                                                                                             quote_id,
                                                                                             null);
                                    await _pqServices.Insert_ProjQuote(pqModel, _userModel.UserID);
                                }
                            }
                        }
                    }
                    else if (_dgvProjSelectedRows.Count == 1)
                    {
                        DataGridViewRow row_0 = _dgvProjSelectedRows[0];
                        if (row_0.Cells["Emp_Id"].Value.ToString() != "")
                        {
                            //update ProjectQuote
                            if (_chkListCustRefNo.CheckedItems.Count == 1)
                            {
                                foreach (DataRowView chkListVal in _chkListCustRefNo.CheckedItems)
                                {
                                    int custRefNo_id = Convert.ToInt32(chkListVal["Id"]);
                                    int emp_id = (row_0.Cells["Emp_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row_0.Cells["Emp_Id"].Value);
                                    int quote_id = 0; // (row_0.Cells["Quote_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row_0.Cells["Quote_Id"].Value);

                                    IProjectQuoteModel pqModel = _pqServices.AddProjectQuote(Convert.ToInt32(row_0.Cells["Id"].Value),
                                                                                             Convert.ToInt32(row_0.Cells["Project_Id"].Value),
                                                                                             custRefNo_id,
                                                                                             emp_id,
                                                                                             quote_id,
                                                                                             null//DateTime.Now
                                                                                             );
                                    await _pqServices.Update_ProjQuote(pqModel, _userModel.UserID);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select only one(1) customer reference no. ");
                            }
                        }
                        else if (row_0.Cells["Emp_Id"].Value.ToString() == "")
                        {
                            //insert project quote
                            foreach (DataGridViewRow row in _dgvProjSelectedRows)
                            {
                                await _pqServices.Delete_ProjQuote(Convert.ToInt32(row.Cells["Project_Id"].Value), _userModel.UserID);

                                foreach (DataRowView chkListVal in _chkListCustRefNo.CheckedItems)
                                {
                                    int custRefNo_id = Convert.ToInt32(chkListVal["Id"]);
                                    int emp_id = (row.Cells["Emp_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row.Cells["Emp_Id"].Value);
                                    int quote_id = 0; // (row.Cells["Quote_Id"].Value.ToString() == "") ? 0 : Convert.ToInt32(row.Cells["Quote_Id"].Value);

                                    IProjectQuoteModel pqModel = _pqServices.AddProjectQuote(Convert.ToInt32(row.Cells["Id"].Value),
                                                                                             Convert.ToInt32(row.Cells["Project_Id"].Value),
                                                                                             custRefNo_id,
                                                                                             emp_id,
                                                                                             quote_id,
                                                                                             null);

                                    await _pqServices.Insert_ProjQuote(pqModel, _userModel.UserID);
                                }
                            }
                        }

                    }

                    await _assignProjPresenter.Load_DGVProjects("");
                    _custRefNoView.CloseThis();
                }
                else if (_chkListCustRefNo.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Invalid Selection");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _custRefNoView_CustomerRefNoViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_ChkListCustRefNo("");
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task Load_ChkListCustRefNo(string searchStr)
        {
            _chkListCustRefNo.DataSource = await _custRefNoServices.GetCustRefNo(searchStr);
            _chkListCustRefNo.DisplayMember = "Customer_Reference_No";
            _chkListCustRefNo.ValueMember = "Id";
        }

        public void ShowThisView()
        {
            _custRefNoView.ShowThis();
        }

        public void Set_SelectedRows(DataGridViewSelectedRowCollection dgvProjSelectedRows)
        {
            _dgvProjSelectedRows = dgvProjSelectedRows;
        }

        public void Set_UserModel(IUserModel userModel)
        {
            _userModel = userModel;
        }

        public ICustomerRefNoPresenter GetNewInstance(IUnityContainer unityC,
                                                      IAssignProjectsPresenter assignProjPresenter)
        {
            unityC
                .RegisterType<ICustomerRefNoView, CustomerRefNoView>()
                .RegisterType<ICustomerRefNoPresenter, CustomerRefNoPresenter>();
            CustomerRefNoPresenter presenter = unityC.Resolve<CustomerRefNoPresenter>();
            presenter._unityC = unityC;
            presenter._assignProjPresenter = assignProjPresenter;

            return presenter;
        }
    }
}
