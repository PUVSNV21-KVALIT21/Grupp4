using System.ComponentModel.DataAnnotations.Schema;

namespace HakimLivs.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public string UnitType { get; set; }
        public string TableOfContent { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenfree { get; set; }
        public bool IsEco { get; set; }
        public int CategoryID { get; set; }
        public int Stock { get; set; }
        public string ImgPath { get; set; }
    }
}
