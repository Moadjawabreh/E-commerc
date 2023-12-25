using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicalTools.Models
{
    public enum Role
    {
        Admin,
        User
    }
    public class User
    {
        public User()
        {
            this.Products = new HashSet<Product>();
        }
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string locationUrl { get; set; }

        [Required]
        public Role Role { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<FeedbackForProduct> FeedbackForProducts { get; set; }

        public ICollection<FeedbackForWeb> FeedbackForWebs { get; set; }

    }
}
