using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTools.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string card { get; set; }
        [Required]
        public string password { get; set; }
        public double Total { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }

    }
}
