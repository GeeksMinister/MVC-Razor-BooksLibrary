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
        try
        {
            var result = await _repository.GetAllCustomers();
            if (result is null) return NoContent();
            return View(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status204NoContent, "Failed to retrive data from server");
        }
    }

    public async Task<IActionResult> CustomerDetails(Guid id)
    {
        try
        {
            var result = await _repository.GetCustomerById(id);
            return View(result);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    public IActionResult AddCustomer()
    {
        try
        {
            return View();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(CustomerDto customerDto)
    {
        try
        {
            if (ModelState.IsValid == false) return View(customerDto);

            Customer customer = _mapper.Map<Customer>(customerDto);
            await _repository.InsertCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    public async Task<IActionResult> UpdateCustomer(Guid id)
    {
        try
        {
            Customer? customer = await _repository.GetCustomerById(id);
            if (customer == null) return NotFound();
            CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);
            customerDto.Id = customer.Guid.ToString();
            return View(customerDto);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto, Guid id)
    {
        try
        {
            if (ModelState.IsValid == false) return View(customerDto);

            Customer? customer = await _repository.GetCustomerById(id);
            if (customer == null) return NotFound();
            customer = _mapper.Map<Customer>(customerDto);
            customer.Guid = id;
            await _repository.UpdateCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            Customer? customer = await _repository.GetCustomerById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCustomer_Post(Guid id)
    {
        try
        {
            await _repository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
