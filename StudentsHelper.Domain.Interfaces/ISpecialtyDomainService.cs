using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain.Services.Interfaces
{
    public interface ISpecialtyDomainService
    {
        IEnumerable<Specialty> GetAll();
        void Create(Specialty specialty);
        void Delete(Specialty specialty);
        Specialty Read(Specialty specialty);
    }
}
