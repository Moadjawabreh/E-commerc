using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTools.Models
{
    public class Image
    {
        public int ID { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [ForeignKey("productID")]
        public int productID { get; set; }
        public virtual Product Product { get; set; }
    }
}
