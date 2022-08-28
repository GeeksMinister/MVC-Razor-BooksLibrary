using MVC_Razor.MVC.Models;

namespace MVC_Razor.MVC.DataAccess.Repositories;


public interface ICustomerRepository
{
    Task<List<Customer>> GetAllCustomers();
    Task<List<Book>> GetBorrowedBooks(Guid customerId);
}