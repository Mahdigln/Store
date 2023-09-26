using Core.DTOs;
using Core.Security;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Users
{
    [PermissionChecker(5)]
    public class DeleteUserModel : PageModel
    {
        private IUserService _usrService;

        public DeleteUserModel(IUserService usrService)
        {
            _usrService = usrService;
        }

        public InformationUserViewModel InformationUserViewModel { get; set; }

        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            InformationUserViewModel = _usrService.GetUserInformation(id);
        }

        public IActionResult OnPost(int UserId)
        {
            _usrService.DeleteUser(UserId);
            return RedirectToPage("Index");
        }
    }
}
