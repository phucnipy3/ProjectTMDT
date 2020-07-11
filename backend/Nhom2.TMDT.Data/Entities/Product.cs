using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Quantity { get; set; }
        public string Detail { get; set; }
        public int? Warranty { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
        public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual Category Category { get; set; }
    }
}
