using DataLayer.Entities.Course;
using DataLayer.Entities.Order;
using DataLayer.Entities.Permissions;
using DataLayer.Entities.User;
using DataLayer.Entities.Wallet;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public class StoreContext:DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options):base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDeleted);//query filter =>  !u.IsDeleted= ISDeleted=false

        modelBuilder.Entity<Role>()
            .HasQueryFilter(r => !r.IsDeleted);

        modelBuilder.Entity<CourseGroup>()
            .HasQueryFilter(g => !g.IsDelete);
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasOne<CourseGroup>(f => f.CourseGroup)
            .WithMany(g => g.Courses).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(f => f.GroupId);

        modelBuilder.Entity<Course>()
            .HasOne<CourseGroup>(f => f.Groups)
            .WithMany(g => g.SubGroup).OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(f => f.SubGroup);


        #region for CasCade error

        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        #endregion




    }

    #region User

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserDiscountCode> UserDiscountCodes { get; set; }

    #endregion

    #region Wallet
    public DbSet<WalletType> WalletTypes { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    #endregion

    #region Permission

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    #endregion

    
    #region Course

    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<CourseLevel> CourseLevels { get; set; }
    public DbSet<CourseStatus> CourseStatus { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseEpisode> CourseEpisodes { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<CourseComment> CourseComments { get; set; }
    public DbSet<CourseVote> CourseVotes { get; set; }

    #endregion

    #region Order

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    #endregion


}