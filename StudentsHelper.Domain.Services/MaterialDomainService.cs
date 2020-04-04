using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Domain.Services
{
    public class MaterialDomainService : IMaterialDomainService
    {
        private IUnitOfWork _unitOfWork;
        public MaterialDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Material>> GetMaterialsForTeacher(Guid teacherId)
        {
            return (await _unitOfWork.MaterialsRepository.GetMaterialsForTeacherAsync(teacherId));
        }
        public IEnumerable<Material> GetAll()
        {
            return _unitOfWork.MaterialsRepository.GetAll();
        }
        public void Create(Material material)
        {
            _unitOfWork.MaterialsRepository.Create(material);
        }
        public void Delete(Material material)
        {
            _unitOfWork.MaterialsRepository.Delete(material);
        }
        public void Update(Material material, Material material2)
        {
            _unitOfWork.MaterialsRepository.Update(material, material2);
        }
        public Material Read(Material material)
        {
            return _unitOfWork.MaterialsRepository.Read(material);
        }

        public Material AddMaterial()
        {
            return null;
        }
    }
}
