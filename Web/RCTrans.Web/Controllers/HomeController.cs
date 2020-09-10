namespace RCTrans.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data;
    using RCTrans.Web.ViewModels;
    using RCTrans.Web.ViewModels.Blog;

    public class HomeController : BaseController
    {
        private readonly IBlogsService blogsService;

        public HomeController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
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
    }
}
