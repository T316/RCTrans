namespace RCTrans.Data.Models
{
    using System.Collections.Generic;

    using RCTrans.Data.Common.Models;
    using RCTrans.Data.Models.Enums;

    public class Vehicle : BaseDeletableModel<int>
    {
        public Vehicle()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public Transmission Transmission { get; set; }

        public Fuel Fuel { get; set; }

        public VehicleType Type { get; set; }

        public bool AirConditioner { get; set; }

        public bool WinterTyres { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
