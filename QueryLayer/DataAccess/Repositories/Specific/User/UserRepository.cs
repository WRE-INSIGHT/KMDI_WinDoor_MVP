using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Services.UserServices;
using ModelLayer.Model.User;
using CommonComponents;

namespace QueryLayer.DataAccess.Repositories.Specific.User
{
    public class UserRepository : BaseSpecificRepository, IUserRepository
    {
        public UserRepository(string sqlconstr)
        {
            _sqlConString = sqlconstr;
        }

        public async Task<UserModel> Login(IUserLoginModel userLoginModel)
        {
            UserModel user = new UserModel();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
                {
                    await sqlcon.OpenAsync();
                    using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                    {
                        using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "LogIn_Stp")))
                        {
                            sqlcmd.Connection = sqlcon;
                            sqlcmd.Transaction = sqltrans;
                            sqlcmd.CommandText = "LogIn_Stp";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@UserName", userLoginModel.Username);
                            sqlcmd.Parameters.AddWithValue("@Password", userLoginModel.Password);
                            //sqlcmd.Parameters.AddWithValue("@Password", Encrypt(userLoginModel.Password));
                            using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                            {
                                if (!rdr.HasRows)
                                {
                                    user = null;
                                }
                                else
                                {
                                    while (rdr.Read())
                                    {
                                        if (rdr.GetString(3) == "Admin" || rdr.GetString(3) == "Costing" || rdr.GetString(3) == "Programmer")
                                        {
                                            user.UserID = rdr.GetInt32(0);
                                            user.Fullname = rdr.GetString(1);
                                            user.Nickname = rdr.GetString(2);
                                            user.AccountType = rdr.GetString(3);
                                            user.Username = rdr.GetString(4);
                                            user.Password = rdr.GetString(5);
                                            user.ProfilePath = rdr.GetString(6);
                                        }
                                        else
                                        {
                                            user = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Logger log = new Logger(sqlex.Message, sqlex.StackTrace);
                throw new Exception("Error Number: " + sqlex.Number + "\nError Message: " + sqlex.Message);
            }
            return user;
        }
    }
}
