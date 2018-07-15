using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MassMarket.Domain.Entities;

namespace MassMarket.Web.Models {
  public class CategoryModel {

    public int Id { get; set; }
    public string Name { get; set; }

    public CategoryModel ParentCategory { get; set; }

    public CategoryModel(Category category) {
      Id = category.Id;
      Name = category.Name;

      if (category.ParentCategoryId != null) {
        ParentCategory = new CategoryModel(category.ParentCategory);
      }
    }
  }
}
