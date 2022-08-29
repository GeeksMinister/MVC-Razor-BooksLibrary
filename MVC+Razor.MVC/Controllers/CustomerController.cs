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
        if (ModelState.IsValid == false) return View(customerDto);

        Customer customer = _mapper.Map<Customer>(customerDto);
        await _repository.InsertCustomer(customer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> UpdateCustomer(Guid id)
    {
        Customer? customer = await _repository.GetCustomerById(id);
        if (customer == null) return NotFound();
        CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
        customerDto.Id = customer.Guid.ToString();
        return View(customerDto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto, Guid id)
    {
        if (ModelState.IsValid == false) return View(customerDto);

        Customer? customer = await _repository.GetCustomerById(id);
        if (customer == null) return NotFound();
        customer = _mapper.Map<Customer>(customerDto);
        customer.Guid = id;
        await _repository.UpdateCustomer(customer);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        Customer? customer = await _repository.GetCustomerById(id);
        if (customer == null) return NotFound();
        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCustomer_Post(Guid id)
    {
        await _repository.DeleteCustomer(id);
        return RedirectToAction(nameof(Index));
    }
}
