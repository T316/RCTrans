namespace RCTrans.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogsService
    {
        IEnumerable<T> GetAllArticles<T>();

        IEnumerable<T> GetTopThree<T>();

        T GetArticleById<T>(int id);

        Task<int> CreateAsync(string title, string content, string imageUrl);
    }
}