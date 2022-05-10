using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HakimLivs.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public Discount Discount { get; set; }

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}