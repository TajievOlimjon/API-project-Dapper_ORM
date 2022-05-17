using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class DepartmentManager
    {
        public string? FirsName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }        
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public  DateTime FromDate { get; set; }
        public   DateTime  ToDate { get; set; }

    }
}
