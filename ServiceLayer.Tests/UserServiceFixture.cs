using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.User;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.UserServices;

namespace ServiceLayer.Tests
{
    public class UserServiceFixture
    {
        private IUserServices _userServices;
        private IUserModel _userModel;
        private IUserLoginModel _userLoginModel;

        public UserServiceFixture()
        {
            _userModel = new UserModel();
            _userLoginModel = new UserLoginModel();
            _userServices = new UserServices(null, new ModelDataAnnotationCheck());
        }

        public UserModel UserModel
        {
            get { return (UserModel)_userModel; }
            set { _userModel = value; }
        }

        public UserLoginModel UserLoginModel
        {
            get { return (UserLoginModel)_userLoginModel; }
            set { _userLoginModel = value; }
        }
        public UserServices UserServices
        {
            get { return (UserServices)_userServices; }
            set { _userServices = value; }
        }
    }
}
