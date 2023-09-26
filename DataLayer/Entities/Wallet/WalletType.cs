using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Wallet;

public class WalletType
{
    public WalletType()
    {
        
    }
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]//اینجوری دیگه خود اس کیو ال اعداد رو نمیده
    public int TypeId { get; set; }

    [Required]
    [MaxLength(150)]
    public string TypeTitle { get; set; }



    #region Relations

    public virtual List<Wallet> Wallets { get; set; }

    #endregion
}