using MVC_Razor.MVC.DataAccess.Repositories.CustomerRepository;

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

    public async Task<IActionResult> CustomerDetails(Guid id)
    {
        var result = await _repository.GetCustomerById(id);
        return View(result);
    }


}
