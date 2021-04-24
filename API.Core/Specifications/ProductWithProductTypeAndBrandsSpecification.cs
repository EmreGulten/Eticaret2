﻿using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecification()
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
        }

        public ProductWithProductTypeAndBrandsSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductBrands);
            AddInclude(x => x.ProductType);
        }
    }
}