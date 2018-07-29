using System.Linq;
using MassMarket.Service.Helpers;

namespace MassMarket.Service.Models {

    public class SearchModel {

        public string QueryText { get; set; }
        public int CategoryId { get; set; }
        public int[] PriceRange { get; set; }
        public ProductOrdering Ordering { get; set; }
        public int PageNr { get; set; }

        public int? MinPrice {
            get {
                if (PriceRange.Length == 2) {
                    return PriceRange[0];
                }

                return null;
            }
        }

        public int? MaxPrice {
            get {
                if (PriceRange.Length == 2) {
                    return PriceRange[1];
                }

                return null;
            }
        }
    }
}
