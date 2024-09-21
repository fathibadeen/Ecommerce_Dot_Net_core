using Ecommerce.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IReviewRepository Reviews { get; }
        Task<int> CompleteAsync();
    }
}
