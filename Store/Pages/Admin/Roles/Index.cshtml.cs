using System.Security.Cryptography.X509Certificates;
using Core.Security;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.Pages.Admin.Roles;
[PermissionChecker(6)]
public class IndexModel : PageModel
{
    private IPermissionService _permissionService;

    public IndexModel(IPermissionService permissionService)
    {
        _permissionService = permissionService;

    }

    public List<DataLayer.Entities.User.Role> RoleList { get; set; }
    public void OnGet()
    {
        RoleList = _permissionService.GetRoles();
    }
}

