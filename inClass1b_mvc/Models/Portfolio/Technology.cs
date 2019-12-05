using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Models.Portfolio
{
    public class Technology
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        //Navigation Properties
        //Child Tables
        public virtual ICollection<TechnologyProject> TechnologyProjects { get; set; }

    }
}
