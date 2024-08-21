using Microsoft.AspNetCore.Mvc;

namespace RowadMisrSystem.Controllers;

public class InstructorController : Controller
{
    public IActionResult Index()   
    {
        return View();
    }
}