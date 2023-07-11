﻿using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.Quotation.WinDoor;
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

        private DataGridView _dgv_GlassUpgrade;
        private DataTable _glassUpgradeDT = new DataTable();
        private NumericUpDown num_glassDiscount, num_glassAmount, num_wndwsDoors;
        private ComboBox _cmbGlassType;


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
               _PrevGlassType;


        decimal _totalGlassAmount;

        bool sortAscending = true;

        #endregion

        public GlassUpgradePresenter(IGlassUpgradeView glassUpgradeView)
        {
            _glassUpgradeView = glassUpgradeView;

            _dgv_GlassUpgrade = _glassUpgradeView.GlassUpgradeDGView();
            num_glassDiscount = _glassUpgradeView.DiscountNum;
            num_glassAmount = _glassUpgradeView.GlassAmountNum;
            num_wndwsDoors = _glassUpgradeView.WindowsDoorsNum;
            _cmbGlassType = _glassUpgradeView.GlassTypeCmb();

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

                    
            foreach(DataRow row in _mainPresenter.GlassThicknessDT.Rows)
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
            _dgv_GlassUpgrade.Columns["cmbGlassUpg"].Width = 200;
            dgvCmb.DataPropertyName = "Upgraded To";
                
                        
            return dgvCmb;
        }

        
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
            dt.Columns.Add("Primary Key", Type.GetType("System.String"));

            foreach (DataRow glassupgradeDTRow in _glassUpgradeDT.Rows)
            {
                if(glassupgradeDTRow["Primary Key"].ToString().Contains(".0"))
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
                            glassupgradeDTRow["Primary Key"]);
            }

            return dt;
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
            _glassUpgradeDT.Columns.Add(CreateColumn("Primary Key", "Primary Key", "System.String"));

            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
            _dgv_GlassUpgrade.Columns[0].Width = 38;
            _dgv_GlassUpgrade.Columns[1].Width = 200;
            _dgv_GlassUpgrade.Columns[2].Width = 35;
            _dgv_GlassUpgrade.Columns[3].Width = 60;
            _dgv_GlassUpgrade.Columns[4].Width = 60;
            _dgv_GlassUpgrade.Columns[5].Width = 200;

            _dgv_GlassUpgrade.Columns[7].Visible = false;
            _dgv_GlassUpgrade.Columns[8].Width = 130;
            _dgv_GlassUpgrade.Columns[12].Visible = false;

            _glassUpgradeView.AENameAndPosLbl.Text = _mainPresenter.aeic + "\n" + _mainPresenter.position;
            _glassUpgradeView.ClientNameLbl.Text = _mainPresenter.inputted_projectName;
            _glassUpgradeView.ClientAddressLbl.Text = _mainPresenter.projectAddress;
            _glassUpgradeView.QuoteNumberLbl.Text = _mainPresenter.inputted_quotationRefNo;
            _glassUpgradeView.DateLbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
            _glassUpgradeView.ItemDescriptionLbl.Text = "";

            _glassUpgradeView.GlassAmountNum.Maximum = decimal.MaxValue;
            _glassUpgradeView.GlassAmountNum.Minimum = decimal.MinValue;

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
            DgvComboBox("");
            
            _dgv_GlassUpgrade.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.Programmatic);
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
            _dgv_GlassUpgrade.Columns.Remove("cmbGlassUpg");
            _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
            DgvComboBox(_cmbGlassType.SelectedItem.ToString());
        }

        private void _glassUpgradeView_glassUpgradeDGV_CellEndEditEventRaised(object sender, EventArgs e)
        {
            var currCell_col = _dgv_GlassUpgrade.CurrentCell.ColumnIndex;
            var currCell_row = _dgv_GlassUpgrade.CurrentCell.RowIndex;
            var currCell_value = _dgv_GlassUpgrade.CurrentCell.Value;
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
                if (currCell_col != 0)
                {
                    _glassUpgradeDT.Rows[currCell_row][currCell_col] = currCell_value;

                    foreach (DataRow dtrow in _mainPresenter.GlassThicknessDT.Rows)
                    {
                        string _selectedGlass = _glassUpgradeDT.Rows[currCell_row][7].ToString();

                        if(dtrow[1].ToString() == _selectedGlass)
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
                                _glassUpgradeDT.Rows[currCell_row][9] = _upgradeValue.ToString(); 
                            }
                            else
                            {
                                 _upgradeValue = _convePrevGlassPrice - _conveSelectedGlassPrice;// glass Upgrade Value
                                _glassUpgradeDT.Rows[currCell_row][9] = "(" + _upgradeValue.ToString() + ")";
                                _isNegative = true;
                            }

                            decimal _glassQty = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][2]);
                            decimal _glassWidth = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][3]);
                            decimal _glassHeight = Convert.ToDecimal(_glassUpgradeDT.Rows[currCell_row][4]);

                            decimal _amountPerUnit = Math.Round((_glassWidth * _glassHeight * _upgradeValue * 1.1m) / 1000000m,2);// glass amount per unit
                            decimal _totalNetPrice = Math.Round(_amountPerUnit * _glassQty,2);// glass total net price


                            if(_isNegative)
                            {
                                _glassUpgradeDT.Rows[currCell_row][10] = "(" + _amountPerUnit.ToString() + ")";
                                _glassUpgradeDT.Rows[currCell_row][11] = "(" + _totalNetPrice.ToString() + ")";
                            }
                            else
                            {
                                _glassUpgradeDT.Rows[currCell_row][10] =  _amountPerUnit.ToString();
                                _glassUpgradeDT.Rows[currCell_row][11] =  _totalNetPrice.ToString();
                            }
                            break;
                        }
                    }

                }
                _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
                TotalGlassAmount();
            }
            catch
            {
                MessageBox.Show("Error in Loading GlassList");
            }


        }

        private void glassUpgradeDGV_ColumnHeaderMouseClickEventRaised(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (sortAscending)
                {

                    DataTable SortedTable = _glassUpgradeDT.AsEnumerable().OrderBy(r => r.Field<string>("Primary Key")).CopyToDataTable();
                    _glassUpgradeDT.Clear();
                    _glassUpgradeDT = SortedTable.AsEnumerable().CopyToDataTable();

                    sortAscending = false;
                }
                else
                {

                    DataTable SortedTable = _glassUpgradeDT.AsEnumerable().OrderBy(r => r.Field<string>("Primary Key")).Reverse().CopyToDataTable();
                    _glassUpgradeDT.Clear();
                    _glassUpgradeDT = SortedTable.AsEnumerable().CopyToDataTable();

                    sortAscending = true;
                }
                _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
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

                foreach(DataRow row in _glassUpgradeDT.Rows)
                {
                    if(dgv_indices == _indxcounter)
                    {
                        _dgv_GlassUpgrade.Rows.RemoveAt(dgv_indices);
                        _glassUpgradeDT.Rows.RemoveAt(dgv_indices);
                        break;
                    }
                    _indxcounter++;
                }

            }
        }

        private void TotalGlassAmount()
        {
            var charToRemove = new string[] {"(",")"};

            foreach(DataRow row in _glassUpgradeDT.Rows)
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

            _glassUpgradeView.GlassAmountNum.Value = Math.Round(_totalGlassAmount,2);
            _totalGlassAmount = 0;
        }

        private void AddGlassToRowPerItems()
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
                                       
                                        if(_addItem == true)
                                        {
                                          string _primaryKeyFormat = wdm.WD_id.ToString() + "." + _primaryKey.ToString();
                                            bool _isPrimaryKeyPresent = PrimaryKeyChecker(_primaryKeyFormat);

                                            if(_isPrimaryKeyPresent == false)
                                            {
                                                _glassUpgradeDT.Rows.Add(wdm.WD_id,
                                                                         wdm.WD_WindoorNumber + "  " + wdm.WD_itemName,
                                                                         1,
                                                                         pnl.Panel_GlassWidth,
                                                                         pnl.Panel_GlassHeight,
                                                                         pnl.Panel_GlassThicknessDesc,
                                                                         pnl.Panel_GlassPricePerSqrMeter,
                                                                         "",
                                                                         "",
                                                                         "",
                                                                         "",
                                                                         "",
                                                                         _primaryKeyFormat
                                                                         );
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

                                if (_addItem == true)
                                {
                                    string _primaryKeyFormat = wdm.WD_id.ToString() + "." + _primaryKey.ToString();
                                    bool _isPrimaryKeyPresent = PrimaryKeyChecker(_primaryKeyFormat);
                                    
                                    if(_isPrimaryKeyPresent == false)
                                    {
                                        _glassUpgradeDT.Rows.Add(wdm.WD_id,
                                                           wdm.WD_WindoorNumber + " " + wdm.WD_itemName,
                                                           1,
                                                           Singlepnl.Panel_GlassWidth,
                                                           Singlepnl.Panel_GlassHeight,
                                                           Singlepnl.Panel_GlassThicknessDesc,
                                                           Singlepnl.Panel_GlassPricePerSqrMeter,
                                                           "",
                                                           "",
                                                           "",
                                                           "",
                                                           "",
                                                           _primaryKeyFormat
                                                           );
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
                _dgv_GlassUpgrade.DataSource = PopulateDgvGlassUpgrade();
            }
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

            foreach(DataRow row in _glassUpgradeDT.Rows)
            {
              if(row[0].ToString() == _itemNumber.ToString())
                {
                    _counter++;
                }   
            }

            if(_counter >= _CountLimit)
            {
                _addItemNumber = false;
            }

            return _addItemNumber;
        }
        private bool PrimaryKeyChecker(string PrimaryKey)
        {
            bool _isPrimaryKeyPresent = false;
            string _primaryKey = PrimaryKey;

            foreach(DataRow row in _glassUpgradeDT.Rows)
            {
                if(row[12].ToString() == _primaryKey)
                {
                    _isPrimaryKeyPresent = true;
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