using System.Collections;
using System.Collections.Generic;

namespace MassMarket.Domain.Entities {

    public class MetaField {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MetaFieldOption> Options { get; set; }
        public virtual ICollection<ProductMetaField> Products { get; set; }
    }
}
