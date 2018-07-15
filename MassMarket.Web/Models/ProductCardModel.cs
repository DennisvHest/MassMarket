using MassMarket.Domain.Entities;

namespace MassMarket.Web.Models {

  public class ProductCardModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryModel Category { get; set; }

    public ProductCardModel(Product product) {
      Id = product.Id;
      Name = product.Name;
      Description = product.Description;

      if (product.CategoryId != null) {
        Category = new CategoryModel(product.Category);
      }
    } 
  }
}
