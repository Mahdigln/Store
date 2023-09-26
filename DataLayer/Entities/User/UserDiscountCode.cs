using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.Order;
#nullable disable
namespace DataLayer.Entities.User;

public class UserDiscountCode
{
    [Key]
    public int UD_Id { get; set; }
    public int UserId { get; set; }
    public int DiscountId { get; set; }


    public User User { get; set; }
    public Discount Discount { get; set; }


}