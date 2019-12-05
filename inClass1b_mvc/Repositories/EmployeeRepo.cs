using inClass1b_mvc.Models.FoodStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Repositories
{
    public class EmployeeRepo
    {
        private FoodStoreContext db;

        public EmployeeRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public Employee Get(int id)
        {
            return db.Employee.FirstOrDefault(e => e.EmployeeId == id);
        }
        public bool Update(int id, string first, string last)
        {
            Employee employee = Get(id);

            employee.FirstName = first;
            employee.LastName = last;
            db.SaveChanges();
            return true;
        }
    }
}
