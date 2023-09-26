using Core.DTOs;
using Core.Security;
using Core.Services.Interfaces;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Roles;
[PermissionChecker(7)]
public class CreateRoleModel : PageModel
{
    private IPermissionService _permissionService;

    public CreateRoleModel(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    //[BindProperty] 
    //public CreateRolesViewModel Role { get; set; }

    [BindProperty]
    public Role Role { get; set; }
    public void OnGet()
    {
        ViewData["Permission"] = _permissionService.GetAllPermission();
    }

    public IActionResult OnPost(List<int> SelectedPermission)
    {
        
        if (!ModelState.IsValid)
            return Page();


        Role.IsDeleted = false;

        //int roleId = _permissionService.AddRollFromAdmin(Role);
        int roleId = _permissionService.AddRole(Role);
        _permissionService.AddPermissionsToRole(roleId,SelectedPermission);


        return RedirectToPage("Index");

    }
}

