using StudentsHelper.Domain;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsHelper.Infastructure
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private ApplicationDbContext _dbContext;
        public InstitutionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Institution> GetAll()
        {
            return _dbContext.Institutions;
        }
        public void Create(Institution institution)
        {
            _dbContext.Institutions.Add(institution);
            _dbContext.SaveChanges();
        }
        public void Delete(Institution institution)
        {
            _dbContext.Institutions.Remove(institution);
            _dbContext.SaveChanges();
        }
        public Institution Read(Institution institution)
        {
            return _dbContext.Institutions.Find(institution);
        }
    }
}
