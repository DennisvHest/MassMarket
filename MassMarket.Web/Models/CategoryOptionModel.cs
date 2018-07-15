using System.Collections.Generic;
using System.Linq;
using MassMarket.Domain.Entities;

namespace MassMarket.Web.Models {

  public class CategoryOptionModel {

    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<CategoryOptionModel> ChildCategories { get; set; }

    public CategoryOptionModel(Category category) {
      Id = category.Id;
      Name = category.Name;

      if (category.ChildCategories.Any()) {
        ChildCategories = category.ChildCategories.Select(c => new CategoryOptionModel(c));
      }
    }
  }
}
