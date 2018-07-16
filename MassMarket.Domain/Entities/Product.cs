using System.Collections;
using System.Collections.Generic;

namespace MassMarket.Domain.Entities {

    public class Product {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
