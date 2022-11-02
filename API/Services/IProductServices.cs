using API.Models;

namespace API.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<bool> AdjustInventory(int id, int quantity);
        Task<Product?> GetProductById(int id);
        Task<int?> AddNewProduct(Product product);
        Task<bool> RemoveProduct(int id);
    }
}