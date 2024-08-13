using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolApplication.Models;
using SchoolApplication.Repositories.Interfaces;

namespace SchoolApplication.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _contextGrade;
        private readonly IStudentService _contextStudent;
        private readonly ICourseService _contextCourse;

        public GradeController(IGradeService contextGrade, IStudentService contextStudent, ICourseService contextCourse)
        {
            _contextGrade = contextGrade;
            _contextCourse = contextCourse;
            _contextStudent = contextStudent;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var grades = await _contextGrade.GetAllGradesAsync(true);
            return View(grades.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var grade = await _contextGrade.GetGradeByIdAsync(id, true);

            if (grade is null) return RedirectToAction(actionName: "List", controllerName: "Grade");

            ViewBag.Action = nameof(Edit);
            var viewModel = await InitModel(grade);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GradeViewModel gradeViewModel)
        {
            if (ModelState.IsValid && id == gradeViewModel.Grade.Id)
            {
                await _contextGrade.UpdateGradeAsync(gradeViewModel.Grade);
                return RedirectToAction(actionName: "List", controllerName: "Grade");
            }

            ViewBag.Action = nameof(Edit);
            // Reload the dropdown lists if the model state is invalid
            var viewModel = await InitModel(gradeViewModel.Grade);
            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Action = nameof(Add);
            var viewModel = await InitModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GradeViewModel gradeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _contextGrade.AddGradeAsync(gradeViewModel.Grade);
                return RedirectToAction(actionName: "List", controllerName: "Grade");
            }

            ViewBag.Action = nameof(Add);
            // Reload the dropdown lists if the model state is invalid
            var viewModel = await InitModel(gradeViewModel.Grade);
            return View(viewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _contextGrade.DeleteGradeAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Grade grade)
        {
            if (id == grade.Id) await _contextGrade.DeleteGradeAsync(id);

            return RedirectToAction("List", "Grade");
        }

        private async Task<GradeViewModel> InitModel(Grade? grade = null)
        {
            var students = await _contextStudent.GetAllStudentsAsync();
            var courses = await _contextCourse.GetAllCoursesAsync();

            var studentSelectList = students.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            var courseSelectList = courses.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            var viewModel = new GradeViewModel
            {
                Students = studentSelectList,
                Courses = courseSelectList,
                Grade = grade ?? new Grade()
            };
            return viewModel;
        }
    }
}
