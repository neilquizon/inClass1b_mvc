using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.ViewModels
{
    public class EmployeeStoreVM
    {
        [DisplayName("Employee ID")] // Give nice label name for CRUD.
        public int EmployeeID { get; set; }
        [DisplayName("Last Name")]   // Give nice label name for CRUD.
        public string LastName { get; set; }
        [DisplayName("First Name")]  // Give nice label name for CRUD.
        public string FirstName { get; set; }
        public string Branch { get; set; }
        public string Region { get; set; }
        [DisplayName("Building Name")] // Give nice label name for CRUD.
        public string BuildingName { get; set; }
        [DisplayName("Unit")]        // Give nice label name for CRUD.
        public int UnitNum { get; set; }
    }
}