﻿namespace RCTrans.Web.ViewModels.Autopark
{
    using RCTrans.Data.Models;
    using RCTrans.Data.Models.Enums;
    using RCTrans.Services.Mapping;

    public class VehicleViewModel : IMapFrom<Vehicle>
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public Transmission Transmission { get; set; }

        public Fuel Fuel { get; set; }

        public VehicleType VehicleType { get; set; }

        public VehicleSubType VehicleSubType { get; set; }

        public bool AirConditioner { get; set; }

        public bool WinterTyres { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }
    }
}
