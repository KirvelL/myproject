using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain
{
    public class MaterialTeacher
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
