using System.Data;
using Core.DTOs;
using DataLayer.Entities.Permissions;
using DataLayer.Entities.User;

namespace Core.Services.Interfaces;

public interface IPermissionService
{
    #region Roles
    List<Role> GetRoles();
    int AddRole(Role role);
    void AddRolesToUser(List<int> roleIds, int userId);
    void EditRolesUser(int userId, List<int> rolesId);
    int AddRollFromAdmin(CreateRolesViewModel roll);
    Role GetRoleById(int roleId);
    void UpdateRole(Role role);
    EditRolesViewModel GetRolesForShowInEditMode(int roleId);
    void EditRolesFromAdmin(EditRolesViewModel editRoles);
    void DeleteRole(Role role);
    #endregion

    #region Permission

    List<Permission> GetAllPermission();
    void AddPermissionsToRole(int roleId, List<int> permission);
    List<int> PermissionsRole(int roleId);
    void UpdatePermissionsRole(int roleId, List<int> permissions);
    bool CheckPermission(int permissionId,string userName);
    #endregion
}