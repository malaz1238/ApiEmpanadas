using System.Drawing;
using Empanadas.Data.Entities;

namespace Empanadas.Data.ProductDto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Taste> Tastes { get; set; } = new List<Taste>();
    }
}
