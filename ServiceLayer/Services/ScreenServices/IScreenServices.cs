using ModelLayer.Model.Quotation.Screen;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.ScreenServices
{
    public interface IScreenServices
    {
        IScreenModel AddScreenModel(decimal screen_itemnumber,
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
                                    string plissemagnumType,
                                    decimal factor,
                                    decimal addonsspecialfactor,
                                    string screen_displayeddimension);

        void ValidateModel(IScreenModel screenModel);
    }
}