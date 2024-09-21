using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repository;
using Ecommerce.Infrastructure.Persistence;
using IUnitOfWork = Ecommerce.Application.Repository.IUnitOfWork;

namespace Ecommerce.Infrastructure.Services
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly EcommerceDbContext _context;

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IReviewRepository Reviews { get; private set; }

       IProductRepository IUnitOfWork.Products => throw new NotImplementedException();

        IReviewRepository IUnitOfWork.Reviews => throw new NotImplementedException();

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
