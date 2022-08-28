namespace MVC_Razor.MVC.DataAccess.Repositories.BookRepository;

public interface IBookRepository
{
    Task<List<Book>> GetBorrowedBooks(Guid customerId);
}