using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.Model.User;
using ServiceLayer.Services.UserServices;
using ServiceLayer.CommonServices;
using QueryLayer.DataAccess.Repositories.Specific.User;
using System.Threading.Tasks;

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
        public async Task AdminLogin_Test()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "201";
            admin.Password = "201";

            //act
            UserModel expectedAdmin = new UserModel();
            expectedAdmin = await Task.Run(() => _userService.Login_Prsntr(admin));

            //assert
            Assert.AreEqual("Admin", expectedAdmin.AccountType);
        }

        [TestMethod]
        public async Task CostingLogin_Test()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "44";
            admin.Password = "44";

            //act
            UserModel expectedAdmin = new UserModel();
            expectedAdmin = await Task.Run(() => _userService.Login_Prsntr(admin));

            //assert
            Assert.AreEqual("Costing", expectedAdmin.AccountType);
        }

        [TestMethod]
        public async Task Login_LoginFailed_ShouldReturnException()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "qwe";
            admin.Password = "asd";

            try
            {
                //act
                UserModel expectedAdmin = new UserModel();
                expectedAdmin = await Task.Run(() => _userService.Login_Prsntr(admin));

            }
            catch (Exception ex)
            {
                // assert
                StringAssert.Contains(ex.Message, "Login Failed");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public async Task Login_UsernameRequired_ShouldReturnException()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "";
            admin.Password = "asd";

            try
            {
                //act
                UserModel expectedAdmin = new UserModel();
                expectedAdmin = await Task.Run(() => _userService.Login_Prsntr(admin));

            }
            catch (Exception ex)
            {
                // assert
                StringAssert.Contains(ex.Message, "Username is Required");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public async Task Login_PasswordRequired_ShouldReturnException()
        {
            //arrange
            UserLoginModel admin = new UserLoginModel();
            admin.Username = "qwe";
            admin.Password = "";

            try
            {
                //act
                UserModel expectedAdmin = new UserModel();
                expectedAdmin = await Task.Run(() => _userService.Login_Prsntr(admin));

            }
            catch (Exception ex)
            {
                // assert
                StringAssert.Contains(ex.Message, "Password is Required");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
