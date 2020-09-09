namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RCTrans.Data.Common.Repositories;
    using RCTrans.Data.Models;
    using RCTrans.Services.Mapping;

    public class BlogsService : IBlogsService
    {
        private readonly IRepository<Article> articleRepository;

        public BlogsService(IRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<T> GetAllArticles<T>()
        {
            return this.articleRepository.All().To<T>().ToList();
        }

        public T GetArticleById<T>(int id)
        {
            return this.articleRepository.All().Where(a => a.Id == id).To<T>().First();
        }
    }
}
