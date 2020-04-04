using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MaterialTeacher> MaterialTeachers { get; set; }
    }
}
