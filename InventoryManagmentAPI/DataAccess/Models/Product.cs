namespace InventoryManagmentAPI.DataAccess.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int QuantityInStock { get; set; }

        public double Value { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderTimeInDays { get; set; }

        public int QuantityInReorder { get; set; }

        public bool Discontinued { get; set; }
    }
}
