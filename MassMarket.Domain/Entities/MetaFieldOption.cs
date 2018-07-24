using System.Collections;
using System.Collections.Generic;

namespace MassMarket.Domain.Entities {

    public class MetaFieldOption {

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<MetaField> MetaFields { get; set; }
        public virtual ICollection<ProductMetaField> Products { get; set; }
    }
}
