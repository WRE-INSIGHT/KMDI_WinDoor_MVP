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
    }
}
