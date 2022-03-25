using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
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
        
        private List<ICustomArrowHeadUCPresenter> _lst_arrowUCP = new List<ICustomArrowHeadUCPresenter>();

        private Panel _customArrowHeadPnlWD;
        private Panel _customArrowHeadPnlHT;
        private int _lbl_ArrowWdCount;


        int _arrowWD_count;
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
        public CustomArrowHeadPresenter(ICustomArrowHeadView customArrowHead,
                                        ICustomArrowHeadUCPresenter customArrowHeadUCP
                                        // , IWindoorModel windoorModel
                                        )
        {
            _customArrowHeadUCP = customArrowHeadUCP;
            _customArrowHead = customArrowHead;
            // _windoorModel = windoorModel;
            _customArrowHeadPnlWD = _customArrowHead.GetPnlArrowWD();
            _customArrowHeadPnlHT = _customArrowHead.GetPnlArrowWD();


            subscribeToEventSetup();
        }

        private void subscribeToEventSetup()
        {
            _customArrowHead.BtnAddArrowHeadHeightCkickEventRaised += _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised;
            _customArrowHead.BtnAddArrowHeadWidthCkickEventRaised += _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised;
            _customArrowHead.BtnSaveCustomArrowCkickEventRaised += _customArrowHead_BtnSaveCustomArrowCkickEventRaised;
        }

        private void _customArrowHead_BtnSaveCustomArrowCkickEventRaised(object sender, EventArgs e)
        {

        }

        private void _customArrowHead_BtnAddArrowHeadWidthCkickEventRaised(object sender, EventArgs e)
        {
           // _lbl_ArrowWdCount = Convert.ToInt32(_windoorModel.lbl_ArrowWdCount);

            ICustomArrowHeadUCPresenter CustomArrowHeadPresenter = _customArrowHeadUCP.GetNewInstance(_unityC, this);
            _lst_arrowUCP.Add(CustomArrowHeadPresenter);
            UserControl CustomArrowHeadUC = (UserControl)CustomArrowHeadPresenter.GetCustomArrowUC();
            CustomArrowHeadUC.Dock = DockStyle.Top;
            _customArrowHeadPnlWD.Controls.Add(CustomArrowHeadUC);
            CustomArrowHeadUC.BringToFront();
            ArrowWD_Count++;
             _windoorModel.lbl_ArrowWdCount++;

        }

        private void _customArrowHead_BtnAddArrowHeadHeightCkickEventRaised(object sender, EventArgs e)
        {

        }

        public ICustomArrowHeadView GetICustomArrowHeadView(IUnityContainer unityC)
        {
            _unityC = unityC;
            return _customArrowHead;
        }
        public void Remove_ArrowHeadUCP(ICustomArrowHeadUCPresenter CustomArrowHeadUCP)
        {
            _lst_arrowUCP.Remove(CustomArrowHeadUCP);
        }

        public ICustomArrowHeadPresenter GetNewInstance(IUnityContainer unityC,
                                                        ICustomArrowHeadUCPresenter customArrowHeadUC,
                                                        IWindoorModel windoorModel)
        {
            unityC
                  .RegisterType<ICustomArrowHeadPresenter, CustomArrowHeadPresenter>()
                  .RegisterType<ICustomArrowHeadView, CustomArrowHeadView>();
            CustomArrowHeadPresenter CustomArrow = unityC.Resolve<CustomArrowHeadPresenter>();
            CustomArrow._unityC = unityC;
            CustomArrow._customArrowHeadUCP = customArrowHeadUC;
            CustomArrow._windoorModel = windoorModel;
            return CustomArrow;
        }

        public Dictionary<string, Binding> CreateBindingDictionary()
        {
            Dictionary<string, Binding> binding = new Dictionary<string, Binding>();

            binding.Add("Lbl_ArrowWdCount", new Binding("Text", _windoorModel, "Lbl_ArrowWdCount", true, DataSourceUpdateMode.OnPropertyChanged));
            binding.Add("Lbl_ArrowHtCount", new Binding("Text", _windoorModel, "Lbl_ArrowHtCount", true, DataSourceUpdateMode.OnPropertyChanged));

            return binding;
        }

    }
}
