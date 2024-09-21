using Ecommerce.Application.Repository;
using Ecommerce.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Application.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        // Add any specific methods for Review repository here
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(int userId);
    }
}
