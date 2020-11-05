using ModelLayer.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.CommonServices;

namespace ServiceLayer.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private IUserRepository _userRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public UserServices(IUserRepository userRepository, IModelDataAnnotationCheck modelcheck)
        {
            _userRepository = userRepository;
            _modelDataAnnotationCheck = modelcheck;
        }

        public UserModel Login(IUserLoginModel userLoginModel)
        {
            return _userRepository.Login(userLoginModel);
        }

        public void ValidateModel(IUserLoginModel userLoginModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(userLoginModel);
        }
    }
}
