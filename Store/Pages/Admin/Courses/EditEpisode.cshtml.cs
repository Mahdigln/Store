using Core.Services.Interfaces;
using DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Courses
{
    public class EditEpisodeModel : PageModel
    {
        private ICourseService _courseService;

        public EditEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }
        public void OnGet(int id)
        {
            CourseEpisode = _courseService.GetEpisodeById(id);
        }

        public IActionResult OnPost(IFormFile fileEpisode)//name should the same in view
        {
            if (!ModelState.IsValid)
                return Page();

            if (fileEpisode != null)
            {
                if (_courseService.CheckExistFile(fileEpisode.FileName))
                {
                    ViewData["IsExistFile"] = true;
                    return Page();

                }
            }

            _courseService.EditEpisode(CourseEpisode, fileEpisode);

            return Redirect("/Admin/Courses/IndexEpisode/" + CourseEpisode.CourseId);
        }

    }
}
