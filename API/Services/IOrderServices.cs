using API.Models;

namespace API.Services
{
    public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<bool> UpdateOrder(Order order);
        Task<Order?> GetOrderById(int id);
        Task<int?> AddNewOrder(Order order);
        Task<bool> RemoveOrder(int id);
    }
}