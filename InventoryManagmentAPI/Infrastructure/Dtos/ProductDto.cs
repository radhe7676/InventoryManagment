using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentAPI.Infrastructure.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public int ReorderTimeInDays { get; set; }

        [Required]
        public int QuantityInReorder { get; set; }

        public bool Discontinued { get; set; }
    }
}
