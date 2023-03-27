using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Views.UserControls;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter.UserControls
{
    public class SortItemUCPresenter : ISortItemUCPresenter
    {
        ISortItemUC _sortItemUC;
        private IUnityContainer _unityC;
        private ISortItemPresenter _sortItemPresenter;
        private IWindoorModel _windoorModel;
        private bool _isDragging = false;
        private int _mX = 0;
        private int _mY = 0;
        private int _DDradius = 40;
        public SortItemUCPresenter(ISortItemUC sortItemUC)
        {
            _sortItemUC = sortItemUC;
            SubscribeToEventSetUp();
        }

        private void SubscribeToEventSetUp()
        {
            _sortItemUC.SortItemUCLoadEventRaised += _sortItemUC_SortItemUCLoadEventRaised;
            _sortItemUC.cbItemMouseDownEventRaised += _sortItemUC_cbItemMouseDownEventRaised;
            _sortItemUC.cbItemMouseMoveEventRaised += _sortItemUC_cbItemMouseMoveEventRaised;
            _sortItemUC.cbItemMouseUpEventRaised += _sortItemUC_cbItemMouseUpEventRaised;
            _sortItemUC.DuplicateToolStripButtonClickEventRaised += _sortItemUC_DuplicateToolStripButtonClickEventRaised;
            _sortItemUC.cbitem_CheckedChangedEventRaised += _sortItemUC_cbitem_CheckedChangedEventRaised;
        }

        private void _sortItemUC_cbitem_CheckedChangedEventRaised(object sender, EventArgs e)
        {
            var chk = ((CheckBox)sender);
            if (chk.Checked)
            {
                _sortItemPresenter.lstItem.Add(chk.Text);
            }
            else
            {
                _sortItemPresenter.lstItem.Remove(chk.Text);
            }
            if(_sortItemPresenter.lstItem.Count == 0)
            {
                _sortItemPresenter.DeleteEnable = false;
            }
            else
            {
                _sortItemPresenter.DeleteEnable = true;
            }
        }

        private void _sortItemUC_DuplicateToolStripButtonClickEventRaised(object sender, EventArgs e)
        {
            
        }

        private void _sortItemUC_cbItemMouseUpEventRaised(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void _sortItemUC_cbItemMouseMoveEventRaised(object sender, MouseEventArgs e)
        {
            if (!_isDragging)
            {
                // This is a check to see if the mouse is moving while pressed.
                // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
                if (e.Button == MouseButtons.Left && _DDradius > 0)
                {
                    int num1 = _mX - e.X;
                    int num2 = _mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > _DDradius)
                    {

                        _sortItemUC.GetSortItem().DoDragDrop(_sortItemUC.GetSortItem(), DragDropEffects.All);
                        _isDragging = true;
                        return;
                    }
                }
            }
        }

        private void _sortItemUC_cbItemMouseDownEventRaised(object sender, MouseEventArgs e)
        {
            _mX = e.X;
            _mY = e.Y;
            this._isDragging = false;
        }
        private void _sortItemUC_SortItemUCLoadEventRaised(object sender, EventArgs e)
        {
            
        }

        public ISortItemUCPresenter GetNewInstance(IUnityContainer unityC, IWindoorModel windoorModel, ISortItemPresenter sortItemPresenter)
        {
            unityC
               .RegisterType<ISortItemUCPresenter, SortItemUCPresenter>()
               .RegisterType<ISortItemUC, SortItemUC>();
            SortItemUCPresenter sortItem = unityC.Resolve<SortItemUCPresenter>();
            sortItem._unityC = unityC;
            sortItem._windoorModel = windoorModel;
            sortItem._sortItemPresenter = sortItemPresenter;
            return sortItem;
        }

        public ISortItemUC GetSortItemUC()
        {
            return _sortItemUC;
        }
    }
}
