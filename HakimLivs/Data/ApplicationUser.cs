using HakimLivs.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HakimLivs.Data
{
    public class ApplicationUser : IdentityUser
    {
        [RegularExpression("^[a-öA-Ö-].*?$", ErrorMessage = "Bara bokstäver är tillåtna värden."), MaxLength(50)]
        public string firstName { get; set; }

        [RegularExpression("^[a-öA-Ö-].*?$", ErrorMessage = "Bara bokstäver är tillåtna värden."), MaxLength(50)]
        public string lastName { get; set; }

        [RegularExpression("^[a-öA-Ö0-9].*?$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden."), MaxLength(100)]
        public string Address { get; set; }

        [RegularExpression("^[a-öA-Ö0-9].*?$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden."), MaxLength(20)]
        public string Postcode { get; set; }

        [RegularExpression("^[a-öA-Ö-].*?$", ErrorMessage = "Bara bokstäver är tillåtna värden."), MaxLength(100)]
        public string City { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Age { get; set; }

        public List<Discount> UsedDiscounts { get; set; }

    }
}
