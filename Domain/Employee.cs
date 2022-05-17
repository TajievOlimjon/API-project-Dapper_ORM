using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class Employee
    {
      public int Id { get; set; }
      
       public string? FirsName { get; set; }
       public string? LastName { get; set; }
       public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string? Name { get; set; }
    }
}
