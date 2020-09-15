namespace RCTrans.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RCTrans.Services.Data.Interfaces;
    using RCTrans.Web.ViewModels.Blog;

    public class BlogController : BaseController
    {
        private readonly IBlogsService blogsService;

        public BlogController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var articles = this.blogsService.GetAllArticles<IndexArticleViewModel>();
            viewModel.Articles = articles;

            return this.View(viewModel);
        }

        public IActionResult Article(int id)
        {
            var viewModel = this.blogsService.GetArticleById<ArticleViewModel>(id);

            return this.View(viewModel);
        }
    }
}
