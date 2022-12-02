using ModelLayer.Model.Quotation.Frame;
using ModelLayer.Model.Quotation.MultiPanel;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenter
{
  public class SetMultipleGlassThicknessPresenter : ISetMultipleGlassThicknessPresenter
    {
        ISetMultipleGlassThicknessView _setMultipleGlassThicknessView;
        IWindoorModel _wdm;

        public ISetMultipleGlassThicknessView Get_MltpleGlssThcknView()
        {
            return _setMultipleGlassThicknessView;
        }

        public SetMultipleGlassThicknessPresenter(ISetMultipleGlassThicknessView setMultipleGlassThicknessView)
        {
            _setMultipleGlassThicknessView = setMultipleGlassThicknessView;
            
            SubscribeToEventsSetup();
        }

        private void SubscribeToEventsSetup()
        {
            _setMultipleGlassThicknessView.cmbSelectGlassTypeEventRaised += new EventHandler(OncmbSelectGlassTypeEventRaised);
            _setMultipleGlassThicknessView.setMultipleGlassThicknessLoadEventRaised += new EventHandler(OnsetMultipleGlassThicknessLoadEventRaised);
            _setMultipleGlassThicknessView.mouseClickEventRaised += new EventHandler(OnmouseClickEventRaised);
        }

        private void OnmouseClickEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnsetMultipleGlassThicknessLoadEventRaised(object sender, EventArgs e)
        {
            showGlassSummary();
        }

        private void OncmbSelectGlassTypeEventRaised(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void showGlassSummary()
        {
            foreach(IFrameModel fr in _wdm.lst_frame)
            {
                if(fr.Lst_MultiPanel.Count() >= 1 && fr.Lst_Panel.Count() == 0)
                {
                    foreach(IMultiPanelModel mpnl in fr.Lst_MultiPanel)
                    {
                        foreach(IMultiPanelModel pnl in mpnl.MPanelLst_Panel)
                        {

                        }
                    }
                }
            }
        }
    }
}
