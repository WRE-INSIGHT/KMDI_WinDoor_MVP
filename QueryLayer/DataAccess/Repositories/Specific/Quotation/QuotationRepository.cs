using ModelLayer.Model.Quotation;
using ServiceLayer.Services.QuotationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer.DataAccess.Repositories.Specific.Quotation
{
    public class QuotationRepository : IQuotationRepository
    {
        private string _sqlConString;

        public QuotationRepository(string sqlConString)
        {
            _sqlConString = sqlConString;
        }

        public async Task<decimal> GetFactorByProvince(string province)
        {
            decimal factor = 0;

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Quote_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Quote_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetFactorByProvince";
                        sqlcmd.Parameters.Add("@Province", SqlDbType.VarChar).Value = province;

                        factor = (decimal)await sqlcmd.ExecuteScalarAsync();
                        sqltrans.Commit();
                    }
                }

                return factor;
            }
        }

        public async Task<int> Insert_Quotation(IQuotationModel quotationModel, int user_id)
        {
            int inserted_id = 0;

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Quote_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Quote_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Insert_returnVal_insertedId";
                        sqlcmd.Parameters.Add("@Quote_Ref_No", SqlDbType.VarChar).Value = quotationModel.Quotation_ref_no;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = user_id;


                        inserted_id = (Int32) await sqlcmd.ExecuteScalarAsync();
                        sqltrans.Commit();
                    }
                }

                return inserted_id;
            }
        }
    }
}