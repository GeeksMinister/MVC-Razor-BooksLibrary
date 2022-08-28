using Microsoft.AspNetCore.Mvc;
using MVC_Razor.MVC.DataAccess.Repositories;
using MVC_Razor.MVC.Models;

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
}
