namespace RCTrans.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Data.Common.Repositories;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data;
    using RCTrans.Services.Mapping;

    using RCTrans.Web.ViewModels.Autopark;

    public class AutoparkController : BaseController
    {
        private readonly IVehiclesService vehiclesService;

        public AutoparkController(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var vehicles = this.vehiclesService.GetCars<IndexVehicleViewModel>();
            viewModel.Vehicles = vehicles;

            return this.View(viewModel);
        }
    }
}
