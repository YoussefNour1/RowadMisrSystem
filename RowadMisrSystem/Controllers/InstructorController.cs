using Microsoft.AspNetCore.Mvc;
using RowadMisrSystem.Contexts;

namespace RowadMisrSystem.Controllers;

public class InstructorController : Controller
{
    public IActionResult Index()   
    {
        var Context = new RowadDbContext();
        var AllInstructors = Context.Instructors.ToList();
        return View(AllInstructors);
    }
}