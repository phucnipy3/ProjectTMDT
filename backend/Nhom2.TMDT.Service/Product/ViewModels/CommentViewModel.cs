using System.Collections.Generic;

namespace Nhom2.TMDT.Service.Product.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public List<CommentViewModel> Children { get; set; }
        public bool CanDelete { get; set; }
        public bool Manager { get; set; }
    }
}
