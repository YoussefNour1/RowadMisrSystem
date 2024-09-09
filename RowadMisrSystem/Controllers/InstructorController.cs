using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Controllers;

public class InstructorController : Controller
{
    private readonly IInstructorService _instructorService;
    private readonly IDepartmentService _departmentService;
    private readonly IWebHostEnvironment _environment;

    public InstructorController(IInstructorService instructorService, IDepartmentService departmentService, IWebHostEnvironment environment)
    {
        _instructorService = instructorService;
        _departmentService = departmentService;
        _environment = environment;
    }

    // READ: List all instructors
    public async Task<IActionResult> Index()
    {
        var instructors = await _instructorService.GetAllInstructorsAsync();
        return View(instructors);
    }

    // READ: Get details of a specific instructor
    public async Task<IActionResult> Details(int id)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(id);
        if (instructor == null)
        {
            return NotFound("No instructor found.");
        }
        return View(instructor);
    }

    // CREATE: Show form to create a new instructor
    public async Task<IActionResult> New()
    {
        ViewBag.Departments = new SelectList((await _departmentService.GetAllDepartmentsAsync()).ToList(), "Id", "Name");
        return View();
    }

    // CREATE: Add a new instructor
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Instructor instructor, IFormFile imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                instructor.Image = (await SaveFileAsync(imageFile)).ToString();
            }

            await _instructorService.AddInstructorAsync(instructor);
            return RedirectToAction("Index");
        }
        ViewBag.Departments =new SelectList((await _departmentService.GetAllDepartmentsAsync()).ToList(), "Id", "Name");
        return View("New", instructor);
    }

    // UPDATE: Show form to edit an existing instructor
    public async Task<IActionResult> Edit(int id)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(id);
        if (instructor == null)
        {
            return NotFound("No instructor found.");
        }
        ViewBag.Departments = new SelectList((await _departmentService.GetAllDepartmentsAsync()).ToList(), "Id", "Name" );
        return View(instructor);
    }

    // UPDATE: Update an existing instructor
    [HttpPost]
    public async Task<IActionResult> Update(int InstructorId, [FromForm] Instructor instructor, [FromForm] IFormFile? imageFile)
    {
        if (InstructorId != instructor.InstructorId)
        {
            return BadRequest("Instructor ID mismatch.");
        }

        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                instructor.Image = await SaveFileAsync(imageFile);
            }

            await _instructorService.UpdateInstructorAsync(instructor);
            return RedirectToAction("Index");
        }
        var departments = await _departmentService.GetAllDepartmentsAsync();
        ViewBag.Departments = departments.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.Name
        }).ToList();
        return View("Edit", instructor);
    }

    // DELETE: Show confirmation page for deleting an instructor
    public async Task<IActionResult> Delete(int id)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(id);
        if (instructor == null)
        {
            return NotFound("No instructor found.");
        }
        return View(instructor);
    }

    // DELETE: Confirm deletion of an instructor
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _instructorService.DeleteInstructorAsync(id);
        return RedirectToAction("Index");
    }

    private async Task<string> SaveFileAsync(IFormFile imageFile)
    {
        string uploadsFolder = Path.Combine(_environment.WebRootPath, "images/instructors");
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }
        return uniqueFileName;
    }
}
