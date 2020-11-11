using ModelLayer.Model.User;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public interface IUserRepository
    {
        Task<UserModel> Login(IUserLoginModel userModel);
    }
}