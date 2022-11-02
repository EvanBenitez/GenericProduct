using API.Models;

namespace API.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<bool> UpdateCustomer(Customer customer);
        Task<Customer?> GetCustomerById(int id);
        Task<int?> AddNewCustomer(Customer customer);
        Task<bool> RemoveCustomer(int id);
    }
}