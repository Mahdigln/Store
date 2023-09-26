using Core.DTOs;
using Core.Security;
using Core.Services.Interfaces;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Roles
{
    [PermissionChecker(8)]
    public class EditRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        //[BindProperty] 
        //public Role Role { get; set; }
        [BindProperty]
        public EditRolesViewModel EditRole { get; set; }
       

        public void OnGet(int id)
        {
            //Role = _permissionService.GetRoleById(id);
            EditRole = _permissionService.GetRolesForShowInEditMode(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);

        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
                return Page();

           
           _permissionService.EditRolesFromAdmin(EditRole);
            //_permissionService.UpdateRole(Role);
            _permissionService.UpdatePermissionsRole(EditRole.RoleId, SelectedPermission);
            return RedirectToPage("Index");

        }
    }
}
