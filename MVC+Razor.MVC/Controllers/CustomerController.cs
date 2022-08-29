namespace MVC_Razor.MVC.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

    public IActionResult AddCustomer()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(CustomerDto customerDto)
    {
        if (ModelState.IsValid)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _repository.InsertCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customerDto);
    } 
}
