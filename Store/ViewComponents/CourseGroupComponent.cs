using Core.Services;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Store.ViewComponents;

public class CourseGroupComponent : ViewComponent
{
    private ICourseService _courseService;

    public CourseGroupComponent(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult((IViewComponentResult) View("CourseGroup"
        ,_courseService.GetAllGroup()));
    }
}