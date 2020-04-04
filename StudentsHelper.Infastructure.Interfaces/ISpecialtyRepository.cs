using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Infastructure.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        IEnumerable<Specialty> GetAll();
        void Create(Specialty specialty);
        void Delete(Specialty specialty);
        Specialty Read(Specialty specialty);
    }
}
