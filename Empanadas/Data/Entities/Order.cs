using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empanadas.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<LineOrder> LinesOrders { get; set; } = new List<LineOrder>();

    }
}
