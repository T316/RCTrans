﻿namespace RCTrans.Web.ViewModels.Blog
{
    using System;

    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class IndexArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
