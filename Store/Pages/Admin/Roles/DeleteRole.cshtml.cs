using Core.Security;
using Core.Services.Interfaces;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Roles;
[PermissionChecker(9)]
public class DeleteRoleModel : PageModel
{
    private IPermissionService _permissionService;

    public DeleteRoleModel(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    [BindProperty]
    public Role Role { get; set; }
    public void OnGet(int id)
    {
        Role = _permissionService.GetRoleById(id);
    }

    public IActionResult OnPost()
    {
        _permissionService.DeleteRole(Role);

        return RedirectToPage("Index");
    }
}

