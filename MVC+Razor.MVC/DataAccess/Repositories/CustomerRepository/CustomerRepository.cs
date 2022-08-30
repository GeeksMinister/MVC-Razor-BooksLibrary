namespace MVC_Razor.MVC.DataAccess.Repositories.CustomerRepository;

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
        var result = await _dbContext.Customer!.FirstOrDefaultAsync(
            c => c.Guid.Equals(customerId));
        return result;
    }

    public async Task<int> GetBorrowedCount(Guid customerId)
    {
        var result = await _dbContext.Customer_book!.Where(
            customer_book => customer_book.CustomerId.Equals(customerId)).CountAsync();
        return result;
    }

    public async Task InsertCustomer(Customer customer)
    {
        await _dbContext.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCustomer(Customer updated)
    {
        var customer = await _dbContext.Customer!.FirstOrDefaultAsync(
            c => c.Guid.Equals(updated.Guid));
        if (customer == null) return;
        customer.FirstName = updated.FirstName;
        customer.LastName = updated.LastName;
        customer.Birthdate = updated.Birthdate;
        customer.Email = updated.Email;
        customer.Phone = updated.Phone;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomer(Guid customerId)
    {
        var customer = await _dbContext.Customer!.FirstOrDefaultAsync(
        c => c.Guid.Equals(customerId));
        if (customer == null) return;
        _dbContext.Customer!.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }

}
