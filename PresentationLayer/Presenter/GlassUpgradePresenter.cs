using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.DataTables;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class GlassUpgradePresenter : IGlassUpgradePresenter
    {
        private IGlassUpgradeView _glassUpgradeView;

        private IUnityContainer _unityC;
        private IMainPresenter _mainPresenter;
        private IWindoorModel _windoorModel;
        private IQuotationModel _quotationModel;
        private IPrintQuotePresenter _printQuotePresenter;

        private DataGridView _dgv_GlassUpgrade;
        private DataTable _glassUpgradeDT = new DataTable();
        private DataTable _glassUpgradeUnglazedDT = new DataTable();
        private NumericUpDown num_glassDiscount, num_glassAmount, num_wndwsDoors;
        private ComboBox _cmbGlassType;
        private ComboBox _cmbMultipleGlassUpgrade;
        private CheckBox _chkboxSelectAll;
        private CheckBox _allowDuplicate;
        private Label _lblWindoor;

        #region Variable

        int _descCurrentStateWidth,
            _formCurrentStateWidth,
            _itemPBoxCurrentWidth,
            _itemDescPanelWidth,
            _primaryKey = 0
            ;

        Point _itemImageLoc,
              _itemDescLoc,
              _itemDescPanelLoc;

        string _prevPanelType,
               _PrevGlassType,
               _primaryKeyDuplicateChecker;

        decimal _totalGlassAmount,
                _totalWindoorsAmount,
                _totalNetPriceforPrint;

        bool sortAscending = true,
             changeGlassType = false,
            _isUnglazed,
            _addItem,
            _glassTypeWithPriKeyExist;


        #endregion

        public GlassUpgradePresenter(IGlassUpgradeView glassUpgradeView,IPrintQuotePresenter printQuotePresenter)
        {
            _glassUpgradeView = glassUpgradeView;
            _printQuotePresenter = printQuotePresenter;

            _dgv_GlassUpgrade = _glassUpgradeView.GlassUpgradeDGView();
            num_glassDiscount = _glassUpgradeView.DiscountNum;
            num_glassAmount = _glassUpgradeView.GlassAmountNum;
            num_wndwsDoors = _glassUpgradeView.WindowsDoorsNum;
            _cmbGlassType = _glassUpgradeView.GlassTypeCmb();
            _chkboxSelectAll = _glassUpgradeView.SelectAllItems();
            _lblWindoor = _glassUpgradeView.WindoorLbl();
            _allowDuplicate = _glassUpgradeView.AllodDuplicate();
            _cmbMultipleGlassUpgrade = _glassUpgradeView.MultipleGlassUpgrade();

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _glassUpgradeView.GlassUpgradeView_LoadEventRaised += new EventHandler(OnGlassUpgradeViewLoadEventRaised);
            _glassUpgradeView.chkbx_ItemList_SelectedValueChangedEventRaised += new EventHandler(Onchkbx_ItemList_SelectedValueChangedEventRaised);
            _glassUpgradeView.GlassUpgradeView_SizeChangedEventRaised += _glassUpgradeView_GlassUpgradeView_SizeChangedEventRaised;
            _glassUpgradeView.btn_add_ClickEventRaised += _glassUpgradeView_btn_add_ClickEventRaised;
            _glassUpgradeView.deleteToolStripMenuItem_ClickEventRaised += _glassUpgradeView_deleteToolStripMenuItem_ClickEventRaised;
            _glassUpgradeView.glassUpgradeDGV_ColumnHeaderMouseClickEventRaised += new DataGridViewCellMouseEventHandler(glassUpgradeDGV_ColumnHeaderMouseClickEventRaised);
            _glassUpgradeView.glassUpgradeDGV_CellEndEditEventRaised += _glassUpgradeView_glassUpgradeDGV_CellEndEditEventRaised;
            _glassUpgradeView.cmb_glassType_SelectedValueChangedEventRaised += _glassUpgradeView_cmb_glassType_SelectedValueChangedEventRaised;
            _glassUpgradeView.glassUpgradeDGV_CellMouseClickEventRaised += _glassUpgradeView_glassUpgradeDGV_CellMouseClickEventRaised;
            _glassUpgradeView.chkbx_selectall_CheckedChangedEventRaised += _glassUpgradeView_chkbx_selectall_CheckedChangedEventRaised;
            _glassUpgradeView.GlassUpgradeView_FormClosingEventRaised += _glassUpgradeView_GlassUpgradeView_FormClosingEventRaised;
            _glassUpgradeView._printBtn_ClickEventRaised += _glassUpgradeView_printBtn_ClickEventRaised;
            _glassUpgradeView.upgradeToToolStripMenuItemClickEventRaised += _glassUpgradeView_upgradeToToolStripMenuItemClickEventRaised;
            
        }

        private void _glassUpgradeView_upgradeToToolStripMenuItemClickEventRaised(object sender, EventArgs e)
        {
            List<int> indx = new List<int>();

            foreach(DataGridViewRow dgvRow in _dgv_GlassUpgrade.SelectedRows)
            {
                indx.Add(Convert.ToInt32(dgvRow.Cells[0].RowIndex));
            }

            foreach(var rows in indx.ToList())
            {
                // 7 col number for glasstype selection
                try
                {
                    MultipleGlassUpgrade(rows, 7, _cmbMultipleGlassUpgrade.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Missing GlassType and/or Selected Rows");
                    break;
                }
            }
        }
        private void MultipleGlassUpgrade(int currCell_row, int currCell_col, string currCell_value)
        {
            bool _isNegative = false;

            /*
             row[2] = Qty
             row[3] = widht
             row[4] = height
             row[5] = original glass
             row[6] = orignal glass price
             row[7] = selected glass
             row[8] = selected glass price
             row[9] = Upgrade Value
             row[10] = amount per unit
             row[11] = total net price
             */

            try
            {
                if (currCell_col != 0 && currCell_col != 1)
                {
                    if (!_isUnglazed)
                    {
                        #region non-unglazed

                        if (currCell_col == 7)
                        {
                            _glassTypeWithPriKeyExist = PrimaryAndGlassTypeChecker(currCell_row, currCell_value);
                            if (!_glassTypeWithPriKeyExist)
                            {
                                _glassUpgradeDT.Rows[currCell_row][currCell_col] = currCell_value;
                            }
                        }
                        else
                        {
                            _glassUpgradeDT.Rows[currCell_row][currCell_col] = currCell_value;
                            _glassTypeWithPriKeyExist = false;
                        }

                        if (!_glassTypeWithPriKeyExist)
                        {
                            foreach (DataRow dtrow in _mainPresenter.GlassThicknessDT.Rows)
                            {
                                string _selectedGlass = _glassUpgradeDT.Rows[currCell_row][7].ToString();

                                if (dtrow[1].ToString() == _selectedGlass)
                                {
                                    _glassUpgradeDT.Rows[currCell_row][8] = dtrow[3].ToString(); // assign selected glass price
                                    string _prevGlassPrice = _glassUpgradeDT.Rows[currCell_row][6].ToString(); // original glass price 
                                    string _selectedGlassPrice = _glassUpgradeDT.Rows[currCell_row][8].ToString();// selected glass price

                                    decimal _convePrevGlassPrice = Convert.ToDecimal(_prevGlassPrice);
                                    decimal _conveSelectedGlassPrice = Convert.ToDecimal(_selectedGlassPrice);
                                    decimal _upgradeValue;

                                    if (_conveSelectedGlassPrice > _convePrevGlassPrice)
                                    {
                                        _upgradeValue = _conveSelectedGlassPrice - _convePrevGlassPrice;// glass Upgrade Value
                                        _glassUpgradeDT.Rows[currCell_row][9] = _upgradeValue.ToString("n");
                                    }
                                    else
                                    {
                                        _upgradeValue = _convePrevGlassPrice - _conveSelectedGlassPrice;// glass Upgrade Value
                                        _glassUpgradeDT.Rows[currCell_row][9] = "(" + _upgradeValue.ToString("n") + ")";
                                        _isNegative = true;
                                    }

                                    decimal _glassQty = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][2]);
                                    decimal _glassWidth = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][3]);
                                    decimal _glassHeight = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][4]);

                                    decimal _amountPerUnit = Math.Round((_glassWidth * _glassHeight * _upgradeValue * 1.1m) / 1000000m, 2);// glass amount per unit
                                    decimal _totalNetPrice = Math.Round(_amountPerUnit * _glassQty, 2);// glass total net price


                                    if (_isNegative)
                                    {
                                        _glassUpgradeDT.Rows[currCell_row][10] = "(" + _amountPerUnit.ToString("n") + ")";
                                        _glassUpgradeDT.Rows[currCell_row][11] = "(" + _totalNetPrice.ToString("n") + ")";
                                    }
                                    else
                                    {
                                        _glassUpgradeDT.Rows[currCell_row][10] = _amountPerUnit.ToString("n");
                                        _glassUpgradeDT.Rows[currCell_row][11] = _totalNetPrice.ToString("n");
                                    }
                                    _glassUpgradeDT.Rows[currCell_row][12] = _cmbGlassType.SelectedItem.ToString();
                                    break;
                                }
                            }
                            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                            TotalGlassAndWindoorsAmount();
                            #endregion
                        }
                        else
                        {
                            if (currCell_value != "")
                            {
                                MessageBox.Show("Some Panel Have Same GlassType");
                                _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                            }
                        }
                    }

                }
            }
            catch
            {
                //MessageBox.Show("Error in Loading GlassList");
            }
        }

        private DataColumn CreateColumn(string columnName, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columnName;
            col.Caption = caption;
            
            return col;
        }
        private DataGridViewComboBoxColumn DgvComboBox(string glassType)
        {
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();

            string GlassType = glassType;
            dgvCmb.HeaderText = "Upgraded To";
            dgvCmb.Name = "cmbGlassUpg";                      

            foreach (DataRow row in _mainPresenter.GlassThicknessDT.Rows)
            {
                if (!row[1].ToString().Contains("Georgian Bar"))
                {
                    if (GlassType == "")
                    {
                        dgvCmb.Items.Add(row[1]);
                    }
                    else if (GlassType == "Tempered Glass")
                    {
                        if (row[1].ToString().Contains("Tempered"))
                        {
                            dgvCmb.Items.Add(row[1]);                        
                        }
                    }
                    else if (GlassType == "Insulated Glass Unit (IGU)")
                    {
                        if (row[2].ToString().Contains("Insulated"))
                        {
                            dgvCmb.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Laminated Glass")
                    {
                        if (row[2].ToString().Contains("Laminated"))
                        {
                            dgvCmb.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Tinted Glass")
                    {
                        if (row[1].ToString().Contains("Tinted"))
                        {
                            dgvCmb.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Unglazed")
                    {

                    }
                }
            }
               
                _dgv_GlassUpgrade.Columns.Add(dgvCmb);
                _dgv_GlassUpgrade.Columns["cmbGlassUpg"].DisplayIndex = 7;
                _dgv_GlassUpgrade.Columns["cmbGlassUpg"].Width = 220;
                dgvCmb.DataPropertyName = "Upgraded To";
                            
            return dgvCmb;
        }   
        private DataGridViewComboBoxCell DgvCell(int r,string glasstype)
        {
            int _row = r;
            string GlassType = glasstype;

            ((DataGridViewComboBoxCell)_dgv_GlassUpgrade.Rows[0].Cells[7]).Value = null;
            DataGridViewComboBoxCell dgvcell = (DataGridViewComboBoxCell)_dgv_GlassUpgrade.Rows[_row].Cells[7];
            dgvcell.Items.Clear();

            foreach (DataRow row in _mainPresenter.GlassThicknessDT.Rows)
            {
                if (!row[1].ToString().Contains("Georgian Bar"))
                {
                    if (GlassType == "")
                    {
                        dgvcell.Items.Add(row[1]);
                    }
                    else if (GlassType == "Tempered Glass")
                    {
                        if (row[1].ToString().Contains("Tempered"))
                        {
                            dgvcell.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Insulated Glass Unit (IGU)")
                    {
                        if (row[2].ToString().Contains("Insulated"))
                        {
                            dgvcell.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Laminated Glass")
                    {
                        if (row[2].ToString().Contains("Laminated"))
                        {
                            dgvcell.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Tinted Glass")
                    {
                        if (row[1].ToString().Contains("Tinted"))
                        {
                            dgvcell.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Unglazed")
                    {

                    }
                }
            }
            
            return dgvcell;
        }
        private void OnGlassUpgradeViewLoadEventRaised(object sender, EventArgs e)
        {
            _glassUpgradeDT.Columns.Add(CreateColumn("Item No.", "Item No", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Qty", "Qty", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Width", "Width", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Height", "Height", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Original Glass Used", "Original Glass Used", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassPrice", "GlassPrice", "System.String"));
                                                                                          
            _glassUpgradeDT.Columns.Add(CreateColumn("Upgraded To", "Glass Upgraded To", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Glass Upgrade Price", "Glass Upgrade Price", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Upgrade Value", "Upgrade Value", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Amount Per Unit", "Amount Per Unit", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Total Net Prices", "Total Net Prices", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("GlassType", "GlassType", "System.String"));
            _glassUpgradeDT.Columns.Add(CreateColumn("Primary Key", "Primary Key", "System.Decimal"));

            LoadDataGridViewSettings();

            _glassUpgradeView.AENameAndPosLbl.Text = _mainPresenter.aeic + "\n" + _mainPresenter.position;
            _glassUpgradeView.ClientNameLbl.Text = _mainPresenter.inputted_projectName;
            _glassUpgradeView.ClientAddressLbl.Text = _mainPresenter.projectAddress;
            _glassUpgradeView.QuoteNumberLbl.Text = _mainPresenter.inputted_quotationRefNo;
            _glassUpgradeView.DateLbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
            _glassUpgradeView.ItemDescriptionLbl.Text = "";
           
            num_glassAmount.Maximum = decimal.MaxValue;
            num_glassAmount.Minimum = decimal.MinValue;
            num_glassAmount.DecimalPlaces = 2;
            num_glassAmount.ThousandsSeparator = true;

            num_wndwsDoors.Maximum = decimal.MaxValue;
            num_wndwsDoors.Minimum = decimal.MinValue;
            num_wndwsDoors.DecimalPlaces = 2;
            num_wndwsDoors.ThousandsSeparator = true;

            num_glassDiscount.Value = 30m;


            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                _glassUpgradeView.ItemListChkBx().Items.Add("Item: " + wdm.WD_id);
            }

            _glassUpgradeView.GlassTypeCmb().Items.Add("");
            _glassUpgradeView.GlassTypeCmb().Items.Add("Tempered Glass");
            _glassUpgradeView.GlassTypeCmb().Items.Add("Insulated Glass Unit (IGU)");
            _glassUpgradeView.GlassTypeCmb().Items.Add("Laminated Glass");
            _glassUpgradeView.GlassTypeCmb().Items.Add("Tinted Glass");
            _glassUpgradeView.GlassTypeCmb().Items.Add("Unglazed");

            DefaultWidthAndLocGetter();

            _dgv_GlassUpgrade.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.Programmatic);

            LoadNonUnglazedGlassList();
        }
        private void DefaultWidthAndLocGetter()
        {
            //default
            _descCurrentStateWidth = _glassUpgradeView.ItemDescriptionTxt.Width;
            _formCurrentStateWidth = _glassUpgradeView.GlassUpgraedViewForm().Width;
            _itemPBoxCurrentWidth = _glassUpgradeView.ItemImage.Width;
            _itemDescLoc = _glassUpgradeView.ItemDescriptionTxt.Location;
            _itemImageLoc = _glassUpgradeView.ItemImage.Location;
            _itemDescPanelLoc = _glassUpgradeView.ItemDescriptionPnl().Location;
            _itemDescPanelWidth = _glassUpgradeView.ItemDescriptionPnl().Width;

        }

        private void _glassUpgradeView_GlassUpgradeView_FormClosingEventRaised(object sender, FormClosingEventArgs e)
        {
            try
            {
                _mainPresenter.NonUnglazed.Clear();
                _mainPresenter.NonUnglazed = _glassUpgradeDT.AsEnumerable().ToList();

                _mainPresenter.Unglazed.Clear();
                _mainPresenter.Unglazed = _glassUpgradeUnglazedDT.AsEnumerable().ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving Glass Uprade" + ex.Message);
            }
           
        }
        private void LoadUnglazedGlassList()
        {
            foreach(var item in _mainPresenter.Unglazed)
            {
                _glassUpgradeUnglazedDT.Rows.Add(item[0].ToString(),
                                                 item[1].ToString(),
                                                 item[2].ToString(),
                                                 item[3].ToString(),
                                                 item[4].ToString(),
                                                 item[5].ToString(),
                                                 item[6].ToString(),
                                                 item[7].ToString(),
                                                 item[8].ToString(),
                                                 item[9].ToString(),
                                                 item[10].ToString(),
                                                 item[11].ToString(),
                                                 item[12].ToString(),
                                                 item[13].ToString(),
                                                 item[14].ToString());
            }
            _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();
            TotalGlassAndWindoorsAmount();
        }
        private void LoadNonUnglazedGlassList()
        {
            foreach(var item in _mainPresenter.NonUnglazed)
            {
                _glassUpgradeDT.Rows.Add(item[0].ToString(),
                                         item[1].ToString(),
                                         item[2].ToString(),
                                         item[3].ToString(),
                                         item[4].ToString(),
                                         item[5].ToString(),
                                         item[6].ToString(),
                                         item[7].ToString(),
                                         item[8].ToString(),
                                         item[9].ToString(),
                                         item[10].ToString(),
                                         item[11].ToString(),
                                         item[12].ToString(),
                                         item[13].ToString());
                                
            }
            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
            TotalGlassAndWindoorsAmount();
        }

        #region unglazed Glass
        private void LoadDataGridViewSettingsForUnglazed()
        {
            if (!_glassUpgradeUnglazedDT.Columns.Contains("Total Amount(Unglazed-Window/Door)"))
            {
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Item No.", "Item No", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Window/Door I.D.", "Window/Door I.D.", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Unit Price", "Unit Price", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Net Price","Net Price","System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Qty", "Qty", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Width", "Width", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Height", "Height", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Original Glass Used", "Original Glass Used", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("GlassPrice", "GlassPrice", "System.String"));

                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("New GlassPrice", "New GlassPrice", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Net Unit Price(Unglazed-Windoow/Door)", "Net Unit Price(Unglazed-Windoow/Door)", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("List Unit Price(Unglazed-Windoow/Door)", "List Unit Price(Unglazed-Windoow/Door)", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Total Amount(Glass)", "Total Amount(Glass)", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Total Amount(Unglazed-Window/Door)", "Total Amount(Unglazed-Windoow/Door)", "System.String"));
                _glassUpgradeUnglazedDT.Columns.Add(CreateColumn("Primary Key", "Primary Key", "System.Decimal"));

                LoadUnglazedGlassList();
            }

            _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();
            _dgv_GlassUpgrade.Columns[0].Width = 38;
            _dgv_GlassUpgrade.Columns[1].Width = 200;
            _dgv_GlassUpgrade.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[4].Width = 35;
            _dgv_GlassUpgrade.Columns[5].Width = 60;
            _dgv_GlassUpgrade.Columns[6].Width = 60;
            _dgv_GlassUpgrade.Columns[7].Width = 200;
            _dgv_GlassUpgrade.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //_dgv_GlassUpgrade.Columns[7].Width = 200;
            //_dgv_GlassUpgrade.Columns[7].Visible = false;
            _dgv_GlassUpgrade.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dgv_GlassUpgrade.Columns[14].Visible = false;

            num_wndwsDoors.Visible = true;
            _lblWindoor.Visible = true;

        }
        private DataTable PopulateDgvUsingUnglazed()
        {
            DataTable dt = new DataTable();
            string _itemNumHolder;

            dt.Columns.Add("Item No.", Type.GetType("System.String"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
            dt.Columns.Add("Unit Price",Type.GetType("System.String"));
            dt.Columns.Add("Net Price",Type.GetType("System.String"));
            dt.Columns.Add("Qty", Type.GetType("System.String"));
            dt.Columns.Add("Width", Type.GetType("System.String"));
            dt.Columns.Add("Height", Type.GetType("System.String"));
            dt.Columns.Add("Original Glass Used", Type.GetType("System.String"));
            dt.Columns.Add("GlassPrice", Type.GetType("System.String"));

            dt.Columns.Add("New GlassPrice", Type.GetType("System.String"));
            dt.Columns.Add("Net Unit Price(Unglazed-Windoow/Door)", Type.GetType("System.String"));
            dt.Columns.Add("List Unit Price(Unglazed-Windoow/Door)", Type.GetType("System.String"));
            dt.Columns.Add("Total Amount(Glass)", Type.GetType("System.String"));
            dt.Columns.Add("Total Amount(Unglazed-Window/Door)", Type.GetType("System.String"));
            dt.Columns.Add("Primary Key", Type.GetType("System.String"));


            foreach (DataRow glassupgradeDTRow in _glassUpgradeUnglazedDT.Rows)
            {
                if (glassupgradeDTRow["Primary Key"].ToString().Contains(".0"))
                {
                    _itemNumHolder = glassupgradeDTRow["Item No."].ToString();
                }
                else
                {
                    _itemNumHolder = " ";
                }

                dt.Rows.Add(_itemNumHolder,
                            glassupgradeDTRow["Window/Door I.D."],
                            glassupgradeDTRow["Unit Price"],
                            glassupgradeDTRow["Net Price"],
                            glassupgradeDTRow["Qty"],
                            glassupgradeDTRow["Width"],
                            glassupgradeDTRow["Height"],
                            glassupgradeDTRow["Original Glass Used"],
                            glassupgradeDTRow["GlassPrice"],

                            glassupgradeDTRow["New GlassPrice"],
                            glassupgradeDTRow["Net Unit Price(Unglazed-Windoow/Door)"],
                            glassupgradeDTRow["List Unit Price(Unglazed-Windoow/Door)"],
                            glassupgradeDTRow["Total Amount(Glass)"],
                            glassupgradeDTRow["Total Amount(Unglazed-Window/Door)"],
                            glassupgradeDTRow["Primary Key"]);

            }

            return dt;
        }
        private void InsertToUnglazedDT(int itemNo, string windoorID, decimal unitPrice, decimal discount,
                                        int width, int height, string glassDesc, decimal glassPrice, string prikey)
        {
            decimal dscntdUnitPrice,
                    newGlassPrice,  
                    netUnitPrice,   
                    listUnitPrice,  
                    tAmountGlass,   
                    tAmountWindoor, 
                    userdefineDiscount = (100m - num_glassDiscount.Value) / 100m,
                    _convWidth = Convert.ToDecimal(width),                              
                    _convHeight = Convert.ToDecimal(height),
            _convGlassPrice = Convert.ToDecimal(glassPrice);

            dscntdUnitPrice = Math.Round(unitPrice * (1 - (discount / 100m)), 2);
            newGlassPrice = Math.Round((_convGlassPrice * _convWidth * _convHeight * 1.1m) / 1000000m, 2);
            netUnitPrice = Math.Round(dscntdUnitPrice - newGlassPrice, 2);
            listUnitPrice = Math.Round(netUnitPrice / userdefineDiscount, 2);
            tAmountGlass = newGlassPrice * 1;             
            tAmountWindoor = listUnitPrice * 1;
            
            _glassUpgradeUnglazedDT.Rows.Add(itemNo,
                                             windoorID,
                                             unitPrice.ToString("n"),
                                             dscntdUnitPrice.ToString("n"), // net price
                                             1, // qty
                                             width,
                                             height,
                                             glassDesc, // orignal glass used
                                             glassPrice.ToString("n"),
                                             newGlassPrice.ToString("n"),
                                             netUnitPrice.ToString("n"),
                                             listUnitPrice.ToString("n"),
                                             tAmountGlass.ToString("n"),
                                             tAmountWindoor.ToString("n"),
                                             prikey
                                             );
            TotalGlassAndWindoorsAmount();
        }

        private void UpdateUnglazeDT(int currCell_col,int currCell_row,string currCell_Value)
        {
            decimal unitPrice,
                    discntedUnitPrice,
                    qty = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][4]),
                    widt = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][5]),
                    height = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][6]),
                    glassPrice = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][8]),
                    newGlassPrice,
                    itemdiscount,
                    netUnitPrice,
                    listUnitPrice,
                    userdefineDiscount = (100m - num_glassDiscount.Value) / 100m,
                    tAmountGlass,
                    tAmountWindoor;

            string id = _glassUpgradeUnglazedDT.Rows[currCell_row][0].ToString();
            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {          
                if (id == wdm.WD_id.ToString())
                {
                    if (currCell_col != 3)
                    {
                        itemdiscount = wdm.WD_discount;
                        unitPrice = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][2]);

                        discntedUnitPrice = Math.Round(unitPrice * (1 - (itemdiscount / 100m)), 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][3] = discntedUnitPrice; // netPrice

                        newGlassPrice = Math.Round((glassPrice * widt * height * 1.1m) / 1000000m, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][9] = newGlassPrice; // new glass price

                        netUnitPrice = Math.Round(discntedUnitPrice - newGlassPrice, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][10] = netUnitPrice; // net unit price

                        listUnitPrice = Math.Round(netUnitPrice / userdefineDiscount, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][11] = listUnitPrice; // list unit price

                        tAmountGlass = newGlassPrice * qty;
                        _glassUpgradeUnglazedDT.Rows[currCell_row][12] = tAmountGlass; // total amount glass

                        tAmountWindoor = listUnitPrice * qty;
                        _glassUpgradeUnglazedDT.Rows[currCell_row][13] = tAmountWindoor; // total amount windoor
                        break;
                    }
                    else
                    {
                        itemdiscount = wdm.WD_discount;
                        discntedUnitPrice = Convert.ToDecimal(_glassUpgradeUnglazedDT.Rows[currCell_row][3]);

                        unitPrice = Math.Round(discntedUnitPrice / (1 - (itemdiscount / 100m)), 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][2] = unitPrice;


                        newGlassPrice = Math.Round((glassPrice * widt * height * 1.1m) / 1000000m, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][9] = newGlassPrice; // new glass price

                        netUnitPrice = Math.Round(discntedUnitPrice - newGlassPrice, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][10] = netUnitPrice; // net unit price

                        listUnitPrice = Math.Round(netUnitPrice / userdefineDiscount, 2);
                        _glassUpgradeUnglazedDT.Rows[currCell_row][11] = listUnitPrice; // list unit price

                        tAmountGlass = newGlassPrice * qty;
                        _glassUpgradeUnglazedDT.Rows[currCell_row][12] = tAmountGlass; // total amount glass

                        tAmountWindoor = listUnitPrice * qty;
                        _glassUpgradeUnglazedDT.Rows[currCell_row][13] = tAmountWindoor; // total amount windoor
                        break;
                    }                     
                }
            }
            TotalGlassAndWindoorsAmount();
        }
        
        #endregion

        #region Non-unglazed Glass
        public DataTable PopulateDgvGlassUpgrade()
        {
            DataTable dt = new DataTable();
            string _itemNumHolder; 

            dt.Columns.Add("Item No.", Type.GetType("System.String"));
            dt.Columns.Add("Window/Door I.D.", Type.GetType("System.String"));
            dt.Columns.Add("Qty", Type.GetType("System.String"));
            dt.Columns.Add("Width", Type.GetType("System.String"));
            dt.Columns.Add("Height", Type.GetType("System.String"));
            dt.Columns.Add("Original Glass Used", Type.GetType("System.String"));
            dt.Columns.Add("GlassPrice", Type.GetType("System.String"));

            dt.Columns.Add("Upgraded To", Type.GetType("System.String"));
            dt.Columns.Add("Glass Upgrade Price", Type.GetType("System.String"));
            dt.Columns.Add("Upgrade Value", Type.GetType("System.String"));
            dt.Columns.Add("Amount Per Unit", Type.GetType("System.String"));
            dt.Columns.Add("Total Net Prices", Type.GetType("System.String"));
            dt.Columns.Add("GlassType", Type.GetType("System.String"));
            dt.Columns.Add("Primary Key", Type.GetType("System.String"));

            foreach (DataRow glassupgradeDTRow in _glassUpgradeDT.Rows)
            {
                if (glassupgradeDTRow["Primary Key"].ToString().Contains(".0"))
                {
                    _itemNumHolder = glassupgradeDTRow["Item No."].ToString();
                }
                else
                {
                    _itemNumHolder = " ";
                }

                dt.Rows.Add(_itemNumHolder,
                            glassupgradeDTRow["Window/Door I.D."],
                            glassupgradeDTRow["Qty"],
                            glassupgradeDTRow["Width"],
                            glassupgradeDTRow["Height"],
                            glassupgradeDTRow["Original Glass Used"],
                            glassupgradeDTRow["GlassPrice"],

                            glassupgradeDTRow["Upgraded To"],
                            glassupgradeDTRow["Glass Upgrade Price"],
                            glassupgradeDTRow["Upgrade Value"],
                            glassupgradeDTRow["Amount Per Unit"],
                            glassupgradeDTRow["Total Net Prices"],
                            glassupgradeDTRow["GlassType"],
                            glassupgradeDTRow["Primary Key"]);

            }
            return dt;
        }
        private void LoadDataGridViewSettings()
        {
            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
            _dgv_GlassUpgrade.Columns[0].Width = 38;
            _dgv_GlassUpgrade.Columns[1].Width = 200;
            _dgv_GlassUpgrade.Columns[2].Width = 35;
            _dgv_GlassUpgrade.Columns[3].Width = 60;
            _dgv_GlassUpgrade.Columns[4].Width = 60;
            _dgv_GlassUpgrade.Columns[5].Width = 200;
            //_dgv_GlassUpgrade.Columns[7].Width = 200;
            _dgv_GlassUpgrade.Columns[7].Visible = false;
            _dgv_GlassUpgrade.Columns[8].Width = 130;
            _dgv_GlassUpgrade.Columns[12].Visible = false;
            _dgv_GlassUpgrade.Columns[13].Visible = false;

            num_wndwsDoors.Visible = false;
            _lblWindoor.Visible = false;

            DgvComboBox("");

        }
        #endregion

        private void _glassUpgradeView_GlassUpgradeView_SizeChangedEventRaised(object sender, EventArgs e)
        {
            //TextBox Desc
            //Point itemImageLoc = _glassUpgradeView.ItemImage.Location;
            //int LocDiff = itemImageLoc.X - _itemImageLoc.X;
            //int itemDescLoc = _itemDescLoc.X + LocDiff;
            //_glassUpgradeView.ItemDescriptionTxt.Width = _descCurrentStateWidth + LocDiff; //Description New Width
            //_glassUpgradeView.ItemDescriptionTxt.Location = new System.Drawing.Point(itemDescLoc, _itemDescLoc.Y);//Desc New Loc   

            Point itemImageLoc = _glassUpgradeView.ItemImage.Location;
            int LocDiff = itemImageLoc.X - _itemImageLoc.X;
            int itemDescPanelLoc = _itemDescPanelLoc.X + LocDiff;

            _glassUpgradeView.ItemDescriptionPnl().Width = _itemDescPanelWidth + LocDiff; //Description New Width
            _glassUpgradeView.ItemDescriptionPnl().Location = new System.Drawing.Point(itemDescPanelLoc, _itemDescPanelLoc.Y);//Desc New Loc 
        }
        private void _glassUpgradeView_chkbx_selectall_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            int i = 0;
            bool _selectAllCheckBox = Convert.ToBoolean(_chkboxSelectAll.CheckState);
            
            if(_selectAllCheckBox == true)
            {
                foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    _glassUpgradeView.ItemListChkBx().SetItemChecked(i, true);
                    i++;
                }
            }
            else
            {
                foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    _glassUpgradeView.ItemListChkBx().SetItemChecked(i, false);
                    i++;
                }
            }

        }
        private void Onchkbx_ItemList_SelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            foreach(WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                int frmItemList_id = _glassUpgradeView.ItemListChkBx().SelectedIndex + 1;

                if(frmItemList_id == wdm.WD_id)
                {
                    //_glassUpgradeView.ItemDescriptionTxt.Text = wdm.WD_description;
                    _glassUpgradeView.ItemDescriptionLbl.Text = wdm.WD_description;
                    _glassUpgradeView.ItemImage.Image = wdm.WD_image;
                }
            }
        }
        private void _glassUpgradeView_cmb_glassType_SelectedValueChangedEventRaised(object sender, EventArgs e)
        {           
            bool _isSameGlassType = false;
            if(_PrevGlassType != null)
            {
                if(_PrevGlassType == _cmbGlassType.SelectedItem.ToString())
                {
                    _isSameGlassType = true;
                }
            }

            if (_isSameGlassType == false)
            {
                if (_cmbGlassType.SelectedItem.ToString() != "Unglazed")
                {
                    _isUnglazed = false;

                    //reset dgv 
                    _cmbMultipleGlassUpgrade.Items.Clear();
                    _dgv_GlassUpgrade.Columns.Clear();
                    _dgv_GlassUpgrade.DataSource = null;

                    //databinding new DT
                    LoadNewItemsInMultipleGlassUpgrade(_cmbGlassType.SelectedItem.ToString());
                    LoadDataGridViewSettings();
                    _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                    TotalGlassAndWindoorsAmount();
                    
                }
                else if (_cmbGlassType.SelectedItem.ToString() == "Unglazed")
                {
                    _isUnglazed = true;

                    //reset dgv 
                    _dgv_GlassUpgrade.DataSource = null;
                    _dgv_GlassUpgrade.Columns.Clear();

                    //databinding new DT
                    LoadDataGridViewSettingsForUnglazed();
                    _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();
                    TotalGlassAndWindoorsAmount();
                }
                _PrevGlassType = _cmbGlassType.SelectedItem.ToString();
            }

        }

        private void LoadNewItemsInMultipleGlassUpgrade(string GlassType)
        {
            foreach (DataRow row in _mainPresenter.GlassThicknessDT.Rows)
            {
                if (!row[1].ToString().Contains("Georgian Bar"))
                {
                    if (GlassType == "")
                    {
                        _cmbMultipleGlassUpgrade.Items.Add(row[1]);
                    }
                    else if (GlassType == "Tempered Glass")
                    {
                        if (row[1].ToString().Contains("Tempered"))
                        {
                            _cmbMultipleGlassUpgrade.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Insulated Glass Unit (IGU)")
                    {
                        if (row[2].ToString().Contains("Insulated"))
                        {
                            _cmbMultipleGlassUpgrade.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Laminated Glass")
                    {
                        if (row[2].ToString().Contains("Laminated"))
                        {
                            _cmbMultipleGlassUpgrade.Items.Add(row[1]);
                        }
                    }
                    else if (GlassType == "Tinted Glass")
                    {
                        if (row[1].ToString().Contains("Tinted"))
                        {
                            _cmbMultipleGlassUpgrade.Items.Add(row[1]);
                        }
                    }
                }
            }
        }
        private void _glassUpgradeView_glassUpgradeDGV_CellMouseClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ind = 0;
            if (!_isUnglazed)
            {
                if (e.ColumnIndex == 7)
                {
                    if (_cmbGlassType.SelectedItem != null)
                    {
                        foreach (DataRow dtrow in _glassUpgradeDT.Rows)
                        {
                            if (e.RowIndex == ind)
                            {
                                if (dtrow[7].ToString() == "")
                                {
                                    DgvCell(e.RowIndex, _cmbGlassType.SelectedItem.ToString());
                                }
                            }
                            ind++;
                        }
                    }
                }
            }
        }
        private void _glassUpgradeView_glassUpgradeDGV_CellEndEditEventRaised(object sender, EventArgs e)
        {
            var currCell_col = _dgv_GlassUpgrade.CurrentCell.ColumnIndex;
            var currCell_row = _dgv_GlassUpgrade.CurrentCell.RowIndex;
            var currCell_value = _dgv_GlassUpgrade.CurrentCell.Value.ToString();
            
            bool _isNegative = false;

            /*
             row[2] = Qty
             row[3] = widht
             row[4] = height
             row[5] = original glass
             row[6] = orignal glass price
             row[7] = selected glass
             row[8] = selected glass price
             row[9] = Upgrade Value
             row[10] = amount per unit
             row[11] = total net price
             */

            try
            {
                if (currCell_col != 0 && currCell_col != 1)
                {
                    if (!_isUnglazed)
                    {
                        #region non-unglazed

                        if(currCell_col == 7)
                        {
                            _glassTypeWithPriKeyExist = PrimaryAndGlassTypeChecker(currCell_row,currCell_value);
                            if (!_glassTypeWithPriKeyExist)
                            {
                                _glassUpgradeDT.Rows[currCell_row][currCell_col] = currCell_value;
                            }
                        }
                        else
                        {
                            _glassUpgradeDT.Rows[currCell_row][currCell_col] = currCell_value;
                            _glassTypeWithPriKeyExist = false;
                        }

                        if (!_glassTypeWithPriKeyExist)
                        {
                            foreach (DataRow dtrow in _mainPresenter.GlassThicknessDT.Rows)
                            {
                                string _selectedGlass = _glassUpgradeDT.Rows[currCell_row][7].ToString();

                                if (dtrow[1].ToString() == _selectedGlass)
                                {
                                    _glassUpgradeDT.Rows[currCell_row][8] = dtrow[3].ToString(); // assign selected glass price
                                    string _prevGlassPrice = _glassUpgradeDT.Rows[currCell_row][6].ToString(); // original glass price 
                                    string _selectedGlassPrice = _glassUpgradeDT.Rows[currCell_row][8].ToString();// selected glass price
                                    
                                    decimal _convePrevGlassPrice = Convert.ToDecimal(_prevGlassPrice);
                                    decimal _conveSelectedGlassPrice = Convert.ToDecimal(_selectedGlassPrice);
                                    decimal _upgradeValue;

                                    if (_conveSelectedGlassPrice > _convePrevGlassPrice)
                                    {
                                        _upgradeValue = _conveSelectedGlassPrice - _convePrevGlassPrice;// glass Upgrade Value
                                        _glassUpgradeDT.Rows[currCell_row][9] = _upgradeValue.ToString("n");
                                    }
                                    else
                                    {
                                        _upgradeValue = _convePrevGlassPrice - _conveSelectedGlassPrice;// glass Upgrade Value
                                        _glassUpgradeDT.Rows[currCell_row][9] = "(" + _upgradeValue.ToString("n") + ")";
                                        _isNegative = true;
                                    }

                                    decimal _glassQty = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][2]);
                                    decimal _glassWidth = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][3]);
                                    decimal _glassHeight = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][4]);

                                    decimal _amountPerUnit = Math.Round((_glassWidth * _glassHeight * _upgradeValue * 1.1m) / 1000000m, 2);// glass amount per unit
                                    decimal _totalNetPrice = Math.Round(_amountPerUnit * _glassQty, 2);// glass total net price


                                    if (_isNegative)
                                    {
                                        _glassUpgradeDT.Rows[currCell_row][10] = "(" + _amountPerUnit.ToString("n") + ")";
                                        _glassUpgradeDT.Rows[currCell_row][11] = "(" + _totalNetPrice.ToString("n") + ")";
                                    }
                                    else
                                    {
                                        _glassUpgradeDT.Rows[currCell_row][10] = _amountPerUnit.ToString("n");
                                        _glassUpgradeDT.Rows[currCell_row][11] = _totalNetPrice.ToString("n");
                                    }
                                    _glassUpgradeDT.Rows[currCell_row][12] = _cmbGlassType.SelectedItem.ToString();
                                    break;
                                }
                            }
                            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                            TotalGlassAndWindoorsAmount();
                            #endregion
                        }
                        else
                        {
                            if (currCell_value != "")
                            {
                                MessageBox.Show("Some Panel Have Same GlassType");
                                _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                            }
                        }
                    }   
                    else if (_isUnglazed)
                    {
                        #region unglazed
                        if (currCell_col >= 2 && currCell_col <= 6)
                        {
                            _glassUpgradeUnglazedDT.Rows[currCell_row][currCell_col] = currCell_value;
                            UpdateUnglazeDT(currCell_col, currCell_row, currCell_value.ToString());
                            _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();
                        }
                        #endregion
                    }
                }
                else
                {
                    changeGlassType = false;
                }

            }
            catch
            {
                //MessageBox.Show("Error in Loading GlassList");
            }


        }
        private void glassUpgradeDGV_ColumnHeaderMouseClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(!_isUnglazed)
                {
                    #region non-unglazed sorting
                    if (sortAscending)
                    {
                        DataTable SortedTable = _glassUpgradeDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Primary Key")).CopyToDataTable();
                        _glassUpgradeDT.Clear();
                        _glassUpgradeDT = SortedTable.AsEnumerable().CopyToDataTable();

                        sortAscending = false;
                    }
                    else
                    {
                        DataTable SortedTable = _glassUpgradeDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Primary Key")).Reverse().CopyToDataTable();
                        _glassUpgradeDT.Clear();
                        _glassUpgradeDT = SortedTable.AsEnumerable().CopyToDataTable();

                        sortAscending = true;
                    }
                    _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                    #endregion
                }
                else if (_isUnglazed)
                {
                    #region unglazed Sorting 
                    if (sortAscending)
                    {
                        DataTable SortedTable = _glassUpgradeUnglazedDT.AsEnumerable().OrderBy(r => r.Field<decimal>("Primary Key")).CopyToDataTable();
                        _glassUpgradeUnglazedDT.Clear();
                        _glassUpgradeUnglazedDT = SortedTable.AsEnumerable().CopyToDataTable();

                        sortAscending = false;
                    }
                    else
                    {
                        DataTable SortedTable = _glassUpgradeUnglazedDT.AsEnumerable().OrderBy(r => r.Field <decimal>("Primary Key")).Reverse().CopyToDataTable();
                        _glassUpgradeUnglazedDT.Clear();
                        _glassUpgradeUnglazedDT = SortedTable.AsEnumerable().CopyToDataTable();

                        sortAscending = true;
                    }
                    _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();
                    #endregion
                }

            }
        }
        private void _glassUpgradeView_btn_add_ClickEventRaised(object sender, EventArgs e)
        {
            AddGlassToRowPerItems();
        }
        private void _glassUpgradeView_deleteToolStripMenuItem_ClickEventRaised(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvRow in _dgv_GlassUpgrade.SelectedRows)
            {
                var dgv_indices = dgvRow.Cells[0].RowIndex;
                int _indxcounter = 0;

                if (!_isUnglazed)
                {
                    #region non-unglazed delete
                    foreach (DataRow row in _glassUpgradeDT.Rows)
                    {
                        if (dgv_indices == _indxcounter)
                        {
                            _dgv_GlassUpgrade.Rows.RemoveAt(dgv_indices);
                            _glassUpgradeDT.Rows.RemoveAt(dgv_indices);
                            break;
                        }
                        _indxcounter++;
                    }
                    TotalGlassAndWindoorsAmount();
                    #endregion`
                }
                else if (_isUnglazed)
                {
                    #region unglazed delete
                    foreach (DataRow row in _glassUpgradeUnglazedDT.Rows)
                    {
                        if (dgv_indices == _indxcounter)
                        {
                            _dgv_GlassUpgrade.Rows.RemoveAt(dgv_indices);
                            _glassUpgradeUnglazedDT.Rows.RemoveAt(dgv_indices);
                            break;
                        }
                        _indxcounter++;
                    }
                    TotalGlassAndWindoorsAmount();
                    #endregion
                }

            }
        }
        private void TotalGlassAndWindoorsAmount()
        {
            var charToRemove = new string[] {"(",")"};

            if (!_isUnglazed)
            {
                foreach (DataRow row in _glassUpgradeDT.Rows)
                {
                    string _strGlassAmount = row[11].ToString();
            

                    if (_strGlassAmount != "")
                    {
                        if (_strGlassAmount.Contains("("))
                        {
                            foreach (var item in charToRemove)
                            {
                                _strGlassAmount = _strGlassAmount.Replace(item, string.Empty);
                            }

                            decimal _conStrGlassAmount = Convert.ToDecimal(_strGlassAmount);
                            _totalGlassAmount = _totalGlassAmount - _conStrGlassAmount;
                        }
                        else
                        {
                            decimal _conStrGlassAmount = Convert.ToDecimal(_strGlassAmount);
                            _totalGlassAmount = _totalGlassAmount + _conStrGlassAmount;
                        }
                    }
                }

            }
            else
            {
                foreach (DataRow dtrow in _glassUpgradeUnglazedDT.Rows)
                {
                    decimal _convGlassAmount = Convert.ToDecimal(dtrow[12].ToString());
                    decimal _convWindoorsAmount = Convert.ToDecimal(dtrow[13].ToString());

                    _totalGlassAmount = _totalGlassAmount + _convGlassAmount;
                    _totalWindoorsAmount = _totalWindoorsAmount + _convWindoorsAmount;
                }
            }
            
            num_glassAmount.Value = Math.Round(_totalGlassAmount,2);
            num_wndwsDoors.Value = Math.Round(_totalWindoorsAmount, 2);
            _totalGlassAmount = 0;
            _totalWindoorsAmount = 0;
        }
        private void AddGlassToRowPerItems ()
        {
            foreach (int item in _glassUpgradeView.ItemListChkBx().CheckedIndices)
            {
                int itemNum = item + 1;
                foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
                {
                    if(itemNum.ToString() == wdm.WD_id.ToString())
                    {
                        int Limiter = ItemLimitGetter(wdm.WD_id);
                        foreach (IFrameModel fr in wdm.lst_frame)
                        {
                            if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)
                            {
                                foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                                {
                                    foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                    {

                                      bool _addItem =   ItemNumberRepeatCheck(wdm.WD_id, Limiter);
                                       
                                        if(_addItem == true || _allowDuplicate.Checked)
                                        {
                                          string _primaryKeyFormat = wdm.WD_id.ToString() + "." + _primaryKey.ToString();
                                            bool _isPrimaryKeyPresent = PrimaryKeyChecker(_primaryKeyFormat);

                                            if(_isPrimaryKeyPresent == false || _allowDuplicate.Checked)
                                            {
                                                if (_cmbGlassType.SelectedItem != null)
                                                {
                                                    if (_cmbGlassType.SelectedItem.ToString() != "Unglazed")
                                                    {
                                                        _glassUpgradeDT.Rows.Add(wdm.WD_id,
                                                                             wdm.WD_WindoorNumber + "  " + wdm.WD_itemName,
                                                                             1,
                                                                             pnl.Panel_GlassWidth,
                                                                             pnl.Panel_GlassHeight,
                                                                             pnl.Panel_GlassThicknessDesc,
                                                                             pnl.Panel_GlassPricePerSqrMeter.ToString("n"),
                                                                             "",
                                                                             "",
                                                                             "",
                                                                             "",
                                                                             "",
                                                                             "",
                                                                             _primaryKeyFormat
                                                                             );                                                     
                                                    }
                                                    else
                                                    {
                                                        InsertToUnglazedDT(wdm.WD_id,
                                                        wdm.WD_WindoorNumber + "  " + wdm.WD_itemName,
                                                        wdm.WD_price,
                                                        wdm.WD_discount,
                                                        pnl.Panel_GlassWidth,
                                                        pnl.Panel_GlassHeight,
                                                        pnl.Panel_GlassThicknessDesc,
                                                        pnl.Panel_GlassPricePerSqrMeter,
                                                        _primaryKeyFormat);
                                                    }
                                                }
                                            }
                                            
                                        }
                                        else if(_addItem == false)
                                        {
                                            //item no. already exist
                                        }

                                        if (_primaryKey == (Limiter - 1))
                                        {
                                            _primaryKey = 0;
                                        }
                                        else
                                        {
                                            _primaryKey++;
                                        }
                                    }
                                }

                            }
                            else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                            {
                                IPanelModel Singlepnl = fr.Lst_Panel[0];

                                bool _addItem = ItemNumberRepeatCheck(wdm.WD_id, Limiter);

                                if (_addItem == true || _allowDuplicate.Checked)
                                {
                                    string _primaryKeyFormat = wdm.WD_id.ToString() + "." + _primaryKey.ToString();
                                    bool _isPrimaryKeyPresent = PrimaryKeyChecker(_primaryKeyFormat);
                                    
                                    if(_isPrimaryKeyPresent == false || _allowDuplicate.Checked)
                                    {
                                        if ((_cmbGlassType.SelectedItem != null))
                                        {
                                            if (_cmbGlassType.SelectedItem.ToString() != "Unglazed")
                                            {
                                                _glassUpgradeDT.Rows.Add(wdm.WD_id,
                                                               wdm.WD_WindoorNumber + " " + wdm.WD_itemName,
                                                               1,
                                                               Singlepnl.Panel_GlassWidth,
                                                               Singlepnl.Panel_GlassHeight,
                                                               Singlepnl.Panel_GlassThicknessDesc,
                                                               Singlepnl.Panel_GlassPricePerSqrMeter.ToString("n"),
                                                               "",
                                                               "",
                                                               "",
                                                               "",
                                                               "",
                                                               "",
                                                               _primaryKeyFormat
                                                               );
                                            }
                                            else
                                            {                                               
                                                InsertToUnglazedDT(wdm.WD_id,
                                                                   wdm.WD_WindoorNumber + "  " + wdm.WD_itemName,
                                                                   wdm.WD_price,
                                                                   wdm.WD_discount,
                                                                   Singlepnl.Panel_GlassWidth,
                                                                   Singlepnl.Panel_GlassHeight,
                                                                   Singlepnl.Panel_GlassThicknessDesc,
                                                                   Singlepnl.Panel_GlassPricePerSqrMeter,
                                                                   _primaryKeyFormat);
                                            }
                                        }
                                    }

                                }  
                                else if (_addItem == false)
                                {
                                    //item no. already exist
                                }

                                if (_primaryKey == (Limiter - 1))
                                {
                                    _primaryKey = 0;
                                }
                                else
                                {
                                    _primaryKey++;

                                }
                            }
                        }
                    }
                }
            }
            if(_cmbGlassType.SelectedItem != null)
            {
                if (!_isUnglazed)
                {
                    _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();

                }
                else if (_isUnglazed)
                {
                    _dgv_GlassUpgrade.DataSource = PopulateDgvUsingUnglazed();

                }
            }
        }
        private void _glassUpgradeView_printBtn_ClickEventRaised(object sender, EventArgs e)
        {
            DSQuotation _dsq = new DSQuotation();
            string _itemNumHolder,
                   _dimension;

            /*row0 itemNo.
             *row1 Window/Door I.D.
             *row2 Qty
             *row3 Width
             *row4 Height
             *row5 Original Glass Used
             *row6 GlassPrice
             *row7 Upgraded To
             *row8 Glass Upgrade Price
             *row9 Upgrade Value
             *row10 Amount Per Unit
             *row11 Total Net Prices
             *row12 GlassType
             *row13 Primary Key
             */
            try
            {
                foreach (DataRow dtrow in _glassUpgradeDT.Rows)
                {

                    if (dtrow["GlassType"].ToString() == _cmbGlassType.SelectedItem.ToString())
                    {
                        decimal TotalNetPrice =   DsqValueTotalNetPricePrint(_cmbGlassType.SelectedItem.ToString());

                        if (dtrow["Primary Key"].ToString().Contains(".0"))
                        {
                            _itemNumHolder = dtrow["Item No."].ToString();
                        }
                        else
                        {
                            _itemNumHolder = " ";
                        }

                        _dimension = dtrow["Width"].ToString() + " x " + dtrow["Height"].ToString();

                        _dsq.dtGlassUpgrade.Rows.Add(_itemNumHolder,
                                                     dtrow["Window/Door I.D."],
                                                     dtrow["Original Glass Used"],
                                                     dtrow["Upgraded To"],
                                                     _dimension,
                                                     dtrow["Amount Per Unit"],
                                                     dtrow["Qty"],
                                                     dtrow["Total Net Prices"],
                                                     TotalNetPrice,
                                                     dtrow["GlassType"]);

                    }
                }
                _mainPresenter.printStatus = "GlassUpgrade";
                IPrintQuotePresenter printQuote = _printQuotePresenter.GetNewInstance(_unityC, _mainPresenter);
                printQuote.GetPrintQuoteView().GlassType = _cmbGlassType.SelectedItem.ToString();
                printQuote.GetPrintQuoteView().GetBindingSource().DataSource = _dsq.dtGlassUpgrade.DefaultView;
                printQuote.GetPrintQuoteView().ShowPrintQuoteView();

                //reset print variables 
                _totalNetPriceforPrint = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in GU Print: " + ex.Message);
            }
        }
        private decimal DsqValueTotalNetPricePrint(string glassType)
        {
            var charToRemove = new string[] { "(", ")" };
            string _strRmvChr;
            decimal  _convTotalNetPrice;

            foreach (DataRow row in _glassUpgradeDT.Rows)
            {
                if (row["GlassType"].ToString() == glassType)
                {              
                    if(!row["Total Net Prices"].ToString().Contains("("))
                    {
                        _convTotalNetPrice = Convert.ToDecimal(row["Total Net Prices"]);
                        _totalNetPriceforPrint = _totalNetPriceforPrint + _convTotalNetPrice;
                    }
                    else
                    {
                        _strRmvChr = row["Total Net Prices"].ToString();
                        foreach (var item in charToRemove)
                        {
                            _strRmvChr = _strRmvChr.Replace(item, string.Empty);
                        }
                        _convTotalNetPrice = Convert.ToDecimal(_strRmvChr);
                        _totalNetPriceforPrint = _totalNetPriceforPrint - _convTotalNetPrice;
                    }


                }
            }



            return _totalNetPriceforPrint;
           
        }

        private bool PrimaryAndGlassTypeChecker(int currcellrow,string glasstype)
        {
            bool _isPresent = false;
            int _indx = 0;
            
            
            foreach(DataRow dtrow in _glassUpgradeDT.Rows)
            {
                if(_indx == currcellrow)
                {
                    _primaryKeyDuplicateChecker = dtrow["Primary Key"].ToString();
                    break;
                }
                    _indx++;
            }
                        
            foreach(DataRow dtrow in _glassUpgradeDT.Rows)
            {
                if(_primaryKeyDuplicateChecker == dtrow["Primary Key"].ToString())
                {
                    if(glasstype == dtrow[7].ToString())
                    {
                        _isPresent = true;
                    }
                }
            }
                                                           
            return _isPresent;
        }
        private int ItemLimitGetter(int ID)
        {
            int _id = ID;
            int _limitCounter = 0;
            
            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                if (_id.ToString() == wdm.WD_id.ToString())
                {
                    foreach (IFrameModel fr in wdm.lst_frame)
                    {
                        if (fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)
                        {
                            foreach (IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                            {
                                foreach (IPanelModel pnl in mpnl.MPanelLst_Panel)
                                {
                                    _limitCounter++;
                                }
                            }
                        }
                        else if (fr.Lst_Panel.Count() == 1 && fr.Lst_MultiPanel.Count() == 0)
                        {
                            IPanelModel Singlepnl = fr.Lst_Panel[0];

                            _limitCounter++;

                        }
                    }
                }
            
            }

            return _limitCounter;
        }
        private bool ItemNumberRepeatCheck(int ID,int Limit)
        {
            bool _addItemNumber = true;
            int _itemNumber = ID, 
                _counter = 0,
                _CountLimit = Limit;


            if (!_isUnglazed)
            {
                foreach (DataRow row in _glassUpgradeDT.Rows)
                {
                    if (row[0].ToString() == _itemNumber.ToString())
                    {
                        _counter++;
                    }
                }

                if (_counter >= _CountLimit)
                {
                    _addItemNumber = false;
                }
            }
            else if (_isUnglazed)
            {
                foreach (DataRow row in _glassUpgradeUnglazedDT.Rows)
                {
                    if (row[0].ToString() == _itemNumber.ToString())
                    {
                        _counter++;
                    }
                }

                if (_counter >= _CountLimit)
                {
                    _addItemNumber = false;
                }
            }
            

            return _addItemNumber;
        }
        private bool PrimaryKeyChecker(string PrimaryKey)
        {
            bool _isPrimaryKeyPresent = false;
            string _primaryKey = PrimaryKey;

            if (!_isUnglazed)
            {
                foreach (DataRow row in _glassUpgradeDT.Rows)
                {
                    if (row[13].ToString() == _primaryKey)
                    {
                        _isPrimaryKeyPresent = true;
                    }
                }
            }
            else if (_isUnglazed)
            {
                foreach (DataRow row in _glassUpgradeUnglazedDT.Rows)
                {
                    if (row[14].ToString() == _primaryKey)
                    {
                        _isPrimaryKeyPresent = true;
                    }
                }
            }
            

            return _isPrimaryKeyPresent;
        }
        private bool ItemNumberChecker(int ID)
        {
            bool _itemNumIsPresent = false;
            int _itemNum = ID;

            foreach (DataRow row in _glassUpgradeDT.Rows)
            {
                if(_itemNum.ToString() == row[0].ToString())
                {
                    _itemNumIsPresent = true;
                }
            }

            return _itemNumIsPresent;
        }
        private bool GlassWidthAndHeightChecker(int ID,int w, int h)
        {
            bool _itemWxHIsSame = false;
            int  _itemNum = ID,
                 _itemWidth = w,
                 _itemHeight = h;
                 
            foreach(DataRow row in _glassUpgradeDT.Rows)
            {
                if (_itemNum.ToString() == row[0].ToString())
                {
                   if(_itemWidth.ToString() == row[3].ToString() && 
                      _itemHeight.ToString() == row[4].ToString())
                    {
                        _itemWxHIsSame = true;
                        break;
                    }
                }
            }

            return _itemWxHIsSame;
        }
      
        public IGlassUpgradeView GetGlassUpgradeView()
        {
            return _glassUpgradeView;
        }

        public IGlassUpgradePresenter CreateNewIntance(IWindoorModel windoorModel, IMainPresenter mainPresenter,IQuotationModel quotationModel,IUnityContainer unityC)
        {
            unityC
                    .RegisterType<IGlassUpgradeView, GlassUpgradeView>()
                    .RegisterType<IGlassUpgradePresenter, GlassUpgradePresenter>();

            GlassUpgradePresenter glassUpgrade = unityC.Resolve<GlassUpgradePresenter>();
            glassUpgrade._unityC = unityC;
            glassUpgrade._windoorModel = windoorModel;
            glassUpgrade._mainPresenter = mainPresenter;
            glassUpgrade._quotationModel = quotationModel;

            return glassUpgrade;

        }

    }
}
