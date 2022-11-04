using API.Models;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly GPContext _context;
        public OrderServices(GPContext context)
        {
            _context = context;

        }
        public async Task<int?> AddNewOrder(Order order)
        {
            Order? newOrder = await CreateOrder(order);
            if(newOrder == null) return null;

            await CreateOrderedItems(order, newOrder.Id);

            return newOrder.Id;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            if(order == null) return null;

            return order;
        }

        public async Task<bool> RemoveOrder(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            if(order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            Order? oldOrder = await _context.Orders.FindAsync(order.Id);

            if(oldOrder == null) return false;

            oldOrder.Customer = order.Customer ?? oldOrder.Customer;
            oldOrder.OrderDate = order.OrderDate;

            if(order.OrderedItems != null){
                var newOrderItems = new List<OrderedItem>();
                foreach(var item in order.OrderedItems){
                    item.OrderId = order.Id;
                    newOrderItems.Add(item);
                }
                oldOrder.OrderedItems = order.OrderedItems;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<Order?> CreateOrder(Order order){
            Order newOrder = new Order{
                Customer = order.Customer,
                OrderDate = order.OrderDate
            };

            var orderEntry = _context.Orders.Add(newOrder);

            if(orderEntry == null) return null;

            await _context.SaveChangesAsync();

            return orderEntry.Entity;
        }

        private async Task CreateOrderedItems(Order order, int id){
            if(order.OrderedItems != null && order.OrderedItems.Count() > 0)
            {
                foreach(var item in order.OrderedItems){
                    item.OrderId = id;
                    _context.OrderedItems.Add(item);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}