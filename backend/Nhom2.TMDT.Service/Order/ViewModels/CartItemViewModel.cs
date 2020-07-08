﻿namespace Nhom2.TMDT.Service.Order.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
    }
}
