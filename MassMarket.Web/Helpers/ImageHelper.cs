using MassMarket.Domain.Entities;

namespace MassMarket.Web.Helpers {

  public static class ImageHelper {

    public static string Path(this Image image) {
      return $"/images/products/{image.Id}.{image.MimeType}";
    }
  }
}
