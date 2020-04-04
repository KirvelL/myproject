using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsHelper.Domain.Services
{
    public class ReviewDomainService : IReviewDomainService
    {
        private IUnitOfWork _unitOfWork;
        public ReviewDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Review review)
        {
            _unitOfWork.ReviewsRepository.Create(review);
        }
        public void Delete(Review review)
        {
            _unitOfWork.ReviewsRepository.Delete(review);
        }
        public Review Read(Review review)
        {
           return _unitOfWork.ReviewsRepository.Read(review);
        }
        public void Update(Review review, Review review2)
        {
            _unitOfWork.ReviewsRepository.Update(review, review2);
        }
        public IEnumerable<Review> GetAll()
        {
            return _unitOfWork.ReviewsRepository.GetAll();
        }
        public IEnumerable<Review> GetTeacher()
        {
            return null;
        }
        public Review GetReviewById(Guid id)
        {
            return _unitOfWork.ReviewsRepository.GetReviewById(id);
        }

    }
}
