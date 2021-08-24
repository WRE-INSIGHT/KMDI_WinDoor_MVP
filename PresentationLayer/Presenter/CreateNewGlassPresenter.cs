using PresentationLayer.Views;
using System;
using System.Data;
using System.Windows.Forms;
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

            _createNewGlassView.GlassType1().DropDown += OnGlassType1DropDownEventRaised;
            _createNewGlassView.GlassType2().DropDown += OnGlassType2DropDownEventRaised;
            _createNewGlassView.GlassType3().DropDown += OnGlassType3DropDownEventRaised;
            _createNewGlassView.Color1().DropDown += OnGlassColor1DropDownEventRaised;
            _createNewGlassView.Color2().DropDown += OnGlassColor2DropDownEventRaised;
            _createNewGlassView.Color3().DropDown += OnGlassColor3DropDownEventRaised;
            _createNewGlassView.Spacer1().DropDown += OnGlassSpacer1DropDownEventRaised;
            _createNewGlassView.Spacer2().DropDown += OnGlassSpacer2DropDownEventRaised;
        }


        #region CmbEvent


        private void OnGlassType1DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.GlassType1().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType1().DisplayMember = "GlassType";
        }
        private void OnGlassType2DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.GlassType2().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType2().DisplayMember = "GlassType";
        }
        private void OnGlassType3DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.GlassType3().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType3().DisplayMember = "GlassType";
        }
        private void OnGlassColor1DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.Color1().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color1().DisplayMember = "Color";
        }
        private void OnGlassColor2DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.Color2().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color2().DisplayMember = "Color";
        }
        private void OnGlassColor3DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.Color3().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color3().DisplayMember = "Color";
        }
        private void OnGlassSpacer1DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.Spacer1().DataSource = _mainPresenter.Spacer.Copy();
            _createNewGlassView.Spacer1().DisplayMember = "Spacer";
        }

        private void OnGlassSpacer2DropDownEventRaised(object sender, EventArgs e)
        {
            _createNewGlassView.Spacer2().DataSource = _mainPresenter.Spacer.Copy();
            _createNewGlassView.Spacer2().DisplayMember = "Spacer";
        }
        #endregion

        private void OnNewGlassViewLoadEventRaised(object sender, EventArgs e)
        {
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
                _createNewGlassView.GlassViewHeight = 335;
                _createNewGlassView.pnlGlassVisible3 = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleLaminated)
            {
                _createNewGlassView.lblGlassHeader = "Double Laminated Glass";
                _createNewGlassView.lblBetweenTheGlass = "Polyvinyl";
                _createNewGlassView.GlassViewHeight = 335;
                _createNewGlassView.pnlGlassVisible3 = false;
                _createNewGlassView.SpacerVisible = false;
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
                _createNewGlassView.SpacerVisible = false;
            }
            _createNewGlassView.GlassType1().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType1().DisplayMember = "GlassType";
            _createNewGlassView.GlassType2().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType2().DisplayMember = "GlassType";
            _createNewGlassView.GlassType3().DataSource = _mainPresenter.Glass_Type.Copy();
            _createNewGlassView.GlassType3().DisplayMember = "GlassType";

            _createNewGlassView.Color1().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color1().DisplayMember = "Color";
            _createNewGlassView.Color2().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color2().DisplayMember = "Color";
            _createNewGlassView.Color3().DataSource = _mainPresenter.Color.Copy();
            _createNewGlassView.Color3().DisplayMember = "Color";

            _createNewGlassView.Spacer1().DataSource = _mainPresenter.Spacer.Copy();
            _createNewGlassView.Spacer1().DisplayMember = "Spacer";
            _createNewGlassView.Spacer2().DataSource = _mainPresenter.Spacer.Copy();
            _createNewGlassView.Spacer2().DisplayMember = "Spacer";


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
        string _GlassType1;
        string _GlassType2;
        string _GlassType3;
        private void OnGlassTextchangeEventRaised(object sender, EventArgs e)
        {

            #region GlassDescription   

            _GlassType1 = _createNewGlassView.GlassType1().Text;
            _GlassType2 = _createNewGlassView.GlassType2().Text;
            _GlassType3 = _createNewGlassView.GlassType3().Text;

            #region glass1
            if (_GlassType1.ToUpper() == "ANNEALED")
            {
                _GlassType1 = _GlassType1.ToUpper().Replace("ANNEALED", string.Empty);
                _Glass1Description = _createNewGlassView.GlassThickness1.Value + " mm" + _GlassType1 + " " + _createNewGlassView.Color1().Text;
            }
            else if (_GlassType1.ToUpper().Contains("GEORGIAN BAR") && _GlassType1.ToUpper().Contains("LOW-E"))
            {
                _GlassType1 = _GlassType1.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType1 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType1.ToLower());
                _Glass1Description = _createNewGlassView.GlassThickness1.Value + " mm " + _GlassType1 + " " + _createNewGlassView.Color1().Text + " Low-e with Georgian Bar";

            }
            else if (_GlassType1.ToUpper().Contains("GEORGIAN BAR"))
            {
                _GlassType1 = _GlassType1.ToUpper().Replace("ANNEALED", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType1 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType1.ToLower());
                _Glass1Description = _createNewGlassView.GlassThickness1.Value + " mm " + _GlassType1 + " " + _createNewGlassView.Color1().Text + " with Georgian Bar";
            }
            else if (_GlassType1.ToUpper().Contains("LOW-E"))
            {
                _GlassType1 = _GlassType1.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty);
                _GlassType1 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType1.ToLower());
                _Glass1Description = _createNewGlassView.GlassThickness1.Value + " mm " + _GlassType1 + " " + _createNewGlassView.Color1().Text + " Low-e";
            }
            else
            {
                _GlassType1 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType1.ToLower());
                _Glass1Description = _createNewGlassView.GlassThickness1.Value + " mm " + _GlassType1 + " " + _createNewGlassView.Color1().Text;
            }
            #endregion

            #region glass2
            if (_GlassType2.ToUpper() == "ANNEALED")
            {
                _GlassType2 = _GlassType2.ToUpper().Replace("ANNEALED", string.Empty);
                _Glass2Description = _createNewGlassView.GlassThickness2.Value + " mm " + _GlassType2 + " " + _createNewGlassView.Color2().Text;
            }
            else if (_GlassType2.ToUpper().Contains("GEORGIAN BAR") && _GlassType2.ToUpper().Contains("LOW-E"))
            {
                _GlassType2 = _GlassType2.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType2.ToLower());
                _Glass2Description = _createNewGlassView.GlassThickness2.Value + " mm " + _GlassType2 + " " + _createNewGlassView.Color2().Text + " Low-e with Georgian Bar";

            }
            else if (_GlassType2.ToUpper().Contains("GEORGIAN BAR"))
            {
                _GlassType2 = _GlassType2.ToUpper().Replace("ANNEALED", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType2.ToLower());
                _Glass2Description = _createNewGlassView.GlassThickness2.Value + " mm " + _GlassType2 + " " + _createNewGlassView.Color2().Text + " with Georgian Bar";
            }
            else if (_GlassType2.ToUpper().Contains("LOW-E"))
            {
                _GlassType2 = _GlassType2.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty);
                _GlassType2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType2.ToLower());
                _Glass2Description = _createNewGlassView.GlassThickness2.Value + " mm " + _GlassType2 + " " + _createNewGlassView.Color2().Text + " Low-e";
            }
            else
            {
                _GlassType2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType2.ToLower());
                _Glass2Description = _createNewGlassView.GlassThickness2.Value + " mm " + _GlassType2 + " " + _createNewGlassView.Color2().Text;
            }

            #endregion

            #region Glass3
            if (_GlassType3.ToUpper() == "ANNEALED")
            {
                _GlassType3 = _GlassType3.ToUpper().Replace("ANNEALED", string.Empty);
                _Glass3Description = _createNewGlassView.GlassThickness3.Value + " mm " + _GlassType3 + " " + _createNewGlassView.Color3().Text;
            }
            else if (_GlassType3.ToUpper().Contains("GEORGIAN BAR") && _GlassType3.ToUpper().Contains("LOW-E"))
            {
                _GlassType3 = _GlassType3.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType3 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType3.ToLower());
                _Glass3Description = _createNewGlassView.GlassThickness3.Value + " mm " + _GlassType3 + " " + _createNewGlassView.Color3().Text + " Low-e with Georgian Bar";

            }
            else if (_GlassType3.ToUpper().Contains("GEORGIAN BAR"))
            {
                _GlassType3 = _GlassType3.ToUpper().Replace("ANNEALED", string.Empty).Replace($" WITH GEORGIAN BAR", string.Empty);
                _GlassType3 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType3.ToLower());
                _Glass3Description = _createNewGlassView.GlassThickness3.Value + " mm " + _GlassType3 + " " + _createNewGlassView.Color3().Text + " with Georgian Bar";
            }
            else if (_GlassType3.ToUpper().Contains("LOW-E"))
            {
                _GlassType3 = _GlassType3.ToUpper().Replace("ANNEALED", string.Empty).Replace($" LOW-E", string.Empty);
                _GlassType3 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType3.ToLower());
                _Glass3Description = _createNewGlassView.GlassThickness3.Value + " mm " + _GlassType3 + " " + _createNewGlassView.Color3().Text + " Low-e";
            }
            else
            {
                _GlassType3 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_GlassType3.ToLower());
                _Glass3Description = _createNewGlassView.GlassThickness3.Value + " mm " + _GlassType3 + " " + _createNewGlassView.Color3().Text;
            }

            #endregion

            #region Spacer


            if (_createNewGlassView.Spacer1().Text == "Argon")
            {
                _BetweenTheGlassUnit = " Ar";
            }
            else
            {
                _BetweenTheGlassUnit = string.Empty;
            }

            if (_createNewGlassView.Spacer2().Text == "Argon")
            {
                _BetweenTheGlassUnit2 = " Ar";
            }
            else
            {
                _BetweenTheGlassUnit2 = string.Empty;
            }
            #endregion


            #endregion

            _BetweenTheGlass1 = _createNewGlassView.BetweenTheGlass1.Value + _BetweenTheGlassUnit;
            _BetweenTheGlass2 = _createNewGlassView.BetweenTheGlass2.Value + _BetweenTheGlassUnit2;
            string StrGlass1 = Convert.ToString(_createNewGlassView.GlassThickness1.Value);
            string StrGlass2 = Convert.ToString(_createNewGlassView.GlassThickness2.Value);
            string StrGlass3 = Convert.ToString(_createNewGlassView.GlassThickness3.Value);

            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                if (StrGlass1 == string.Empty)
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
                if (StrGlass1 == string.Empty ||
                    StrGlass2 == string.Empty ||
                    StrGlass3 == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    //Glass1 + Spacer + Glass2
                    int glassResult = Convert.ToInt32(Math.Round(_createNewGlassView.GlassThickness1.Value +
                                                                 _createNewGlassView.BetweenTheGlass1.Value +
                                                                 _createNewGlassView.GlassThickness2.Value));

                    _createNewGlassView.TotalThickness.Value = glassResult;


                    _createNewGlassView.lblDescriptionView = _Glass1Description + " + " + _BetweenTheGlass1 + " + " + _Glass2Description;

                }

            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleInsulated ||
                     _purpose == CreateNewGlass_ShowPurpose._TripleLaminated)
            {
                if (_createNewGlassView.GlassThickness1.Text == string.Empty ||
                    _createNewGlassView.GlassThickness2.Text == string.Empty ||
                    _createNewGlassView.GlassThickness3.Text == string.Empty ||
                    _createNewGlassView.BetweenTheGlass1.Text == string.Empty ||
                    _createNewGlassView.BetweenTheGlass2.Text == string.Empty)
                {
                    _createNewGlassView.lblDescriptionView = string.Empty;
                }
                else
                {
                    //Glass1 + Spacer + Glass2 + Spacer + Glass3            
                    int glassResult = Convert.ToInt32(Math.Round(_createNewGlassView.GlassThickness1.Value +
                                                                 _createNewGlassView.BetweenTheGlass1.Value +
                                                                 _createNewGlassView.GlassThickness2.Value +
                                                                 _createNewGlassView.BetweenTheGlass2.Value +
                                                                 _createNewGlassView.GlassThickness3.Value));

                    _createNewGlassView.TotalThickness.Value = glassResult;

                    _createNewGlassView.lblDescriptionView = _Glass1Description + " + " + _BetweenTheGlass1 + " + " + _Glass2Description + " + " + _BetweenTheGlass2 + " + " + _Glass3Description;

                }
            }

        }


        private void OnBtnAddGlassClick(object sender, EventArgs e)
        {
            string WarningMsg;
            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                WarningMsg = "Your Glass Thickness is " + _createNewGlassView.GlassThickness1.Value + ", are you sure you want to add ?";
            }
            else
            {
                WarningMsg = "Your Glass Thickness is " + _createNewGlassView.TotalThickness.Value + ", are you sure you want to add ?";
            }

            if (_createNewGlassView.TotalThickness.Value > 24 || _createNewGlassView.GlassThickness1.Value > 24)
            {
                if (MessageBox.Show(WarningMsg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _glassThicknessDT.Rows.Add(CreateNewGlass_Datarow());
                    _mainPresenter.GlassThicknessDT = _glassThicknessDT;
                    _createNewGlassView.CloseThis();
                }
            }

            else
            {
                _glassThicknessDT.Rows.Add(CreateNewGlass_Datarow());
                _mainPresenter.GlassThicknessDT = _glassThicknessDT;
                _createNewGlassView.CloseThis();
            }
        }

        public DataRow CreateNewGlass_Datarow()
        {

            DataRow newRow;
            newRow = _glassThicknessDT.NewRow();

            // Populate row here
            string GlassDescription = _createNewGlassView.lblDescriptionView;


            if (_purpose == CreateNewGlass_ShowPurpose._Single)
            {
                newRow["TotalThickness"] = _createNewGlassView.GlassThickness1.Value;
                newRow["Description"] = GlassDescription;
                newRow["Single"] = true;
                newRow["Double"] = false;
                newRow["Triple"] = false;
                newRow["Insulated"] = false;
                newRow["Laminated"] = false;


            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleInsulated)
            {
                newRow["TotalThickness"] = _createNewGlassView.TotalThickness.Value;
                newRow["Description"] = GlassDescription;
                newRow["Single"] = false;
                newRow["Double"] = true;
                newRow["Triple"] = false;
                newRow["Insulated"] = true;
                newRow["Laminated"] = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._DoubleLaminated)
            {
                newRow["TotalThickness"] = _createNewGlassView.TotalThickness.Value;
                newRow["Description"] = GlassDescription;
                newRow["Single"] = false;
                newRow["Double"] = true;
                newRow["Triple"] = false;
                newRow["Insulated"] = false;
                newRow["Laminated"] = true;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleInsulated)
            {
                newRow["TotalThickness"] = _createNewGlassView.TotalThickness.Value;
                newRow["Description"] = GlassDescription;
                newRow["Single"] = false;
                newRow["Double"] = false;
                newRow["Triple"] = true;
                newRow["Insulated"] = true;
                newRow["Laminated"] = false;
            }
            else if (_purpose == CreateNewGlass_ShowPurpose._TripleLaminated)
            {
                newRow["TotalThickness"] = _createNewGlassView.TotalThickness.Value;
                newRow["Description"] = GlassDescription;
                newRow["Single"] = false;
                newRow["Double"] = false;
                newRow["Triple"] = true;
                newRow["Insulated"] = false;
                newRow["Laminated"] = true;
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
