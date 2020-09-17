namespace RCTrans.Web.ViewModels.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RCTrans.Data.Models;

    public class OrderCreateInputModel
    {
        [Required(ErrorMessage = "Датата е задължителна.")]
        [Display(Name = "Дата на наемане")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Датата е задължителна.")]
        [Display(Name = "Дата на връщане")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Шофьор")]
        public bool Driver { get; set; }

        [Display(Name = "Пълна застраховка")]
        public bool CarInsurance { get; set; }

        [Display(Name = "Детско столче")]
        public bool ChildSeat { get; set; }

        [Display(Name = "Бебешко столче")]
        public bool BabySeat { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
