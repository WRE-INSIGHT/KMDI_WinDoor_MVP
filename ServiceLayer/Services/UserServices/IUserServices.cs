using ModelLayer.Model.User;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserServices
    {
        UserModel Login(IUserLoginModel userModel);
        void ValidateModel(IUserLoginModel userLoginModel);
    }
}