using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTools.Models
{
    public class Product
    {

        public Product()
        {
            this.Users = new HashSet<User>();
        }
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        public double percentageOfDiscount { get; set; } = 1;

        [Required]
        public int? categoryID { get; set; }

        [ForeignKey("categoryID")]
        public virtual Category Category { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<FeedbackForProduct> FeedbackForProducts { get; set; }

    }
}
