using Microsoft.AspNetCore.Mvc;

namespace RowadMisrSystem.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        return Content("<h1> This is an index for the course</h1>");
    }
}