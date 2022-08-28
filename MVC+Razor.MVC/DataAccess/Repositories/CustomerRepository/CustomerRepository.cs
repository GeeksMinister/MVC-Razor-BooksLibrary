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
        var result = await _dbContext.Customer!.FirstOrDefaultAsync(c => c.Guid.ToString() == customerId.ToString());
        return result;
    }

    public async Task<int> GetBorrowedCount(Guid customerId)
    {
        var result = await _dbContext.Customer_book!.Where(
            c_b => c_b.CustomerId.ToString() == customerId.ToString()).CountAsync();
        return result;
    }




}
