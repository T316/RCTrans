namespace RCTrans.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using RCTrans.Data.Common.Repositories;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data.Interfaces;
    using RCTrans.Services.Mapping;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public decimal CalcutateOrderPrice(
            DateTime startDate,
            DateTime endDate,
            bool carInsurance,
            bool driver,
            bool childSeat,
            bool babySeat,
            decimal vehiclePrice)
        {
            var days = (endDate - startDate).Days;
            var pricePerDay = vehiclePrice;
            if (carInsurance)
            {
                pricePerDay += 20;
            }

            if (driver)
            {
                pricePerDay += 120;
            }

            if (childSeat)
            {
                pricePerDay += 10;
            }

            if (babySeat)
            {
                pricePerDay += 10;
            }

            if (days < 1)
            {
                days = 1;
            }

            var totalPrice = pricePerDay * days;

            return totalPrice;
        }

        public async Task<int> CreateAsync(
            string userId,
            int vehicleId,
            DateTime startDate,
            DateTime endDate,
            bool carInsurance,
            bool driver,
            bool childSeat,
            bool babySeat,
            decimal price)
        {
            var order = new Order
            {
                UserId = userId,
                VehicleId = vehicleId,
                StartDate = startDate,
                EndDate = endDate,
                CarInsurance = carInsurance,
                Driver = driver,
                ChildSeat = childSeat,
                BabySeat = babySeat,
                Price = price,
            };

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();

            return order.Id;
        }

        public T GetOrderById<T>(int id)
        {
            return this.orderRepository.All().Where(v => v.Id == id).To<T>().FirstOrDefault();
        }

        public IEnumerable<T> GetOrdersByUserId<T>(string userId)
        {
            return this.orderRepository.All().Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedOn).To<T>().ToList();
        }

        public IEnumerable<T> GetAllOrders<T>()
        {
            return this.orderRepository.All().OrderByDescending(o => o.CreatedOn).To<T>().ToList();
        }

        public decimal CalculateTotalPrice()
        {
            return this.orderRepository.All().Sum(o => o.Price);
        }

        public async Task DeleteOrderById(int id)
        {
            var order = this.GetOrderById(id);
            this.orderRepository.Delete(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(
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
            decimal price)
        {
            var order = new Order
            {
                Id = id,
                VehicleId = vehicleId,
                UserId = userId,
                StartDate = startDate,
                EndDate = endDate,
                CarInsurance = carInsurance,
                Driver = driver,
                BabySeat = babySeat,
                ChildSeat = childSeat,
                CreatedOn = createdOn,
                Price = price,
            };

            this.orderRepository.Update(order);
            await this.orderRepository.SaveChangesAsync();
        }

        private Order GetOrderById(int id)
        {
            return this.orderRepository.All().Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
