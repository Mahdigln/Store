using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.Permissions;
using DataLayer.Entities.User;

namespace Core.DTOs;

public class CreateRolesViewModel
{
    
    public int RoleId { get; set; }

    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد{0}.")]
    public string RoleTitle { get; set; }

    public bool IsDeleted { get; set; }

    public virtual List<UserRole> UserRoles { get; set; }
    public List<RolePermission> RolePermissions { get; set; }

}

public class EditRolesViewModel
{
    
    public int RoleId { get; set; }

    [Display(Name = "عنوان نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد{0}.")]
    public string RoleTitle { get; set; }

    public bool IsDeleted { get; set; }
}