namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
            decimal price,
            string imageURL = "https://directagro.net/assets/images/no-photo.png",
            bool airConditioner = false,
            bool winterTyres = false)
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
                Price = price,
                ImageURL = imageURL,
                AirConditioner = airConditioner,
                WinterTyres = winterTyres,
            };

            var isSubTypeValid = true;

            if ((int)vehicleType == 1)
            {
                if ((int)vehicleSubType != 1 && (int)vehicleSubType != 2 && (int)vehicleSubType != 3 &&
                    (int)vehicleSubType != 4 && (int)vehicleSubType != 5)
                {
                    isSubTypeValid = false;
                }
            }
            else if ((int)vehicleType == 2)
            {
                if ((int)vehicleSubType != 6 && (int)vehicleSubType != 7)
                {
                    isSubTypeValid = false;
                }
            }
            else if ((int)vehicleType == 3)
            {
                if ((int)vehicleSubType != 8 && (int)vehicleSubType != 9)
                {
                    isSubTypeValid = false;
                }
            }

            if (!isSubTypeValid)
            {
                throw new ValidationException("Подтипа е невалиден");
            }

            await this.vehicleRepository.AddAsync(vehicle);
            await this.vehicleRepository.SaveChangesAsync();

            return vehicle.Id;
        }
    }
}
