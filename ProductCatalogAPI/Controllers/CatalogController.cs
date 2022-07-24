using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.Domain;
using ProductCatalogAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context, 
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogBrands()
        {
            var brands = await _context.CatalogBrands.ToListAsync();
            return Ok(brands);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var types = await _context.CatalogTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0, 
            [FromQuery]int pageSize = 6)
        {
            var itemsCount = _context.Catalog.LongCountAsync();
            var items = await _context.Catalog
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Items(
            [FromQuery] int? catalogTypeId,
            [FromQuery] int? catalogBrandId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<CatalogItem>)_context.Catalog;
            if (catalogTypeId.HasValue)
            {
                query = query.Where(c => c.CatalogTypeId == catalogTypeId.Value);
            }
            if (catalogBrandId.HasValue)
            {
                query = query.Where(c => c.CatalogBrandId == catalogBrandId.Value);
            }

            var itemsCount = query.LongCountAsync();
            var items = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        private List<CatalogItem> ChangePictureUrl(List<CatalogItem> items)
        {
            items.ForEach(item =>
                item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced",
                _config["ExternalBaseUrl"]));
            return items;
        }
    }
}
