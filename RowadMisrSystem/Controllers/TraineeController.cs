using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RowadMisrSystem.Contexts;
using RowadMisrSystem.Models;

namespace RowadMisrSystem.Controllers
{
    [Controller]
    [Route("trainees")]
    public class TraineeController : Controller
    {
        readonly RowadDbContext _context;
        readonly IWebHostEnvironment _environment;
        public TraineeController(RowadDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {   
            var Trainees = _context.Students.ToList();
            return View(Trainees);
        }

        [HttpGet("details/{TraineeId}")]
        public IActionResult Details(int TraineeId)
        {
            return View(_context.Students.FirstOrDefault(T => T.TraineeId == TraineeId));
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost("new")]
        public IActionResult Add(Trainee trainee,[FromForm] IFormFile? ImageFile)
        {

            if (ModelState.IsValid) {
                if (ImageFile !=null)
                {
                    string UploadsFolder = Path.Combine(_environment.WebRootPath + "images/trainees");
                    string UniqueFileName = Guid.NewGuid().ToString()+'_'+ImageFile.FileName;
                    string FilePath = Path.Combine(UploadsFolder, UniqueFileName);
                    using (FileStream f = new(FilePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(f);
                    }
                    trainee.Image = UniqueFileName;
                }
                
                _context.Students.Add(trainee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } 
            return View("New", trainee);
        }

    }
}
