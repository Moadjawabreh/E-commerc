using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTools.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int Quantity { get; set; } = 1;
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int productId { get; set; }
        [ForeignKey("productId")]
        public Product product { get; set; }

    }
}
