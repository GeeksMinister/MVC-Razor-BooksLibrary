namespace MVC_Razor.MVC.DataAccess.Repositories.CustomerRepository;


public interface ICustomerRepository
{
    Task<List<Customer>> GetAllCustomers();
    Task<int> GetBorrowedCount(Guid customerId);
    Task<Customer?> GetCustomerById(Guid customerId);
}