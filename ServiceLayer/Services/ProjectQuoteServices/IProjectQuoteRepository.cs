using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public interface IProjectQuoteRepository
    {
        Task<DataTable> Get_AssignedProjects(string searchStr);
    }
}
