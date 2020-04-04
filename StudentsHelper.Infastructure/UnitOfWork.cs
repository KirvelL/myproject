using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using StudentsHelper.Infastructure.Interfaces;


namespace StudentsHelper.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private ITeacherRepository teacherRepository;
        private IMaterialRepository materialRepository;
        private IInstitutionRepository institutionRepository;
        private ISpecialtyRepository specialtyRepository;
        private IReviewRepository reviewRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        public ITeacherRepository TeachersRepository
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(db);
                return teacherRepository;
            }
        }
        public IMaterialRepository MaterialsRepository
        {
            get
            {
                if (materialRepository == null)
                    materialRepository = new MaterialRepository(db);
                return materialRepository;
            }
        }
        public IReviewRepository ReviewsRepository
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }
        public ISpecialtyRepository SpecialtiesRepository
        {
            get
            {
                if (specialtyRepository == null)
                    specialtyRepository = new SpecialtyRepository(db);
                return specialtyRepository;
            }
        }
        public IInstitutionRepository InstitutionsRepository
        {
            get
            {
                if (institutionRepository == null)
                    institutionRepository = new InstitutionRepository(db);
                return institutionRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }
    }
}
