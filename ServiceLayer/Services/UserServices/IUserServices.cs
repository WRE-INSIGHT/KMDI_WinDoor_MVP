using ModelLayer.Model.User;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserServices
    {
        void ValidateModel(IUserLoginModel userLoginModel);
        Task<UserModel> Login_Prsntr(IUserLoginModel userLoginModel);
        UserModel Offline_Login();
    }
}