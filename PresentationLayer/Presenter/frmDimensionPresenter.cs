using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Views;
using PresentationLayer.Presenter.UserControls;
using ModelLayer.Model.Quotation.WinDoor;
using ModelLayer.Model.Quotation.Frame;
using CommonComponents;
using System.Windows.Forms;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;

namespace PresentationLayer.Presenter
{
    public class frmDimensionPresenter : IfrmDimensionPresenter
    {
        IfrmDimensionView _frmDimensionView;

        private IMainPresenter _mainPresenter;
        private IMultiPanelMullionUCPresenter _multiUCP;

        private string profile_type;
        private bool _isFrmClosed;
        public enum Show_Purpose
        {
            Quotation = 1,
            CreateNew_Item = 2,
            CreateNew_Frame = 3,
            ChangeBasePlatformSize = 4,
            AddPanelIntoMultiPanel = 5
        }

        private Show_Purpose this_purpose;
        #region GetSet
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

        public string profileType_frmDimensionPresenter
        {
            get
            {
                return profile_type;
            }

            set
            {
                profile_type = value;
            }
        }

        public bool mainPresenter_qoutationInputBox_ClickedOK
        {
            get
            {
                return _mainPresenter_qoutationInputBox_ClickedOK;
            }

            set
            {
                _mainPresenter_qoutationInputBox_ClickedOK = value;
            }
        }

        public bool mainPresenter_newItem_ClickedOK
        {
            get
            {
                return _mainPresenter_newItem_ClickedOK;
            }

            set
            {
                _mainPresenter_newItem_ClickedOK = value;
            }
        }

        public bool mainPresenter_AddedFrame_ClickedOK
        {
            get
            {
                return _mainPresenter_AddedFrame_ClickedOK;
            }

            set
            {
                _mainPresenter_AddedFrame_ClickedOK = value;
            }
        }

        #endregion

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
                profile_type = "PremiLine Profile";
            }
        }

        private void OnbtnCancelClickedEventRaised(object sender, EventArgs e)
        {
            _isFrmClosed = true;
            _frmDimensionView.ClosefrmDimension();
        }

        private bool _mainPresenter_qoutationInputBox_ClickedOK;
        private bool _mainPresenter_newItem_ClickedOK;
        private bool _mainPresenter_AddedFrame_ClickedOK;
        private void OnbtnOKClickedEventRaised(object sender, EventArgs e)
        {
            try
            {
                _isFrmClosed = false;
                if (purpose == Show_Purpose.ChangeBasePlatformSize)
                {
                    _mainPresenter.frmDimensionResults(purpose, _frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
                }
                else if (purpose == Show_Purpose.AddPanelIntoMultiPanel)
                {
                    _multiUCP.frmDimensionResults(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
                }
                else
                {
                    _mainPresenter.Scenario_Quotation(_mainPresenter_qoutationInputBox_ClickedOK,
                                                      _mainPresenter_newItem_ClickedOK,
                                                      _mainPresenter_AddedFrame_ClickedOK,
                                                      purpose,
                                                      _frmDimensionView.InumWidth,
                                                      _frmDimensionView.InumHeight,
                                                      profile_type);
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, ex.HResult.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnfrmDimensionLoadEventRaised(object sender, EventArgs e)
        {
            //kapag binalik mo to magagalaw yung sa line 99 ng MultiPanelMullionUCPresenter
            //_frmDimensionView.InumWidth = 400;
            //_frmDimensionView.InumHeight = 400;
        }

        public void SetPresenters(IMainPresenter mainPresenter)
        {
            _mainPresenter = mainPresenter;
        }

        public void SetPresenters(IMultiPanelMullionUCPresenter multiUCP)
        {
            _multiUCP = multiUCP;
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
            else if (purpose == Show_Purpose.CreateNew_Item || 
                     purpose == Show_Purpose.CreateNew_Frame || 
                     purpose == Show_Purpose.ChangeBasePlatformSize ||
                     purpose == Show_Purpose.AddPanelIntoMultiPanel)
            {
                _frmDimensionView.thisHeight = 156;
            }
        }

        public void SetValues(int numWD, int numHT)
        {
            _frmDimensionView.InumWidth = numWD;
            _frmDimensionView.InumHeight = numHT;
        }

        public bool GetfrmResult()
        {
            return _isFrmClosed;
        }
    }
}
