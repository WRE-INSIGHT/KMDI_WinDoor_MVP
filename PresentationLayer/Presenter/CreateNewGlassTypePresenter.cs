using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassTypePresenter : ICreateNewGlassTypePresenter
    {
        ICreateNewGlassTypeView _createNewGlassTypeView;

        private IMainPresenter _mainPresenter;
        private DataTable _glassTypeDT;

        CommonFunctions commonfunc = new CommonFunctions();

        public CreateNewGlassTypePresenter(ICreateNewGlassTypeView createNewGlassTypeView)
        {
            _createNewGlassTypeView = createNewGlassTypeView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _createNewGlassTypeView.OnCreateNewGlassTypeViewLoadEventRaised += new EventHandler(OnCreateNewGlassTypeViewLoadEventRaised);
            _createNewGlassTypeView.OnBtnAddGlassTypeClickEventRaised += new EventHandler(OnBtnAddGlassTypeClickEventRaised);
            _createNewGlassTypeView.DgvGlassTypeListRowpostpaintEventRaised += new DataGridViewRowPostPaintEventHandler(DgvGlassTypeListRowpostpaintEventRaised);
        }

        private void DgvGlassTypeListRowpostpaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void OnBtnAddGlassTypeClickEventRaised(object sender, EventArgs e)
        {
            if (_createNewGlassTypeView.tboxGlassTypeView != string.Empty)
            {
                _glassTypeDT.Rows.Add(CreateNewRowGlassTypeDT());
                _mainPresenter.GlassTypeDT = _glassTypeDT;
                _createNewGlassTypeView.GetDgvGlassTypeList().DataSource = PopulateDgvGlassType();
                _createNewGlassTypeView.tboxGlassTypeView = string.Empty;
            }
        }

        private void OnCreateNewGlassTypeViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassTypeView.GetDgvGlassTypeList().DataSource = PopulateDgvGlassType();
            _createNewGlassTypeView.GetDgvGlassTypeList().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public DataTable PopulateDgvGlassType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GlassType", Type.GetType("System.String"));
            foreach (DataRow row in _glassTypeDT.Rows)
            {
                dt.Rows.Add(row["GlassType"]);
            }
            return dt;
        }
        public DataRow CreateNewRowGlassTypeDT()
        {
            DataRow newRow;
            newRow = _glassTypeDT.NewRow();
            newRow["GlassType"] = _createNewGlassTypeView.tboxGlassTypeView;
            return newRow;
        }



        public ICreateNewGlassTypePresenter GetNewInstance(IUnityContainer unityC,
                                                       IMainPresenter mainPresenter,
                                                       DataTable glassTypeDT)
        {
            unityC
                .RegisterType<ICreateNewGlassTypeView, CreateNewGlassTypeView>()
                .RegisterType<ICreateNewGlassTypePresenter, CreateNewGlassTypePresenter>();
            CreateNewGlassTypePresenter createNewGlassTypePresenter = unityC.Resolve<CreateNewGlassTypePresenter>();
            createNewGlassTypePresenter._mainPresenter = mainPresenter;
            createNewGlassTypePresenter._glassTypeDT = glassTypeDT;

            return createNewGlassTypePresenter;
        }



        public void ShowCreateNewGlassTypeView()
        {
            _createNewGlassTypeView.ShowThis();
        }


    }
}
