using ModelLayer.Model.ProjectQuote;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Project;

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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetProjectToAssign_Admin";
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<int> Delete_ProjQuote(int proj_id, int user_id)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "DeleteProject";
                        sqlcmd.Parameters.Add("@Project_Id", SqlDbType.Int).Value = proj_id;
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
                        sqlcmd.Parameters.Add("@Date_Assigned", SqlDbType.DateTime).Value = DateTime.Now;//pqModel.PQ_DateAssigned;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = user_id;

                        affected_row = await sqlcmd.ExecuteNonQueryAsync();
                        sqltrans.Commit();
                    }
                }

                return affected_row;
            }
        }

        public async Task<int> Update_ProjQuote(IProjectQuoteModel pqModel, int user_id)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "Edit";
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = pqModel.PQ_Id;
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

        public async Task<DataTable> Get_ProjectByCostEngrID(string searchStr, int user_id, string user_role)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetProjectBy_CostEngrID_OrAdminID";
                        sqlcmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = user_id;
                        sqlcmd.Parameters.Add("@User_Role", SqlDbType.VarChar).Value = user_role;
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<DataTable> Get_CustRefNoByProjectID(int projId, int user_id, string user_role)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetCustRefNo_ByProjID";
                        sqlcmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = user_id;
                        sqlcmd.Parameters.Add("@User_Role", SqlDbType.VarChar).Value = user_role;
                        sqlcmd.Parameters.Add("@Project_Id", SqlDbType.Int).Value = projId;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }
        public async Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int projId, int custRefId, int user_id, string user_role)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetQuoteNo_ByCustRef";
                        sqlcmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = user_id;
                        sqlcmd.Parameters.Add("@User_Role", SqlDbType.VarChar).Value = user_role;
                        sqlcmd.Parameters.Add("@Project_Id", SqlDbType.Int).Value = projId;
                        sqlcmd.Parameters.Add("@Cust_ref_id", SqlDbType.Int).Value = custRefId;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<DataTable> Get_AEICByCostEngrID(string searchStr, int user_id, string user_acctType)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetAEICBy_CostEngrID_OrAdminID";
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public string Check_ProjectAEAssignment(string project_Id, string employee_Id)
        {
            try
            {
                string Combination = string.Empty;
                using (SqlConnection Sqlcon = new SqlConnection(_sqlConString))
                {
                    Sqlcon.OpenAsync();
                    using (SqlCommand sqlcmd = Sqlcon.CreateCommand())
                    {
                        using (SqlTransaction sqltrans = Sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "CheckProjectAEAssignment"))
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.Transaction = sqltrans;
                            sqlcmd.CommandText = "Project_Quote_Stp";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Command", "CheckProjectAEAssignment");
                            sqlcmd.Parameters.AddWithValue("@Emp_id", employee_Id);
                            sqlcmd.Parameters.AddWithValue("@Project_Id", project_Id);
                            using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                  
                                        Combination = rdr.GetString(3).ToString() + " already assign in " + rdr.GetString(1).ToString() + " Project!";
                                    }
                                }
                            }



                        }
                    }
                }
                return Combination;
              
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DataTable> Get_AEICByProjectID(string projectId)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetAEICBy_ProjectID";
                        sqlcmd.Parameters.Add("@Project_Id", SqlDbType.Int).Value = projectId;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task SaveAssignAEIC(string employee_Id, string project_Id)
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
                            sqlcmd.CommandText = "Project_Quote_Stp";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Command", "SaveAssignAEIC");
                            sqlcmd.Parameters.AddWithValue("@Project_Id", project_Id);
                            sqlcmd.Parameters.AddWithValue("@Emp_id", employee_Id);
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

        public async Task<DataTable> GetProvince()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter();

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Address_Ref_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Address_Ref_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Merge_To_Do", SqlDbType.VarChar).Value = "Select_Province";

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<DataTable> GetCityAreaBy_Province(string province)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqladapter = new SqlDataAdapter();

            using (SqlConnection sqlcon = new SqlConnection(_sqlConString))
            {
                await sqlcon.OpenAsync();
                using (SqlCommand sqlcmd = sqlcon.CreateCommand())
                {
                    using (SqlTransaction sqltrans = await Task.Run(() => sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "Address_Ref_Stp")))
                    {

                        sqlcmd.Connection = sqlcon;
                        sqlcmd.Transaction = sqltrans;
                        sqlcmd.CommandText = "Address_Ref_Stp";
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.Add("@Merge_To_Do", SqlDbType.VarChar).Value = "Select_City_Area";
                        sqlcmd.Parameters.Add("@Province", SqlDbType.VarChar).Value = province;
                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task SaveProject(IProjectModel projectModel)
        {

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
                        sqlcmd.Parameters.AddWithValue("@Command", SqlDbType.VarChar).Value = "SaveProject";
                        sqlcmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = projectModel.Firstname;
                        sqlcmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = projectModel.Lastname;
                        sqlcmd.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = projectModel.CompanyName;
                        sqlcmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = projectModel.ContactNo;
                        sqlcmd.Parameters.AddWithValue("@FileLableAs", SqlDbType.VarChar).Value = projectModel.FileLableAs;
                        sqlcmd.Parameters.AddWithValue("@UnitNo", SqlDbType.VarChar).Value = projectModel.UnitNo;
                        sqlcmd.Parameters.AddWithValue("@Establishment", SqlDbType.VarChar).Value = projectModel.Establishment;
                        sqlcmd.Parameters.AddWithValue("@HouseNo", SqlDbType.VarChar).Value = projectModel.HouseNo;
                        sqlcmd.Parameters.AddWithValue("@Street", SqlDbType.VarChar).Value = projectModel.Street;
                        sqlcmd.Parameters.AddWithValue("@Village", SqlDbType.VarChar).Value = projectModel.Village;
                        sqlcmd.Parameters.AddWithValue("@Barangay", SqlDbType.VarChar).Value = projectModel.Barangay;
                        sqlcmd.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = projectModel.City;
                        sqlcmd.Parameters.AddWithValue("@Province", SqlDbType.VarChar).Value = projectModel.Province;
                        sqlcmd.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = projectModel.Area;
                        sqlcmd.Parameters.AddWithValue("@CompleteAddress", SqlDbType.VarChar).Value = projectModel.CompleteAddress;
                        sqltrans.Commit();
                        sqlcmd.ExecuteReader();
                    }
                }
            }
        }
    }
}
