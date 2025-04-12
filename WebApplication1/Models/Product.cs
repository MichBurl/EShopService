using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } // Nazwa produktu
        public string Ean { get; set; } // Kod kreskowy

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; } // Cena produktu

        public int Stock { get; set; } = 0; // Ilość dostępnych sztuk
        public string Sku { get; set; } // SKU

        // Relacja do kategorii
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
