using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StudentsHelper.Domain;

namespace StudentsHelper.Infastructure.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        void Create(Review review);
        IEnumerable<Review> GetAll();
        Review Read(Review review);
        void Update(Review review, Review review2);
        void Delete(Review review);
        Review GetReviewById(Guid id);
    }
}
