using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal? TotalShipping { get; set; }
        public string PaymentMethod { get; set; }
        public int? ShipmentDetailId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Ordered { get; set; }
        public DateTime? Confirmed { get; set; }
        public DateTime? Transporting { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime? Canceled { get; set; }
        public DateTime? Deleted { get; set; }
        public int? Status { get; set; }

        public virtual User User { get; set; }
        public virtual ShipmentDetail ShipmentDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
