namespace HakimLivs.Models
{

    public class BasketProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int BasketID { get; set; }
        public int ProductQuantity { get; set; }

    }


}

