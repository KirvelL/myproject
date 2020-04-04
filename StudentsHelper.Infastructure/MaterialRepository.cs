using System;
using System.Collections.Generic;
using System.Text;
using StudentsHelper.Infastructure.Interfaces;
using StudentsHelper.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentsHelper.Infastructure
{
    public class MaterialRepository : IMaterialRepository
    {
        private ApplicationDbContext _dbContext;
        public MaterialRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Material> GetAll()
        {
            return _dbContext.Materials;
        }
        public async Task<IEnumerable<Material>> GetMaterialsForTeacherAsync(Guid teacherId)
        {
            return (await _dbContext.MaterialTeachers.Include(x => x.Material)
                .Where(x => x.TeacherId == teacherId)
                .Select(x => x.Material)
                .ToListAsync());
        }
        public void Create(Material material)
        {
            _dbContext.Materials.Add(material);
            _dbContext.SaveChanges();
        }
        public void Delete(Material material)
        {
            _dbContext.Materials.Remove(material);
            _dbContext.SaveChanges();
        }
        public Material Read(Material material)
        {
            return _dbContext.Materials.Find(material);
        }
        public void Update(Material material, Material material2)
        {
            var temp = _dbContext.Materials.Find(material);
            temp = material2;
            _dbContext.SaveChanges();
        }
    }
}
