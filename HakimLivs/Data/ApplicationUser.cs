using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HakimLivs.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Age { get; set; }
    }
}
