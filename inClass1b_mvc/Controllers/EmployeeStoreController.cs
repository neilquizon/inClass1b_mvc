using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b_mvc.Models.FoodStore;
using inClass1b_mvc.Repositories;
using inClass1b_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace inClass1b_mvc.Controllers
{
    public class EmployeeStoreController : Controller
    {
        private readonly FoodStoreContext db;
        public EmployeeStoreController(FoodStoreContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var results = new EmployeeStoreVMRepo(db).GetAll();
            return View(results);
        }

        public IActionResult Details(int employeeID, string branch)
        {
            var result = new EmployeeStoreVMRepo(db).Get(employeeID, branch);
            return View(result);
        }

        // This method is called when the user arrives at the edit page.
        [HttpGet]
        public ActionResult Edit(int employeeID, string branch)
        {
            var result = new EmployeeStoreVMRepo(db).Get(employeeID, branch);
            return View(result);
        }

        // This method is called when the user clicks the submit
        // button from the edit page.
        [HttpPost]
        public ActionResult Edit(EmployeeStoreVM esVM)
        {
            EmployeeStoreVMRepo esRepo = new EmployeeStoreVMRepo(db);
            esRepo.Update(esVM);

            // go to index action method of the same controller.
            return RedirectToAction("Index");
        }

    }
}