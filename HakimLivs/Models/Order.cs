namespace HakimLivs.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Basket Basket { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Orderdate { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryAdress { get; set; }
    }
}