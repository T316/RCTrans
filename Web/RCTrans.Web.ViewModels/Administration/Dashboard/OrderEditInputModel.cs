namespace RCTrans.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;
    using RCTrans.Web.ViewModels.Autopark;

    public class OrderEditInputModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Датата е задължителна.")]
        [Display(Name = "Дата на наемане")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Датата е задължителна.")]
        [Display(Name = "Дата на връщане")]
        public DateTime EndDate { get; set; }

        public DateTime CreatedOn { get; set; }

        [Display(Name = "Шофьор")]
        public bool Driver { get; set; }

        [Display(Name = "Пълна застраховка")]
        public bool CarInsurance { get; set; }

        [Display(Name = "Детско столче")]
        public bool ChildSeat { get; set; }

        [Display(Name = "Бебешко столче")]
        public bool BabySeat { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public VehicleViewModel Vehicle { get; set; }
    }
}
