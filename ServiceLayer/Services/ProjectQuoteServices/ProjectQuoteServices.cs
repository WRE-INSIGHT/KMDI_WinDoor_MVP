using ModelLayer.Model.ProjectQuote;
using ServiceLayer.CommonServices;
using System;
using System.Data;
using System.Threading.Tasks;
using ModelLayer.Model.Project;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public class ProjectQuoteServices : IProjectQuoteServices
    {
        private IProjectQuoteRepository _projQuoteRepo;
        private IModelDataAnnotationCheck _modelCheck;

        public ProjectQuoteServices(IProjectQuoteRepository projQuoteRepo, IModelDataAnnotationCheck modelCheck)
        {
            _projQuoteRepo = projQuoteRepo;
            _modelCheck = modelCheck;
        }

        public async Task<DataTable> Get_AssignedProjects(string searchStr)
        {
            return await _projQuoteRepo.Get_AssignedProjects(searchStr);
        }

        public async Task<int> Delete_ProjQuote(int proj_quote_id, int user_id)
        {
            return await _projQuoteRepo.Delete_ProjQuote(proj_quote_id, user_id);
        }

        public async Task<int> Insert_ProjQuote(IProjectQuoteModel pqModel, int user_id)
        {
            return await _projQuoteRepo.Insert_ProjQuote(pqModel, user_id);
        }

        public async Task<int> Update_ProjQuote(IProjectQuoteModel pqModel, int user_id)
        {
            return await _projQuoteRepo.Update_ProjQuote(pqModel, user_id);
        }

        private IProjectQuoteModel CreateProjectQuote(int pq_id,
                                                      int pq_ProjId,
                                                      int? pq_CustRefId,
                                                      int? pq_EmployeeId,
                                                      int pq_QuoteId,
                                                      DateTime? pq_DateAssigned
                                                      )
        {
            ProjectQuoteModel pqModel = new ProjectQuoteModel();
            pqModel.PQ_Id = pq_id;
            pqModel.PQ_ProjId = pq_ProjId;
            pqModel.PQ_CustRefId = pq_CustRefId;
            pqModel.PQ_EmployeeId = pq_EmployeeId;
            pqModel.PQ_QuoteId = pq_QuoteId;
            pqModel.PQ_DateAssigned = pq_DateAssigned;


            ValidateModel(pqModel);
            return pqModel;
        }

        public IProjectQuoteModel AddProjectQuote(int pq_id,
                                                  int pq_ProjId,
                                                  int? pq_CustRefId,
                                                  int? pq_EmployeeId,
                                                  int pq_QuoteId,
                                                  DateTime? pq_DateAssigned
                                                  )
        {
            IProjectQuoteModel pqModel = CreateProjectQuote(pq_id,
                                                            pq_ProjId,
                                                            pq_CustRefId,
                                                            pq_EmployeeId,
                                                            pq_QuoteId,
                                                            pq_DateAssigned
                                                            );

            return pqModel;
        }

        public void ValidateModel(IProjectQuoteModel pqModel)
        {
            _modelCheck.ValidateModelDataAnnotations(pqModel);
        }

        public async Task<DataTable> Get_ProjectByCostEngrID(string searchStr, int user_id, string user_acctType)
        {
            return await _projQuoteRepo.Get_ProjectByCostEngrID(searchStr, user_id, user_acctType);
        }

        public async Task<DataTable> Get_CustRefNoByProjectID(int projId, int user_id, string user_role)
        {
            return await _projQuoteRepo.Get_CustRefNoByProjectID(projId, user_id, user_role);
        }

        public async Task<DataTable> Get_QuoteNo_ByProjectID_ByCUstRefNo(int pqId, int projId, int custRefId, int user_id, string user_role)
        {
            return await _projQuoteRepo.Get_QuoteNo_ByProjectID_ByCUstRefNo(pqId, projId, custRefId, user_id, user_role);
        }

        public async Task<DataTable> Get_AEICByCostEngrID(string searchStr, int user_id, string user_acctType)
        {
            return await _projQuoteRepo.Get_AEICByCostEngrID(searchStr, user_id, user_acctType);
        }

        public string CheckProjectAEAssignment(string Project_Id, string Employee_Id)
        {
            return _projQuoteRepo.Check_ProjectAEAssignment(Project_Id, Employee_Id);
        }

        public async Task<DataTable> Get_AEICByProjectID(string projectId)
        {
            return await _projQuoteRepo.Get_AEICByProjectID(projectId);
        }

        public async Task SaveAssignAEIC(string Employee_Id, string Project_Id)
        {
            await _projQuoteRepo.SaveAssignAEIC(Employee_Id, Project_Id);
        }

        public async Task<DataTable> GetProvince()
        {
            return await _projQuoteRepo.GetProvince();
        }

        public async Task<DataTable> GetCityAreaBy_Province(string province)
        {
            return await _projQuoteRepo.GetCityAreaBy_Province(province);
        }

        public async Task SaveProject(IProjectModel projectModel)
        {
            ValidateModel(projectModel);
            await _projQuoteRepo.SaveProject(projectModel);
        }

        private void ValidateModel(IProjectModel projectModel)
        {
            _modelCheck.ValidateModelDataAnnotations(projectModel);
        }

        public async Task DeleteAEIC(string Project_Id, string Employee_Id)
        {
            await _projQuoteRepo.DeleteAEIC(Project_Id, Employee_Id);
        }

        public async Task<DataTable> GetProjectAssignAE(string searchStr, int user_id, string user_acctType)
        {
            return await _projQuoteRepo.GetProjectAssignAE(searchStr, user_id, user_acctType);
        }

        public async Task<bool> CheckCustomerRefById(int custRefId, int Employee_Id)
        {
            return await _projQuoteRepo.CheckCustomerRefById(custRefId, Employee_Id);
        }

        public async Task Delete_Project(int Project_Id, int userID)
        {
            await _projQuoteRepo.Delete_Project(Project_Id, userID);
        }
    }
}
