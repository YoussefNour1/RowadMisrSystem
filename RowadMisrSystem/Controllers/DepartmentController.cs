
using Microsoft.AspNetCore.Mvc;
using RowadMisrSystem.Interfaces;
using RowadMisrSystem.Models;
using System;
using System.Threading.Tasks;

namespace RowadMisrSystem.Controllers;
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    private readonly IInstructorService _instructorService;

    public DepartmentController(IDepartmentService departmentService, IInstructorService instructorService)
    {
        _departmentService = departmentService;
        _instructorService = instructorService;
    }

    // READ: List all departments
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return View(departments);
    }

    // READ: Get details of a specific department
    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
        {
            return NotFound("No department found.");
        }

        ViewBag.Manager = await _instructorService.GetInstructorByIdAsync((int)department.Manager!);
        ViewBag.Instructors = (await _instructorService.GetAllInstructorsAsync()).Where(I => I.DepartmentId == id).ToList();
        return View(department);
    }

    // CREATE: Show form to create a new department
    public IActionResult New() => View();

    // CREATE: Add a new department
    [HttpPost]
    public async Task<IActionResult> Add(Department department)
    {
        if (ModelState.IsValid)
        {
            await _departmentService.AddDepartmentAsync(department);
            return RedirectToAction("Index");
        }
        return View("New", department);
    }

    // UPDATE: Show form to edit an existing department
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        return department == null? NotFound("No department found."): View(department);
    }

    // UPDATE: Update an existing department
    [HttpPost]
    public async Task<IActionResult> Update(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest("Department ID mismatch.");
        }

        if (ModelState.IsValid)
        {
            await _departmentService.UpdateDepartmentAsync(department);
            return RedirectToAction("Index");
        }
        return View("Edit", department);
    }

    // DELETE: Delete a department
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        if (department == null)
        {
            return NotFound("No department found.");
        }

        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _departmentService.DeleteDepartmentAsync(id);
        return RedirectToAction("Index");
    }
}