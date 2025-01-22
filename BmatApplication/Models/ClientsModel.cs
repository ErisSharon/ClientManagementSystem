
using System.ComponentModel.DataAnnotations;


namespace BmatApplication.Models
{
    public class ClientsModel
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product is required")]
        [MaxLength(100)]
        public string Product { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(50)]
        public string Status { get; set; }


    }
}
