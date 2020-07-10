using System;
using System.Collections.Generic;

namespace Nhom2.TMDT.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public string Verification { get; set; }
        public DateTime? ExprireTime { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new HashSet<ShipmentDetail>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Rate> Rates { get; set; } = new HashSet<Rate>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
