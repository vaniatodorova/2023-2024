using System;
using System.Collections.Generic;

#nullable disable

namespace CRUDWITHIMG.Models
{
    public partial class Employeemaster
    {
        public int Id { get; set; }
        public int Empcode { get; set; }
        public string Empname { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public string Empimg { get; set; }
    }
}
