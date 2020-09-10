namespace RCTrans.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Data.Models;
    using RCTrans.Services.Data;
    using RCTrans.Web.ViewModels;
    using RCTrans.Web.ViewModels.Blog;

    public class HomeController : BaseController
    {
        private readonly IBlogsService blogsService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IBlogsService blogsService, UserManager<ApplicationUser> userManager)
        {
            this.blogsService = blogsService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var articles = this.blogsService.GetTopThree<IndexArticleViewModel>();
            viewModel.Articles = articles;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult Terms()
        {
            return this.View();
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        // public async Task<IActionResult> AddAdministrator()
        // {
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    var result = await this.userManager.AddToRoleAsync(user, "Administrator");
        //    return this.Json(result);
        // }
    }
}
