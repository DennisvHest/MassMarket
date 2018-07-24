using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MassMarket.Common;

namespace MassMarket.Domain.Entities {

    public class Product {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ProductMetaField> MetaFields { get; set; }

        [NotMapped]
        public string Brand {
            get { return MetaFields.SingleOrDefault(m => m.MetaFieldId == Constants.BrandMetaFieldId)?.Option.Value; }
        }
    }
}
