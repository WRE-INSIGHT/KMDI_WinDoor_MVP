using ModelLayer.Model.ProjectQuote;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer.DataAccess.Repositories.Specific.Project_Quote
{
    public class ProjectQuoteRepository : IProjectQuoteRepository
    {
        private string _sqlConString;

        public ProjectQuoteRepository(string sqlConString)
        {
            _sqlConString = sqlConString;
        }

        public async Task<DataTable> Get_AssignedProjects(string searchStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter();

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Project_Quote_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Project_Quote_Stp";
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

        public async Task<int> Delete_ProjQuote(int id, int user_id)
        {
            int affected_row = 0;

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Project_Quote_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Project_Quote_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Delete";
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = user_id;

                        affected_row = await sqlcmd.ExecuteNonQueryAsync();
                        sqltrans.Commit();
                    }
                }
            }

            return affected_row;
        }

        public async Task<int> Insert_ProjQuote(IProjectQuoteModel pqModel, int user_id)
        {
            int affected_row = 0;

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Project_Quote_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Project_Quote_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Create";
                        sqlcmd.Parameters.Add("@Project_Id", SqlDbType.Int).Value = pqModel.PQ_ProjId;
                        sqlcmd.Parameters.Add("@Quote_Id", SqlDbType.Int).Value = pqModel.PQ_QuoteId;
                        sqlcmd.Parameters.Add("@Cust_ref_id", SqlDbType.Int).Value = pqModel.PQ_CustRefId;
                        sqlcmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = pqModel.PQ_EmployeeId;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = user_id;

                        affected_row = await sqlcmd.ExecuteNonQueryAsync();
                        sqltrans.Commit();
                    }
                }

                return affected_row;
            }
        }
    }
}
