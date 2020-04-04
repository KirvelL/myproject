using System;
using System.Collections.Generic;

namespace StudentsHelper.Domain.Interfaces
{
    public interface IReviewDomainService
    {
        IEnumerable<Review> GetAll();
        IEnumerable<Review> GetTeacher();
        Review GetReviewById(Guid id);
        void Delete(Review review);
        void Create(Review review);
        Review Read(Review review);
        void Update(Review review, Review review2);
    }
}
