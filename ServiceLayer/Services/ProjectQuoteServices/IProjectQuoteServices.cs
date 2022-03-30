﻿using ModelLayer.Model.ProjectQuote;
using System;
using System.Data;
using System.Threading.Tasks;

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
        Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int projId, int custRefNo, int user_id, string user_role);
        IProjectQuoteModel AddProjectQuote(int pq_id,
                                           int pq_ProjId,
                                           int? pq_CustRefId,
                                           int? pq_EmployeeId,
                                           int pq_QuoteId,
                                           DateTime? pq_DateAssigned);
    }
}