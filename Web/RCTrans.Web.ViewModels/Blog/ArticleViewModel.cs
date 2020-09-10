namespace RCTrans.Web.ViewModels.Blog
{
    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
