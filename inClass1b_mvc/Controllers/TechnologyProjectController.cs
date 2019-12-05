using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b_mvc.Models.Portfolio;
using inClass1b_mvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inClass1b_mvc.Controllers
{
    [Route("NeilQuizon")]
    public class TechnologyProjectController : Controller
    {
        private PortfolioContext db;
        public TechnologyProjectController(PortfolioContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            TechnologyProjectVMRepo repo = new TechnologyProjectVMRepo(db);

            return View(repo.GetAll());
        }
        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            TechnologyProjectVMRepo repo = new TechnologyProjectVMRepo(db);
            return View(repo.GetDetails(id));
        }
    }
}