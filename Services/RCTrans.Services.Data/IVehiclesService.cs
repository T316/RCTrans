namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RCTrans.Data.Models.Enums;

    public interface IVehiclesService
    {
        IEnumerable<T> GetCars<T>();

        IEnumerable<T> GetBuses<T>();

        IEnumerable<T> GetAutobuses<T>();

        T GetVehicleById<T>(int id);

        Task<int> CreateAsync(
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
            bool airConditioner,
            bool winterTyres);
    }
}
