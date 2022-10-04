using ModelLayer.Model.ProjectQuote;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model.Project;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public interface IProjectQuoteRepository
    {
        Task<DataTable> Get_AssignedProjects(string searchStr);
        Task<int> Delete_ProjQuote(int proj_id, int user_id);
        Task<int> Insert_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<int> Update_ProjQuote(IProjectQuoteModel pqModel, int user_id);
        Task<DataTable> Get_ProjectByCostEngrID(string searchStr, int user_id, string user_role);
        Task<DataTable> Get_CustRefNoByProjectID(int projId, int user_id, string user_role);
        Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int projId, int custRefId, int user_id, string user_role);
        Task<DataTable> Get_AEICByCostEngrID(string searchStr, int user_id, string user_acctType);
        string Check_ProjectAEAssignment(string project_Id, string employee_Id);
        Task<DataTable> Get_AEICByProjectID(string projectId);
        Task SaveAssignAEIC(string employee_Id, string project_Id);
        Task<DataTable> GetProvince();
        Task<DataTable> GetCityAreaBy_Province(string province);
        Task SaveProject(IProjectModel projectModel);
    }
}
