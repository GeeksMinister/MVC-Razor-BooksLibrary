namespace MVC_Razor.MVC.Controllers;
public class BookController : Controller
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> GetBorrowedBooks(Guid id)
    {
        var result = await _repository.GetBorrowedBooks(id);
        return View("BorrowedBooks", result);
    }
}
