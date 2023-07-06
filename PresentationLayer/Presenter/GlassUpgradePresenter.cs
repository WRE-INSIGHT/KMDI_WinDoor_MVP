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

        #region Variable
        int _descCurrentStateWidth,
            _formCurrentStateWidth,
            _itemPBoxCurrentWidth,
            _itemDescPanelWidth,
            _primaryKey
            ;

        Point _itemImageLoc,
              _itemDescLoc,
              _itemDescPanelLoc;

        string _prevPanelType,
               _PrevGlassType;




        #endregion

        public GlassUpgradePresenter(IGlassUpgradeView glassUpgradeView)
        {
            _glassUpgradeView = glassUpgradeView;

            _dgv_GlassUpgrade = _glassUpgradeView.GlassUpgradeDGView();
            num_glassDiscount = _glassUpgradeView.DiscountNum;
            num_glassAmount = _glassUpgradeView.GlassAmountNum;
            num_wndwsDoors = _glassUpgradeView.WindowsDoorsNum;

            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _glassUpgradeView.GlassUpgradeView_LoadEventRaised += new EventHandler(OnGlassUpgradeViewLoadEventRaised);
            _glassUpgradeView.chkbx_ItemList_SelectedValueChangedEventRaised += new EventHandler(Onchkbx_ItemList_SelectedValueChangedEventRaised);
            _glassUpgradeView.GlassUpgradeView_SizeChangedEventRaised += _glassUpgradeView_GlassUpgradeView_SizeChangedEventRaised;
            _glassUpgradeView.btn_add_ClickEventRaised += _glassUpgradeView_btn_add_ClickEventRaised;
            _glassUpgradeView.deleteToolStripMenuItem_ClickEventRaised += _glassUpgradeView_deleteToolStripMenuItem_ClickEventRaised;
        }



        private DataColumn CreateColumn(string columnName, string caption, string type)
        {
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType(type);
            col.ColumnName = columnName;
            col.Caption = caption;
            
            return col;
        }

        private DataGridViewComboBoxColumn DgvComboBox()
        {
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "Upgraded To";
            dgvCmb.Name = "cmbGlassUpg";

            foreach(DataRow row in _mainPresenter.GlassThicknessDT.Rows)
            {
                dgvCmb.Items.Add(row[1]);             
            }

            _dgv_GlassUpgrade.Columns.Add(dgvCmb);
            _dgv_GlassUpgrade.Columns["cmbGlassUpg"].DisplayIndex = 7;
            _dgv_GlassUpgrade.Columns["cmbGlassUpg"].Width = 200;

            return dgvCmb;
        }

        
        public DataTable PopulateDgvGlassUpgrade()
        {
            DataTable dt = new DataTable();
            string _prevNum = "0";
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
                if(glassupgradeDTRow["Item No."].ToString() == _prevNum)
                {
                    _itemNumHolder = " ";
                }
                else
                {
                    _prevNum = glassupgradeDTRow["Item No."].ToString();
                    _itemNumHolder = _prevNum;
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

            _glassUpgradeView.AENameAndPosLbl.Text = _mainPresenter.aeic + "\n" + _mainPresenter.position;
            _glassUpgradeView.ClientNameLbl.Text = _mainPresenter.inputted_projectName;
            _glassUpgradeView.ClientAddressLbl.Text = _mainPresenter.projectAddress;
            _glassUpgradeView.QuoteNumberLbl.Text = _mainPresenter.inputted_quotationRefNo;
            _glassUpgradeView.DateLbl.Text = DateTime.Now.ToString("MM/dd/yyyy");
            _glassUpgradeView.ItemDescriptionLbl.Text = "";

            foreach (WindoorModel wdm in _quotationModel.Lst_Windoor)
            {
                _glassUpgradeView.ItemListChkBx().Items.Add("Item: " + wdm.WD_id);
            }
            DefaultWidthAndLocGetter();
            DgvComboBox();
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

        private void _glassUpgradeView_btn_add_ClickEventRaised(object sender, EventArgs e)
        {
            LoadGlassPerItems();
        }
        private void _glassUpgradeView_deleteToolStripMenuItem_ClickEventRaised(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvRow in _dgv_GlassUpgrade.SelectedRows)
            {
                
            }
        }
        private void LoadGlassPerItems()
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
                                                                     wdm.WD_id.ToString() + "." + _primaryKey.ToString()
                                                                     );
                                        }
                                        else if(_addItem == false)
                                        {
                                            //item no. already exist
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
                                                             wdm.WD_id.ToString() + "." + _primaryKey.ToString()
                                                             );
                                }  
                                else if (_addItem == false)
                                {
                                    //item no. already exist
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

            _primaryKey = _counter;

            return _addItemNumber;
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
