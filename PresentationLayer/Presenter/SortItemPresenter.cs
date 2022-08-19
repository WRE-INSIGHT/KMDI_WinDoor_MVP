using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Quotation;
using ModelLayer.Model.Quotation.WinDoor;
using PresentationLayer.Presenter.UserControls;
using PresentationLayer.Views;
using Unity;
using System.Windows.Forms;

namespace PresentationLayer.Presenter
{
    public class SortItemPresenter : ISortItemPresenter
    {
        ISortItemView _sortItemView;
        private IUnityContainer _unityC;
        private IQuotationModel _quotationModel;
        private IWindoorModel _windoorModel;
        private ISortItemUCPresenter _sortItemUCPresenter;
        private IMainPresenter _mainPresenter;
        #region Variables
        private List<ISortItemUCPresenter> _lstSortItemUC = new List<ISortItemUCPresenter>();
        #endregion
        public SortItemPresenter(ISortItemView sortItemView)
        {
            _sortItemView = sortItemView;
            SubscribeToEventSetup();
        }

        private void SubscribeToEventSetup()
        {
            _sortItemView.SortItemViewLoadEventRaised += _sortItemView_SortItemViewLoadEventRaised;
        }

        private void _sortItemView_SortItemViewLoadEventRaised(object sender, EventArgs e)
        {
            for (int i = 0; i < _quotationModel.Lst_Windoor.Count; i++)
            {
                _sortItemUCPresenter = _sortItemUCPresenter.GetNewInstance(_unityC, _windoorModel);
                UserControl sortItem = (UserControl)_sortItemUCPresenter.GetSortItemUC();

                //itemDescription();
                //ItemCostingPoints();

                //List<string> lst_glassThicknessDistinct = lst_glassThickness.Distinct().ToList();
                //List<string> lst_glassFilmDistinct = lst_glassFilm.Distinct().ToList();

                //foreach (string GT in lst_glassThicknessDistinct)
                //{
                //    glassThick += GT;
                //}

                //foreach (string GF in lst_glassFilmDistinct)
                //{
                //    glassFilm += "with " + GF + "\n";
                //}

                //if (GeorgianBarHorizontalQty > 0)
                //{
                //    GeorgianBarHorizontalDesc = "GeorgianBar Horizontal: " + GeorgianBarHorizontalQty + "\n";
                //}

                //if (GeorgianBarVerticalQty > 0)
                //{
                //    GeorgianBarVerticalDesc = "GeorgianBar Vertical: " + GeorgianBarVerticalQty + "\n";
                //}

                IWindoorModel wdm = _quotationModel.Lst_Windoor[i];

                //wdm.WD_description += glassThick + glassFilm + GeorgianBarHorizontalDesc + GeorgianBarVerticalDesc;


                _sortItemUCPresenter.GetSortItemUC().ItemName = wdm.WD_name;
                //_sortItemUCPresenter.GetSortItemUC().itemDesc = wdm.WD_width.ToString() + " x " + wdm.WD_height.ToString() + "\n"
                //                                                          + wdm.WD_description
                //                                                          + costingPointsDesc
                //                                                          + laborCostDesc
                //                                                          + InstallationCostDesc
                //                                                          + GlassDesc
                //                                                          + MaterialCostDesc
                //                                                          + FramePriceDesc
                //                                                          + FrameReinPriceDesc
                //                                                          + SashPriceDesc
                //                                                          + SashReinPriceDesc
                //                                                          + DivPriceDesc
                //                                                          + FittingAndSuppliesDesc
                //                                                          + AncillaryProfileCostDesc
                //                                                          + AccesorriesCostDesc
                //                                                          + sealantDesc
                //                                                          + PUFoamingDesc;

                _sortItemUCPresenter.GetSortItemUC().GetPboxItemImage().Image = wdm.WD_image;
                //_sortItemUCPresenter.GetSortItemUC().GetPboxTopView().Image = wdm.WD_SlidingTopViewImage;
                //_sortItemUCPresenter.GetSortItemUC().itemPrice.Value = Math.Round(lstTotalPrice[i], 2);  //TotaPrice;
                //_sortItemUCPresenter.GetSortItemUC().GetLblPrice().Text = Math.Round(lstTotalPrice[i], 2).ToString();  //TotaPrice.ToString();
                this._lstSortItemUC.Add(_sortItemUCPresenter);
                //TotalItemArea = wdm.WD_width * wdm.WD_height;
                //this._lstItemArea.Add(TotalItemArea);


            }
        }

        public ISortItemPresenter GetNewInstance(IUnityContainer unityC, 
                                                IQuotationModel quotationModel, 
                                                ISortItemUCPresenter sortItemUCPresenter, 
                                                IWindoorModel windoorModel, 
                                                IMainPresenter mainPresenter)
        {
            unityC
                  .RegisterType<ISortItemPresenter, SortItemPresenter>()
                  .RegisterType<ISortItemView, SortItemView>();
            SortItemPresenter sortItemList = unityC.Resolve<SortItemPresenter>();
            sortItemList._unityC = unityC;
            sortItemList._quotationModel = quotationModel;
            sortItemList._sortItemUCPresenter = sortItemUCPresenter;
            sortItemList._windoorModel = windoorModel;
            sortItemList._mainPresenter = mainPresenter;
            return sortItemList;
        }

        public ISortItemView GetSortItemView()
        {
            return _sortItemView;
        }
    }
}
