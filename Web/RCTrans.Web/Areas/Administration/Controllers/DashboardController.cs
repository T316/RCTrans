namespace RCTrans.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data;
    using RCTrans.Web.ViewModels.Administration.Dashboard;
    using RCTrans.Web.ViewModels.Blog;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IBlogsService blogService;

        public DashboardController(ISettingsService settingsService, IBlogsService blogService)
        {
            this.settingsService = settingsService;
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var viewModel = new ViewModels.Administration.Dashboard.IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        public IActionResult CreateVehicle()
        {
            return this.View();
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

            var articleId = await this.blogService.CreateAsync(input.Title, input.Content, input.ImageUrl);

            return this.Redirect($"/Blog/Article/{articleId}");
        }
    }
}
