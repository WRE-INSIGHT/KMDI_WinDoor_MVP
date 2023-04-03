using ModelLayer.Model.Quotation.Screen;
using ServiceLayer.CommonServices;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.ScreenServices
{
    public class ScreenServices : IScreenServices
    {

        private IModelDataAnnotationCheck _modelCheck;

        public ScreenServices(IModelDataAnnotationCheck modelCheck)
        {
            _modelCheck = modelCheck;
        }

             private IScreenModel CreateScreen(decimal screen_itemnumber,
                                               int screen_width,
                                               int screen_height,
                                               ScreenType screen_types,
                                               string screen_windoorID,
                                               decimal screen_unitPrice,
                                               int screen_quantity,
                                               int screen_set,
                                               int discount,
                                               decimal screen_netPrice,
                                               decimal screen_totalAmount,
                                               string screen_description,
                                               decimal factor,
                                               decimal addonsspecialfactor
                                               )
        {
             IScreenModel scrn = new ScreenModel(screen_itemnumber,
                                                screen_width,
                                                screen_height,
                                                screen_types,
                                                screen_windoorID, //location
                                                screen_unitPrice,
                                                screen_quantity,
                                                screen_set,
                                                discount,
                                                screen_netPrice,
                                                screen_totalAmount,
                                                screen_description,
                                                factor,
                                                addonsspecialfactor);

            ValidateModel(scrn);
            return scrn;
        }

              public IScreenModel AddScreenModel(decimal screen_itemnumber,
                                                int screen_width,
                                                int screen_height,
                                                ScreenType screen_types,
                                                string screen_windoorID,
                                                decimal screen_unitPrice,
                                                int screen_quantity,
                                                int screen_set,
                                                int discount,
                                                decimal screen_netPrice,
                                                decimal screen_totalAmount,
                                                string screen_description,
                                                 decimal factor,
                                                 decimal addonsspecialfactor
                                                 )
        {

               IScreenModel _screenModel = CreateScreen(screen_itemnumber,
                                                        screen_width,
                                                        screen_height,
                                                        screen_types,
                                                        screen_windoorID, //location
                                                        screen_unitPrice,
                                                        screen_quantity,
                                                        screen_set,
                                                        discount,
                                                        screen_netPrice,
                                                        screen_totalAmount,
                                                        screen_description,
                                                        factor,
                                                        addonsspecialfactor);

            return _screenModel;
        }

        public void ValidateModel(IScreenModel screenModel)
        {
            _modelCheck.ValidateModelDataAnnotations(screenModel);
        }
    }
}
