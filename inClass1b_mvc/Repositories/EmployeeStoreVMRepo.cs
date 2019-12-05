using inClass1b_mvc.Models.FoodStore;
using inClass1b_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Repositories
{
    public class EmployeeStoreVMRepo
    {
        private readonly FoodStoreContext db;
        public EmployeeStoreVMRepo(FoodStoreContext db)
        {
            this.db = db;
        }

        public IEnumerable<EmployeeStoreVM> GetAll()
        {
            IEnumerable<EmployeeStoreVM> results =
                db.Employee.Select(es => new EmployeeStoreVM()
                {
                    EmployeeID = es.EmployeeId,
                    LastName = es.LastName,
                    FirstName = es.FirstName,
                    Branch = es.Branch,
                    Region = es.BranchNavigation.Region,
                    BuildingName =
                        es.BranchNavigation.BuildingName != null ?
                        es.BranchNavigation.BuildingName : "",
                    UnitNum = es.BranchNavigation.UnitNum == null ? 0 :
                        (int)es.BranchNavigation.UnitNum
                });
            return results;
        }

        public EmployeeStoreVM Get(int employeeID, string branch)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo(db);
            Employee employee = employeeRepo.Get(employeeID);

            StoreRepo storeRepo = new StoreRepo(db);
            Store store = storeRepo.Get(branch);

            EmployeeStoreVM esVM = new EmployeeStoreVM
            {
                EmployeeID = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Branch = store.Branch,
                BuildingName = store.BuildingName == null ? "" : store.BuildingName,
                Region = store.Region,
                // Need condition to handle null
                UnitNum = store.UnitNum == null ? 0 : (int)store.UnitNum
            };
            return esVM;
        }
        public bool Update(EmployeeStoreVM esVM)
        {
            // Updating our ViewModel really requires updates to 
            // two separate tables. 

            // Update the 'Store'.
            StoreRepo storeRepo = new StoreRepo(db);
            storeRepo.Update(esVM.Branch, esVM.Region);

            // Update the 'Employee'.
            EmployeeRepo empRepo = new EmployeeRepo(db);
            empRepo.Update(esVM.EmployeeID, esVM.FirstName, esVM.LastName);

            // Error handling could go here and if problems are encountered
            // 'false' could be returned.

            // Otherwise if things go well return true.
            return true;
        }


    }
}
