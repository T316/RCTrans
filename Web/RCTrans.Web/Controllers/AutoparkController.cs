namespace RCTrans.Web.Controllers
{
    using System.Threading.Tasks;

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
            var viewModel = new ViewModels.Autopark.IndexViewModel();
            var vehicles = this.vehiclesService.GetCars<VehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Buses()
        {
            var viewModel = new ViewModels.Autopark.IndexViewModel();
            var vehicles = this.vehiclesService.GetBuses<VehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Autobuses()
        {
            var viewModel = new ViewModels.Autopark.IndexViewModel();
            var vehicles = this.vehiclesService.GetAutobuses<VehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.vehiclesService.GetVehicleById<DetailsVehicleViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult EditVehicle(int id)
        {
            var viewModel = this.vehiclesService.GetVehicleById<VehicleEditInputModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditVehicle(VehicleEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var vehicleId = await this.vehiclesService.UpdateAsync(
                input.Id,
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

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var actionName = await this.vehiclesService.DeleteVehicleById(id);

            return this.RedirectToAction(actionName);
        }
    }
}
