using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain
{
    public class Institution
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Specialty> Specialties { get; set; }

    }
}
