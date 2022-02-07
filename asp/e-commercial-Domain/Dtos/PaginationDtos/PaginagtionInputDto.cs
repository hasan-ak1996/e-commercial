using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Domain.Dtos.PaginationDtos
{
    public class PaginagtionInputDto
    {
        // max amount of items for one page is 50 items
        private const int MaxPageSize = 50;
        // page number, default is a first page
        public int PageIndex { get; set; } = 1;
        // default of amount items in a one page
        private int _pageSize = 10;
        // amount of items in a one page
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        // property for sorting
        public string Sort { get; set; }
    }
}
