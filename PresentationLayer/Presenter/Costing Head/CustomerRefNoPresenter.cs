using CommonComponents;
using ModelLayer.Model.CustomerRefNo;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.CustomerRefNoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private IAssignProjectsPresenter _assignProjPresenter;

        private CheckedListBox _chkListCustRefNo;
        private DataGridViewSelectedRowCollection _dgvProjSelectedRows;
        private Panel _pnlStatus;
        private Label _lblStatus;

        public CustomerRefNoPresenter(ICustomerRefNoView custRefNoView, ICustomerRefNoServices custRefNoServices)
        {
            _custRefNoView = custRefNoView;
            _custRefNoServices = custRefNoServices;

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

        private void _custRefNoView_btnAcceptClickEventRaised(object sender, EventArgs e)
        {

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
