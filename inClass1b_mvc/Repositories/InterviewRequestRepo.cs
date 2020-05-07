using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inClass1b_mvc.Models;
using inClass1b_mvc.Models.Portfolio;
using inClass1b_mvc.ViewModels;

namespace inClass1b_mvc.Repositories
{
    public class InterviewRequestRepo
    {
        private readonly PortfolioContext db;

        public InterviewRequestRepo(PortfolioContext db)
        {
            this.db = db;
        }


        public bool Create(InterviewRequestVM irVM)
        {
            Company company = db.Companies.FirstOrDefault(com => com.Name == irVM.Company);
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
                 InterviewRequest ir = new InterviewRequest
                 {
                     Time = irVM.Time,
                     Location = irVM.Location
                 };
                 Company c = new Company
                 {
                     Contact = irVM.Contact,
                     Name = irVM.Company,
                     Email = irVM.Email,
                     Phone = irVM.Phone
                 };
                 db.Companies.Add(c);
                 //Which one I think the second ?????
                 db.InterviewRequests.Add(ir);
                 c.InterviewRequests.Add(ir);
             }
            db.SaveChanges();
            return true;

        }
    }
}
    