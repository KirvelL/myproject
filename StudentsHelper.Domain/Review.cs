using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public virtual User Sender { get; set; }
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public string Text { get; set; }        
    }
}
