
using System.ComponentModel.DataAnnotations;


namespace BmatApplication.Models
{
    public class ClientsModel
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Product { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public bool Status { get; set; }

    }
}
