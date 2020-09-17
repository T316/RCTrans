namespace RCTrans.Web.Controllers
{
    using System.Threading.Tasks;

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

        public IActionResult EditArticle(int id)
        {
            var viewModel = this.blogsService.GetArticleById<ArticleEditInputModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var articleId = await this.blogsService.UpdateAsync(input.Id, input.Title, input.Content, input.ImageUrl, input.CreatedOn);

            return this.Redirect($"/Blog/Article/{articleId}");
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            await this.blogsService.DeleteArticleById(id);

            return this.RedirectToAction("Index");
        }
    }
}
