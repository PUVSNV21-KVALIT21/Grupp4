using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HakimLivs.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett namn på produkten.")]
        [Display(Name = "Produktnamn")]
        [MaxLength(30, ErrorMessage = "Namnet får inte innehålla fler än 30 tecken.") ,MinLength(2, ErrorMessage = "Namnet måste innehålla minst 2 tecken.")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden.")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Unit { get; set; }
        [Required]
        public string UnitType { get; set; }
        [Required]
        public string TableOfContent { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public bool IsVegan { get; set; }

        public bool IsGlutenfree { get; set; }

        public bool IsEco { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string ImgPath { get; set; }
    }
}
