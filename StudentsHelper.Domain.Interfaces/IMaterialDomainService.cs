using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsHelper.Domain.Interfaces
{
    public interface IMaterialDomainService
    {
        IEnumerable<Material> GetAll();
        void Create(Material material);
        void Delete(Material material);
        Task<IEnumerable<Material>> GetMaterialsForTeacher(Guid teacherId);
        Material Read(Material material);
        void Update(Material material, Material material2);
    }
}
