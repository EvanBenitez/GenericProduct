using API.Models;

namespace API.Persistence
{
    public class Seed
    {
        public static async Task SeedData(GPContext context)
        {
            await SeedCatagory(context);
            await SeedProduct(context);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCatagory(GPContext context)
        {
            if(context.Categories.Any()) return;

            var catagories = new List<Category>
            {
                new Category{
                    Name = "Baseball"
                }
            };

            await context.AddRangeAsync(catagories);
        }

        private static async Task SeedProduct(GPContext context){
             if(context.Products.Any()) return;

            var catagory = context.Categories.ToList()[0];
            var products = new List<Product>
            {
                new Product{
                    Name = "Baseball Bat",
                    Price = 34.92,
                    Category = catagory
                },
                 new Product{
                    Name = "Baseball",
                    Price = 7.32,
                    Category = catagory
                },
                 new Product{
                    Name = "Baseball Mit",
                    Price = 76.99,
                    Category = catagory
                },
                 new Product{
                    Name = "Baseball Helmet",
                    Price = 49.99,
                    Category = catagory
                },
            };

            await context.Products.AddRangeAsync(products);
        }
    }
}