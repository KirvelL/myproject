using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentsHelper.Domain;

namespace StudentsHelper.Infastructure.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void Create(Teacher teacher);
        Teacher Read(Teacher teacher);
        Teacher GetTeacherById(Guid id);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        IEnumerable<Teacher> GetAll();
        Task<Teacher> GetTeacherWithReview(Guid id);
        Task<IEnumerable<Teacher>> GetTeachersForMaterialAsync(Guid materialId);
    }
}
