using Ecommerce.Application.Repository;
using Ecommerce.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductAsync(int productId)
        {
            return await _unitOfWork.Reviews.GetReviewsByProductIdAsync(productId);
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserAsync(int userId)
        {
            return await _unitOfWork.Reviews.GetReviewsByUserIdAsync(userId);
        }

        public async Task AddReviewAsync(Review review)
        {
            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
            await _unitOfWork.Reviews.UpdateAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(reviewId);
            if (review != null)
            {
                await _unitOfWork.CompleteAsync();
            }
            // Handle else case as needed
        }
    }
}
