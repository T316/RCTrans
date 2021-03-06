﻿namespace RCTrans.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        decimal CalcutateOrderPrice(
            DateTime startDate,
            DateTime endDate,
            bool carInsurance,
            bool driver,
            bool childSeat,
            bool babySeat,
            decimal vehiclePrice);

        Task<int> CreateAsync(
            string userId,
            int vehicleId,
            DateTime startDate,
            DateTime endDate,
            bool carInsurance,
            bool driver,
            bool childSeat,
            bool babySeat,
            decimal price);

        T GetOrderById<T>(int id);

        IEnumerable<T> GetOrdersByUserId<T>(string userId);

        IEnumerable<T> GetAllOrders<T>();

        decimal CalculateTotalPrice();

        Task DeleteOrderById(int id);

        Task UpdateAsync(
            int id,
            int vehicleId,
            string userId,
            DateTime startDate,
            DateTime endDate,
            bool carInsurance,
            bool driver,
            bool childSeat,
            bool babySeat,
            DateTime createdOn,
            decimal price);
    }
}
