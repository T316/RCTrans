namespace RCTrans.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Transmission
    {
        [Display(Name = "Ръчно")]
        Manual = 1,
        [Display(Name = "Автоматично")]
        Automatic = 2,
    }
}
