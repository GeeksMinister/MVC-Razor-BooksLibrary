using Microsoft.EntityFrameworkCore;
using MVC_Razor.MVC.DataAccess.Data;
using MVC_Razor.MVC.Models;

namespace MVC_Razor.MVC.DataAccess.Repositories;


public class CustomerRepository : ICustomerRepository
{
	private readonly MVCwithRazorDbContext _dbContext;

	public CustomerRepository(MVCwithRazorDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Customer>> GetAllCustomers()
	{
		var result = await _dbContext.Customer!.Include(customer => customer.Customer_Book).ToListAsync();
		return result;
	}

	public async Task<List<Book>> GetBorrowedBooks(Guid customerId)
	{
		var result = await _dbContext.Book!.Include(book => book.Customer_Book).ThenInclude(
			customer_book => customer_book.Customer).Where(customer => customer.Guid == customerId).ToListAsync();
		return result;
	}
}
