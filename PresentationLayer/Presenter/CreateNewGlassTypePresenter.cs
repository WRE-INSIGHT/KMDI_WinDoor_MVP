using PresentationLayer.Views;
using System;
using System.Data;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassTypePresenter : ICreateNewGlassTypePresenter
    {
        ICreateNewGlassTypeView _createNewGlassTypeView;

        private IMainPresenter _mainPresenter;
        private DataTable _glassTypeDT;

        public CreateNewGlassTypePresenter(ICreateNewGlassTypeView createNewGlassTypeView)
        {
            _createNewGlassTypeView = createNewGlassTypeView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _createNewGlassTypeView.OnCreateNewGlassTypeViewLoadEventRaised += new EventHandler(OnCreateNewGlassTypeViewLoadEventRaised);
            _createNewGlassTypeView.OnBtnAddGlassTypeClickEventRaised += new EventHandler(OnBtnAddGlassTypeClickEventRaised);
        }

        private void OnBtnAddGlassTypeClickEventRaised(object sender, EventArgs e)
        {
        
            _glassTypeDT.Rows.Add(CreateNewRowGlassTypeDT());
            _mainPresenter.GlassTypeDT = _glassTypeDT;
            _createNewGlassTypeView.GetDgvGlassTypeList().DataSource = PopulateDgvGlassType();


        }

        private void OnCreateNewGlassTypeViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassTypeView.GetDgvGlassTypeList().DataSource = PopulateDgvGlassType();
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
