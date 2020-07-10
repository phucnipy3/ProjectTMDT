namespace Nhom2.TMDT.Service.Product.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string SavePersent
        {
            get
            {
                if (Price != 0)
                {
                    return ((1 - PromotionPrice.GetValueOrDefault() / Price) * 100).ToString("##,##\\%");
                }
                return "0";
            }
        }
        public string Detail { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
    }
}
