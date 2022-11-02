using API.Models;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProductServices : IProductServices
    {
        private readonly GPContext _context;
        public ProductServices(GPContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<bool> AdjustInventory(int id, int quantity){
            int success = await _context.Database
                .ExecuteSqlInterpolatedAsync($"EXEC spProducts_AdjustQuantity {id}, {quantity}");

            if(success == 1){
                return true;
            }
            return false;
        }

        public async Task<Product?> GetProductById(int id){
            return await _context.Products.FindAsync(id);
        }

        public async Task<int?> AddNewProduct(Product product){
            var newProduct = _context.Products.Add(product);
            await _context.SaveChangesAsync();

            if(newProduct == null) return null;

            return newProduct.Entity.Id;
        }

        public async Task<bool> RemoveProduct(int id){
            Product? product = await _context.Products.FindAsync(id);

            if(product == null) return false;

            var delectedProduct = _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            if(delectedProduct == null) return false;

            return true;
        }
    }
}