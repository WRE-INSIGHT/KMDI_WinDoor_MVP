using ModelLayer.Model.Quotation.Concrete;

namespace ServiceLayer.Services.ConcreteServices
{
    public interface IConcreteServices
    {
        IConcreteModel AddConcreteModel(int width, int height, float zoom, float imager_zoom, int id = 0, string name = "");
    }
}