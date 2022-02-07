using e_commercial_Domain.Dtos.ProductDtos;
using e_commercial_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Repository.Specifications.Products
{
    public class ProductWithFiltersForCountSpicification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpicification(GetProductsInputDto inputParams)
            : base(
                  x =>
                    ((!inputParams.BrandId.HasValue || x.ProductBrandId == inputParams.BrandId) &&
                    (!inputParams.TypeId.HasValue || x.ProductTypeId == inputParams.TypeId)) &&
                    (String.IsNullOrEmpty(inputParams.Search) || x.Name.ToLower().Contains(inputParams.Search))
                  )
        {

        }
    }
}
