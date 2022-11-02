using API.Models;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly GPContext _context;
        public CustomerServices(GPContext context)
        {
            _context = context;

        }
        public async Task<int?> AddNewCustomer(Customer customer)
        {
            var newCustomer = _context.Customers.Add(customer);

            // add address checking logic

            if(newCustomer == null) return null;

            await _context.SaveChangesAsync();

            return newCustomer.Entity.Id;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);

            if(customer == null) return null;

            return customer;
        }

        public async Task<bool> RemoveCustomer(int id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);

            if(customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            Customer? oldCustomer = await _context.Customers.FindAsync(customer.Id);
            
            if(oldCustomer == null) return false;

            oldCustomer.Address = customer.Address ?? oldCustomer.Address;
            oldCustomer.email = customer.email ?? oldCustomer.email;
            oldCustomer.FirstName = customer.FirstName ?? oldCustomer.FirstName;
            oldCustomer.LastName = customer.LastName ?? oldCustomer.LastName;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}