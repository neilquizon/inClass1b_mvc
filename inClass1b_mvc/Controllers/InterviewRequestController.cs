using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using thirdLab.Models;
using thirdLab.Repositories;
using thirdLab.Services;
using thirdLab.ViewModels;

namespace thirdLab.Controllers
{
    public class InterviewRequestController : Controller
    {
        private PortfolioContext db;
        private EmailSettings _eSettings;

        public InterviewRequestController(PortfolioContext db, IOptions<EmailSettings> _eSettings)
        {
            this.db = db;
            this._eSettings = _eSettings.Value;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InterviewRequestVM irVM)
        {
            if (ModelState.IsValid)
            {
                //if (new InterviewRequestRepo(db).Create(irVM))
                Company company = db.Companies.FirstOrDefault(c => c.Name == irVM.Company);
                if (company != null)
                {
                    company.InterviewRequests.Add(new InterviewRequest
                    {
                        Time = irVM.Time,
                        Location = irVM.Location
                    });
                }
                else
                {
                    Company com = new Company
                    {
                        Contact = irVM.Contact,
                        Email = irVM.Email,
                        Name = irVM.Company,
                        Phone = irVM.Phone
                    };
                    InterviewRequest ir = new InterviewRequest
                    {
                        Time = irVM.Time,
                        Location = irVM.Location
                    };
                    db.InterviewRequests.Add(ir);
                    db.Companies.Add(com);
                }
                               
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(irVM);
        }

        public IActionResult Contact()
        {
            //if (new EmailHelper(_eSettings).SendEmail("jaleh36@gmail.com", "Thank you for the request"))
                return RedirectToAction("index", "Home");
            //return Error();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}