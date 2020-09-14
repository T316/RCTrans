namespace RCTrans.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Fuel
    {
        [Display(Name = "Бензин")]
        Petrol = 1,
        [Display(Name = "Дизел")]
        Diesel = 2,
        [Display(Name = "Газ")]
        Gas = 3,
    }
}
