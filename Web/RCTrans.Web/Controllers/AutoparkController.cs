namespace RCTrans.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data.Interfaces;

    using RCTrans.Web.ViewModels.Autopark;
    using System.Threading.Tasks;

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

        public IActionResult EditVehicle(int id)
        {
            return this.View();
        }

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = this.vehiclesService.GetVehicleById(id);
            await this.vehiclesService.DeleteVehicleById(vehicle);

            var actionName = vehicle.VehicleType.ToString();
            if (vehicle.VehicleType.ToString() == "Car")
            {
                actionName += "s";
            }
            else
            {
                actionName += "es";
            }

            return this.RedirectToAction(actionName);
        }
    }
}
