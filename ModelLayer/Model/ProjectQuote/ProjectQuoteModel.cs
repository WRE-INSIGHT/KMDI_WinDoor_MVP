using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.ProjectQuote
{
    public class ProjectQuoteModel : IProjectQuoteModel
    {
        public int PQ_Id { get; set; }
        public int PQ_ProjId { get; set; }
        public int PQ_CustRefId { get; set; }
        public int PQ_EmployeeId { get; set; } //assigned CE
        public int PQ_QuoteId { get; set; }
        public DateTime PQ_DateAssigned { get; set; }
    }
}
