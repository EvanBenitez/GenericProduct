using API.Models;

namespace API.Persistence
{
    public class Seed
    {
        public static async Task SeedData(GPContext context)
        {
            await SeedCatagory(context);
            await SeedAddress(context);
            await SeedProduct(context);
            await SeedCustomer(context);
            await SeedOrder(context);
            await SeedOrderedItems(context);
        }

        private static async Task SeedOrderedItems(GPContext context)
        {
            if(context.OrderedItems.Any()) return;

            var products = context.Products.ToList();
            var orders = context.Orders.ToList();

            var orderedItems = new List<OrderedItem>{
                new OrderedItem {
                    ProductId = products[0].Id,
                    OrderId = orders[0].Id,
                    Quantity = 1
                },
                new OrderedItem {
                    ProductId = products[1].Id,
                    OrderId = orders[0].Id,
                    Quantity = 1
                },
                new OrderedItem {
                    ProductId = products[2].Id,
                    OrderId = orders[1].Id,
                    Quantity = 1
                },
                new OrderedItem {
                    ProductId = products[0].Id,
                    OrderId = orders[2].Id,
                    Quantity = 1
                },
                new OrderedItem {
                    ProductId = products[1].Id,
                    OrderId = orders[3].Id,
                    Quantity = 1
                }
            };

            context.AddRange(orderedItems);
            await context.SaveChangesAsync();
        }

        private static async Task SeedOrder(GPContext context)
        {
            if(context.Orders.Any()) return;

            var customers = context.Customers.ToList();

            var orders = new List<Order>{
                new Order{
                    Customer = customers[0],
                    OrderDate = DateTime.Now,
                    // OrderedItems = new List<OrderedItem>()
                },
                new Order{
                    Customer = customers[1],
                    OrderDate = DateTime.Now,
                    // OrderedItems = new List<OrderedItem>()
                },
                new Order{
                    Customer = customers[0],
                    OrderDate = DateTime.Now,
                    // OrderedItems = new List<OrderedItem>()
                },
                new Order{
                    Customer = customers[2],
                    OrderDate = DateTime.Now,
                    // OrderedItems = new List<OrderedItem>()
                }
            };

            context.AddRange(orders);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAddress(GPContext context)
        {
            if(context.Addresses.Any()) return;

            List<Address> addresses = new List<Address>{
                new Address{
                    StreetAddress = "123 Main St",
                    City = "Heresville",
                    State = "Kentucky",
                    ZipCode = 12345,
                    Country = "USA"
                },
                 new Address{
                    StreetAddress = "543 Side St",
                    City = "Kokoku",
                    State = "Hokkaido",
                    ZipCode = 32132,
                    Country = "Japan"
                },
                 new Address{
                    StreetAddress = "754 Lolipop ln",
                    City = "Gumdrop Burrow",
                    State = "Candyland",
                    ZipCode = 32323,
                    Country = "Hasbro"
                },
                 new Address{
                    StreetAddress = "3089 Gal Blvd",
                    City = "Ryndomville",
                    State = "South Dekota",
                    ZipCode = 19684,
                    Country = "USA"
                }
            };

            await context.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCustomer(GPContext context)
        {
            if(context.Customers.Any()) return;

            var addresses = context.Addresses.ToList();

            List<Customer> customers = new List<Customer>{
                new Customer{
                    FirstName = "John",
                    LastName = "Smith",
                    Address = addresses[0],
                    email = "johnsmith@gmail.com"
                },
                new Customer{
                    FirstName = "Emon",
                    LastName = "Rikisha",
                    Address = addresses[1],
                    email = "erikisha@gmail.com"
                },
                new Customer{
                    FirstName = "Bill",
                    LastName = "Dubaou",
                    Address = addresses[2],
                    email = "dubaoub@gmail.com"
                },
                new Customer{
                    FirstName = "Ken",
                    LastName = "Doe",
                    Address = addresses[3],
                    email = "ken12128@gmail.com"
                },
                new Customer{
                    FirstName = "Shin",
                    LastName = "Doe",
                    Address = addresses[3],
                    email = "shindoe@gmail.com"
                },
            };

            await context.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCatagory(GPContext context)
        {
            if(context.Categories.Any()) return;

            var catagories = new List<Category>
            {
                new Category{
                    Name = "Baseball"
                },
                 new Category{
                    Name = "Hockey"
                },
                 new Category{
                    Name = "Basketball"
                }
            };

            await context.AddRangeAsync(catagories);
            await context.SaveChangesAsync();
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
            await context.SaveChangesAsync();
        }
    }
}