using System;

namespace ModelLayer.Model.ProjectQuote
{
    public interface IProjectQuoteModel
    {
        int? PQ_CustRefId { get; set; }
        DateTime? PQ_DateAssigned { get; set; }
        int? PQ_EmployeeId { get; set; }
        int PQ_Id { get; set; }
        int PQ_ProjId { get; set; }
        int PQ_QuoteId { get; set; }
    }
}