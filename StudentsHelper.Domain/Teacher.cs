using System;
using System.Collections.Generic;

namespace StudentsHelper.Domain
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string OtherInformation { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<MaterialTeacher> MaterialTeachers { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
