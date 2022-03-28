using ModelLayer.Model.ProjectQuote;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> Delete_ProjQuote(int proj_id, int user_id)
        {
            return await _projQuoteRepo.Delete_ProjQuote(proj_id, user_id);
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
                                                      int pq_CustRefId,
                                                      int pq_EmployeeId,
                                                      int pq_QuoteId,
                                                      DateTime? pq_DateAssigned)
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
                                                  int pq_CustRefId,
                                                  int pq_EmployeeId,
                                                  int pq_QuoteId,
                                                  DateTime? pq_DateAssigned)
        {
            IProjectQuoteModel pqModel = CreateProjectQuote(pq_id,
                                                            pq_ProjId,
                                                            pq_CustRefId,
                                                            pq_EmployeeId,
                                                            pq_QuoteId,
                                                            pq_DateAssigned);

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
    }
}
