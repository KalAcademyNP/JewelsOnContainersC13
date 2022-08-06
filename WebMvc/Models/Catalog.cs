using System.Collections.Generic;

namespace WebMvc.Models
{
    public class Catalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }

        public IEnumerable<CatalogItem> Data { get; set; }
    }
}
