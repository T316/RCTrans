namespace RCTrans.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data.Interfaces;
    using RCTrans.Web.ViewModels.Administration.Dashboard;
    using RCTrans.Web.ViewModels.Autopark;
    using RCTrans.Web.ViewModels.Order;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IBlogsService blogsService;
        private readonly IVehiclesService vehiclesService;
        private readonly IOrdersService ordersService;

        public DashboardController(
            ISettingsService settingsService,
            IBlogsService blogsService,
            IVehiclesService vehiclesService,
            IOrdersService ordersService)
        {
            this.settingsService = settingsService;
            this.blogsService = blogsService;
            this.vehiclesService = vehiclesService;
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            var viewModel = new ViewModels.Administration.Dashboard.IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        public IActionResult CreateArticle()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var articleId = await this.blogsService.CreateAsync(input.Title, input.Content, input.ImageUrl);

            return this.Redirect($"/Blog/Article/{articleId}");
        }

        public IActionResult CreateVehicle()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(VehicleCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var vehicleId = await this.vehiclesService.CreateAsync(
                input.Manufacturer,
                input.Model,
                input.AdditionalInfo,
                input.Seats,
                input.Doors,
                input.Transmission,
                input.Fuel,
                input.VehicleType,
                input.VehicleSubType,
                input.Price,
                input.ImageURL,
                input.AirConditioner,
                input.WinterTyres);

            return this.Redirect($"/Autopark/Details/{vehicleId}");
        }

        public IActionResult AllOrders()
        {
            var viewModel = new AllOrdersViewModel();
            var orders = this.ordersService.GetAllOrders<SingleOrderViewModel>();
            viewModel.Orders = orders;
            viewModel.TotalPrice = this.ordersService.CalculateTotalPrice();

            return this.View(viewModel);
        }

        public IActionResult EditOrder(int orderId, int vehicleId)
        {
            var viewModel = this.ordersService.GetOrderById<OrderEditInputModel>(orderId);
            viewModel.Vehicle = this.vehiclesService.GetVehicleById<VehicleViewModel>(vehicleId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(OrderEditInputModel input, int vehicleId)
        {
            var vehicle = this.vehiclesService.GetVehicleById<VehicleViewModel>(vehicleId);
            input.Vehicle = vehicle;

            if (input.EndDate <= input.StartDate)
            {
                this.ModelState.AddModelError(string.Empty, "Датата на връщане трябва да е след датата на вземане.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ordersService.UpdateAsync(
                input.Id,
                input.VehicleId,
                input.UserId,
                input.StartDate,
                input.EndDate,
                input.CarInsurance,
                input.Driver,
                input.ChildSeat,
                input.BabySeat,
                input.CreatedOn,
                input.Price);

            return this.RedirectToAction($"AllOrders");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            await this.ordersService.DeleteOrderById(id);

            return this.RedirectToAction($"AllOrders");
        }
    }
}
