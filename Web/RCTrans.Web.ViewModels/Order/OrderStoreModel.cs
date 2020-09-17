namespace RCTrans.Web.ViewModels.Order
{
    using System;

    using RCTrans.Web.ViewModels.Autopark;

    public class OrderStoreModel
    {
        public string UserId { get; set; }

        public int VehicleId { get; set; }

        public VehicleViewModel Vehicle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Driver { get; set; }

        public bool CarInsurance { get; set; }

        public bool ChildSeat { get; set; }

        public bool BabySeat { get; set; }

        public decimal Price { get; set; }
    }
}
