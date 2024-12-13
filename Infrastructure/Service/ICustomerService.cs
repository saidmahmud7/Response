using Domain.Model;

namespace Infrastructure.Service;

public interface ICustomerService
{
    List<Customer> GetCustomers();
    bool CreateCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(int id);
}