using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _context;
        public StudentController(IStudentService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _context.GetAllStudentsAsync();
            return View(students.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int studentId)
        {
            var student = await _context.GetStudentByIdAsync(studentId);

            if (student is null) return RedirectToAction(actionName: "List", controllerName: "Student");
            ViewBag.Action = nameof(Edit);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id == student.Id) await _context.UpdateStudentAsync(student);
            return RedirectToAction(actionName: "List", controllerName: "Student");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = nameof(Add);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            ViewBag.Action = nameof(Add);
            if (!ModelState.IsValid) return View(student);

            await _context.AddStudentAsync(student);
            return RedirectToAction(actionName: "List", controllerName: "Student");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.DeleteStudentAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Student student)
        {
            if (id == student.Id) await _context.DeleteStudentAsync(id);

            return RedirectToAction("List", "Student");
        }


    }
}
