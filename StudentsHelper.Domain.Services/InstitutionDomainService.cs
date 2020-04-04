using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services.Interfaces;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain.Services
{
    public class InstitutionDomainService : IInstitutionDomainService
    {
        private IUnitOfWork _unitOfWork;
        public InstitutionDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Institution> GetAll()
        {
            return _unitOfWork.InstitutionsRepository.GetAll();
        }
        public void Create(Institution institution)
        {
            _unitOfWork.InstitutionsRepository.Create(institution);
        }
        public void Delete(Institution institution)
        {
            _unitOfWork.InstitutionsRepository.Delete(institution);
        }
        public Institution Read(Institution institution)
        {
           return _unitOfWork.InstitutionsRepository.Read(institution);
        }

    }
}
