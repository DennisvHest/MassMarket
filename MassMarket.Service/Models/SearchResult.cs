using System.Collections.Generic;
using MassMarket.Domain.Entities;

namespace MassMarket.Service.Models {

    public class SearchResult {

        public IEnumerable<Product> FoundProducts { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int TotalProductCount { get; set; }
    }
}
