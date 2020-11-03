using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.UserServices
{
    public class UserServices : IUserRepository
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Login(UserModel userModel)
        {
            throw new NotImplementedException();

        }
    }
}
