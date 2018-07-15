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
    public IEnumerable<ProductCardModel> Search([FromUri] SearchModel query) {
      IEnumerable<Product> foundProducts = _productService.Search(query).ToList();

      return foundProducts.Select(p => new ProductCardModel(p)).ToArray();
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
