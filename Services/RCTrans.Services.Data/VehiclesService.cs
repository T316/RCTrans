namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using RCTrans.Data.Common.Repositories;
    using RCTrans.Data.Models;
    using RCTrans.Data.Models.Enums;
    using RCTrans.Services.Mapping;

    public class VehiclesService : IVehiclesService
    {
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepository;

        public VehiclesService(IDeletableEntityRepository<Vehicle> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<T> GetCars<T>()
        {
            return this.vehicleRepository.All().Where(v => v.VehicleType == VehicleType.Car).To<T>().ToList();
        }

        public IEnumerable<T> GetBuses<T>()
        {
            return this.vehicleRepository.All().Where(v => v.VehicleType == VehicleType.Bus).To<T>().ToList();
        }

        public IEnumerable<T> GetAutobuses<T>()
        {
            return this.vehicleRepository.All().Where(v => v.VehicleType == VehicleType.Autobus).To<T>().ToList();
        }

        public T GetVehicleById<T>(int id)
        {
            return this.vehicleRepository.All().Where(v => v.Id == id).To<T>().First();
        }

        public async Task<int> CreateAsync(
            string manufacturer,
            string model,
            string additionalInfo,
            int seats,
            int doors,
            Transmission transmission,
            Fuel fuel,
            VehicleType vehicleType,
            VehicleSubType vehicleSubType,
            string imageURL,
            decimal price,
            bool airConditioner = true,
            bool winterTyres = true)
        {
            var vehicle = new Vehicle
            {
                Manufacturer = manufacturer,
                Model = model,
                AdditionalInfo = additionalInfo,
                Seats = seats,
                Doors = doors,
                Transmission = transmission,
                Fuel = fuel,
                VehicleType = vehicleType,
                VehicleSubType = vehicleSubType,
                ImageURL = imageURL,
                Price = price,
                AirConditioner = airConditioner,
                WinterTyres = winterTyres,
            };

            await this.vehicleRepository.AddAsync(vehicle);
            await this.vehicleRepository.SaveChangesAsync();

            return vehicle.Id;
        }
    }
}
