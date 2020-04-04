using StudentsHelper.Domain.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsHelper.Domain.Interfaces
{
    public interface ITeacherDomainService
    {
        Teacher GetTeacherById(Guid id);
        IEnumerable<Teacher> GetAll();
        IEnumerable<Teacher> GetTeacher();
        IEnumerable<Teacher> GetImage();
        Task<IEnumerable<Review>> GetTeacherReview(Guid id);
        Task<IEnumerable<Teacher>> GetTeachersForMaterial(Guid materialId);
        Task Create(CreateTeacherDTO teacher);
        Task Delete(Teacher teacher);
        Teacher Read(Teacher teacher);
        Task Update(UpdateTeacherDTO teacher);
    }
}
