namespace RCTrans.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum VehicleSubType
    {
        [Display(Name = "Хечбек")]
        Hatchback = 1,
        [Display(Name = "Седан")]
        Sedan = 2,
        [Display(Name = "Комби")]
        StationWagon = 3,
        [Display(Name = "Джип")]
        SUV = 4,
        [Display(Name = "Пикап")]
        PickUp = 5,
        [Display(Name = "Мини ван")]
        MiniVan = 6,
        [Display(Name = "Товарен бус")]
        Freight = 7,
        [Display(Name = "Автобус")]
        Regular = 8,
        [Display(Name = "Специален автобус")]
        Special = 9,
    }
}
