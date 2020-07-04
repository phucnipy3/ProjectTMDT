using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2.TMDT.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? ProductID { get; set; }
        public int? ParentID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
    }
}
