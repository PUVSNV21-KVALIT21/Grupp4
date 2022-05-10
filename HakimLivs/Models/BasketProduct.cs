using System.ComponentModel.DataAnnotations;

namespace HakimLivs.Models
{

    public class BasketProduct
    {
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Basket Basket { get; set; }

        public int ProductQuantity { get; set; }
    }


}
