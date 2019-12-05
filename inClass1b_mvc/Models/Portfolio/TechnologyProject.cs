using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Models.Portfolio
{
    public class TechnologyProject
    {
        [Key, Column(Order = 1)]
        public string TechnologyName { get; set; }

        [Key, Column(Order = 0)]
        public int ProjectId { get; set; }

        public virtual Technology Technology { get; set; }

        public virtual Project Project { get; set; }
    }
}
