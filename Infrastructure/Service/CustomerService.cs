using Dapper;
using Domain.Model;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class CustomerService(DapperContext _context) : ICustomerService
{
    public List<Customer> GetCustomers()
    {
        using var context = _context.Connection();
        var sql = "select * from customers";
        var res = context.Query<Customer>(sql).ToList();
        return res;
    }

    public bool CreateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var sql = @"insert into customers (fullname,phone,email) 
                    values (@fullname,@phone,@email)";
        var res = context.Execute(sql, customer);
        return res > 0;
    }

    public bool UpdateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var sql = @"update customers set fullname = @fullname,phone=@phone,email=@email
                     where CustomerId = @Id";
        var res = context.Execute(sql, customer);
        return res > 0; 
    }

    public bool DeleteCustomer(int id)
    {
        using var context = _context.Connection();
        var cmd = "delete from customers where CustomerId = @Id";
        var response = context.Execute(cmd, new {Id = id});
        return response != 0;
    }
}