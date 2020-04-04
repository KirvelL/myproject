using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain
{
    public class Specialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}
