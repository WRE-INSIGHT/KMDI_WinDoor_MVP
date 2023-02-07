using ModelLayer.Model.ProjectQuote;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Project;
using ModelLayer.Model.User;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public interface IProjectQuoteRepository
    {
        Task<DataTable> Get_AssignedProjects(string searchStr);
        Task<int> Delete_ProjQuote(int proj_quote_id, int user_id);
        Task<int> Insert_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<int> Update_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<DataTable> Get_ProjectByCostEngrID(string searchStr, int user_id, string user_role);
        Task<DataTable> Get_CustRefNoByProjectID(int projId, int user_id, string user_role);
        Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int pqId, int projId, int custRefId, int user_id, string user_role);
        Task<DataTable> Get_AEICByCostEngrID(string searchStr, int user_id, string user_acctType);
        string Check_ProjectAEAssignment(string project_Id, string employee_Id);
        Task<DataTable> Get_AEICByProjectID(string projectId);
        Task SaveAssignAEIC(string employee_Id, string project_Id);
        Task<DataTable> GetProvince();
        Task<DataTable> GetCityAreaBy_Province(string province);
        Task SaveProject(IProjectModel projectModel);
        Task DeleteAEIC(string project_Id, string employee_Id);
        Task<DataTable> GetProjectAssignAE(string searchStr, int user_id, string user_acctType);
        Task<bool> CheckCustomerRefById(int custRefId, int employee_Id);
        Task Delete_Project(int Project_Quote_Id, int userID);
        Task EditProject(int projectId, IProjectModel _projectModel);
        Task UpdateProject(int projectId, IProjectModel projectModel, IUserModel userModel);
    }
}
