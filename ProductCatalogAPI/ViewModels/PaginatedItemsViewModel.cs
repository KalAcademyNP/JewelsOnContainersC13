using ProductCatalogAPI.Domain;
using System.Collections.Generic;

namespace ProductCatalogAPI.ViewModels
{
    public class PaginatedItemsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }

        public IEnumerable<CatalogItem> Data { get; set; }
    }
}
