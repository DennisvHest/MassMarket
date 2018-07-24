namespace MassMarket.Service.Models {

    public class SearchModel {

        public string QueryText { get; set; }
        public int CategoryId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
