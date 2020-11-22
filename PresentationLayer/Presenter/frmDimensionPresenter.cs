using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using ModelLayer.Model.Quotation.WinDoor;
using CommonComponents;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public class frmDimensionPresenter : IfrmDimensionPresenter
    {
        IfrmDimensionView _frmDimensionView;
        private IMainPresenter _mainPresenter;
        private IBasePlatformPresenter _basePlatformPresenter;

        private string profile_type;
        public enum Show_Purpose
        {
            Quotation = 1,
            CreateNew_Frame = 2
        }

        private Show_Purpose this_purpose;

        public Show_Purpose purpose
        {
            get
            {
                return this_purpose;
            }

            set
            {
                this_purpose = value;
            }
        }

        public frmDimensionPresenter(IfrmDimensionView frmDimensionView)
        {
            _frmDimensionView = frmDimensionView;
            SubscribeToEventsSetup();
        }

        public IfrmDimensionView GetDimensionView()
        {
            return _frmDimensionView;
        }
        private void SubscribeToEventsSetup()
        {
            _frmDimensionView.frmDimensionLoadEventRaised += new EventHandler(OnfrmDimensionLoadEventRaised);
            _frmDimensionView.btnOKClickedEventRaised += new EventHandler(OnbtnOKClickedEventRaised);
            _frmDimensionView.btnCancelClickedEventRaised += new EventHandler(OnbtnCancelClickedEventRaised);
            _frmDimensionView.radbtnCheckChangedEventRaised += new EventHandler(OnradbtnCheckChangedEventRaised);
        }

        private void OnradbtnCheckChangedEventRaised(object sender, EventArgs e)
        {
            RadioButton radbtn = (RadioButton)sender;
            if (radbtn.Name == "rad_c70")
            {
                profile_type = "C70 Profile";
            }
            else if (radbtn.Name == "rad_PremiLine")
            {
                profile_type = "PremiLine";
            }
        }

        private void OnbtnCancelClickedEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.ClosefrmDimension();
        }

        private void OnbtnOKClickedEventRaised(object sender, EventArgs e)
        {
            try
            {
                if (this_purpose == Show_Purpose.Quotation)
                {
                    _mainPresenter.AddQuotationModel(_mainPresenter.inputted_quotationRefNo);
                }

                IWindoorModel wndr = _mainPresenter.AddWindoorModel(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight, profile_type);
                if (this_purpose == Show_Purpose.Quotation)
                {
                    _mainPresenter.AddWndrList_QuotationModel(wndr);

                    _mainPresenter.AddBasePlatform(_basePlatformPresenter.getBasePlatformViewUC());
                    _mainPresenter.ItemToolStrip_Enable();
                }
                else if (this_purpose == Show_Purpose.CreateNew_Frame)
                {
                    _mainPresenter.AddWndrList_QuotationModel(wndr);
                }
                _basePlatformPresenter.SetBasePlatformSize(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
                _basePlatformPresenter.InvalidateBasePlatform();

                _mainPresenter.SetMainViewTitle(_mainPresenter.inputted_quotationRefNo,
                                                wndr.WD_name,
                                                wndr.WD_profile,
                                                false);
                _mainPresenter.AddItemInfoUC(wndr); //add item information user control

                //add item properties user control
                _frmDimensionView.ClosefrmDimension();
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnfrmDimensionLoadEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.InumWidth = 400;
            _frmDimensionView.InumHeight = 400;
        }

        public void SetPresenters(IMainPresenter mainPresenter, IBasePlatformPresenter basePlatformPresenter)
        {
            _mainPresenter = mainPresenter;
            _basePlatformPresenter = basePlatformPresenter;
        }

        public void SetProfileType(string profileType)
        {
            profile_type = profileType;
        }

        public void SetHeight()
        {
            if (purpose == Show_Purpose.Quotation)
            {
                _frmDimensionView.thisHeight = 193;
            }
            else if (purpose == Show_Purpose.CreateNew_Frame)
            {
                _frmDimensionView.thisHeight = 156;
            }
        }
    }
}
