using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Permissions;

namespace DataLayer.Entities.User
{
    public class Role
    {
        public Role()
        {
            
        }
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "نمیتواند بیشتر از {1} کاراکتر باشد{0}.")]
        public string RoleTitle { get; set; }

        public bool IsDeleted { get; set; }
        #region Relation

        public virtual List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
