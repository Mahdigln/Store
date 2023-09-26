#nullable disable
using Core.Services;
using Core.Services.Interfaces;
using DataLayer.Entities.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Pages.Admin.Courses
{
    public class EditCourseModel : PageModel
    {
        private ICourseService _courseService;

        public EditCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public Course Course { get; set; }


        public void OnGet(int id)
        {
            Course = _courseService.GetCourseById(id);

            var groups = _courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text", Course.GroupId);

            List<SelectListItem> subgroups = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "انتخاب کنید",Value = ""
                }
            };
            subgroups.AddRange(_courseService.GetSubGroupForManageCourse(Course.GroupId));
            string selectedSubGroup = null;
            if (Course.SubGroup != null)
            {
                selectedSubGroup = Course.SubGroup.ToString();
            }
            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text", selectedSubGroup);


            var teacher = _courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList(teacher, "Value", "Text", Course.TeacherId);

            var levels = _courseService.GetLevels();
            ViewData["Levels"] = new SelectList(levels, "Value", "Text", Course.LevelId);

            var statues = _courseService.GetStatus();
            ViewData["Statues"] = new SelectList(statues, "Value", "Text", Course.StatusId);

        }

        public IActionResult OnPost(IFormFile imgCourseUp, IFormFile demoUp) //name should the same in View
        {
            if (!ModelState.IsValid)

                return Page();

            _courseService.UpdateCourse(Course, imgCourseUp, demoUp);

            return RedirectToPage("Index");
        }

    }
}
