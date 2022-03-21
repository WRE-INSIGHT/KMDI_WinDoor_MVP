using System.Data;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProjectQuoteServices
{
    public interface IProjectQuoteServices
    {
        Task<DataTable> Get_AssignedProjects(string searchStr);
    }
}