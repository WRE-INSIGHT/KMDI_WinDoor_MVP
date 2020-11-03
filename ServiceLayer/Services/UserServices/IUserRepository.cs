using ModelLayer.Model.User;
namespace ServiceLayer.Services.UserServices
{
    public interface IUserRepository
    {
        UserModel Login(UserModel userModel);
    }
}