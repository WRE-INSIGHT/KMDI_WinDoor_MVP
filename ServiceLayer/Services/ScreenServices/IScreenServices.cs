using ModelLayer.Model.Quotation.Screen;
using static EnumerationTypeLayer.EnumerationTypes;

namespace ServiceLayer.Services.ScreenServices
{
    public interface IScreenServices
    {
        IScreenModel AddScreenModel(int screen_id,
                                    int screen_width,
                                    int screen_height,
                                    decimal screen_factor,
                                    ScreenType screen_types,
                                    string screen_windoorID,
                                    decimal screen_unitPrice,
                                    int screen_quantity,
                                    decimal screen_totalAmount);

        void ValidateModel(IScreenModel screenModel);
    }
}