namespace RCTrans.Data.Models
{
    using System;

    using RCTrans.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Driver { get; set; }

        public bool CarInsurance { get; set; }

        public decimal Price { get; set; }
    }
}
