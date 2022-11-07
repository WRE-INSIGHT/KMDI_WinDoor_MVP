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

        private IScreenModel CreateScreen(int screen_id, 
                                          int screen_width,
                                          int screen_height,
                                          decimal screen_factor,
                                          ScreenType screen_types,
                                          string screen_windoorID, // location
                                          decimal screen_unitPrice,
                                          int screen_quantity,
                                          decimal screen_totalAmount)
        {
            IScreenModel scrn = new ScreenModel(screen_id,
                                                screen_width,
                                                screen_height,
                                                screen_factor,
                                                screen_types,
                                                screen_windoorID, //location
                                                screen_unitPrice,
                                                screen_quantity,
                                                screen_totalAmount);

            ValidateModel(scrn);
            return scrn;
        }

        public IScreenModel AddScreenModel(int screen_id,
                                          int screen_width,
                                          int screen_height,
                                          decimal screen_factor,
                                          ScreenType screen_types,
                                          string screen_windoorID, // location
                                          decimal screen_unitPrice,
                                          int screen_quantity,
                                          decimal screen_totalAmount)
        {

            IScreenModel _screenModel = CreateScreen(screen_id,
                                                      screen_width,
                                                      screen_height,
                                                      screen_factor,
                                                      screen_types,
                                                      screen_windoorID, //location
                                                      screen_unitPrice,
                                                      screen_quantity,
                                                      screen_totalAmount);

            return _screenModel;
        }

        public void ValidateModel(IScreenModel screenModel)
        {
            _modelCheck.ValidateModelDataAnnotations(screenModel);
        }
    }
}
