using Core.DTOs.Course;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Courses
{
    public class IndexModel : PageModel
    {
        private ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public List<ShowCourseForAdminViewModel> ListCourse { get; set; }
        public void OnGet()
        {
            ListCourse = _courseService.GetCourseForAdmin();
        }
    }
}
