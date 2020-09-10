namespace RCTrans.Services.Data
{
    using System.Collections.Generic;

    public interface IBlogsService
    {
        IEnumerable<T> GetAllArticles<T>();

        IEnumerable<T> GetTopThree<T>();

        T GetArticleById<T>(int id);
    }
}