using Microsoft.AspNetCore.Http;
using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHelper.Models.Teachers
{
    public class UpdateTeacherViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Other Information")]
        public string OtherInformation { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
