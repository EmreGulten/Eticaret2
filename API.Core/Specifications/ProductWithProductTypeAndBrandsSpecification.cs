using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams) 
            :base(x=>
             (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) 
            && 
            (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
            //AddOrderBy(x => x.Name);

            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithProductTypeAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
        }
    }
}
