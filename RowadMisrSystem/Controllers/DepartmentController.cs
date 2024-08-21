using Microsoft.AspNetCore.Mvc;

namespace RowadMisrSystem.Controllers;

public class DepartmentController : Controller
{
    public IActionResult Index()
    {
        return Content("this is index for Department");
    }
}