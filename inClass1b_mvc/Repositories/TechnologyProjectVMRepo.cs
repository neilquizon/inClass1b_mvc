using inClass1b_mvc.Models.Portfolio;
using inClass1b_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Repositories
{
    public class TechnologyProjectVMRepo
    {
        private PortfolioContext db;
        public TechnologyProjectVMRepo(PortfolioContext db)
        {
            this.db = db;
        }

        public IEnumerable<TechnologyProjectVM> GetAll()
        {
            return db.Projects.Select(tp => new TechnologyProjectVM
            {
                Project = tp,
                Technologies = tp.TechnologyProjects.Select(t => t.Technology)
            });
        }

        public TechnologyProjectVM GetDetails(int id)
        {
            return GetAll().FirstOrDefault(tp => tp.Project.ProjectId == id);
        }
    }
}
