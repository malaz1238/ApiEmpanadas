using Empanadas.Data.Entities;

namespace Empanadas.Services.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetById(int id);
        public Product Add(Product product);
        public void Delete(int productId);
    }
}
