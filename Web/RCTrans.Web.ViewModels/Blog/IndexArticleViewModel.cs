namespace RCTrans.Web.ViewModels.Blog
{
    using System;

    using Ganss.XSS;
    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class IndexArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortSanitizedContent
        {
            get
            {
                var shortContent =
                    this.Content.Length > 250
                    ? this.Content.Substring(0, 250) + "..."
                    : this.Content;

                var shortSanitizedContent = new HtmlSanitizer().Sanitize(shortContent);

                return shortSanitizedContent;
            }
        }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
