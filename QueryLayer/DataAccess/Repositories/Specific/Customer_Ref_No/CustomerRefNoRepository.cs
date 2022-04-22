using ServiceLayer.Services.CustomerRefNoServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ModelLayer.Model.CustomerRefNo;

namespace QueryLayer.DataAccess.Repositories.Specific.Customer_Ref_No
{
    public class CustomerRefNoRepository : ICustomerRefNoRepository
    {
        private string _sqlConString;

        public CustomerRefNoRepository(string sqlConString)
        {
            _sqlConString = sqlConString;
        }

        public async Task<DataTable> GetCustRefNo(string searchStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter();

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Customer_Ref_No_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Customer_Ref_No_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Get";
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<int> Insert_CustRefNo(int user_id, ICustomerRefNoModel custRefNo)
        {
            int affected_rows = 0;

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Customer_Ref_No_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Customer_Ref_No_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Create";
                        sqlcmd.Parameters.Add("@CustRef_No", SqlDbType.VarChar).Value = custRefNo.CustomerReferenceNumber;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = user_id;

                        affected_rows = await sqlcmd.ExecuteNonQueryAsync();
                        sqltrans.Commit();
                    }
                }
            }

            return affected_rows;
        }
    }
}
