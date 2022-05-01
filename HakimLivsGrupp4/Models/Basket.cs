using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HakimLivsGrupp4.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public IEnumerable<Product>? ProductList { get; set; }
        public string? Total { get; set; }

        [Required]
        public int UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
