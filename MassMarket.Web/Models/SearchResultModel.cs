using System.Linq;
using MassMarket.Service.Models;

namespace MassMarket.Web.Models {

  public class SearchResultModel {

    public ProductCardModel[] Products { get; set; }

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int TotalProductCount { get; set; }
    public MetaFieldOptionModel[] BrandOptions { get; set; }

    public SearchResultModel(SearchResult result) {
      Products = result.FoundProducts.Select(p => new ProductCardModel(p)).ToArray();
      BrandOptions = result.BrandOptions.Select(o => new MetaFieldOptionModel(o)).ToArray();

      MinPrice = result.MinPrice;
      MaxPrice = result.MaxPrice;
      TotalProductCount = result.TotalProductCount;
    }
  }
}
