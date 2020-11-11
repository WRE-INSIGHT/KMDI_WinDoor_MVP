﻿using ModelLayer.Model.User;
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

        public void ValidateModel(IUserLoginModel userLoginModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(userLoginModel);
        }

        public async Task<UserModel> Login_Prsntr(IUserLoginModel userLoginModel)
        {
            ValidateModel(userLoginModel);
            UserModel userModel = await _userRepository.Login(userLoginModel);

            if (userModel != null)
            {
                return userModel;
            }
            else
            {
                throw new Exception("Login Failed");
            }
        }
    }
}
