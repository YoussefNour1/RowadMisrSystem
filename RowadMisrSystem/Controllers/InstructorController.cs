using Microsoft.AspNetCore.Mvc;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Controllers;

public class InstructorController : Controller
{
    static readonly RowadDbContext Context = new ();
    public IActionResult Index()   
    {
        var AllInstructors = Context.Instructors.ToList();
        return View(AllInstructors);
    }

    public IActionResult Details(int Id)
    {
        var Instructor = Context.Instructors.FirstOrDefault(Ins => Ins.InstructorId == Id);
        return View(Instructor);
    }
    public IActionResult Add(Instructor instructor)
    {
        if (instructor != null)
        {
            Context.Instructors.Add(instructor);
            Context.SaveChanges();
            return RedirectToAction(nameof(Details), nameof(InstructorController), new { Id = instructor.InstructorId });
        }
        return View();
    }
}