using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thirdLab.ViewModels
{
    public class InterviewRequestVM
    {
        [Required(ErrorMessage="Input is required")]
        [DisplayName("Company Name")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Input is required")]
        [DisplayName("Contact")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Input is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email Address")]
        [Required(ErrorMessage = "This input is required.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This input is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Time")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "This input is required.")]
        [DisplayName("Location")]
        public string Location { get; set; }

    }
}
