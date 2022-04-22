using ServiceLayer.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer.DataAccess.Repositories.Specific.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _sqlConString;

        public EmployeeRepository(string sqlConString)
        {
            _sqlConString = sqlConString;
        }

        public async Task<DataTable> GetCostEngrEmp(string searchStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter();

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Employee_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Employee_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetCostEngrEmp";
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }
    }
}
