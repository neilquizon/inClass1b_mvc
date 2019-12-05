using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b_mvc.Models.Portfolio
{
    public class Project
    {
        //Key notation to assign Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        //Navigation Properties
        //Child Tables
        public virtual ICollection<TechnologyProject> TechnologyProjects { get; set; }

    }
}
