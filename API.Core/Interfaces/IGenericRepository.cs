using API.Core.DbModels;
using API.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity 
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpecc(ISpecification<T> specc);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specc);
    }
}
