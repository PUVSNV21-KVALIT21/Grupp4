using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HakimLivsGrupp4.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public IEnumerable<BasketProduct>? ProductList { get; set; }
        public string? Total { get; set; }
        public string? DiscountID { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
