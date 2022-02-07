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
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductSpecification(GetProductsInputDto inputParams)
            // (x => (left side || or else right side))
            // if condition is false in left side , exceute right side , || means (or else)
            : base (x => 
                    ((!inputParams.BrandId.HasValue || x.ProductBrandId == inputParams.BrandId) && 
                    (!inputParams.TypeId.HasValue || x.ProductTypeId == inputParams.TypeId)) && 
                    (String.IsNullOrEmpty(inputParams.Search) || x.Name.ToLower().Contains(inputParams.Search))
            )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            ApplyPagination(inputParams.PageSize * (inputParams.PageIndex - 1), inputParams.PageSize);
            AddOrderByAsc(p => p.Name);
            if (!string.IsNullOrEmpty(inputParams.Sort))
            {
                switch(inputParams.Sort)
                {
                    case "priceAsc":
                        AddOrderByAsc(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderByAsc(p => p.Name);
                        break;
                }
            }
        }
    }
}
