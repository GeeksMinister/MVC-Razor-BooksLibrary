namespace MVC_Razor.MVC.DataAccess.Repositories.CustomerRepository;

public interface ICustomerRepository
{
    Task InsertCustomer(Customer customer);
    Task<List<Customer>> GetAllCustomers();
    Task<int> GetBorrowedCount(Guid customerId);
    Task<Customer?> GetCustomerById(Guid customerId);
    Task UpdateCustomer(Customer updated);
    Task DeleteCustomer(Guid customerId);
}