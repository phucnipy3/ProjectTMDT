namespace Nhom2.TMDT.Service.Order.ViewModels
{
    public class DeliveryMethodViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost
        {
            get
            {
                return Id * 6000;
            }
        }
    }
}
