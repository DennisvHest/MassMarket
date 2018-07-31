using MassMarket.Domain.Entities;

namespace MassMarket.Web.Models {

  public class MetaFieldOptionModel {

    public int Id { get; set; }
    public string Value { get; set; }

    public MetaFieldOptionModel(MetaFieldOption option) {
      Id = option.Id;
      Value = option.Value;
    }
  }
}
