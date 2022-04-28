
using System.ComponentModel.DataAnnotations.Schema;

namespace HakimLivsGrupp4.Models
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
        public string Category { get; set; }
        public int Stock { get; set; }
        public string ImgPath { get; set; }
    }
}
