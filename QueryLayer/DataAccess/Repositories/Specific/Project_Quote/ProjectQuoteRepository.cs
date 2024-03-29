﻿using ModelLayer.Model.ProjectQuote;
using ServiceLayer.Services.ProjectQuoteServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Project;
using CommonComponents;
using ModelLayer.Model.AddProject;
using ModelLayer.Model.User;

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

        public async Task<int> Delete_ProjQuote(int proj_quote_id, int user_id)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "DeleteProjectQuote";
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = proj_quote_id;
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
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = pqModel.PQ_Id;
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
                        sqlcmd.Parameters.Add("@Date_Assigned", SqlDbType.DateTime).Value = DateTime.Now;//pqModel.PQ_DateAssigned;
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
        public async Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int pqId, int projId, int custRefId, int user_id, string user_role)
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
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = pqId;
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
                        sqlcmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = projectModel.Title == null ? "" : projectModel.Title;
                        sqlcmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = projectModel.Firstname == null ? "" : projectModel.Firstname;
                        sqlcmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = projectModel.Lastname == null ? "" : projectModel.Lastname;
                        sqlcmd.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = projectModel.CompanyName == null ? "" : projectModel.CompanyName;
                        sqlcmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = projectModel.ContactNo == null ? "" : projectModel.ContactNo;
                        sqlcmd.Parameters.AddWithValue("@FileLableAs", SqlDbType.VarChar).Value = projectModel.FileLableAs == null ? "" : projectModel.FileLableAs;
                        sqlcmd.Parameters.AddWithValue("@UnitNo", SqlDbType.VarChar).Value = projectModel.UnitNo == null ? "" : projectModel.UnitNo;
                        sqlcmd.Parameters.AddWithValue("@Establishment", SqlDbType.VarChar).Value = projectModel.Establishment == null ? "" : projectModel.Establishment;
                        sqlcmd.Parameters.AddWithValue("@HouseNo", SqlDbType.VarChar).Value = projectModel.HouseNo == null ? "" : projectModel.HouseNo;
                        sqlcmd.Parameters.AddWithValue("@Street", SqlDbType.VarChar).Value = projectModel.Street == null ? "" : projectModel.Street;
                        sqlcmd.Parameters.AddWithValue("@Village", SqlDbType.VarChar).Value = projectModel.Village == null ? "" : projectModel.Village;
                        sqlcmd.Parameters.AddWithValue("@Barangay", SqlDbType.VarChar).Value = projectModel.Barangay == null ? "" : projectModel.Barangay;
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

        public async Task DeleteAEIC(string project_Id, string employee_Id)
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
                            sqlcmd.Parameters.AddWithValue("@Command", "DeleteAssignAEIC");
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

        public async Task<DataTable> GetProjectAssignAE(string searchStr, int user_id, string user_acctType)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "GetProjectAssignAE";
                        sqlcmd.Parameters.Add("@Emp_id", SqlDbType.Int).Value = user_id;
                        sqlcmd.Parameters.Add("@User_Role", SqlDbType.VarChar).Value = user_acctType;
                        sqlcmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = searchStr;

                        sqladapter.SelectCommand = sqlcmd;
                        sqladapter.Fill(dt);
                        sqltrans.Commit();
                    }
                }
            }

            return dt;
        }

        public async Task<bool> CheckCustomerRefById(int custRefId, int employee_Id)
        {
            try
            {
                bool Combination = false;
                using (SqlConnection Sqlcon = new SqlConnection(_sqlConString))
                {
                    await Sqlcon.OpenAsync();
                    using (SqlCommand sqlcmd = Sqlcon.CreateCommand())
                    {
                        using (SqlTransaction sqltrans = Sqlcon.BeginTransaction(IsolationLevel.RepeatableRead, "CheckProjectAEAssignment"))
                        {
                            sqlcmd.Connection = Sqlcon;
                            sqlcmd.Transaction = sqltrans;
                            sqlcmd.CommandText = "Project_Quote_Stp";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Command", "CheckCustomerRefById");
                            sqlcmd.Parameters.AddWithValue("@Emp_id", employee_Id);
                            sqlcmd.Parameters.AddWithValue("@Cust_ref_id", custRefId);
                            using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        Combination = rdr.GetBoolean(0);
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

        public async Task Delete_Project(int Project_Quote_Id, int userID)
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
                        sqlcmd.Parameters.Add("@Command", SqlDbType.VarChar).Value = "DeleteProject";
                        sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = Project_Quote_Id;
                        sqlcmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = userID;
                        sqltrans.Commit();
                        sqlcmd.ExecuteReader();
                    }
                }
            }
        }

        public async Task EditProject(int projectId, IProjectModel projectModel)
        {
            try
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
                            sqlcmd.Parameters.AddWithValue("Command", "EditProject");
                            sqlcmd.Parameters.AddWithValue("@Project_Id", projectId);
                            using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                            {
                                if (!rdr.HasRows)
                                {
                                    projectModel = null;
                                }
                                else
                                {
                                    while (rdr.Read())
                                    {
                                        projectModel.Title = rdr.GetString(0);
                                        projectModel.Firstname = rdr.GetString(1);
                                        projectModel.Lastname = rdr.GetString(2);
                                        projectModel.CompanyName = rdr.GetString(3);
                                        projectModel.ContactNo = rdr.GetString(4);
                                        projectModel.FileLableAs = rdr.GetString(5);
                                        projectModel.UnitNo = rdr.GetString(6);
                                        projectModel.Establishment = rdr.GetString(7);
                                        projectModel.HouseNo = rdr.GetString(8);
                                        projectModel.Street = rdr.GetString(9);
                                        projectModel.Village = rdr.GetString(10);
                                        projectModel.Barangay = rdr.GetString(11);
                                        projectModel.Province = rdr.GetString(12);
                                        projectModel.City = rdr.GetString(13);
                                        projectModel.Area = rdr.GetString(14);
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
        }

        public async Task UpdateProject(int projectId, IProjectModel projectModel, IUserModel userModel)
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
                        sqlcmd.Parameters.AddWithValue("@Command", SqlDbType.VarChar).Value = "UpdateProject";
                        sqlcmd.Parameters.AddWithValue("@User_Id", SqlDbType.VarChar).Value = userModel.UserID;
                        sqlcmd.Parameters.AddWithValue("@Project_Id", SqlDbType.VarChar).Value = projectId;
                        sqlcmd.Parameters.AddWithValue("@Title", SqlDbType.VarChar).Value = projectModel.Title == null ? "" : projectModel.Title;
                        sqlcmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = projectModel.Firstname == null ? "" : projectModel.Firstname;
                        sqlcmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = projectModel.Lastname == null ? "" : projectModel.Lastname;
                        sqlcmd.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = projectModel.CompanyName == null ? "" : projectModel.CompanyName;
                        sqlcmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = projectModel.ContactNo == null ? "" : projectModel.ContactNo;
                        sqlcmd.Parameters.AddWithValue("@FileLableAs", SqlDbType.VarChar).Value = projectModel.FileLableAs == null ? "" : projectModel.FileLableAs;
                        sqlcmd.Parameters.AddWithValue("@UnitNo", SqlDbType.VarChar).Value = projectModel.UnitNo == null ? "" : projectModel.UnitNo;
                        sqlcmd.Parameters.AddWithValue("@Establishment", SqlDbType.VarChar).Value = projectModel.Establishment == null ? "" : projectModel.Establishment;
                        sqlcmd.Parameters.AddWithValue("@HouseNo", SqlDbType.VarChar).Value = projectModel.HouseNo == null ? "" : projectModel.HouseNo;
                        sqlcmd.Parameters.AddWithValue("@Street", SqlDbType.VarChar).Value = projectModel.Street == null ? "" : projectModel.Street;
                        sqlcmd.Parameters.AddWithValue("@Village", SqlDbType.VarChar).Value = projectModel.Village == null ? "" : projectModel.Village;
                        sqlcmd.Parameters.AddWithValue("@Barangay", SqlDbType.VarChar).Value = projectModel.Barangay == null ? "" : projectModel.Barangay;
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
