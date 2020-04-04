using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using StudentsHelper.Infastructure;


namespace StudentsHelper.Infastructure.Interfaces
{
    public interface IUnitOfWork
    {
        ITeacherRepository TeachersRepository { get; }
        IMaterialRepository MaterialsRepository { get; }
        IReviewRepository ReviewsRepository { get; }
        IInstitutionRepository InstitutionsRepository { get; }
        ISpecialtyRepository SpecialtiesRepository { get; }
        void Save();

    }
}
