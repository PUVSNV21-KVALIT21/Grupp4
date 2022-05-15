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
        [RegularExpression("^[a-öA-Ö0-9 ]*$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vänligen ange produktens tillverkare.")]
        [MaxLength(30, ErrorMessage = "Namnet får inte innehålla fler än 30 tecken."), MinLength(2, ErrorMessage = "Namnet måste innehålla minst 2 tecken.")]
        [RegularExpression("^[a-öA-Ö0-9 ]*$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Vänligen ange produktens tillverkare.")]
        [MaxLength(500, ErrorMessage = "Beskrivningen får inte innehålla fler än 500 tecken."), MinLength(2, ErrorMessage = "Namnet måste innehålla minst 3 tecken.")]
        [RegularExpression("^[a-öA-Ö0-9_-].*?$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden.")]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Värdet får inte vara lägre än 1 eller högre än 1000")]
        public int UnitQty { get; set; }
     
        [Required]
        public int UnitID { get; set; }
        public Unit Unit { get; set; }

        [Required(ErrorMessage = "Vänligen ange produktens innehållsförteckning.")]
        [MaxLength(1000, ErrorMessage = "Beskrivningen får inte innehålla fler än 1000 tecken."), MinLength(2, ErrorMessage = "Namnet måste innehålla minst 3 tecken.")]
        [RegularExpression("^[a-öA-Ö0-9_-].*?$", ErrorMessage = "Bara bokstäver och siffror är tillåtna värden.")]
        public string TableOfContent { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1.00, 1000.00, ErrorMessage = "Priset får inte vara lägregit än 1kr och inte högre än 1000kr")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public bool IsVegan { get; set; }

        public bool IsGlutenfree { get; set; }

        public bool IsEco { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Lagersaldot får inte vara lägre än 0 och inte högre än 10 000 produkter")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Vänligen ange sökvägen till produktens bild.")]
        [MaxLength(30, ErrorMessage = "Beskrivningen får inte innehålla fler än 500 tecken."), MinLength(3, ErrorMessage = "Namnet måste innehålla minst 3 tecken.")]
        [RegularExpression("^(?!.*([<>{}\"\\[\\]])).*$", ErrorMessage = "Det ser ut som du försöker skriva in kod. Ajabaja!")]
        public string ImgPath { get; set; }
    }
}
