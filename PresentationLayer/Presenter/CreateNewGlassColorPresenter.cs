using PresentationLayer.CommonMethods;
using PresentationLayer.Views;
using System;
using System.Data;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassColorPresenter : ICreateNewGlassColorPresenter
    {
        ICreateNewGlassColorView _createNewGlassColorView;
        private IMainPresenter _mainPresenter;
        private DataTable _colorDT;

        CommonFunctions commonfunc = new CommonFunctions();

        public CreateNewGlassColorPresenter(ICreateNewGlassColorView createNewGlassColorView)
        {
            _createNewGlassColorView = createNewGlassColorView;
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _createNewGlassColorView.OnCreateNewGlassColorViewLoadEventRaised += new EventHandler(OnCreateNewGlassColorViewLoadEventRaised);
            _createNewGlassColorView.OnBtnAddGlassColorClickEventRaised += new EventHandler(OnBtnAddGlassColorClickEventRaised);
            _createNewGlassColorView.DgvGlassColorListRowpostpaintEventRaised += new DataGridViewRowPostPaintEventHandler(OnDgvGlassColorListRowpostpaintEventRaised);
        }

        private void OnDgvGlassColorListRowpostpaintEventRaised(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            commonfunc.rowpostpaint(sender, e);
        }

        private void OnBtnAddGlassColorClickEventRaised(object sender, EventArgs e)
        {
            if (_createNewGlassColorView.tboxGlassColorView != string.Empty)
            {
                _colorDT.Rows.Add(CreateNewRow_ColorDT());
                _mainPresenter.GlassColorDT = _colorDT;
                _createNewGlassColorView.GetDgvGlassColorList().DataSource = PopulateDgvGlassColor();
                _createNewGlassColorView.tboxGlassColorView = string.Empty;
            }

        
        }

        private void OnCreateNewGlassColorViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassColorView.GetDgvGlassColorList().DataSource = PopulateDgvGlassColor();
            _createNewGlassColorView.GetDgvGlassColorList().Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public DataTable PopulateDgvGlassColor()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Color", Type.GetType("System.String"));
            foreach (DataRow colorDTRow in _colorDT.Rows)
            {
                dt.Rows.Add(colorDTRow["Color"]);
            }
            return dt;
        }

        public DataRow CreateNewRow_ColorDT()
        {
            DataRow newRow;
            newRow = _colorDT.NewRow();     
            newRow["Color"] = _createNewGlassColorView.tboxGlassColorView;
            return newRow;
        }



        public ICreateNewGlassColorPresenter GetNewInstance(IUnityContainer unityC,
                                                      IMainPresenter mainPresenter,
                                                      DataTable colorDT)
        {
            unityC
                .RegisterType<ICreateNewGlassColorView, CreateNewGlassColorView>()
                .RegisterType<ICreateNewGlassColorPresenter, CreateNewGlassColorPresenter>();
            CreateNewGlassColorPresenter createNewGlassColorPresenter = unityC.Resolve<CreateNewGlassColorPresenter>();
            createNewGlassColorPresenter._mainPresenter = mainPresenter;
            createNewGlassColorPresenter._colorDT = colorDT;

            return createNewGlassColorPresenter;
        }


        public void ShowCreateNewGlassColorView()
        {
            _createNewGlassColorView.ShowThis();
        }


    }
}
