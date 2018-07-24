using System.Linq;
using MassMarket.Domain.Entities;
using MassMarket.Web.Helpers;

namespace MassMarket.Web.Models {

  public class ProductCardModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public string Image { get; set; }
    public CategoryModel Category { get; set; }

    public ProductCardModel(Product product) {
      Id = product.Id;
      Name = product.Name;
      Description = product.Description;
      Price = product.Price;
      Brand = product.Brand;
      Image = product.Images.FirstOrDefault()?.Path();

      if (product.CategoryId != null) {
        Category = new CategoryModel(product.Category);
      }
    } 
  }
}
