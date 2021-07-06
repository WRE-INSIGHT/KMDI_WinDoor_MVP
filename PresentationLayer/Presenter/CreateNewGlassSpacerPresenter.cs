using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassSpacerPresenter : ICreateNewGlassSpacerPresenter
    {
        ICreateNewGlassSpacerView _createNewGlassSpacerView;

        private IMainPresenter _mainPresenter;
        private DataTable _spacerDT;

        CommonFunctions commonfunc = new CommonFunctions();

        public CreateNewGlassSpacerPresenter(ICreateNewGlassSpacerView createNewGlassSpacerView)
        {
            _createNewGlassSpacerView = createNewGlassSpacerView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _createNewGlassSpacerView.OnBtnAddGlassSpacerClickEventRaised += new EventHandler(OnBtnAddGlassSpacerClickEventRaised);
            _createNewGlassSpacerView.OnCreateNewGlassSpacerViewLoadEventRaised += new EventHandler(OnCreateNewGlassSpacerViewLoadEventRaised);
            _createNewGlassSpacerView.OnDgvGlassSpacerListRowpostpaintEventRaised += new DataGridViewRowPostPaintEventHandler(OnDgvGlassSpacerListRowpostpaintEventRaised);
        }

        private void OnDgvGlassSpacerListRowpostpaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void OnCreateNewGlassSpacerViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassSpacerView.GetDgvGlassSpacerList().DataSource = PopulateDgvGlassSpacer();
            _createNewGlassSpacerView.GetDgvGlassSpacerList().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        string ChkRowStatus;
        private void OnBtnAddGlassSpacerClickEventRaised(object sender, EventArgs e)
        {
            foreach (DataGridViewRow ChkRows in _createNewGlassSpacerView.GetDgvGlassSpacerList().Rows)
            {
                if (ChkRows.Cells["Spacer"].Value.ToString().ToUpper() == _createNewGlassSpacerView.tboxGlassSpacerView.ToUpper())
                {
                    ChkRowStatus = "Duplicate";
                    MessageBox.Show(_createNewGlassSpacerView.tboxGlassSpacerView + " Already Exist");
                }
                else
                {
                    ChkRowStatus = "Valid";
                }
            }

            if (ChkRowStatus == "Valid" && _createNewGlassSpacerView.tboxGlassSpacerView != string.Empty)
            {
                _spacerDT.Rows.Add(CreateNewRowGlassSpacerDT());
                _mainPresenter.GlassSpacerDT = _spacerDT;
                _createNewGlassSpacerView.GetDgvGlassSpacerList().DataSource = PopulateDgvGlassSpacer();
                _createNewGlassSpacerView.tboxGlassSpacerView = string.Empty;
            }
        }

        public DataTable PopulateDgvGlassSpacer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Spacer", Type.GetType("System.String"));
            foreach (DataRow spacerRow in _spacerDT.Rows)
            {
                dt.Rows.Add(spacerRow["Spacer"]);
            }
            return dt;
        }

        public DataRow CreateNewRowGlassSpacerDT()
        {
            DataRow newRow;
            newRow = _spacerDT.NewRow();
            newRow["Spacer"] = _createNewGlassSpacerView.tboxGlassSpacerView;
            return newRow;
        }

        public ICreateNewGlassSpacerPresenter GetNewInstance(IUnityContainer unityC,
                                                      IMainPresenter mainPresenter,
                                                      DataTable spacerDT)
        {
            unityC
                .RegisterType<ICreateNewGlassSpacerView, CreateNewGlassSpacerView>()
                .RegisterType<ICreateNewGlassSpacerPresenter, CreateNewGlassSpacerPresenter>();
            CreateNewGlassSpacerPresenter createNewGlassSpacerPresenter = unityC.Resolve<CreateNewGlassSpacerPresenter>();
            createNewGlassSpacerPresenter._mainPresenter = mainPresenter;
            createNewGlassSpacerPresenter._spacerDT = spacerDT;

            return createNewGlassSpacerPresenter;
        }

        public void ShowCreateNewGlassSpacerView()
        {
            _createNewGlassSpacerView.ShowThis();
        }


    }
}
