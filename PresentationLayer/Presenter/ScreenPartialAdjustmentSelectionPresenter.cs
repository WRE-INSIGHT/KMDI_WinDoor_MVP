using ModelLayer.Model.Quotation.Screen;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PresentationLayer.Presenter
{
    public class ScreenPartialAdjustmentSelectionPresenter : IScreenPartialAdjustmentSelectionPresenter
    {
        IScreenPartialAdjusmentSelectionView _screenPartialAdjusmentSelectionView;
        IUnityContainer _unityC;

        private IMainPresenter _mainPresenter;
        private IScreenPresenter _screenPresenter;
        private IScreenModel _screenModel;
        private IScreenPartialAdjustmentProperties _screenPartialAdjustmentProperties;

        CheckedListBox _checkedListBox;

        public IScreenPartialAdjusmentSelectionView GetScreenPartialAdjustmentView()
        {
            return _screenPartialAdjusmentSelectionView;
        }

        public ScreenPartialAdjustmentSelectionPresenter(IScreenPartialAdjusmentSelectionView screenPartialAdjusmentSelectionView)
        {

            _screenPartialAdjusmentSelectionView = screenPartialAdjusmentSelectionView;

            _screenPartialAdjusmentSelectionView.ScreenPartialAdjusmentSelectionView_LoadEventRaised += _screenPartialAdjusmentSelectionView_ScreenPartialAdjusmentSelectionView_LoadEventRaised;
            _screenPartialAdjusmentSelectionView.btn_addToList_ClickEventRaised += _screenPartialAdjusmentSelectionView_btn_addToList_ClickEventRaised;

            _checkedListBox = _screenPartialAdjusmentSelectionView.GetCheckListBox();

        }

        private void _screenPartialAdjusmentSelectionView_ScreenPartialAdjusmentSelectionView_LoadEventRaised(object sender, EventArgs e)
        {
            int indx = 0;
            if (!_mainPresenter.Screen_List.Equals(0))
            {
               foreach (var item in _mainPresenter.Screen_List)
               {                
                  _checkedListBox.Items.Add("Item: " + item.Screen_ItemNumber);
                  if (_mainPresenter.Dic_PaScreenID.Keys.Contains(item.Screen_id))
                  {
                      _checkedListBox.SetItemChecked(indx, true);
                  }
                   indx++;
               }
            }
        }

        private void _screenPartialAdjusmentSelectionView_btn_addToList_ClickEventRaised(object sender, EventArgs e)
        {
            string StrItemValue = string.Empty;
            decimal DecItemValue = 0;

            foreach (string item in _checkedListBox.CheckedItems)
            {
                StrItemValue = item.Substring(item.IndexOf(": ") + 2);
                DecItemValue = Convert.ToDecimal(StrItemValue);

                foreach(IScreenModel ScrLst in _mainPresenter.Screen_List)
                {
                    if(ScrLst.Screen_ItemNumber == DecItemValue)
                    {
                        if (!_mainPresenter.Dic_PaScreenID.Keys.Contains(ScrLst.Screen_id))
                        {
                            _mainPresenter.Dic_PaScreenID.Add(ScrLst.Screen_id, ScrLst.Screen_ItemNumber);

                            IScreenPartialAdjustmentProperties Spap = new ScreenPartialAdjustmentProperties();

                            Spap.Screen_isAdjusted = true;
                            Spap.Screen_IsChild = false;
                            Spap.Screen_Parent_ID = 0;
                            Spap.Screen_Original_Quantity = ScrLst.Screen_Quantity;

                            Spap.Screen_id = ScrLst.Screen_id;
                            Spap.Screen_ItemNumber = ScrLst.Screen_ItemNumber;
                            Spap.Screen_WindoorID = ScrLst.Screen_WindoorID;
                            Spap.Screen_Description = ScrLst.Screen_Description;
                            Spap.Screen_Set = ScrLst.Screen_Set;
                            Spap.Screen_DisplayedDimension = ScrLst.Screen_DisplayedDimension;
                            Spap.Screen_UnitPrice = ScrLst.Screen_UnitPrice;
                            Spap.Screen_Quantity = ScrLst.Screen_Quantity;
                            Spap.Screen_NetPrice = ScrLst.Screen_NetPrice;
                            Spap.Screen_Discount = ScrLst.Screen_Discount;
                            Spap.Screen_TotalAmount = ScrLst.Screen_TotalAmount;

                            _mainPresenter.Lst_ScreenPartialAdjustment.Add(Spap);
                                                      
                            _screenPresenter.Insert_Adjustment_to_DGV(Spap);                        
                        }
                    }
                }
            }
            _screenPresenter.PopulateDataGridView();
            _screenPartialAdjusmentSelectionView.ClosePartialAdjustmentSelecionView();
         
        }

        public IScreenPartialAdjustmentSelectionPresenter CreateNewInstance(IUnityContainer unityC,
                                                                            IMainPresenter mainPreseter,
                                                                            IScreenPresenter screenPresenter,
                                                                            IScreenModel screenModel,
                                                                            IScreenPartialAdjustmentProperties screenPartialAdjustmentProperties)
        {
            unityC
                    .RegisterType<IScreenPartialAdjusmentSelectionView, ScreenPartialAdjusmentSelectionView>()
                    .RegisterType<IScreenPartialAdjustmentSelectionPresenter, ScreenPartialAdjustmentSelectionPresenter>();
               ScreenPartialAdjustmentSelectionPresenter SPASP = unityC.Resolve<ScreenPartialAdjustmentSelectionPresenter>();

            SPASP._unityC = unityC;
            SPASP._mainPresenter = mainPreseter;
            SPASP._screenPresenter = screenPresenter;
            SPASP._screenModel = screenModel;
            SPASP._screenPartialAdjustmentProperties = screenPartialAdjustmentProperties;

            return SPASP;
        }
        
    }
}
