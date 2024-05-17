using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer.DataAccess.Repositories.Specific.Address
{
    public class AddressRepository : IAddressRepository
    {
        private string _sqlConString;

        public AddressRepository(string sqlConString)
        {
            _sqlConString = sqlConString;
        }
        public async Task<DataTable> Get_Factor(string searchStr,DateTime cus_ref_date)
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
                        sqlcmd.CommandText = "Address_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetFactor";
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;
                        sqlcmd.Parameters.Add("@Implementation", SqlDbType.VarChar).Value = cus_ref_date;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task Update_Factor(string id, decimal factor)
        {
            try
            {
                using (SqlConnection Sqlcon = new SqlConnection(_sqlConString))
                {
                    await Sqlcon.OpenAsync();
                    using (SqlCommand sqlcmd = Sqlcon.CreateCommand())
                    {
                        using (SqlTransaction sqltrans = await Task.Run(() => Sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Project_Quote_Stp")))
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.Transaction = sqltrans;
                            sqlcmd.CommandText = "Address_Stp";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Command", "UpdateFactor");
                            sqlcmd.Parameters.AddWithValue("@factorId", id);
                            sqlcmd.Parameters.AddWithValue("@factor", factor);
                            sqltrans.Commit();
                            sqlcmd.ExecuteReader();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
