namespace RCTrans.Services.Data
{
    using System.Collections.Generic;

    public interface IVehiclesService
    {
        IEnumerable<T> GetCars<T>();

        IEnumerable<T> GetBuses<T>();

        IEnumerable<T> GetAutobuses<T>();

        T GetVehicleById<T>(int id);
    }
}
