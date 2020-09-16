namespace RCTrans.Web.ViewModels.Administration.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    using RCTrans.Data.Models;
    using RCTrans.Data.Models.Enums;
    using RCTrans.Services.Mapping;

    public class VehicleCreateInputModel : IMapFrom<Vehicle>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Марката е задължителна.")]
        [StringLength(20, ErrorMessage = "Марката трябва да е между {2} и {1} символа.", MinimumLength = 2)]
        [Display(Name = "Марка")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Модела е задължителен.")]
        [StringLength(20, ErrorMessage = "Модела трябва да е между {2} и {1} символа.", MinimumLength = 2)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInfo { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(1, 100)]
        [Display(Name = "Места")]
        public int Seats { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(1, 10)]
        [Display(Name = "Врати")]
        public int Doors { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Трансмисия")]
        public Transmission Transmission { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Гориво")]
        public Fuel Fuel { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Тип")]
        public VehicleType VehicleType { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Display(Name = "Подтип")]
        public VehicleSubType VehicleSubType { get; set; }

        [Display(Name = "Климатик")]
        public bool AirConditioner { get; set; }

        [Display(Name = "Зимни гуми")]
        public bool WinterTyres { get; set; }

        [Required(ErrorMessage = "Цената е задължителна.")]
        [Range(20, 10000)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Картинка")]
        public string ImageURL { get; set; }
    }
}
