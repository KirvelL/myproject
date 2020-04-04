using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain.Services.Interfaces
{
    public interface IInstitutionDomainService
    {
        IEnumerable<Institution> GetAll();
        void Create(Institution institution);
        void Delete(Institution institution);
        Institution Read(Institution institution);
    }
}
