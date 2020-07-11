using System;

namespace Nhom2.TMDT.Data.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int? RatePoint { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
