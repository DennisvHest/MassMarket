namespace MassMarket.Domain.Entities {

    public class ProductMetaField {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MetaFieldId { get; set; }
        public int OptionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual MetaField MetaField { get; set; }
        public virtual MetaFieldOption Option { get; set; }
    }
}
