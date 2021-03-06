﻿namespace MassMarket.Domain.Entities {

    public class Image {

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string MimeType { get; set; }

        public virtual Product Product { get; set; }
    }
}
