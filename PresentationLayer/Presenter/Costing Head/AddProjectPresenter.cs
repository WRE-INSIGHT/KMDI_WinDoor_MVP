using CommonComponents;
using ModelLayer.Model.Project;
using ModelLayer.Model.User;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class AddProjectPresenter : IAddProjectPresenter, IPresenterCommon
    {
        private IUnityContainer _unityC;
        IAddProjectView _addProjectView;
        private int _projectId;
        private IUserModel _userModel;
        private IProjectQuoteServices _projQuoteServices;
        private IMainPresenter _mainPresenter;
        ComboBox _cmbProvince, _cmbCity, _cmbArea;
        private IProjectModel _projectModel;
        public AddProjectPresenter(IProjectQuoteServices projQuoteServices,
                                   IAddProjectView addProjectView,
                                   IProjectModel projectModel)
        {
            _addProjectView = addProjectView;
            _projQuoteServices = projQuoteServices;
            _projectModel = projectModel;
            _cmbProvince = _addProjectView.cmbProvince();
            _cmbCity = _addProjectView.cmbCity();
            _cmbArea = _addProjectView.cmbArea();
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _addProjectView.AddProjectViewLoadEventRaised += _addProjectView_AddProjectViewLoadEventRaised;
            _addProjectView.cmbProvinceSelectedItemChange += _addProjectView_cmbProvinceSelectedItemChange;
            _addProjectView.btnSaveClickEventRaised += _addProjectView_btnSaveClickEventRaised;
            _addProjectView.AddProjectViewFormClosedEventRaised += _addProjectView_AddProjectViewFormClosedEventRaised;
        }

        private void _addProjectView_AddProjectViewFormClosedEventRaised(object sender, FormClosedEventArgs e)
        {
            _addProjectView.ClearBinding();
        }

        private async void _addProjectView_btnSaveClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (_projectId == 0)
                {
                    await SaveProject();
                    MessageBox.Show("Save Succesfully!");
                }
                else
                {
                    await _projQuoteServices.UpdateProject(_projectId, _projectModel, _userModel);
                }
               
                _addProjectView.CloseThisView();

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }
        private async Task SaveProject()
        {
            await _projQuoteServices.SaveProject(_projectModel);
        }
        private async void _addProjectView_cmbProvinceSelectedItemChange(object sender, EventArgs e)
        {
            try
            {
                await Load_CityArea();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }
        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> projectBinding = new Dictionary<string, Binding>();
            projectBinding.Add("Title", new Binding("Text", _projectModel, "Title", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Firstname", new Binding("Text", _projectModel, "Firstname", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Lastname", new Binding("Text", _projectModel, "Lastname", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("CompanyName", new Binding("Text", _projectModel, "CompanyName", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("ContactNo", new Binding("Text", _projectModel, "ContactNo", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("FileLableAs", new Binding("Text", _projectModel, "FileLableAs", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("UnitNo", new Binding("Text", _projectModel, "UnitNo", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Establishment", new Binding("Text", _projectModel, "Establishment", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("HouseNo", new Binding("Text", _projectModel, "HouseNo", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Street", new Binding("Text", _projectModel, "Street", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Village", new Binding("Text", _projectModel, "Village", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Barangay", new Binding("Text", _projectModel, "Barangay", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Province", new Binding("Text", _projectModel, "Province", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("City", new Binding("Text", _projectModel, "City", true, DataSourceUpdateMode.OnPropertyChanged));
            projectBinding.Add("Area", new Binding("Text", _projectModel, "Area", true, DataSourceUpdateMode.OnPropertyChanged));
            return projectBinding;
        }
        private async Task Load_CityArea()
        {
            DataTable dt = await _projQuoteServices.GetCityAreaBy_Province(_cmbProvince.SelectedItem.ToString());
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            _cmbCity.Items.Clear();
            _cmbCity.Text = string.Empty;
            _cmbCity.SelectedItem = string.Empty;
            DataTable dataTable = (DataTable)bs.DataSource;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                _cmbCity.Items.Add(dataTable.Rows[i][0].ToString().Trim());
                _cmbArea.SelectedItem = dataTable.Rows[i][1].ToString().Trim();

            }
            _cmbCity.Text = _projectModel.City;
        }

        private async void _addProjectView_AddProjectViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_Province();
                if(_projectId != 0)
                {
                    await _projQuoteServices.EditProject(_projectId, _projectModel);
                }
                _addProjectView.ThisBinding(CreateBindingDictionary());

            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task Load_Province()
        {
            DataTable dt = await _projQuoteServices.GetProvince();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            _cmbProvince.Items.Clear();
            DataTable dataTable = (DataTable)bs.DataSource;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                _cmbProvince.Items.Add(dataTable.Rows[i][0].ToString());
            }
        }

        public IAddProjectPresenter GetNewInstance(IUnityContainer unityC, 
                                                   IMainPresenter mainPresenter,
                                                   int projectId,
                                                   IUserModel userModel)
        {
            unityC
               .RegisterType<IAddProjectView, AddProjectView>()
               .RegisterType<IAddProjectPresenter, AddProjectPresenter>();
            AddProjectPresenter presenter = unityC.Resolve<AddProjectPresenter>();
            presenter._unityC = unityC;
            presenter._mainPresenter = mainPresenter;
            presenter._projectId = projectId;
            presenter._userModel = userModel;
            return presenter;
        }
        public void ShowThisView()
        {
            _addProjectView.ShowThisView();
        }
       
    }
}
