namespace RCTrans.Web.ViewModels.Order
{
    using System;

    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class SingleOrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }
    }
}
