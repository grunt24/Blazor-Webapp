using System.ComponentModel.DataAnnotations;

namespace CoreEntities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }

        public List<Product> Products { get; set; }

    }
}