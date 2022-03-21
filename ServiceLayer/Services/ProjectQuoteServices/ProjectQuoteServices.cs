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

        public ProjectQuoteServices(IProjectQuoteRepository projQuoteRepo)
        {
            _projQuoteRepo = projQuoteRepo;
        }

        public async Task<DataTable> Get_AssignedProjects(string searchStr)
        {
            return await _projQuoteRepo.Get_AssignedProjects(searchStr);
        }
    }
}
