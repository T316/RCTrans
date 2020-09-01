namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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
    }
}
