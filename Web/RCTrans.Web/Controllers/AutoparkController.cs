namespace RCTrans.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data.Interfaces;

    using RCTrans.Web.ViewModels.Autopark;

    public class AutoparkController : BaseController
    {
        private readonly IVehiclesService vehiclesService;

        public AutoparkController(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        public IActionResult Cars()
        {
            var viewModel = new IndexViewModel();
            var vehicles = this.vehiclesService.GetCars<IndexVehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Buses()
        {
            var viewModel = new IndexViewModel();
            var vehicles = this.vehiclesService.GetBuses<IndexVehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Autobuses()
        {
            var viewModel = new IndexViewModel();
            var vehicles = this.vehiclesService.GetAutobuses<IndexVehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.vehiclesService.GetVehicleById<ReserveVehicleViewModel>(id);

            return this.View(viewModel);
        }
    }
}
