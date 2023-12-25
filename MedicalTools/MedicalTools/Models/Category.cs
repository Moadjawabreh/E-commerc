using System.ComponentModel.DataAnnotations;

namespace MedicalTools.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
