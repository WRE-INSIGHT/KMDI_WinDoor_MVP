using PresentationLayer.Views;
using System;
using System.Data;
using Unity;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Presenter
{
    public class CreateNewGlassPresenter : ICreateNewGlassPresenter
    {
        ICreateNewGlassView _createNewGlassView;

        private IMainPresenter _mainPresenter;

        private CreateNewGlass_ShowPurpose _purpose;
        private DataTable _glassThicknessDT;
        /* DataTable scheme
         * 
         * Example : Double Laminated 12.75mm
         * 
         * TotalThickness (Decimal) | Description (String)| Single (bool) | Double (bool) | Triple (bool) | Insulated (bool) | Laminated (bool) |
         * ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|
         * 12.75                    | 10mm + 0.75mm + 6mm | false         | true          | false         | false            | true             |
         *                          |                     |               |               |               |                  |                  |
         * ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯                         
         */
        public CreateNewGlassPresenter(ICreateNewGlassView createNewGlassView)
        {
            _createNewGlassView = createNewGlassView;
            SubscribeToEventsSetup();
        }


        private void SubscribeToEventsSetup()
        {
            _createNewGlassView.NewGlassViewLoadEventRaised += new EventHandler(OnNewGlassViewLoadEventRaised);
            _createNewGlassView.GlassThicknessTextChange += new EventHandler(OnGlassTextchangeEventRaised);
        }



        private void OnNewGlassViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.cmbSelectedindex = 0;
            _createNewGlassView.lblDescriptionView = string.Empty;
            if (_purpose.Value == 0)
            {
                _createNewGlassView.lblGlassHeader = "Single Glass";
                _createNewGlassView.GlassViewHeight = 210;
                _createNewGlassView.pnlGlassVisible2 = false;
                _createNewGlassView.pnlGlassVisible3 = false;
                _createNewGlassView.pnlTotalGlassVisible = false;
            }
            else if (_purpose.Value == 1)
            {
                _createNewGlassView.lblGlassHeader = "Double Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Spacer";
                _createNewGlassView.GlassViewHeight = 330;
                _createNewGlassView.pnlGlassVisible3 = false;
            }
            else if (_purpose.Value == 2)
            {
                _createNewGlassView.lblGlassHeader = "Double Laminated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Polyvinyl";
                _createNewGlassView.GlassViewHeight = 330;
                _createNewGlassView.pnlGlassVisible3 = false;
            }
            else if (_purpose.Value == 3)
            {
                _createNewGlassView.lblGlassHeader = "Triple Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Spacer";
            }
            else if (_purpose.Value == 4)
            {
                _createNewGlassView.lblGlassHeader = "Triple Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Polyvinyl";
            }
        }


        string _Glass1Description;
        string _Glass2Description;
        string _Glass3Description;
        string _BetweenTheGlass1;
        string _BetweenTheGlass2;
        string _BetweenTheGlassUnit;
        string _BetweenTheGlassUnit2;
        private void OnGlassTextchangeEventRaised(object sender, EventArgs e)
        {

            _Glass1Description = _createNewGlassView.GetTboxGlassThickness1().Text + " mm " + _createNewGlassView.cmbGlassType_1 + " " + _createNewGlassView.cmbColor_1;
            _Glass2Description = _createNewGlassView.GetTboxGlassThickness2().Text + " mm " + _createNewGlassView.cmbGlassType_2 + " " + _createNewGlassView.cmbColor_2;
            _Glass3Description = _createNewGlassView.GetTboxGlassThickness3().Text + " mm " + _createNewGlassView.cmbGlassType_3 + " " + _createNewGlassView.cmbColor_3;
            //_Glass1Description = _createNewGlassView.tboxGlassThickness_1 + " mm " + _createNewGlassView.cmbGlassType_1 + " " + _createNewGlassView.cmbColor_1;
            //_Glass2Description = _createNewGlassView.tboxGlassThickness_2 + " mm " + _createNewGlassView.cmbGlassType_2 + " " + _createNewGlassView.cmbColor_2;
            //_Glass3Description = _createNewGlassView.tboxGlassThickness_3 + " mm " + _createNewGlassView.cmbGlassType_3 + " " + _createNewGlassView.cmbColor_3;

            if (_createNewGlassView.cmbBetweenTheGlass_1 == "Argon")
            {
                _BetweenTheGlassUnit = " Ar";
            }
            else
            {
                _BetweenTheGlassUnit = string.Empty;
            }

            if (_createNewGlassView.cmbBetweenTheGlass_2 == "Argon")
            {
                _BetweenTheGlassUnit2 = " Ar";
            }
            else
            {
                _BetweenTheGlassUnit2 = string.Empty;
            }


            _BetweenTheGlass1 = _createNewGlassView.GetTboxBetweenTheGlass1().Text + _BetweenTheGlassUnit;
            _BetweenTheGlass2 = _createNewGlassView.GetTboxBetweenTheGlass2().Text + _BetweenTheGlassUnit2;
            //_BetweenTheGlass1 = _createNewGlassView.tboxBetweenTheGlass_1 + _BetweenTheGlassUnit;
            //_BetweenTheGlass2 = _createNewGlassView.tboxBetweenTheGlass_2 + _BetweenTheGlassUnit2;

            if (_purpose.Value == 0)
            {
                if (_createNewGlassView.GetTboxGlassThickness1().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    _createNewGlassView.lblDescriptionView = _Glass1Description;
                }

            }
            else if (_purpose.Value == 1 || _purpose.Value == 2)
            {
                if (_createNewGlassView.GetTboxGlassThickness1().Text == string.Empty || _createNewGlassView.GetTboxGlassThickness2().Text == string.Empty || _createNewGlassView.GetTboxBetweenTheGlass1().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    double glassResult, glass1 = 0, glass2 = 0, BetweenTheGlass1 = 0;
                    glass1 = Convert.ToDouble(_createNewGlassView.GetTboxGlassThickness1().Text);
                    glass2 = Convert.ToDouble(_createNewGlassView.GetTboxGlassThickness2().Text);
                    BetweenTheGlass1 = Convert.ToDouble(_createNewGlassView.GetTboxBetweenTheGlass1().Text);
                    glassResult = glass1 + BetweenTheGlass1 + glass2;

                    _createNewGlassView.GetTboxTotalGlassThickness1().Text = Convert.ToString(glassResult);

                    _createNewGlassView.lblDescriptionView = _Glass1Description + " ➕ " + _BetweenTheGlass1 + " ➕ " + _Glass2Description;
                }



            }
            else if (_purpose.Value == 3 || _purpose.Value == 4)
            {
                if (_createNewGlassView.GetTboxGlassThickness1().Text == string.Empty || _createNewGlassView.GetTboxGlassThickness2().Text == string.Empty || _createNewGlassView.GetTboxGlassThickness3().Text == string.Empty || _createNewGlassView.GetTboxBetweenTheGlass1().Text == string.Empty || _createNewGlassView.GetTboxBetweenTheGlass2().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    double glassResult, glass1 = 0, glass2 = 0, glass3 = 0, BetweenTheGlass1 = 0, BetweenTheGlass2 = 0;
                    glass1 = Convert.ToDouble(_createNewGlassView.GetTboxGlassThickness1().Text);
                    glass2 = Convert.ToDouble(_createNewGlassView.GetTboxGlassThickness2().Text);
                    glass3 = Convert.ToDouble(_createNewGlassView.GetTboxGlassThickness3().Text);
                    BetweenTheGlass1 = Convert.ToDouble(_createNewGlassView.GetTboxBetweenTheGlass1().Text);
                    BetweenTheGlass2 = Convert.ToDouble(_createNewGlassView.GetTboxBetweenTheGlass2().Text);
                    glassResult = glass1 + BetweenTheGlass1 + glass2 + BetweenTheGlass2 + glass3;

                    _createNewGlassView.GetTboxTotalGlassThickness1().Text = Convert.ToString(glassResult);

                    _createNewGlassView.lblDescriptionView = _Glass1Description + " ➕ " + _BetweenTheGlass1 + " ➕ " + _Glass2Description + " ➕ " + _BetweenTheGlass2 + " ➕ " + _Glass3Description;

                }


            }





        }




        public DataRow CreateNewGlass_Datarow()
        {
            DataRow newRow;
            newRow = _glassThicknessDT.NewRow();

            // Populate row here

            return newRow;
        }

        public ICreateNewGlassPresenter GetNewInstance(IUnityContainer unityC,
                                                       IMainPresenter mainPresenter,
                                                       CreateNewGlass_ShowPurpose purpose,
                                                       DataTable glassThicknessDT)
        {
            unityC
                .RegisterType<ICreateNewGlassView, CreateNewGlassView>()
                .RegisterType<ICreateNewGlassPresenter, CreateNewGlassPresenter>();
            CreateNewGlassPresenter createNewGlassPresenter = unityC.Resolve<CreateNewGlassPresenter>();
            createNewGlassPresenter._mainPresenter = mainPresenter;
            createNewGlassPresenter._mainPresenter = mainPresenter;
            createNewGlassPresenter._purpose = purpose;
            createNewGlassPresenter._glassThicknessDT = glassThicknessDT;

            return createNewGlassPresenter;
        }

        public void ShowCreateNewGlassView()
        {
            _createNewGlassView.ShowThis();
        }
    }
}
