namespace RCTrans.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum VehicleType
    {
        [Display(Name = "Кола")]
        Car = 1,
        [Display(Name = "Бус")]
        Bus = 2,
        [Display(Name = "Автобус")]
        Autobus = 3,
    }
}
