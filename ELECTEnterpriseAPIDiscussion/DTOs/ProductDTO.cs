using System.ComponentModel.DataAnnotations;

namespace ELECTEnterpriseAPIDiscussion.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
    
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool InStock => StockQuantity > 0;
        public int Category { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool  IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateProductDto
    {
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        [Required, StringLength(40, MinimumLength = 2)]
        public string Sku { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }

    public class UpdateProductDto
    {
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]    
        public int StockQuantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
