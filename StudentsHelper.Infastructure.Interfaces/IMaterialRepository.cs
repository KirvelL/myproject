using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentsHelper.Domain;

namespace StudentsHelper.Infastructure.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        IEnumerable<Material> GetAll();
        void Create(Material material);
        Material Read(Material material);
        void Update(Material material, Material material2);
        Task<IEnumerable<Material>> GetMaterialsForTeacherAsync(Guid teacherId);
        void Delete(Material material);
    }
}
