using CommonComponents;
using Microsoft.VisualBasic;
using PresentationLayer.Views.Costing_Head;
using ServiceLayer.Services.AddressServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter.Costing_Head
{
    public class FactorPresenter : IFactorPresenter
    {
        IFactorView _factorView;
        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IAddressServices _addressServices;
        DataGridView _dgvFactor;

        public FactorPresenter(IFactorView factorView,
                               IAddressServices addressServices)
        {
            _factorView = factorView;
            _dgvFactor = _factorView.DGV_Factor;
            _addressServices = addressServices;
            SubscribeToEventsSetup();
        }
        private void SubscribeToEventsSetup()
        {
            _factorView.FactorViewLoadEventRaised += _factorView_FactorViewLoadEventRaised;
            _factorView.EditToolStripMenuItemClickEventRaised += _factorView_EditToolStripMenuItemClickEventRaised;
            _factorView.btnSearchClickEventRaised += _factorView_btnSearchClickEventRaised;
        }

        private async void _factorView_btnSearchClickEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVFactor(_factorView.SearchFactorStr);

                _dgvFactor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                _dgvFactor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async void _factorView_EditToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Input factor" , "WinDoor Maker", _dgvFactor.SelectedRows[0].Cells["Factor"].Value.ToString());
            if (input != "" && input != "0")
            {
                
                try
                {
                    decimal int_input = Convert.ToDecimal(input);
                    if (int_input >= 0)
                    {
                        foreach (DataGridViewRow row in _dgvFactor.SelectedRows)
                        {
                            await _addressServices.UpdateFactor(row.Cells["Id"].Value.ToString(), Convert.ToDecimal(input));
                        }
                        MessageBox.Show("Update Successfully!");
                    }
                    else if (int_input < 0)
                    {
                        MessageBox.Show("Invalid number");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233033)
                    {
                        MessageBox.Show("Please input a number.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, ex.HResult.ToString());
                    }
                }
            }
            try
            {
                await Load_DGVFactor("");

                _dgvFactor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                _dgvFactor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }

        }

        private async void _factorView_FactorViewLoadEventRaised(object sender, EventArgs e)
        {
            try
            {
                await Load_DGVFactor("");

                _dgvFactor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
                _dgvFactor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        private async Task Load_DGVFactor(string searchStr)
        {
            DataTable dt = await _addressServices.Get_Factor(searchStr);
            _dgvFactor.DataSource = dt;

            foreach (DataGridViewColumn col in _dgvFactor.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            _dgvFactor.Columns["Id"].Visible = false;
            _dgvFactor.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.0f, FontStyle.Bold);
            _dgvFactor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            _dgvFactor.Refresh();
        }

        public IFactorPresenter GetNewInstance(IUnityContainer unityC, 
                                               IMainPresenter mainPresenter)
        {
            unityC
               .RegisterType<IFactorView, FactorView>()
               .RegisterType<IFactorPresenter, FactorPresenter>();
            FactorPresenter presenter = unityC.Resolve<FactorPresenter>();
            presenter._unityC = unityC;
            presenter._mainPresenter = mainPresenter;

            return presenter;
        }

        public IFactorView GetFactorView()
        {
            return _factorView;
        }
    }
}
