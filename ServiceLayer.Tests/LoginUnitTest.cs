using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.User;
using ServiceLayer.Services.UserServices;
using ServiceLayer.CommonServices;
using QueryLayer.DataAccess.Repositories.Specific.User;

namespace ServiceLayer.Tests
{
    [TestClass]
    public class LoginUnitTest
    {
        private string sqlconStr;
        private UserServices _userService;
        [TestInitialize]
        public void SetUp()
        {
            sqlconStr = "Data Source='121.58.229.248,49107';Network Library=DBMSSOCN;Initial Catalog='KMDIDATA';User ID='kmdiadmin';Password='kmdiadmin';";
            _userService = new UserServices(new UserRepository(sqlconStr), new ModelDataAnnotationCheck());
        }

        [TestMethod]
        public void AdminLogin_Test()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "e";
            admin.Password = "z";

            //act
            UserModel expectedAdmin = new UserModel();
            expectedAdmin = _userService.Login(admin);

            //assert
            Assert.AreEqual("Admin", expectedAdmin.AccountType);
        }

        [TestMethod]
        public void CostingLogin_Test()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "44";
            admin.Password = "44";

            //act
            UserModel expectedAdmin = new UserModel();
            expectedAdmin = _userService.Login(admin);

            //assert
            Assert.AreEqual("Costing", expectedAdmin.AccountType);
        }
    }
}
