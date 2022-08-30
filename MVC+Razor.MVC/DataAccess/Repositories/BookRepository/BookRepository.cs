namespace MVC_Razor.MVC.DataAccess.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly MVCwithRazorDbContext _dbContext;

    public BookRepository(MVCwithRazorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetBorrowedBooks(Guid customerId)
    {
        var result = await (from customer_book in _dbContext.Customer_book
                            where customer_book.CustomerId.Equals(customerId)
                            select customer_book.Book).ToListAsync();
        return result;
    }
}
