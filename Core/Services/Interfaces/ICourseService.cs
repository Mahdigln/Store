using Core.DTOs.Course;
using DataLayer.Entities.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Services.Interfaces;

public interface ICourseService
{
    #region group
    List<CourseGroup> GetAllGroup();
    List<SelectListItem> GetGroupForManageCourse();
    List<SelectListItem> GetSubGroupForManageCourse(int groupId);
    List<SelectListItem> GetTeachers();
    List<SelectListItem> GetLevels();
    List<SelectListItem> GetStatus();


    CourseGroup GetById(int groupId);
    void AddGroup(CourseGroup group);
    void UpdateGroup(CourseGroup group);

    #endregion


    #region Course

    int AddCourse(Course course, IFormFile imgCourse, IFormFile courseDemo);
    List<ShowCourseForAdminViewModel> GetCourseForAdmin();
    Course GetCourseById(int courseId);
    void UpdateCourse(Course course, IFormFile imgCourse, IFormFile courseDemo);

    Tuple<List<ShowCourseListItemViewModel>, int> GetCourse(int pageId = 1, string filter = ""
        , string getType = "all", string orderByType = "date",
        int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0);
    List<ShowCourseListItemViewModel> GetPopularCourse();

    Course GetCourseForShow(int courseId);
    bool IsFree(int courseId);
    #endregion

    #region Course Vote
    void AddsVote(int userId, int courseId, bool vote);
    Tuple<int, int> GetCourseVote(int courseId);

    #endregion

    #region Episode
    List<CourseEpisode> GetListEpisodeCourse(int courseId);
    bool CheckExistFile(string fileName);
    int AddEpisode(CourseEpisode episode, IFormFile episodeFile);
    CourseEpisode GetEpisodeById(int episodeId);
    void EditEpisode(CourseEpisode episode, IFormFile episodeFile);

    #endregion

    #region Comments

    void AddComment(CourseComment comment);
    Tuple<List<CourseComment>, int> GetCourseComment(int courseId, int pageId = 1);

    #endregion



}