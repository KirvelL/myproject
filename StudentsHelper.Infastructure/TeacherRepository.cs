using System;
using System.Collections.Generic;
using System.Text;
using StudentsHelper.Infastructure.Interfaces;
using StudentsHelper.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace StudentsHelper.Infastructure
{
    public class TeacherRepository : ITeacherRepository
    {
        private ApplicationDbContext _dbContext;
        public TeacherRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Teacher GetTeacherById(Guid id)
        {
            var teacher = _dbContext.Teachers.Find(id);
            return teacher;
        }
        public async Task<Teacher> GetTeacherWithReview(Guid id)
        {
            var teacher = await _dbContext.Teachers.Include(x => x.Reviews).FirstOrDefaultAsync(c => c.Id == id);
            return teacher;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersForMaterialAsync(Guid materialId)
        {
            return (await _dbContext.MaterialTeachers.Include(x => x.Teacher)
                .Where(x => x.MaterialId == materialId)
                .Select(x => x.Teacher)
                .ToListAsync());
        }
        public IEnumerable<Teacher> GetAll()
        {
            
            return _dbContext.Teachers;
        }
        public void Create(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges(); 
        }
        public void Delete(Teacher teacher)
        {
            _dbContext.Teachers.Remove(teacher);
            _dbContext.SaveChanges();
        }
        public Teacher Read(Teacher teacher)
        {
            return _dbContext.Teachers.Find(teacher);
        }
        public void Update(Teacher teacher)
        {
            this._dbContext.Teachers.Attach(teacher);
            _dbContext.Entry(teacher).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

    }
}
