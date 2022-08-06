using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }

    }
}
