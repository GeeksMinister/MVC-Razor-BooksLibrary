namespace MVC_Razor.MVC.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _repository.GetAllCustomers();
        return View(result);
    }

    public async Task<IActionResult> CustomerBorrowedBooks(Guid guid)
    {
        var result = await _repository.GetBorrowedBooks(guid);
        return View(result);
    }
}
