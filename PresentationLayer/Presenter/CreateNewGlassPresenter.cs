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
        /* DataTable schema
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
            _createNewGlassView.BtnAddGlassClick += new EventHandler(OnBtnAddGlassClick);
        }




        private void OnNewGlassViewLoadEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.cmbSelectedindex = 0;
            _createNewGlassView.lblDescriptionView = string.Empty;
            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                _createNewGlassView.lblGlassHeader = "Single Glass";
                _createNewGlassView.GlassViewHeight = 210;
                _createNewGlassView.pnlGlassVisible2 = false;
                _createNewGlassView.pnlGlassVisible3 = false;
                _createNewGlassView.pnlTotalGlassVisible = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleInsulated)
            {
                _createNewGlassView.lblGlassHeader = "Double Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Spacer";
                _createNewGlassView.GlassViewHeight = 330;
                _createNewGlassView.pnlGlassVisible3 = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleLaminated)
            {
                _createNewGlassView.lblGlassHeader = "Double Laminated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Polyvinyl";
                _createNewGlassView.GlassViewHeight = 330;
                _createNewGlassView.pnlGlassVisible3 = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleInsulated)
            {
                _createNewGlassView.lblGlassHeader = "Triple Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Spacer";
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleLaminated)
            {
                _createNewGlassView.lblGlassHeader = "Triple Insulated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Polyvinyl";
            }

            _createNewGlassView.GlassType1.DataSource = _mainPresenter.Glass_Type;
            _createNewGlassView.GlassType1.DisplayMember = "GlassType";

            /* yung gagamitin mong dataSource
             * _mainPresenter.Color at _mainPresenter.Spacer
             * 
             * yung sa DisplayMember
             * "Color" at "Spacer"
             * 
             */
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

            _Glass1Description = _createNewGlassView.GetNudGlassThickness1().Text + " mm " + _createNewGlassView.cmbGlassType_1 + " " + _createNewGlassView.cmbColor_1;
            _Glass2Description = _createNewGlassView.GetNudGlassThickness2().Text + " mm " + _createNewGlassView.cmbGlassType_2 + " " + _createNewGlassView.cmbColor_2;
            _Glass3Description = _createNewGlassView.GetNudGlassThickness3().Text + " mm " + _createNewGlassView.cmbGlassType_3 + " " + _createNewGlassView.cmbColor_3;

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


            _BetweenTheGlass1 = _createNewGlassView.GetNudBetweenTheGlass1().Text + _BetweenTheGlassUnit;
            _BetweenTheGlass2 = _createNewGlassView.GetNudBetweenTheGlass2().Text + _BetweenTheGlassUnit2;

            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                if (_createNewGlassView.GetNudGlassThickness1().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    _createNewGlassView.lblDescriptionView = _Glass1Description;
                }

            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleInsulated ||
                     _purpose == CreateNewGlass_ShowPurpose._DoubleLaminated)
            {
                if (_createNewGlassView.GetNudGlassThickness1().Text == string.Empty ||
                    _createNewGlassView.GetNudGlassThickness2().Text == string.Empty ||
                    _createNewGlassView.GetNudBetweenTheGlass1().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    decimal glassResult, glass1 = 0, glass2 = 0, BetweenTheGlass1 = 0;
                    glass1 = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness1().Text);
                    glass2 = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness2().Text);
                    BetweenTheGlass1 = Convert.ToDecimal(_createNewGlassView.GetNudBetweenTheGlass1().Text);
                    glassResult = glass1 + BetweenTheGlass1 + glass2;

                    _createNewGlassView.GetTboxTotalGlassThickness1().Text = Convert.ToString(glassResult);

                    _createNewGlassView.lblDescriptionView = _Glass1Description + " ➕ " + _BetweenTheGlass1 + " ➕ " + _Glass2Description;
                }

            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleInsulated ||
                     _purpose == CreateNewGlass_ShowPurpose._TripleLaminated)
            {
                if (_createNewGlassView.GetNudGlassThickness1().Text == string.Empty ||
                    _createNewGlassView.GetNudGlassThickness2().Text == string.Empty ||
                    _createNewGlassView.GetNudGlassThickness3().Text == string.Empty ||
                    _createNewGlassView.GetNudBetweenTheGlass1().Text == string.Empty ||
                    _createNewGlassView.GetNudBetweenTheGlass2().Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    decimal glassResult, glass1 = 0, glass2 = 0, glass3 = 0, BetweenTheGlass1 = 0, BetweenTheGlass2 = 0;
                    glass1 = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness1().Text);
                    glass2 = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness2().Text);
                    glass3 = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness3().Text);
                    BetweenTheGlass1 = Convert.ToDecimal(_createNewGlassView.GetNudBetweenTheGlass1().Text);
                    BetweenTheGlass2 = Convert.ToDecimal(_createNewGlassView.GetNudBetweenTheGlass2().Text);
                    glassResult = glass1 + BetweenTheGlass1 + glass2 + BetweenTheGlass2 + glass3;

                    _createNewGlassView.GetTboxTotalGlassThickness1().Text = Convert.ToString(glassResult);

                    _createNewGlassView.lblDescriptionView = _Glass1Description + " ➕ " + _BetweenTheGlass1 + " ➕ " + _Glass2Description + " ➕ " + _BetweenTheGlass2 + " ➕ " + _Glass3Description;
                }


            }





        }


        private void OnBtnAddGlassClick(object sender, EventArgs e)
        {
            CreateNewGlass_Datarow();
        }

        public DataRow CreateNewGlass_Datarow()
        {

            DataRow newRow;
            newRow = _glassThicknessDT.NewRow();

            // Populate row here
            string GlassDescription = _createNewGlassView.lblDescriptionView;


            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                decimal SingleTotalThicknessDecimal = Convert.ToDecimal(_createNewGlassView.GetNudGlassThickness1().Text);
                _glassThicknessDT.Rows.Add(SingleTotalThicknessDecimal,
                                           GlassDescription,
                                           true,
                                           false,
                                           false,
                                           false,
                                           false);
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleInsulated)
            {
                decimal TotalThicknessDecimal = Convert.ToDecimal(_createNewGlassView.GetTboxTotalGlassThickness1().Text);
                _glassThicknessDT.Rows.Add(TotalThicknessDecimal,
                                           GlassDescription,
                                           false,
                                           true,
                                           false,
                                           true,
                                           false);
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleLaminated)
            {
                decimal TotalThicknessDecimal = Convert.ToDecimal(_createNewGlassView.GetTboxTotalGlassThickness1().Text);
                _glassThicknessDT.Rows.Add(TotalThicknessDecimal,
                                           GlassDescription,
                                           false,
                                           true,
                                           false,
                                           false,
                                           true);
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleInsulated)
            {
                decimal TotalThicknessDecimal = Convert.ToDecimal(_createNewGlassView.GetTboxTotalGlassThickness1().Text);
                _glassThicknessDT.Rows.Add(TotalThicknessDecimal,
                                             GlassDescription,
                                             false,
                                             false,
                                             true,
                                             true,
                                             false);
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleLaminated)
            {
                decimal TotalThicknessDecimal = Convert.ToDecimal(_createNewGlassView.GetTboxTotalGlassThickness1().Text);
                _glassThicknessDT.Rows.Add(TotalThicknessDecimal,
                                           GlassDescription,
                                           false,
                                           false,
                                           true,
                                           false,
                                           true);
            }





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
