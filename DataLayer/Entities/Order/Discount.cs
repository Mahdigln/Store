using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.User;

#nullable disable
namespace DataLayer.Entities.Order;

public class Discount
{
    [Key]
    public int DiscountId { get; set; }

    [Display(Name = "کد")]
    [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
    [MaxLength(150)]
    public string DiscountCode { get; set; }

    [Display(Name = "درصد")]
    [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
    public int DiscountPercent { get; set; }

    public int? UsableCount { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    #region Relations

    public List<UserDiscountCode> UserDiscountCodes { get; set; }

    #endregion

}