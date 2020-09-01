namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RCTrans.Data.Common.Repositories;
    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class VehiclesService : IVehiclesService
    {
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepository;

        public VehiclesService(IDeletableEntityRepository<Vehicle> vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.vehicleRepository.All().To<T>().ToList();
        }
    }
}
