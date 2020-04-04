using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Infastructure.Interfaces
{
    public interface IInstitutionRepository : IRepository<Institution>
    {
        IEnumerable<Institution> GetAll();
        void Create(Institution institution);
        void Delete(Institution institution);
        Institution Read(Institution institution);
    }
}
