using System.Collections.Generic;

namespace Nhom2.TMDT.Data.Entities
{
    public class ShipmentDetail
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
