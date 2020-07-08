namespace Nhom2.TMDT.Service.Product.ViewModels
{
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string Tag { get; set; }
    }
}
