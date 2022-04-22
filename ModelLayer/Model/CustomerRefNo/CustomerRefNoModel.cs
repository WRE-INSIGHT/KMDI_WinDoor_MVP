using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.CustomerRefNo
{
    public class CustomerRefNoModel : ICustomerRefNoModel
    {
        public int CustRefNo_Id { get; set; }
        public string CustomerReferenceNumber { get; set; }
    }
}
