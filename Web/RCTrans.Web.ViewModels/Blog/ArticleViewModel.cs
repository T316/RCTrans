namespace RCTrans.Web.ViewModels.Blog
{
    using Ganss.XSS;
    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent
            => new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }
    }
}
