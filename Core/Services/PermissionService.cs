using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Context;
using DataLayer.Entities.Permissions;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class PermissionService : IPermissionService
{
    private StoreContext _context;

    public PermissionService(StoreContext context)
    {
        _context = context;
    }
    public List<Role> GetRoles()
    {
        return _context.Roles.ToList();
    }

    public void AddRolesToUser(List<int> roleIds, int userId)
    {
        foreach (int roleId in roleIds)
        {
            _context.UserRoles.Add(new UserRole()
            {
                RoleId = roleId,
                UserId = userId
            });
        }

        _context.SaveChanges();

    }

    public void EditRolesUser(int userId, List<int> rolesId)
    {
        //Delete All Roles User
        _context.UserRoles.Where(r => r.UserId == userId).ToList()
            .ForEach(r => _context.UserRoles.Remove(r));

        //Add New Roles
        AddRolesToUser(rolesId, userId);
    }

    public int AddRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
        return role.RoleId;
    }

    public int AddRollFromAdmin(CreateRolesViewModel roll)
    {
        Role AddRole = new Role();
        AddRole.RoleTitle = roll.RoleTitle;
        AddRole.RoleId = roll.RoleId;
        AddRole.IsDeleted = roll.IsDeleted;

        

        _context.Roles.Add(AddRole);
        _context.SaveChanges();
       return roll.RoleId;
       
    }


    public Role GetRoleById(int roleId)
    {
        return _context.Roles.Find(roleId);
    }

    public void UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }

    public EditRolesViewModel GetRolesForShowInEditMode(int roleId)
    {
        return _context.Roles.Where(r => r.RoleId == roleId)
            .Select(r => new EditRolesViewModel()
            {
                RoleId = r.RoleId,
                RoleTitle = r.RoleTitle,
                IsDeleted = r.IsDeleted
            }).First();
    }

    public void EditRolesFromAdmin(EditRolesViewModel editRoles)
    {
        Role role = GetRoleById(editRoles.RoleId);
        role.RoleTitle= editRoles.RoleTitle;
        role.IsDeleted= editRoles.IsDeleted;
        UpdateRole(role);
       
    }

    public void DeleteRole(Role role)
    {
        role.IsDeleted = true;
        UpdateRole(role);
    }

    public List<Permission> GetAllPermission()
    {
        return _context.Permissions.ToList();
    }

    public void AddPermissionsToRole(int roleId, List<int> permission)
    {
        foreach (var p in permission)
        {
            _context.RolePermissions.Add(new RolePermission()
            {
                PermissionId = p,
                RoleId = roleId
            });

        }
        _context.SaveChanges();

    }

    public List<int> PermissionsRole(int roleId)
    {
        return _context.RolePermissions
            .Where(r => r.RoleId == roleId)
            .Select(r => r.PermissionId).ToList();

    }

    public void UpdatePermissionsRole(int roleId, List<int> permissions)
    {
        _context.RolePermissions.Where(p => p.RoleId == roleId)
            .ToList().ForEach(p => _context.RolePermissions.Remove(p));

        AddPermissionsToRole(roleId, permissions);

    }

    public bool CheckPermission(int permissionId, string userName)
    {
        int userId = _context.Users.Single(u => u.UserName == userName).UserId;
        List<int> UserRoles = _context.UserRoles.Where(r => r.UserId == userId)
            .Select(r => r.RoleId).ToList();

        if (!UserRoles.Any())
            return false;

        List<int> RolesPermission = _context.RolePermissions
            .Where(p => p.PermissionId == permissionId)
            .Select(p => p.RoleId).ToList();

        return RolesPermission.Any(p => UserRoles.Contains(p));
    }
}