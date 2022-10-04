using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model.Project
{
    public interface IProjectModel
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string CompanyName { get; set; }
        string ContactNo { get; set; }
        string FileLableAs { get; set; }
        string UnitNo { get; set; }
        string Establishment { get; set; }
        string HouseNo { get; set; }
        string Street { get; set; }
        string Village { get; set; }
        string Barangay { get; set; }
        string City { get; set; }
        string Province { get; set; }
        string Area { get; set; }
        string CompleteAddress { get;}
    }
}
