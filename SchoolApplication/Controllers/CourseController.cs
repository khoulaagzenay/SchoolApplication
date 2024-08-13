using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _context;
        public CourseController(ICourseService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var courses = await _context.GetAllCoursesAsync();
            return View(courses.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            var course = await _context.GetCourseByIdAsync(courseId);

            if (course is null) return RedirectToAction(actionName: "List", controllerName: "Course");
            ViewBag.Action = nameof(Edit);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (id == course.Id) await _context.UpdateCourseAsync(course);
            return RedirectToAction(actionName: "List", controllerName: "Course");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = nameof(Add);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            ViewBag.Action = nameof(Add);
            if (!ModelState.IsValid) return View(course);

            await _context.AddCourseAsync(course);
            return RedirectToAction(actionName: "List", controllerName: "Course");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.DeleteCourseAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Course course)
        {
            if (id == course.Id) await _context.DeleteCourseAsync(id);

            return RedirectToAction("List", "Course");
        }
    }
}
