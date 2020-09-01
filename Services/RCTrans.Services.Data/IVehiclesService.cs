namespace RCTrans.Services.Data
{
    using System.Collections.Generic;

    public interface IVehiclesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
