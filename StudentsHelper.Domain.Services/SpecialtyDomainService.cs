using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services.Interfaces;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain.Services
{
    public class SpecialtyDomainService : ISpecialtyDomainService
    {
        private IUnitOfWork _unitOfWork;
        public SpecialtyDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Specialty> GetAll()
        {
            return _unitOfWork.SpecialtiesRepository.GetAll();
        }
        public void Create(Specialty specialty)
        {
            _unitOfWork.SpecialtiesRepository.Create(specialty);
        }
        public void Delete(Specialty specialty)
        {
            _unitOfWork.SpecialtiesRepository.Delete(specialty);
        }
        public Specialty Read(Specialty specialty)
        {
           return _unitOfWork.SpecialtiesRepository.Read(specialty);
        }

    }
}
