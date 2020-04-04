using System;
using System.Collections.Generic;
using System.Text;
using StudentsHelper.Infastructure.Interfaces;
using StudentsHelper.Domain;

namespace StudentsHelper.Infastructure
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Review> GetAll()
        {
            return _dbContext.Reviews;
        }
        public Review GetReviewById(Guid id)
        {
            var review = _dbContext.Reviews.Find(id);
            return review;
        }
        public void Create(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }
        public void Delete(Review review)
        {
            _dbContext.Reviews.Remove(review);
            _dbContext.SaveChanges();
        }
        public Review Read(Review review)
        {
           return _dbContext.Reviews.Find(review);
        }
        public void Update(Review review, Review review2)
        {
            var temp = _dbContext.Reviews.Find(review);
            temp = review2;
            _dbContext.SaveChanges();
        }

    }
}
