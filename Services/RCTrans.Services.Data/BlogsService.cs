namespace RCTrans.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
            return this.articleRepository.All().OrderByDescending(a => a.CreatedOn).To<T>().ToList();
        }

        public IEnumerable<T> GetTopThree<T>()
        {
            return this.articleRepository.All().OrderByDescending(a => a.CreatedOn).Take(3).To<T>().ToList();
        }

        public T GetArticleById<T>(int id)
        {
            return this.articleRepository.All().Where(a => a.Id == id).To<T>().First();
        }

        public async Task<int> CreateAsync(string title, string content, string imageUrl)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                ImageUrl = imageUrl,
            };

            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            return article.Id;
        }
    }
}
