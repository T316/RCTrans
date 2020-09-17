namespace RCTrans.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data.Interfaces;
    using RCTrans.Web.ViewModels.Autopark;
    using RCTrans.Web.ViewModels.Order;

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IVehiclesService vehiclesService;

        public OrderController(
            IOrdersService ordersService,
            IVehiclesService vehiclesService,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.vehiclesService = vehiclesService;
        }

        [HttpGet]
        public IActionResult CreateOrder(OrderCreateInputModel input, int id)
        {
            var vehicle = this.vehiclesService.GetVehicleById<VehicleViewModel>(id);
            input.Vehicle = vehicle;
            input.StartDate = DateTime.Now;
            input.EndDate = DateTime.Now.AddDays(1);

            return this.View(input);
        }

        [HttpPost]
        [ActionName("CreateOrder")]
        public IActionResult CreateOrderPost(OrderCreateInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.EndDate < input.StartDate)
            {
                return this.View(input);
            }

            var vehiclePrice = this.vehiclesService.GetVehicleById<VehicleViewModel>(id).Price;

            var storeModel = new OrderStoreModel
            {
                VehicleId = id,
                UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                CarInsurance = input.CarInsurance,
                Driver = input.Driver,
                ChildSeat = input.ChildSeat,
                BabySeat = input.BabySeat,
                Price = this.ordersService.CalcutateOrderPrice(
                    input.StartDate,
                    input.EndDate,
                    input.CarInsurance,
                    input.Driver,
                    input.ChildSeat,
                    input.BabySeat,
                    vehiclePrice),
            };

            return this.RedirectToAction("CompleteOrder", "Order", storeModel);
        }

        [HttpGet]
        public IActionResult CompleteOrder(OrderStoreModel storeModel)
        {
            storeModel.Vehicle = this.vehiclesService.GetVehicleById<VehicleViewModel>(storeModel.VehicleId);

            return this.View(storeModel);
        }

        [HttpPost]
        [ActionName("CompleteOrder")]
        public async Task<IActionResult> CompleteOrderPost(OrderStoreModel storeModel)
        {
            await this.ordersService.CreateAsync(
                storeModel.UserId,
                storeModel.VehicleId,
                storeModel.StartDate,
                storeModel.EndDate,
                storeModel.CarInsurance,
                storeModel.Driver,
                storeModel.ChildSeat,
                storeModel.BabySeat,
                storeModel.Price);

            return this.Redirect($"/Order/MyOrders");
        }

        public IActionResult MyOrders()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new MyOrdersViewModel();
            var orders = this.ordersService.GetOrdersByUserId<SingleOrderViewModel>(userId);
            viewModel.Orders = orders;

            return this.View(viewModel);
        }
    }
}
