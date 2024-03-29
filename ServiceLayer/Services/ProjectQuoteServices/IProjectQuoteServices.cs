﻿using ModelLayer.Model.ProjectQuote;
using System;
using System.Data;
using System.Threading.Tasks;
using ModelLayer.Model.Project;
using System.Collections.Generic;
using ModelLayer.Model.User;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public interface IProjectQuoteServices
    {
        Task<DataTable> Get_AssignedProjects(string searchStr);
        Task<int> Delete_ProjQuote(int id, int user_id);
        Task<int> Insert_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<int> Update_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<DataTable> Get_ProjectByCostEngrID(string searchStr, int user_id, string user_acctType);
        Task<DataTable> Get_CustRefNoByProjectID(int projId, int user_id, string user_role);
        Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int pqId, int projId, int custRefId, int user_id, string user_role);
        IProjectQuoteModel AddProjectQuote(int pq_id,
                                           int pq_ProjId,
                                           int? pq_CustRefId,
                                           int? pq_EmployeeId,
                                           int pq_QuoteId,
                                           DateTime? pq_DateAssigned
                                           );
        Task<DataTable> Get_AEICByCostEngrID(string searchStr, int user_id, string user_acctType);
        string CheckProjectAEAssignment(string Project_Id, string Employee_Id);
        Task<DataTable> Get_AEICByProjectID(string projectId);
        Task SaveAssignAEIC(string Employee_Id, string Project_Id);
        Task<DataTable> GetProvince();
        Task<DataTable> GetCityAreaBy_Province(string province);
        Task SaveProject(IProjectModel projectModel);
        Task DeleteAEIC(string Project_Id, string Employee_Id);
        Task<DataTable> GetProjectAssignAE(string searchStr, int user_id, string user_acctType);
        Task<bool> CheckCustomerRefById(int custRefId, int Employee_Id);
        Task Delete_Project(int Project_Quote_Id, int userID);
        Task EditProject(int projectId, IProjectModel projectModel);
        Task UpdateProject(int projectId, IProjectModel projectModel, IUserModel userModel);
    }
}