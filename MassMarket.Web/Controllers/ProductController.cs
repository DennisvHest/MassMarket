using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MassMarket.Domain.Entities;
using MassMarket.Service;
using MassMarket.Service.Models;
using MassMarket.Web.Models;

namespace MassMarket.Web.Controllers {

  [RoutePrefix("api/products")]
  public class ProductController : ApiController {

    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService) {
      _productService = productService;
      _categoryService = categoryService;
    }

    [HttpGet]
    [Route("search")]
    public SearchResultModel Search([FromUri] SearchModel query) {
      SearchResult searchResult = _productService.Search(query);
      searchResult.FoundProducts = searchResult.FoundProducts.ToList();

      return new SearchResultModel(searchResult);
    }

    [HttpGet]
    [Route("searchoptions")]
    public SearchOptionsModel SearchOptions() {
      IEnumerable<Category> categories = _categoryService.GetParentWithChildrenCategories().ToList();

      return new SearchOptionsModel {
        Categories = categories.Select(c => new CategoryOptionModel(c))
      };
    }
  }
}
