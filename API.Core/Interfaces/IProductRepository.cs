using API.Core.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
