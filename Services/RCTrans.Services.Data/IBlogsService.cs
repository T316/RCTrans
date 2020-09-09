namespace RCTrans.Services.Data
{
    using System.Collections.Generic;

    public interface IBlogsService
    {
        IEnumerable<T> GetAllArticles<T>();

        T GetArticleById<T>(int id);
    }
}