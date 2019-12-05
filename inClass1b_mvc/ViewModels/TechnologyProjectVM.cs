using inClass1b_mvc.Models.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.ViewModels
{
    public class TechnologyProjectVM
    {
        public Project Project { get; set; }
        public IEnumerable<Technology> Technologies { get; set; }
    }
}
