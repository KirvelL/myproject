using StudentsHelper.Domain;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Infastructure
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private ApplicationDbContext _dbContext;
        public SpecialtyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Specialty> GetAll()
        {
            return _dbContext.Specialties;
        }
        public void Create(Specialty specialty)
        {
            _dbContext.Specialties.Add(specialty);
            _dbContext.SaveChanges();
        }
        public void Delete(Specialty specialty)
        {
            _dbContext.Specialties.Remove(specialty);
            _dbContext.SaveChanges();
        }
        public Specialty Read(Specialty specialty)
        {
            return _dbContext.Specialties.Find(specialty);
        }
    }
}
