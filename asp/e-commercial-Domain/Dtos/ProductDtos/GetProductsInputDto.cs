using e_commercial_Domain.Dtos.PaginationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Domain.Dtos.ProductDtos
{
    public class GetProductsInputDto : PaginagtionInputDto
    {
        // properties for filtering
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        private string _search;
        public string Search { 
            get => _search;
            set => _search = value.ToLower(); 
        }
    }
}
