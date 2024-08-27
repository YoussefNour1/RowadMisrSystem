using Microsoft.AspNetCore.Mvc;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Controllers;

public class DepartmentController : Controller
{
    static readonly RowadDbContext Context = new ();
    public IActionResult Index()
    {
        var departments = Context.Departments.ToList();
        return View(departments);
    }

    public IActionResult Details(int Id)
    {
        Department Dept = Context.Departments.FirstOrDefault(d => d.Id == Id);
        return View(Dept);
    }
}