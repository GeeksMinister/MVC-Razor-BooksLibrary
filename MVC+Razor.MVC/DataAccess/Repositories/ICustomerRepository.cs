using MVC_Razor.MVC.Models;

namespace MVC_Razor.MVC.DataAccess.Repositories;


public interface ICustomerRepository
{
    Task<List<Customer>> GetAllCustomers();
    Task<List<Book>> GetBorrowedBooks(Guid customerId);
    Task<int> GetBorrowedCount(Guid customerId);
    Task<Customer?> GetCustomerById(Guid customerId);
}