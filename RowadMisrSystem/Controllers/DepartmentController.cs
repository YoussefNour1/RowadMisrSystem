using Microsoft.AspNetCore.Mvc;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Controllers;

public class DepartmentController : Controller
{
    static RowadDbContext context = new RowadDbContext();
    public IActionResult Index()
    {
        var departments = context.Departments.ToList();
        return View(departments);
    }

    public IActionResult Details(int Id)
    {
        Department Dept = context.Departments.FirstOrDefault(d => d.Id == Id)?? new Department { Id = -1, Name="Annon", Manager=-1};
        return View(Dept);
    }
}