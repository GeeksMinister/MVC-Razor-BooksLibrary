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
		var result = await _dbContext.Customer!.ToListAsync();
		return result;
	}

	public async Task<Customer?> GetCustomerById(Guid customerId)
	{
		var result = await _dbContext.Customer!.FirstOrDefaultAsync(c => c.Guid.ToString() == customerId.ToString());
		return result;
	}
	public async Task<List<Book>> GetBorrowedBooks(Guid customerId)
	{
		var result = await _dbContext.Book!.Include(book => book.Customer_Book).ThenInclude(
			customer_book => customer_book.Customer).Where(customer => customer.Guid == customerId).ToListAsync();
		return result;
	}

    public async Task<int> GetBorrowedCount(Guid customerId)
	{
		var result = await _dbContext.Customer_book!.Where(
			c_b => c_b.CustomerId.ToString() == customerId.ToString()).CountAsync();
		return result;
	}




}
