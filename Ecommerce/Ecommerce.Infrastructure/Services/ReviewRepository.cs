using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repository;
using Ecommerce.Domain;
using Ecommerce.Infrastructure.Persistence;


namespace Ecommerce.Infrastructure.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EcommerceDbContext _context;

        public ReviewRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            throw new NotImplementedException();

        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
        }

        public async Task DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();

        }

        Task<Review> IRepository<Review>.AddAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        Task<Review> IRepository<Review>.UpdateAsync(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
