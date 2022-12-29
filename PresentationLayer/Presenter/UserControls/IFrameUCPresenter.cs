using System;
using System.Windows.Forms;
using ModelLayer.Model.Quotation.Frame;
using PresentationLayer.Views.UserControls;
using Unity;
using ModelLayer.Model.Quotation.Panel;
using ModelLayer.Model.User;

namespace PresentationLayer.Presenter.UserControls
{
    public interface IFrameUCPresenter
    {
        void DeleteFrame();
        IFrameUC GetFrameUC();
        IFrameUCPresenter GetNewInstance(IUnityContainer unityC,
                                         IUserModel userModel,
                                         IFrameModel frameModel,
                                         IMainPresenter mainPresenter,
                                         IBasePlatformPresenter basePlatformUCP,
                                         IFrameImagerUCPresenter frameImagerUCP,
                                         IBasePlatformImagerUCPresenter basePlatformImagerUCP,
                                         IFramePropertiesUCPresenter framePropertiesUCP);
        void ViewDeleteControl(UserControl control);
    }
}