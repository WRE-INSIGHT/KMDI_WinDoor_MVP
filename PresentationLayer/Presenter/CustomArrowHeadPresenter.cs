using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class CustomArrowHeadPresenter : ICustomArrowHeadPresenter
    {
        ICustomArrowHeadView _customArrowHead;

        private IUnityContainer _unityC;
        private ICustomArrowHeadUCPresenter _customArrowHeadUCP;
        private IWindoorModel _windoorModel;
        private IMainPresenter _mainPresenter;

        private List<ICustomArrowHeadUCPresenter> _lst_arrowUCP = new List<ICustomArrowHeadUCPresenter>();

        private Panel _customArrowHeadPnlWD;
        private Panel _customArrowHeadPnlHT;

        private int _arrowWD_count;
        public int ArrowWD_Count
        {
            get
            {
                return _arrowWD_count;
            }
            set
            {
                _arrowWD_count = value;
                if (_arrowWD_count == 0)
                {
                    _customArrowHeadPnlWD.Visible = false;
                }
                else if (_arrowWD_count > 0)
                {
                    _customArrowHeadPnlWD.Visible = true;
                }
            }
        }

        private int _arrowHT_count;
        public int ArrowHT_Count
        {
            get
            {
                return _arrowHT_count;
            }
            set
            {
                _arrowHT_count = value;
                if (_arrowHT_count == 0)
                {
                    _customArrowHeadPnlHT.Visible = false;
                }
                else if (_arrowHT_count > 0)
                {
                    _customArrowHeadPnlHT.Visible = true;
                }
            }
        }
        public CustomArrowHeadPresenter(ICustomArrowHeadView customArrowHead,
                                        ICustomArrowHeadUCPresenter customArrowHeadUCP)
        {
            _customArrowHeadUCP = customArrowHeadUCP;
            _customArrowHead = customArrowHead;
            _customArrowHeadPnlWD = _customArrowHead.GetPnlArrowWD();
            _customArrowHeadPnlHT = _customArrowHead.GetPnlArrowHT();


            subscribeToEventSetup();
        }

        private void subscribeToEventSetup()
        {
            _customArrowHead.BtnAddArrowHeadHeightCkickEventRaised += _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised;
            _customArrowHead.BtnAddArrowHeadWidthCkickEventRaised += _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised;
            _customArrowHead.BtnSaveCustomArrowCkickEventRaised += _customArrowHead_BtnSaveCustomArrowCkickEventRaised;
            _customArrowHead.CustomArrowHeadViewLoadEventRaised += _customArrowHead_CustomArrowHeadViewLoadEventRaised;
        }

        private void _customArrowHead_CustomArrowHeadViewLoadEventRaised(object sender, EventArgs e)
        {
            _customArrowHead.ThisBinding(CreateBindingDictionary());
        }

        private void _customArrowHead_BtnSaveCustomArrowCkickEventRaised(object sender, EventArgs e)
        {
            Dictionary<int, int> arrowWdLength_Lst = new Dictionary<int, int>();
            int ArrowWdID = 0;

            foreach (Control arrow in _customArrowHeadPnlWD.Controls)
            {
                ((ICustomArrowHeadUC)arrow).ArrowWidthId = ArrowWdID;
                arrowWdLength_Lst.Add(ArrowWdID, ((ICustomArrowHeadUC)arrow).Arrow_Size);
                ArrowWdID++;
            }

            if (arrowWdLength_Lst.Count > 0)
            {
                _windoorModel.Div_ArrowWdLengthList = arrowWdLength_Lst;
                MessageBox.Show("Saved");

            }

        }

        private void _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            CustomArrowHeadUCPresenter.GetCustomArrowUC().ArrowCount++;
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter.GetCustomArrowUC();
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlWD.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowWD_Count++;
            _windoorModel.Lbl_ArrowWdCount++;
        }

        private void _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised(object sender, EventArgs e)
        {
            ICustomArrowHeadUCPresenter CustomArrowHeadUCPresenter1 = _customArrowHeadUCP.GetNewInstance(_unityC, this, _windoorModel);
            _lst_arrowUCP.Add(CustomArrowHeadUCPresenter1);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadUCPresenter1.GetCustomArrowUC();
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlHT.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowHT_Count++;
            _windoorModel.Lbl_ArrowHtCount++;
        }

        public ICustomArrowHeadView GetICustomArrowHeadView()
        {
            return _customArrowHead;
        }
        public void Remove_ArrowHeadUCP(ICustomArrowHeadUCPresenter CustomArrowHeadUCP)
        {
            _lst_arrowUCP.Remove(CustomArrowHeadUCP);
        }

        public void ComputeTotalArrowLenght()
        {
            int totalArrowWdLength = 0,
                totalArrowHtLength = 0;
        
            foreach (ICustomArrowHeadUCPresenter ArrowHead in _lst_arrowUCP)
            {
                Control CustomArrowHead = ((UserControl)ArrowHead.GetCustomArrowUC()).Parent;

                if (CustomArrowHead.Name == "pnl_ArrowHeight")
                {
                    totalArrowHtLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
                else if (CustomArrowHead.Name == "pnl_ArrowWidth")
                {
                    totalArrowWdLength += ArrowHead.GetCustomArrowUC().Arrow_Size;
                }
            }

            _customArrowHead.SetLblTotalArrowLength_Text(totalArrowWdLength.ToString(), totalArrowHtLength.ToString());

        }

        public ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC,
                                                        ICustomArrowHeadUCPresenter customArrowHeadUC,
                                                        IWindoorModel windoorModel,
                                                        IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<ICustomArrowHeadPresenter, CustomArrowHeadPresenter>()
                  .RegisterType<ICustomArrowHeadView, CustomArrowHeadView>();
            CustomArrowHeadPresenter CustomArrow = unityC.Resolve<CustomArrowHeadPresenter>();
            CustomArrow._unityC = unityC;
            CustomArrow._customArrowHeadUCP = customArrowHeadUC;
            CustomArrow._windoorModel = windoorModel;
            CustomArrow._mainPresenter = mainPresenter;
            return CustomArrow;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Lbl_ArrowWdCount", new Binding("Text", _windoorModel, "Lbl_ArrowWdCount", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Lbl_ArrowHtCount", new Binding("Text", _windoorModel, "Lbl_ArrowHtCount", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Pnl_ArrowHeightVisibility", new Binding("Visible", _windoorModel, "Pnl_ArrowHeightVisibility", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Pnl_ArrowWidthVisibility", new Binding("Visible", _windoorModel, "Pnl_ArrowWidthVisibility", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
