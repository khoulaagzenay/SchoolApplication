using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolApplication.Models
{
    public class GradeViewModel
    {

        public Grade Grade { get; set; } = new Grade();

        public IEnumerable<SelectListItem>? Students { get; set; }

        public IEnumerable<SelectListItem>? Courses { get; set; }
    }
}
