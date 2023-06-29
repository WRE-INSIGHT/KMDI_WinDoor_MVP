using CommonComponents;
using PresentationLayer.Presenter.UserControls.WinDoorPanels;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class frmDimensionPresenter : IfrmDimensionPresenter
    {
        IfrmDimensionView _frmDimensionView;

        private IMainPresenter _mainPresenter;
        private IMultiPanelMullionUCPresenter _multiMullionUCP;
        private IMultiPanelTransomUCPresenter _multiTransomUCP;

        private string profile_type;
        private string _baseColor;
        private bool _isFrmClosed;
        public enum Show_Purpose
        {
            Quotation = 1,
            CreateNew_Item = 2,
            CreateNew_Frame = 3,
            ChangeBasePlatformSize = 4,
            AddPanelIntoMultiPanel = 5,
            CreateNew_Concrete = 6,
            OpenWndrFile = 7,
            Duplicate = 8
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

        public string baseColor_frmDimensionPresenter
        {
            get
            {
                return _baseColor;
            }

            set
            {
                _baseColor = value;
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

        public bool mainPresenter_AddedConcrete_ClickedOK
        {
            get
            {
                return _mainPresenter_AddedConcrete_ClickedOK;
            }
            set
            {
                _mainPresenter_AddedConcrete_ClickedOK = value;
            }
        }

        public bool mainPresenter_OpenWindoorFile_ClickedOK
        {
            get
            {
                return _mainPresenter_OpenWindoorFile_ClickedOK;
            }

            set
            {
                _mainPresenter_OpenWindoorFile_ClickedOK = value;
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
            _frmDimensionView.cmbSystemOptionSelectedValueChangedEventRaised += new EventHandler(_frmDimensionView_cmbSystemOptionSelectedValueChangedEventRaised);
            _frmDimensionView.cmbBaseColorOptionSelectedValueChangedEventRaised += new EventHandler(_frmDimensionView_cmbBaseColorOptionSelectedValueChangedEventRaised);
            _frmDimensionView.numWidthEnterEventRaised += new EventHandler(OnnumWidthEnterEventRaised);
            _frmDimensionView.numHeightEnterEventRaised += new EventHandler(OnnumHeightEnterEventRaised);
        }

        private void OnnumHeightEnterEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.GetNumHeigth().Select(0, _frmDimensionView.GetNumHeigth().Text.Length);
        }

        private void OnnumWidthEnterEventRaised(object sender, EventArgs e)
        {
            _frmDimensionView.GetNumWidth().Select(0, _frmDimensionView.GetNumWidth().Text.Length);
        }

        private void _frmDimensionView_cmbBaseColorOptionSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (_frmDimensionView.SelectedBaseColor == Base_Color._Ivory.ToString() ||
                _frmDimensionView.SelectedBaseColor == Base_Color._White.ToString())
            {
                _baseColor = "White";
            }
            else if (_frmDimensionView.SelectedBaseColor == Base_Color._DarkBrown.ToString())
            {
                _baseColor = "Dark Brown";
            }
        }

        private void _frmDimensionView_cmbSystemOptionSelectedValueChangedEventRaised(object sender, EventArgs e)
        {
            if (_frmDimensionView.SelectedSystem == SystemProfile_Option._C70.ToString())
            {
                profile_type = "C70 Profile";
            }
            else if (_frmDimensionView.SelectedSystem == SystemProfile_Option._Premiline.ToString())
            {
                profile_type = "PremiLine Profile";
            }
            else if (_frmDimensionView.SelectedSystem == SystemProfile_Option._G58.ToString())
            {
                profile_type = "G58 Profile";
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
        private bool _mainPresenter_AddedConcrete_ClickedOK;
        private bool _mainPresenter_OpenWindoorFile_ClickedOK;
        private bool _mainPresenter_Duplicate_ClickedOK;
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
                    if (_multiMullionUCP != null)
                    {
                        _multiMullionUCP.frmDimensionResults(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
                    }
                    else if (_multiTransomUCP != null)
                    {
                        _multiTransomUCP.frmDimensionResults(_frmDimensionView.InumWidth, _frmDimensionView.InumHeight);
                    }
                }
                else
                {
                    _mainPresenter.Scenario_Quotation(_mainPresenter_qoutationInputBox_ClickedOK,
                                                      _mainPresenter_newItem_ClickedOK,
                                                      _mainPresenter_AddedFrame_ClickedOK,
                                                      _mainPresenter_AddedConcrete_ClickedOK,
                                                      _mainPresenter_OpenWindoorFile_ClickedOK,
                                                      _mainPresenter_Duplicate_ClickedOK,
                                                      purpose,
                                                      _frmDimensionView.InumWidth,
                                                      _frmDimensionView.InumHeight,
                                                      profile_type,
                                                      _baseColor);
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
            if (_baseColor == string.Empty)
            {
                _baseColor = "White";
            }
            if (profile_type == string.Empty)
            {
                profile_type = "C70 Profile";
            }
            
            
            //_frmDimensionView.dimension_height = 203;
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
            _multiTransomUCP = null;
            _multiMullionUCP = multiUCP;
        }

        public void SetPresenters(IMultiPanelTransomUCPresenter multiTransomUCP)
        {
            _multiMullionUCP = null;
            _multiTransomUCP = multiTransomUCP;
        }

        public void SetProfileType(string profileType)
        {
            profile_type = profileType;
        }

        public void SetBaseColor(string baseColor)
        {
            _baseColor = baseColor;
        }

        public void SetHeight()
        {
            if (purpose == Show_Purpose.Quotation)
            {
                _frmDimensionView.thisHeight = 203;
            }
            else if (purpose == Show_Purpose.CreateNew_Item ||
                     purpose == Show_Purpose.CreateNew_Frame ||
                     purpose == Show_Purpose.ChangeBasePlatformSize ||
                     purpose == Show_Purpose.AddPanelIntoMultiPanel)
            {
                _frmDimensionView.thisHeight = 140;
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
