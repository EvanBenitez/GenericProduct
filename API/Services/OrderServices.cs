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
            var orderEntry = _context.Orders.Add(order);

            if(orderEntry == null) return null;

            await _context.SaveChangesAsync();
            return orderEntry.Entity.Id;
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
            oldOrder.OrderedItems = order.OrderedItems ?? oldOrder.OrderedItems;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}