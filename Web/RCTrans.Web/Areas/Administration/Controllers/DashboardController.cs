namespace RCTrans.Web.Areas.Administration.Controllers
{
    using System.Data;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data;
    using RCTrans.Web.ViewModels.Administration.Dashboard;
    using RCTrans.Web.ViewModels.Blog;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IBlogsService blogsService;
        private readonly IVehiclesService vehiclesService;

        public DashboardController(
            ISettingsService settingsService,
            IBlogsService blogsService,
            IVehiclesService vehiclesService)
        {
            this.settingsService = settingsService;
            this.blogsService = blogsService;
            this.vehiclesService = vehiclesService;
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

            return this.Redirect($"/Autopark/Reserve/{vehicleId}");
        }
    }
}
