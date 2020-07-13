using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactWebApi.Models
{
    public class EmployeeMo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime JoinedDate { get; set; }
        public int Age { get; set; }
    }
}