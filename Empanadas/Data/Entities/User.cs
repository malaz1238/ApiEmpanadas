using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empanadas.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }

        [Required]
        public string? UserType { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
