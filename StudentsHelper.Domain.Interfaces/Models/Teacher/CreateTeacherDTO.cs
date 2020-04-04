using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StudentsHelper.Domain.Services.Models.Teacher
{
    public class CreateTeacherDTO
    {
        public string OtherInformation { get; set; }
        public Stream Avatar { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
    }
}
