using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HakimLivs.Models
{
    public class UserFavoriteProduct
    {
        public int Id { get; set; }

        [Display(Name = "Produkt")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Användare")]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
